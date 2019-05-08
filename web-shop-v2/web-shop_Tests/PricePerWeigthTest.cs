using NUnit.Framework;
using System;
using web_shop_v2;

namespace web_shop_v2_Tests {
    [TestFixture]
    public class PricePerWeigthTest {
        [TestCase()]
        public void CalcPPW_VariousPricesAndAmounts_1() {
            var ppw = new PricePerWeigth() { Price= 62.57M, Amount= 15.6M};//arrange
            decimal result = ppw.Calc();//act
            Assert.AreEqual(result, 976.09M);//assert
        }

        [TestCase()]
        public void CalcPPW_VariousPricesAndAmounts_2() {
            var ppw = new PricePerWeigth() { Price = 105.77M, Amount = 5.9M };
            decimal result = ppw.Calc();
            Assert.AreEqual(result, 624.04M);
        }
    }
}