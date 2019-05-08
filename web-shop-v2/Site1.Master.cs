using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web_shop_v2 {
    public partial class Site1 : System.Web.UI.MasterPage {
        protected void Page_Load(object sender, EventArgs e) {
            bool loginAndRegisterVisible = true;
            bool logoutAndNameVisible = false;

            var user = Context.User.Identity;

            if (user.IsAuthenticated) {
                loginAndRegisterVisible = !loginAndRegisterVisible;
                logoutAndNameVisible = !logoutAndNameVisible;

                var cartModel = new CartModel();
                string userId = HttpContext.Current.User.Identity.GetUserId();
                hlkStatus.Text = string.Format("{0}  ({1})"
                    , user.Name
                    , cartModel.GetOrdersInCart(userId).Count
                    );
            }

            hlkLogin.Visible = loginAndRegisterVisible;
            hlkRegister.Visible= loginAndRegisterVisible;

            hlbLogout.Visible = logoutAndNameVisible;
            hlkStatus.Visible= logoutAndNameVisible;
            
        }

        protected void hlbLogout_Click(object sender, EventArgs e) {
            var authentificationManager = HttpContext.Current.GetOwinContext().Authentication;
            authentificationManager.SignOut();

            Response.Redirect("~/Index.aspx");
        }
    }
}