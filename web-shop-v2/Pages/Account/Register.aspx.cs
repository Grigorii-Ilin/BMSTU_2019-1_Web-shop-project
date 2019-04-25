﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web_shop_v2.Pages.Account {
    public partial class Register : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void btnConfirm_Click(object sender, EventArgs e) {
            //https://stackoverflow.com/questions/20183777/keyword-not-supported-metadata
            string connectionStringEF = System.Configuration.ConfigurationManager
                .ConnectionStrings["VegetableDBEntities"].ConnectionString;
            //if (connectionStringEF.ToLower().StartsWith("metadata=")) {
            var efBuilder = new System.Data.Entity.Core.EntityClient
                .EntityConnectionStringBuilder(connectionStringEF);
            string connectionStringOK = efBuilder.ProviderConnectionString;

            UserStore<IdentityUser> userStore = new UserStore<IdentityUser>();
            userStore.Context.Database.Connection.ConnectionString = connectionStringOK;

            var manager = new UserManager<IdentityUser>(userStore);

            var user = new IdentityUser();
            user.UserName = txtLogin.Text;

            if (txtPasword.Text == txtConfirmPassword.Text) {
                try {
                    var result = manager.Create(user, txtPasword.Text);
                    if (result.Succeeded) {
                        var autentificationManager = HttpContext.Current.GetOwinContext().Authentication;
                        var userIdentity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                        autentificationManager
                            .SignIn(new Microsoft.Owin.Security.AuthenticationProperties(), userIdentity);
                        Response.Redirect("~/Index.aspx");
                    }
                    else {
                        litStatus.Text = result.Errors.FirstOrDefault();
                    }
                }
                catch (Exception ex) {

                    litStatus.Text = ex.ToString();
                }
            }
            else {
                litStatus.Text = "Пароли не совпадают";
            }
        }
    }
}