using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web_shop_v2 {
    public class PricePerWeigth {
        public decimal Price { get; set; }
        public decimal Amount { get; set; }

        public PricePerWeigth() { }

        public decimal Calc() {
            return Math.Round((Price * Amount), 2);
        }
    }
}