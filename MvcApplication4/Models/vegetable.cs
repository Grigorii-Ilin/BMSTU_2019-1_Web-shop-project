using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication4.Models {
    public class Vegetable {
        public int Id { get; set; }     // get { return id;} set { id = value; }
        public string Name { get; set; }
        public Decimal Price { get; set; }
    }
}