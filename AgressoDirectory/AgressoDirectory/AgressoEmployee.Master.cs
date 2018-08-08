using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AgressoDirectory
{
    public partial class AgressoEmployee : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void BtnLogout_Click(object sender, EventArgs e)
        {
           // var someText = "sdsfsds";
                Session.Clear();
                Session.Abandon();
                FormsAuthentication.SignOut();
                Response.Redirect("~/Login/Login.aspx");
          
        }
    }
}