using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AgressoDirectory.BusinessLogic;
using AgressoDirectory.Common.ViewModel;
using System.Web.Security;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace AgressoDirectory.Login
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                lblIncorrectUserCredentials.Visible = false;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            LoginViewModel objLoginViewModel = new LoginViewModel()
            {
                Username = txtUsername.Text,
                Password = txtPassword.Text
            };
            EmployeeBusinessManager objBL = new EmployeeBusinessManager();
            objLoginViewModel = objBL.UserLogin(objLoginViewModel);


            if (!string.IsNullOrWhiteSpace(objLoginViewModel.UserId))
            {
                //set values to the session
                Session["username"] = objLoginViewModel.Username;
                Session["uid"] = objLoginViewModel.UserId;
                Session["dsgcode"] = objLoginViewModel.objEmployeeViewModel.DesignationCode;
                FormsAuthentication.RedirectFromLoginPage(txtUsername.Text, false);

            }
            else
            {
                lblIncorrectUserCredentials.Visible = true;
            }

        }
    }
}