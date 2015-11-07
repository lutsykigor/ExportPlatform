using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportPlatform.DataAccess
{
    public class Customer
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public DateTime Created { get; set; }

        public string IP { get; set; }

        public string Product { get; set; }

        public string Amount { get; set; }
    }
}
