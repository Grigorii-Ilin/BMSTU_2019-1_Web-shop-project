using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using MyModels;




namespace web_shop_v2.Pages.Management {


        public partial class ManageProductTypes : System.Web.UI.Page {
            protected void Page_Load(object sender, EventArgs e) {

            }

            protected void btnSubmit_Click(object sender, EventArgs e) {
            var model = new ProductTypesModel();
            ProductTypes pt = CreateProductType();
            lblResult.Text = model.InsertProductTypes(pt);


            }

            private ProductTypes CreateProductType() {
                var p = new ProductTypes();
                p.Name = txtName.Text;
                return p;
            }
        }

}