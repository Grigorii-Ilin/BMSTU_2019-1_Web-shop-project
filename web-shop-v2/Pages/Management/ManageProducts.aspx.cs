using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace web_shop_v2.Pages.Management {
    public partial class ManageProducts : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                GetImages();

                if (!String.IsNullOrWhiteSpace(Request.QueryString["id"])) {
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    FillPage(id);
                }
            }
        }

        private void FillPage(int id) {
            var p = new ProductModel().GetProduct(id);
            txtDescription.Text = p.Description;
            txtName.Text = p.Name;
            txtPrice.Text = p.Price.ToString();
            ddlImage.SelectedValue = p.Image;
            ddlType.SelectedValue = p.TypeId.ToString();
        }

        private void GetImages() {
            try {
                string[] imagesFileNames = Directory.GetFiles(Server.MapPath("~/Images/Products/"));
                var imagesList = new ArrayList();

                foreach (var imageFileName in imagesFileNames) {
                    string nameTmp = imageFileName.Substring(
                        imageFileName.LastIndexOf(@"\", StringComparison.Ordinal) + 1
                        );
                    imagesList.Add(nameTmp);
                }

                ddlImage.DataSource = imagesList;
                ddlImage.AppendDataBoundItems=true;
                ddlImage.DataBind();
             }
            catch (Exception e) {
                lblResult.Text=e.ToString();
            }
        }

        private web_shop_v2.Product CreateProduct() {
            var p = new web_shop_v2.Product();

            p.Name = txtName.Text;
            p.Price = Convert.ToDecimal(txtPrice.Text);
            p.TypeId = Convert.ToInt32(ddlType.SelectedValue);
            p.Description = txtDescription.Text;
            p.Image = ddlImage.SelectedValue;

            return p;
        }

        protected void btnSubmit_Click(object sender, EventArgs e) {
            var model = new ProductModel();
            var p = CreateProduct();

            if (!String.IsNullOrWhiteSpace(Request.QueryString["id"])) {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                lblResult.Text = model.UpdateProduct(id, p);
            }
            else {
                lblResult.Text = model.InsertProduct(p);
            }
        }
    }
}