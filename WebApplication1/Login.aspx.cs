using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.QuestionaryServiceReference;

namespace WebApplication1 {
    public partial class Login : BasePage {

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            bool loggedin = GetClient().Login(UserName.Text);
            if (loggedin) {
                HttpCookie cookie = FormsAuthentication.GetAuthCookie(UserName.Text, true);
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(UserName.Text, true, 100);
                cookie.Value = FormsAuthentication.Encrypt(ticket);
                Response.Cookies.Add(cookie);
                Response.Redirect("~/Default.aspx");
            }
            loginfail.Visible = true;

            
        }
    }
}