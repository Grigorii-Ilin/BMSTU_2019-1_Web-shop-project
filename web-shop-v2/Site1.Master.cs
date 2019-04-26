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
                litStatus.Text = user.Name;

                loginAndRegisterVisible = !loginAndRegisterVisible;
                logoutAndNameVisible = !logoutAndNameVisible;
            }

            hlkLogin.Visible = loginAndRegisterVisible;
            hlkRegister.Visible= loginAndRegisterVisible;

            hlbLogout.Visible = logoutAndNameVisible;
            litStatus.Visible= logoutAndNameVisible;
        }

        protected void hlbLogout_Click(object sender, EventArgs e) {
            var authentificationManager = HttpContext.Current.GetOwinContext().Authentication;
            authentificationManager.SignOut();

            Response.Redirect("~/Index.aspx");
        }
    }
}