using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web_shop_v2.Pages {
    public partial class Product : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            FillPage();
        }

        private void FillPage() {
            if (!String.IsNullOrWhiteSpace(Request.QueryString["id"])) {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                var p = new ProductModel().GetProduct(id);

                lblPrice.Text = "Цена за 1 кг. <br/>₽ " + p.Price;
                lblTitle.Text = p.Name;
                lblDescription.Text = p.Description;
                imgProduct.ImageUrl = "~/Images/Products/" + p.Image;
            }
        }

        protected void btnAddToCart_Click(object sender, EventArgs e) {
            if (!String.IsNullOrWhiteSpace(Request.QueryString["id"])) {
                string clientId = Context.User.Identity.GetUserId();
                if (clientId != null) {
                    int id = Convert.ToInt32(Request.QueryString["id"]);

                    //string  amount = string.IsNullOrEmpty(Request.Params["inpAmount"])
                    // ? ""
                    // : Request.Params["inpAmount"];
                    string amountStr = Request.Params["inpAmount"];
                    //decimal amount = Convert.ToDecimal(amountStr);
                    decimal amount = Decimal.Parse(amountStr, new NumberFormatInfo() { NumberDecimalSeparator = "." });


                    //decimal amount = Convert.ToDecimal(Request.Form.GetValues("inpAmount"));
                    //(Request["inpAmount"]);
                    //lblResult.Text = amount.ToString();
                    //Console.WriteLine(amount.ToString());

                    var cart = new Cart() {
                        Amount = amount,
                        ClientId = clientId,
                        DatePurchased = DateTime.Now,
                        IsInCart = true,
                        ProductId = id
                    };

                    var cartModel = new CartModel();
                    lblResult.Text = cartModel.InsertCart(cart);
                }
                else {
                    lblResult.Text = "Незарегистрированные пользователи не могут добавлять товары в корзину";
                }
            }
        }
    }
}