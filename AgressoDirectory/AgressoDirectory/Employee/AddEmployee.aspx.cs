using AgressoDirectory.BusinessLogic;
using AgressoDirectory.Common.ViewModel;
using System;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.Data; // should be deleted later(just for completing edit in different page task)
using System.Data.SqlClient;// should be deleted later (just for completing edit in differnt page task)
using System.Configuration;// should be deleted later (just for completing edit in differnt page task)
namespace AgressoDirectory.Employee
{
    public partial class AddEmployee : System.Web.UI.Page
    {
        // should not be declare just for completing edit in different page functionality
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["dsgcode"]!=null)
            {
               var position  =Convert.ToString(Session["dsgcode"]);
               if (position.Equals("l9", StringComparison.InvariantCultureIgnoreCase)) //If user is manager
                {
                    dvForm.Visible = true;
                    lblauth.Visible = false;
                    drpProjectBind();
                    if(Request.QueryString["Id"] != null)
                    {
                        //Edit Mode
                        hfId.Value = Convert.ToString(Request.QueryString["Id"]).Trim();
                        btnSubmit.Visible = false;
                        btnUpd.Visible = true;
                        if (!Page.IsPostBack)
                            BindTextBoxValues();
                    }
                    else
                    {
                        btnSubmit.Visible = true;
                        btnUpd.Visible = false;
                    }
                }
            }
            //if (Session["Id"] != null)
            //{
            //    hfId.Value = Convert.ToString(Session["Id"]);
            //    btnSubmit.Visible = false;
            //    btnUpd.Visible = true;
            //    if(!Page.IsPostBack)
            //    BindTextBoxValues();
            //}
        }


        /// <summary>
        /// Button click to get calendar on select
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnDateOfBirth_Click(object sender, EventArgs e)
        {

            if (calDateOfBirth.Visible)
            {
                calDateOfBirth.Visible = false;
            }
            else
            {
                calDateOfBirth.Visible = true;
            }
        }


        /// <summary>
        /// selection index changed for calendar on selecting date in calendar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CalDateOfBirth_SelectionChanged(object sender, EventArgs e)
        {

            txtDateOfBirth.Text = String.Format("{0:dd/MM/yyyy}", calDateOfBirth.SelectedDate);
            calDateOfBirth.Visible = false;
        }


        /// <summary>
        /// Submit button event to call AddEmployee method and empty the textboxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btnsubmit_Click(object sender, EventArgs e)
        {
            EmployeeViewModel model = new EmployeeViewModel();
            AddNewEmployee(model);
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtSkills.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtEmailID.Text = string.Empty;
            txtContactNumber.Text = string.Empty;
            txtDateOfBirth.Text = string.Empty;
        }


        /// <summary>
        /// method to get values of asp controls stored in AddEmployeeViewModel and passing the values to EmployeeBL
        /// </summary>
        /// <param name="model"></param>
        protected void AddNewEmployee(EmployeeViewModel objViewModel)
        {

            objViewModel.FirstName = txtFirstName.Text.Trim();
            objViewModel.LastName = txtLastName.Text.Trim();
            objViewModel.DateOfBirth = (Convert.ToDateTime(txtDateOfBirth.Text.Trim()));
            objViewModel.DesignationCode = drpDesignationCode.SelectedValue;
            objViewModel.Gender = radGender.SelectedValue;
            objViewModel.Address = txtAddress.Text.Trim();
            objViewModel.CountryCode = Convert.ToInt32(drpCountryCode.SelectedValue);
            objViewModel.StateCode = Convert.ToInt32(drpStateCode.SelectedValue);
            objViewModel.CityCode = Convert.ToInt32(drpCityCode.SelectedValue);
            objViewModel.EmailID = txtEmailID.Text.Trim();
            objViewModel.ContactNumber = Convert.ToInt64(txtContactNumber.Text.Trim());
            objViewModel.Skills = txtSkills.Text.Trim();
            objViewModel.Experience = Convert.ToInt32(drpExperience.SelectedValue);
            objViewModel.ProjectName = Convert.ToString(drpProject.SelectedItem.Text);

            EmployeeBusinessManager objEmpBL = new EmployeeBusinessManager();
            objEmpBL.AddNewEmployee(objViewModel);
            lblmessage.Visible = true;
           // Response.Redirect("~/Employee/ListEmployee.aspx");
        }

        //protected void btnLogOut_Click(object sender, EventArgs e)
        //{
        //    Session.Clear();
        //    Session.Abandon();
        //    FormsAuthentication.SignOut();
        //    Response.Redirect("~/Login/Login.aspx");
        //}

        protected void BindTextBoxValues()
        {
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("select * from Employee where Id="+ hfId.Value, con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            txtFirstName.Text = dt.Rows[0][1].ToString();
            txtLastName.Text = dt.Rows[0][2].ToString();
            radGender.SelectedValue = dt.Rows[0][5].ToString();
            txtAddress.Text = dt.Rows[0][6].ToString();
            drpDesignationCode.SelectedValue = dt.Rows[0][4].ToString();
            txtSkills.Text= dt.Rows[0][15].ToString();
            txtDateOfBirth.Text= String.Format("{0:dd/MM/yyyy}",dt.Rows[0][3]);
            drpExperience.SelectedValue= dt.Rows[0][16].ToString();
            drpCountryCode.SelectedValue= dt.Rows[0][7].ToString();
            drpStateCode.SelectedValue= dt.Rows[0][8].ToString();
            drpCityCode.SelectedValue= dt.Rows[0][9].ToString();
            txtEmailID.Text= dt.Rows[0][13].ToString();
            txtContactNumber.Text=dt.Rows[0][14].ToString();
            drpProject.SelectedItem.Text = dt.Rows[0][18].ToString();
        }
        protected void drpProjectBind()
        {
            EmployeeBusinessManager EmpBL = new EmployeeBusinessManager();
            var dsproject = EmpBL.GetEmployeeProject();
            drpProject.DataTextField = dsproject.Tables[0].Columns["ProjectType"].ToString();
            drpProject.DataValueField=dsproject.Tables[0].Columns["ProjectId"].ToString();
            drpProject.DataSource = dsproject.Tables[0];
            drpProject.DataBind();
        }

        protected void btnUpd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            con.Open();
            cmd.CommandText = ("Update Employee set FirstName=@FirstName,LastName=@LastName,DateOfBirth=@DateOfBirth,EmpDesignationCode=@EmpDesignationCode,Gender=@Gender,Address=@Address,EmpCountryCode=@EmpCountryCode,EmpStateCode=@EmpStateCode,EmpCityCode=@EmpCityCode,EmailId=@EmailID,MobileNumber=@MobileNumber,Skills=@Skills,TotalExperience=@TotalExperience,ProjectName=@ProjectName where ID=@ID");
            cmd.Connection = con;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = Convert.ToInt32(hfId.Value);
            cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = txtFirstName.Text.Trim();
            cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = txtLastName.Text;
            cmd.Parameters.Add("@DateOfBirth", SqlDbType.Date).Value = txtDateOfBirth.Text;
            cmd.Parameters.Add("@EmpDesignationCode", SqlDbType.Char).Value = drpDesignationCode.SelectedValue;
            cmd.Parameters.Add("@Gender", SqlDbType.VarChar).Value = radGender.SelectedValue;
            cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = txtAddress.Text;
            cmd.Parameters.Add("@EmpCountryCode", SqlDbType.Int).Value = drpCountryCode.SelectedValue;
            cmd.Parameters.Add("@EmpStateCode", SqlDbType.Int).Value = drpStateCode.SelectedValue;
            cmd.Parameters.Add("@EmpCityCode", SqlDbType.Int).Value = drpCityCode.SelectedValue;
            cmd.Parameters.Add("@EmailID", SqlDbType.NVarChar).Value = txtEmailID.Text;
            cmd.Parameters.Add("@MobileNumber", SqlDbType.BigInt).Value = txtContactNumber.Text;
            cmd.Parameters.Add("@skills", SqlDbType.NVarChar).Value = txtSkills.Text;
            cmd.Parameters.Add("@TotalExperience", SqlDbType.Int).Value = drpExperience.SelectedValue;
            cmd.Parameters.Add("@ProjectName", SqlDbType.VarChar).Value = drpProject.SelectedItem.Text;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            Response.Redirect("~/Employee/ListEmployee.aspx");
        }

    }
}