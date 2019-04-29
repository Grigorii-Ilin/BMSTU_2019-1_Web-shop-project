using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using web_shop_v2.MyModels;

namespace web_shop_v2.Pages {
    public partial class Success : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            //var model = new UserInfoModel;

            //litAddress.Text=
            var carts = (List<Cart>)Session[User.Identity.GetUserId()];
            var cartModel = new CartModel();
            cartModel.MarkOrdersAsPurchased(carts);

            Session[User.Identity.GetUserId()]=null;
        }
    }
}