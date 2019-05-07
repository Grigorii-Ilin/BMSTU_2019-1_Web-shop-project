using NUnit.Framework;
using System;
using web_shop_v2;

namespace web_shop_v2_Tests {
    [TestFixture]
    public class PricePerWeigthTest {

        //[TestCase(62.57, 15.6, 976.09)]
        [TestCase()]
        public void CalcPPW_VariousPricesAndAmounts_1() {
            var ppw = new PricePerWeigth() { Price= 62.57M, Amount= 15.6M};//arrange
            decimal result = ppw.Calc();//act
            //Console.WriteLine(result.ToString());
            Assert.AreEqual(result, 976.09M);//assert
            //Assert.AreEqual(true, true);
        }

        [TestCase()]
        public void CalcPPW_VariousPricesAndAmounts_2() {
            var ppw = new PricePerWeigth() { Price = 105.77M, Amount = 5.9M };
            decimal result = ppw.Calc();
            Assert.AreEqual(result, 624.04M);
        }
    }
}