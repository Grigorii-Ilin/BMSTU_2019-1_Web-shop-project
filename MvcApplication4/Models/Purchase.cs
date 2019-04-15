using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication4.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public int VegetableId { get; set; }
        public int ClientId { get; set; }
        public DateTime Date { get; set; }
        public string Address { get; set; }
        public decimal PriceTotal { get; set; }
    }
}