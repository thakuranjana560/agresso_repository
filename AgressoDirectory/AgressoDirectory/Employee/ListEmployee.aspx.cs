using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AgressoDirectory.BusinessLogic;
using AgressoDirectory.Common.ViewModel;
using System.Web;
using System.Web.Security;

namespace AgressoDirectory.Employee
{
    public partial class ListEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //{
            //    HttpCookie ck = Request.Cookies["cookieUsername"];
            //    if (ck != null)
            //    {
            //        Label lblMasterText = (Label)Master.FindControl("lblmaster");
            //        lblMasterText.Text = "Welcome  " + ck.Values["un"];
            //    }
            //    else
            //    {
            //        Response.Write("cookie not created");
            //    }
            //}
            if (!Page.IsPostBack)
            {
                Gridbind();
            }
        }

        /// <summary>
        /// Method to bind gridview. 
        /// </summary>
        public void Gridbind()
        {
            DataSet ds = new DataSet();
            EmployeeBusinessManager objEmpBL = new EmployeeBusinessManager();
           
            ds = objEmpBL.GetAddedEmployees();
            grdListEmployee.Columns[0].Visible = false;
            grdListEmployee.DataSource = objEmpBL.GetAddedEmployees();
            grdListEmployee.DataBind();
        }

        /// <summary>
        /// Gridview row editing event to call edititem template when edit button is clicked and then call to gridbind method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GrdListEmployee_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Session["Id"] = Convert.ToInt32(((Label)(grdListEmployee.Rows[e.NewEditIndex].FindControl("lblId"))).Text);
            int IdToEdit = Convert.ToInt32(((Label)(grdListEmployee.Rows[e.NewEditIndex].FindControl("lblId"))).Text);
            Response.Redirect("~/Employee/AddEmployee.aspx?Id="+ IdToEdit);
            //grdListEmployee.EditIndex = e.NewEditIndex;
            //Gridbind();
        }


        /// <summary>
        /// Gridview row canceling edit event to call item template when cancel button is clicked and then call to gridbind method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GrdListEmployee_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdListEmployee.EditIndex = -1;
            Gridbind();
        }


        /// <summary>
        /// Gridview row-updating event to get values stored in AddEmployeeViewModel from controls in edititem template and call to UpdateEmployee method to pass value in it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GrdListEmployee_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            EmployeeViewModel objUpdViewModel = new EmployeeViewModel
            {
                Id = Convert.ToInt32(((Label)(grdListEmployee.Rows[e.RowIndex].FindControl("lblEditId"))).Text),
                FirstName = ((TextBox)(grdListEmployee.Rows[e.RowIndex].FindControl("txtEditFirstName"))).Text.Trim(),
                LastName = ((TextBox)(grdListEmployee.Rows[e.RowIndex].FindControl("txtEditLastName"))).Text.Trim(),
                DateOfBirth = Convert.ToDateTime(((TextBox)(grdListEmployee.Rows[e.RowIndex].FindControl("txtEditDateOfBirth"))).Text),
                DesignationCode = ((DropDownList)(grdListEmployee.Rows[e.RowIndex].FindControl("drpEditDesignationCode"))).Text,
                Gender = ((RadioButtonList)(grdListEmployee.Rows[e.RowIndex].FindControl("radEditGender"))).SelectedItem.Value,
                Address = ((TextBox)(grdListEmployee.Rows[e.RowIndex].FindControl("txtEditAddress"))).Text.Trim(),
                CountryCode = Convert.ToInt32(((DropDownList)(grdListEmployee.Rows[e.RowIndex].FindControl("drpEditCountryCode"))).Text),
                StateCode = Convert.ToInt32(((DropDownList)(grdListEmployee.Rows[e.RowIndex].FindControl("drpEditStateCode"))).Text),
                CityCode = Convert.ToInt32(((DropDownList)(grdListEmployee.Rows[e.RowIndex].FindControl("drpEditCityCode"))).Text),
                EmailID = ((TextBox)(grdListEmployee.Rows[e.RowIndex].FindControl("txtEditEmail"))).Text.Trim(),
                ContactNumber = Convert.ToInt64(((TextBox)(grdListEmployee.Rows[e.RowIndex].FindControl("txtEditMobileNumber"))).Text.Trim()),
                Skills = ((TextBox)(grdListEmployee.Rows[e.RowIndex].FindControl("txtEditSkills"))).Text.Trim(),
                Experience = Convert.ToInt32(((TextBox)(grdListEmployee.Rows[e.RowIndex].FindControl("txtEditExperience"))).Text.Trim()),
                IsActive = Convert.ToBoolean(Convert.ToInt32((((RadioButtonList)(grdListEmployee.Rows[e.RowIndex].FindControl("radEditIsActive"))).SelectedItem.Value)))
            };
            //model.IsActive =Convert.ToBoolean(((TextBox)(grdListEmployee.Rows[e.RowIndex].FindControl("txtEditIsActive"))).Text);

            EmployeeBusinessManager objUpdBL = new EmployeeBusinessManager();
            objUpdBL.UpdateEmployee(objUpdViewModel);

            grdListEmployee.EditIndex = -1;
            Gridbind();
        }

        //protected void btnLogout_Click(object sender, EventArgs e)
        //{
        //    Session.Clear();
        //    Session.Abandon();
        //    FormsAuthentication.SignOut();
        //    Response.Redirect("~/Login/Login.aspx");
        //}
    }
}