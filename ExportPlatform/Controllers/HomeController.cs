using ExportPlatform.Business;
using ExportPlatform.DataAccess;
using ExportPlatform.Models;
using ExportPlatform.Properties;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ExportPlatform.Controllers
{
    [Authorize]
    public class HomeController : AsyncController
    {
        private const string DEF_InformEmailAddressKey = "InformEmailAddress";
        private const string DEF_AdminEmailAddressKey = "AdminEmailAddress";

        private CustomerService _customerService = new CustomerService();

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
            return new JsonResult
            {
                Data = new { success = await _customerService.Add(email, Request.UserHostAddress, 
                Resources.EmailSubject, Resources.EmailTemplate, 
                ConfigurationManager.AppSettings[DEF_InformEmailAddressKey],
                ConfigurationManager.AppSettings[DEF_AdminEmailAddressKey],
                "New Lead", "From Piesek") },
                JsonRequestBehavior = JsonRequestBehavior.DenyGet
            };
        }
    }
}
