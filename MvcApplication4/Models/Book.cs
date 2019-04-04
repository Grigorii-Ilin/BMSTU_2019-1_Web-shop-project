using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication4.Models
{
    public class Book
    { 
       
        public int Id { get; set; }     // get { return id;} set { id = value; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }
    }

}