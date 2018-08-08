using AgressoDirectory.Common.Model;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AgressoDirectory.Expenses
{
    public partial class ExpenseAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["dsgcode"] != null)
            {
                var position = Convert.ToString(Session["dsgcode"]);
                if (position.Equals("l9", StringComparison.InvariantCultureIgnoreCase))
                {
                    lblmsg.Visible = true;
                    dvExpense.Visible = false;
                }
            }
            var businessLayer = new AgressoDirectory.BusinessLogic.ExpenseManager();
            if (!Page.IsPostBack)
            {


                var dsExpenseType = businessLayer.GetExpenseType();
                ddlExpenseType.DataTextField = dsExpenseType.Tables[0].Columns["ExpenseType"].ToString(); // text field name of table dispalyed in dropdown
                ddlExpenseType.DataValueField = dsExpenseType.Tables[0].Columns["ExpenseID"].ToString();             // to retrive specific  textfield name 
                ddlExpenseType.DataSource = dsExpenseType.Tables[0];   //assigning datasource to the dropdownlist
                ddlExpenseType.DataBind();
                ddlExpenseType.Items.Insert(0, new ListItem("--Select--", "--Select--"));

                var dsProjects = businessLayer.GetProject();
                ddlProject.DataTextField = dsProjects.Tables[0].Columns["ProjectType"].ToString(); // text field name of table dispalyed in dropdown
                ddlProject.DataValueField = dsProjects.Tables[0].Columns["ProjectId"].ToString();             // to retrive specific  textfield name 
                ddlProject.DataSource = dsProjects.Tables[0];   //assigning datasource to the dropdownlist
                ddlProject.DataBind();
                ddlProject.Items.Insert(0, new ListItem("--Select--", "--Select--"));


                var dsApprover = businessLayer.GetApprover();
                ddlApprover.DataTextField = dsApprover.Tables[0].Columns["name"].ToString(); // text field name of table dispalyed in dropdown
                ddlApprover.DataValueField = dsApprover.Tables[0].Columns["UserID"].ToString(); // to retrive specific  textfield name 
                ddlApprover.DataSource = dsApprover.Tables[0].DefaultView;   //assigning datasource to the dropdownlist
                                                                             //ddlApprover.SelectedIndex = -1;
                ddlApprover.DataBind();


                ddlApprover.Items.Insert(0, new ListItem("--Select Approver--", "--Select Approver--"));
            }

        }


        protected void SubmitButton(object sender, EventArgs e)
        {
            var businessLayer = new AgressoDirectory.BusinessLogic.ExpenseManager();
            NameValueCollection nv = Request.Form;
            if (nv.Count > 0)
            {
                Expense model = new Expense();
                model.ExpenseTypeId = Convert.ToInt32(nv["ctl00$cphBody$ddlExpenseType"]);
                model.Amount = Convert.ToDecimal(nv["ctl00$cphBody$txtAmount"]);
                model.Approver = Convert.ToString(nv["ctl00$cphBody$ddlApprover"]);
                model.ProjectCode = Convert.ToInt32(nv["ctl00$cphBody$ddlProject"]);
                model.ApproverId = Convert.ToString(Session["uid"]);
                model.ApproverComment = nv["ctl00$cphBody$txtApproverComment"];

                if (fuExpenseDocument.HasFile)
                {
                    string filename = Path.GetFileName(fuExpenseDocument.FileName);

                    fuExpenseDocument.SaveAs(Server.MapPath("~/Attachments/") + filename);
                    model.Attachment = Server.MapPath("~/Attachments/") + filename;
                }
                lblSuccess.Visible = true;
                businessLayer.SaveExpenses(model);
                ClearFields();
            }


        }

        protected void CancelButton(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtAmount.Text = string.Empty;
            txtApproverComment.InnerText = string.Empty;
            ddlApprover.SelectedIndex = 0;
            ddlProject.SelectedIndex = 0;
            ddlExpenseType.SelectedIndex = 0;
        }
    }
}