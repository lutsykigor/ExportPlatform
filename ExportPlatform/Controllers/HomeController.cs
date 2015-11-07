using ExportPlatform.Communication;
using ExportPlatform.DataAccess;
using ExportPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ExportPlatform.Controllers
{
    [Authorize]
    public class HomeController : AsyncController
    {
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(new CustomerModel());
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Index(string email)
        {
            using (var context = new DataContext())
            {
                context.Customers.Add(new Customer {
                    Email = email,
                    IP = Request.UserHostAddress,
                    Product = string.Empty,
                    Amount = string.Empty,
                    Created = DateTime.Now
                });

                await context.SaveChangesAsync();

                try
                {
                    SmtpManager.SendAsync(email);
                }
                catch (Exception ex)
                {
                    context.Logs.Add(new Log
                    {
                        Email = email,
                        Message = ex.StackTrace,
                        Title = ex.Message,
                        Created = DateTime.Now
                    });
                    await context.SaveChangesAsync();
                    return new JsonResult { Data = new { success = false },
                        JsonRequestBehavior = JsonRequestBehavior.DenyGet };
                }
            }

            return new JsonResult { Data = new { success = true },
                JsonRequestBehavior = JsonRequestBehavior.DenyGet };
        }
    }
}
