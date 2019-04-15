using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication4.Models {
    public abstract class UserAbstract {
        public int Id { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }
    }
}