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

        private void CreateShopTable(List<Cart> purchasedList, out decimal subTotal) {
            //decimal subTotal = new decimal(0.0);
            subTotal = 0.00M;
            var productModel = new ProductModel();

            foreach (var cart in purchasedList) {
                var product = productModel.GetProduct(cart.ProductId);

                //decimal pricePerWeigth = Math.Round((product.Price * cart.Amount), 2);
                //subTotal += pricePerWeigth;
                var ppw = new PricePerWeigth() { Price = product.Price, Amount= cart.Amount };
                subTotal += ppw.Calc();

                var ibtProductImage = new ImageButton {
                    ImageUrl = String.Format("~/Images/Products/{0}", product.Image),
                    PostBackUrl = String.Format("~/Pages/Product.aspx?id={0}", product.Id)
                };

                var lbtDelete = new LinkButton {
                    PostBackUrl = String.Format("~/Pages/ShoppingCarts.aspx?productId={0}", cart.Id),
                    Text = "Удалить из корзины",
                    ID = "del" + cart.Id
                };

                lbtDelete.Click += Delete_Item;

                var table = new Table {
                    CssClass = "cartTable"
                };

                TableCell[] cells = new TableCell[6];
                for (int i = 0; i < cells.GetLength(0); i++) {
                    //for (int j = 0; j < cells.GetLength(1); j++) {
                        cells[i] = new TableCell();
                    //}
                }

                //cells[0, 0].RowSpan = 2;
                cells[0].Width = 50;
                cells[0].Controls.Add(ibtProductImage);

                //cells[1, 0].RowSpan = 2;
                cells[1].Text = String.Format("<h4>{0}</h4>", product.Name);
                cells[1].HorizontalAlign = HorizontalAlign.Left;

                cells[2].Text = "Цена за 1 кг.: <br>" + product.Price + " ₽";
                //cells[2, 1].Text = product.Price + " ₽";

                cells[3].Text = "Вес:<br>" + cart.Amount + " кг.";
                //cells[3, 1].Text = cart.Amount + " кг.";

                //cells[4, 0].Text = "Итого:<br>" + pricePerWeigth.ToString() + " ₽";
                cells[4].Text = "Итого:<br>" + ppw.Calc().ToString() + " ₽";
                //cells[4, 1].Text = pricePerWeigth.ToString();

                //cells[5, 0].RowSpan = 2;
                cells[5].Controls.Add(lbtDelete);

                //TableRow[] tableRows = new TableRow[2];
                var tableRow = new TableRow();
                //for (int i = 0; i < 1; i++) {
                    //tableRows[i] = new TableRow();
                    for (int i = 0; i < cells.GetLength(0); i++) {
                        //tableRows[i].Cells.Add(cells[j, i]);
                        tableRow.Cells.Add(cells[i]);
                    }
                    //table.Rows.Add(tableRows[i]);
                //}
                table.Rows.Add(tableRow);
                pnlShoppingCarts.Controls.Add(table);
            }

            //Add current user's shopping cart to a specific session
            Session[User.Identity.GetUserId()] = purchasedList;
        }

        private void Delete_Item(object sender, EventArgs e) {
            var selectedLink = (LinkButton)sender;
            string link = selectedLink.ID.Replace("del", "");
            int cartId = int.Parse(link);

            var cartModel = new CartModel();
            cartModel.DeleteCart(cartId);

            Response.Redirect("~/Pages/ShoppingCarts.aspx");
        }
    }
}