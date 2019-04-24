using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web_shop_v2.Pages.Management {
    public partial class Management : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void grdProducts_RowEditing(object sender, GridViewEditEventArgs e) {
            var row = grdProducts.Rows[e.NewEditIndex];
            int rowId = Convert.ToInt32(row.Cells[1].Text);
            Response.Redirect("~/Pages/Management/ManageProducts.aspx?id=" + rowId);
        }
    }
}