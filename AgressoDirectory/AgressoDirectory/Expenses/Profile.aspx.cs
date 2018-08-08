using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AgressoDirectory.Expenses
{
    public partial class Profile : System.Web.UI.Page
    {        
        protected void Page_Load(object sender, EventArgs e)
        {            
            var businessLayer = new AgressoDirectory.BusinessLogic.ProfileManager();
            var dsExpenseType = businessLayer.GetDesignationType();
            ddlDesignation.DataTextField = dsExpenseType.Tables[0].Columns["designationName"].ToString(); // text field name of table dispalyed in dropdown
            ddlDesignation.DataValueField = dsExpenseType.Tables[0].Columns["DesignationCode"].ToString();             // to retrive specific  textfield name 
            ddlDesignation.DataSource = dsExpenseType.Tables[0];   //assigning datasource to the dropdownlist
            ddlDesignation.DataBind();

            var model = businessLayer.GetProfileById(Convert.ToString(Session["uid"]));
            ddlDesignation.Items.FindByValue(model.Designation).Selected = true;
            ddlDesignation.Enabled = false;
            txtFirstName.Text = model.FirstName;
            txtLastName.Text = model.LastName;
            txtEmailId.Text = model.EmailId;  
            
        }

        protected void UpdateButton(object sender, EventArgs e)
        {
            NameValueCollection nv = Request.Form;
            if (nv.Count > 0)
            {
                AgressoDirectory.Common.Model.Profile userProfile = new AgressoDirectory.Common.Model.Profile();
                //userProfile.FirstName = txtFirstName.Text;
                //userProfile.LastName = txtLastName.Text;
                //userProfile.EmailId = txtEmailId.Text;
                //userProfile.id = Session["id"].ToString();

                userProfile.FirstName = nv["ctl00$cphBody$txtFirstName"];
                userProfile.LastName = nv["ctl00$cphBody$txtLastName"];
                userProfile.EmailId = nv["ctl00$cphBody$txtEmailId"];
                userProfile.id = Session["uid"].ToString();
                var businessLayerExpense = new AgressoDirectory.BusinessLogic.ProfileManager();
                businessLayerExpense.UpdateUserProfile(userProfile);
                lblUpdate.Visible = true;
                //Response.Redirect("../Employee/ListEmployee.aspx");
            }
        }
    }
}