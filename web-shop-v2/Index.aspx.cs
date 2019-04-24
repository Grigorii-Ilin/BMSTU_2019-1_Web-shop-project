using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web_shop_v2 {
    public partial class Index : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            FillPage();
        }

        private void FillPage() {
            var products = new ProductModel().GetAllProducts();
            if (products!=null) {
                foreach (var p in products) {
                    var ibtProduct = new ImageButton();
                    ibtProduct.ImageUrl = "~/Images/Products/" + p.Image;
                    ibtProduct.CssClass = "productImage";
                    ibtProduct.PostBackUrl = "~/Pages/Product.aspx?id=" + p.Id;

                    var lblName = new Label();
                    lblName.Text = p.Name;
                    lblName.CssClass = "productName";

                    var lblPrice = new Label();
                    lblPrice.Text = "₽ " + p.Price;
                    lblPrice.CssClass = "productPrice";

                    var pnlProduct = new Panel();
                    pnlProduct.Controls.Add(ibtProduct);
                    pnlProduct.Controls.Add(new Literal { Text = "<br />" });
                    pnlProduct.Controls.Add(lblName);
                    pnlProduct.Controls.Add(new Literal { Text = "<br />" });
                    pnlProduct.Controls.Add(lblPrice);

                    pnlProducts.Controls.Add(pnlProduct);
                }
            }
            else {
                pnlProducts.Controls.Add(new Literal { Text = "Товары не найдены!" });
            }
        }
    }
}