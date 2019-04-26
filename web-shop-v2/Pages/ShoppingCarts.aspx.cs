using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web_shop_v2.Pages {
    public partial class WebForm1 : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            string userId = User.Identity.GetUserId();
            GetPurchasedInCart(userId);
        }

        private void GetPurchasedInCart(string userId) {
            var cartModel = new CartModel();
            decimal priceSubtotal = 0.00M;
            var purchasedList = cartModel.GetOrdersInCart(userId);
            CreateShopTable(purchasedList, out priceSubtotal);
            decimal priceTotal = priceSubtotal + 100.00M;

            litSumOrders.Text = priceSubtotal + " ₽";
            litTotal.Text = priceTotal + " ₽";
        }

        private void CreateShopTable(List<Cart> purchasedList, out decimal subtotal) {
            var productModel = new ProductModel();

            foreach (var cart in purchasedList) {
                var product = productModel.GetProduct(cart.ProductId);

                var ibtProductImage = new ImageButton {
                    ImageUrl = String.Format("~/Images/Products/{0}", product.Image),
                    PostBackUrl=String.Format("~/Pages/Product.aspx?id={0}", product.Id)
                };

                var lbtDelete = new LinkButton {
                    PostBackUrl = String.Format("~/Pages/ShoppingCarts.aspx?productId={0}", cart.Id),
                    Text = "Удалить из корзины",
                    ID="del"+cart.Id
                };

                lbtDelete.Click += Delete_Item;

                var table = new Table {
                    CssClass="cartTable"
                };

                TableRow [] rows = new TableRow[2];
                TableCell[,] cells = new TableCell[2, 6];

                cells[0, 0].RowSpan = 2;
                cells[0, 0].Width = 50;

                cells[0, 1].Text = String.Format("<h4>{0}</h4>", product.Name);
                cells[0, 1].HorizontalAlign = HorizontalAlign.Left;

            }
        }
    }
}