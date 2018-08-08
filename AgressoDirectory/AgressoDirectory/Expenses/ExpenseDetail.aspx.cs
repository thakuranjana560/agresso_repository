using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;             // only for expense of manager method down 
using System.Configuration;     // only for expense of manager method down
using System.Data.SqlClient;      // only for expense of manager method down

namespace AgressoDirectory.Expenses
{
    public partial class ExpenseDetail : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                if (Session["dsgcode"] != null)
                {
                    var pos = Convert.ToString(Session["dsgcode"]);
                    var id= Convert.ToString(Session["uid"]).Trim();
                    if (pos.Equals("l9", StringComparison.InvariantCultureIgnoreCase))
                    {
                        //GetManagerExpense();
                        BindData(pos,id);
                    }
                    else
                    {
                        ExpenseDetails.Columns[7].Visible = false;
                        //GetJuniorEmployeeExpense();
                        BindData(pos,id);
                    }
                }
            }


            // IS Postback check for checking if event is initial load or user has performed some event
            //    if (!IsPostBack)
            //    {
            //        BindData();
            //    }
            //    ExpenseDetails.FooterRow.Visible = false;
        }
        protected void BindData(string pos,string id)
        {
            AgressoDirectory.BusinessLogic.ExpenseManager businessLayer = new AgressoDirectory.BusinessLogic.ExpenseManager();
            DataTable FromTable = businessLayer.GetExpenses(pos,id);
            //Database have values
            if (FromTable.Rows.Count > 0)
            {
                ExpenseDetails.DataSource = FromTable;
                ExpenseDetails.DataBind();
            }
            else
            {
                FromTable.Rows.Add(FromTable.NewRow());

                ExpenseDetails.DataSource = FromTable;

                ExpenseDetails.DataBind();

                int TotalColumns = ExpenseDetails.Rows[0].Cells.Count;

                ExpenseDetails.Rows[0].Cells.Clear();

                ExpenseDetails.Rows[0].Cells.Add(new TableCell());

                ExpenseDetails.Rows[0].Cells[0].ColumnSpan = TotalColumns;

                ExpenseDetails.Rows[0].Cells[0].Text = "No records Found";

            }
        }
        protected void ExpenseDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label lblProjectCode = (Label)ExpenseDetails.Rows[e.RowIndex].FindControl("Id");

            AgressoDirectory.BusinessLogic.ExpenseManager businessLayer = new AgressoDirectory.BusinessLogic.ExpenseManager();
            if (lblProjectCode != null)
                businessLayer.DeletetExpense(lblProjectCode.Text);

            var pos = Convert.ToString(Session["dsgcode"]);
            var id = Convert.ToString(Session["uid"]).Trim();
            BindData(pos,id);
        }
        protected void ExpenseDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            TextBox txtEditAmount = (TextBox)ExpenseDetails.Rows[e.RowIndex].FindControl("txtEditAmount");

            DropDownList txtEditStatusId = (DropDownList)ExpenseDetails.Rows[e.RowIndex].FindControl("txtEdiStatusId");

            DropDownList txtEditApproverId = (DropDownList)ExpenseDetails.Rows[e.RowIndex].FindControl("txtEditApproverId");

            DropDownList txtEditProjectCode = (DropDownList)ExpenseDetails.Rows[e.RowIndex].FindControl("Project");

            TextBox txtEditApprovedDate = (TextBox)ExpenseDetails.Rows[e.RowIndex].FindControl("txtEditApprovedDate");

            DropDownList txtEditExpenseTypeId = (DropDownList)ExpenseDetails.Rows[e.RowIndex].FindControl("txtEditExpenseTypeId");

            TextBox txtEditApproverComment = (TextBox)ExpenseDetails.Rows[e.RowIndex].FindControl("txtEditApproverComment");

            string Id = ((HiddenField)ExpenseDetails.Rows[e.RowIndex].FindControl("HiddenField1")).Value;

            AgressoDirectory.BusinessLogic.ExpenseManager businessLayer = new AgressoDirectory.BusinessLogic.ExpenseManager();
            businessLayer.UpdatetExpense(Id, txtEditProjectCode.SelectedItem.Value, txtEditAmount.Text, txtEditStatusId.SelectedItem.Value, txtEditApprovedDate.Text,
                txtEditExpenseTypeId.SelectedItem.Value, txtEditApproverId.SelectedItem.Value, txtEditApproverComment.Text);

            ExpenseDetails.EditIndex = -1;
            var pos = Convert.ToString(Session["dsgcode"]);
            var id = Convert.ToString(Session["uid"]).Trim();
            BindData(pos, id);

        }

        protected void ExpenseDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

            ExpenseDetails.EditIndex = -1;
            var pos = Convert.ToString(Session["dsgcode"]);
            var id = Convert.ToString(Session["uid"]).Trim();
            BindData(pos, id);
        }

        protected void ExpenseDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {
            ExpenseDetails.Columns[0].Visible = false;
            ExpenseDetails.Columns[4].Visible = false;
            ExpenseDetails.Columns[5].Visible = false;
            ExpenseDetails.EditIndex = e.NewEditIndex;
            var pos = Convert.ToString(Session["dsgcode"]);
            var id = Convert.ToString(Session["uid"]).Trim();
            BindData(pos, id);
        }

        private void BindDropDown(DropDownList Project)
        {
            var businessLayer = new AgressoDirectory.BusinessLogic.ExpenseManager();
            var dsProjects = businessLayer.GetProject();
            Project.DataTextField = dsProjects.Tables[0].Columns["ProjectType"].ToString(); // text field name of table dispalyed in dropdown
            Project.DataValueField = dsProjects.Tables[0].Columns["ProjectId"].ToString();             // to retrive specific  textfield name 
            Project.DataSource = dsProjects.Tables[0];   //assigning datasource to the dropdownlist
            Project.DataBind();


        }

        protected void ExpenseDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if ((e.Row.RowState & DataControlRowState.Edit) > 0)
            {
                // BIND THE "DROPDOWNLIST" WITH THE DATASET FILLED WITH "Project" 
                DropDownList Project = new DropDownList();
                Project = (DropDownList)e.Row.FindControl("Project");

                if (Project != null)
                {
                    var businessLayer = new AgressoDirectory.BusinessLogic.ExpenseManager();
                    var dsProjects = businessLayer.GetProject();
                    Project.DataTextField = dsProjects.Tables[0].Columns["ProjectType"].ToString(); // text field name of table dispalyed in dropdown
                    Project.DataValueField = dsProjects.Tables[0].Columns["ProjectId"].ToString();             // to retrive specific  textfield name 
                    Project.DataSource = dsProjects.Tables[0];   //assigning datasource to the dropdownlist
                    Project.DataBind();

                    // ASSIGN THE SELECTED ROW VALUE ("ProjectCode") TO THE DROPDOWNLIST SELECTED VALUE.
                    Project.SelectedIndex = Project.Items.IndexOf(Project.Items.FindByText(DataBinder.Eval(e.Row.DataItem, "ProjectType").ToString()));
                }

                DropDownList Approver = new DropDownList();
                Approver = (DropDownList)e.Row.FindControl("txtEditApproverId");

                if (Approver != null)
                {
                    var businessLayer = new AgressoDirectory.BusinessLogic.ExpenseManager();
                    var dsApprover = businessLayer.GetApprover();
                    Approver.DataTextField = dsApprover.Tables[0].Columns["name"].ToString(); // text field name of table dispalyed in dropdown
                    Approver.DataValueField = dsApprover.Tables[0].Columns["UserID"].ToString();             // to retrive specific  textfield name 
                    Approver.DataSource = dsApprover.Tables[0];   //assigning datasource to the dropdownlist
                    Approver.DataBind();

                    // ASSIGN THE SELECTED ROW VALUE ("QUALIFICATION CODE") TO THE DROPDOWNLIST SELECTED VALUE.
                    Approver.SelectedIndex = Project.Items.IndexOf(Approver.Items.FindByText(DataBinder.Eval(e.Row.DataItem, "name").ToString()));
                }

                DropDownList ExpenseType = new DropDownList();
                ExpenseType = (DropDownList)e.Row.FindControl("txtEditExpenseTypeId");

                if (Approver != null)
                {
                    var businessLayer = new AgressoDirectory.BusinessLogic.ExpenseManager();
                    var dsExpenseType = businessLayer.GetExpenseType();
                    ExpenseType.DataTextField = dsExpenseType.Tables[0].Columns["ExpenseType"].ToString(); // text field name of table dispalyed in dropdown
                    ExpenseType.DataValueField = dsExpenseType.Tables[0].Columns["ExpenseID"].ToString();             // to retrive specific  textfield name 
                    ExpenseType.DataSource = dsExpenseType.Tables[0];   //assigning datasource to the dropdownlist
                    ExpenseType.DataBind();

                    // ASSIGN THE SELECTED ROW VALUE ("QUALIFICATION CODE") TO THE DROPDOWNLIST SELECTED VALUE.
                    ExpenseType.SelectedIndex = Project.Items.IndexOf(ExpenseType.Items.FindByText(DataBinder.Eval(e.Row.DataItem, "ExpenseType").ToString()));
                }


                DropDownList StatusType = new DropDownList();
                StatusType = (DropDownList)e.Row.FindControl("txtEdiStatusId");

                if (Approver != null)
                {
                    var businessLayer = new AgressoDirectory.BusinessLogic.ExpenseManager();
                    var dsStatusType = businessLayer.GetStatus();
                    StatusType.DataTextField = dsStatusType.Tables[0].Columns["Status"].ToString(); // text field name of table dispalyed in dropdown
                    StatusType.DataValueField = dsStatusType.Tables[0].Columns["StatusID"].ToString();             // to retrive specific  textfield name 
                    StatusType.DataSource = dsStatusType.Tables[0];   //assigning datasource to the dropdownlist
                    StatusType.DataBind();

                    // ASSIGN THE SELECTED ROW VALUE ("QUALIFICATION CODE") TO THE DROPDOWNLIST SELECTED VALUE.
                    StatusType.SelectedIndex = Project.Items.IndexOf(StatusType.Items.FindByText(DataBinder.Eval(e.Row.DataItem, "Status").ToString()));
                }
            }
        }

        protected void AddExpense(object sender, EventArgs e)
        {
            Response.Redirect("ExpenseAdd.aspx");
        }
    }
}