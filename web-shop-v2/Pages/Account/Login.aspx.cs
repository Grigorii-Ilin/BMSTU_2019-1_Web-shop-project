using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web_shop_v2.Pages.Account {
    public partial class Login : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void btnConfirm_Click(object sender, EventArgs e) {
            UserStore<IdentityUser> userStore = new UserStore<IdentityUser>();

            string connectionStringEF = System.Configuration.ConfigurationManager
                .ConnectionStrings["VegetableDBEntities"].ConnectionString;
            var efBuilder = new System.Data.Entity.Core.EntityClient
                .EntityConnectionStringBuilder(connectionStringEF);
            string connectionStringOK = efBuilder.ProviderConnectionString;

            userStore.Context.Database.Connection.ConnectionString = connectionStringOK;

            var manager = new UserManager<IdentityUser>(userStore);

            var user = manager.Find(txtLogin.Text, txtPasword.Text);
            if (user!=null) {
                var authentificationManager = HttpContext.Current.GetOwinContext().Authentication;
                var userIdentity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                authentificationManager.SignIn(
                    new AuthenticationProperties { IsPersistent = false },
                    userIdentity
                    );

                Response.Redirect("~/Index.aspx");
            }
            else {
                litStatus.Text = "Неправильно введена электронная почта или пароль";
            }
            
        }
    }
}