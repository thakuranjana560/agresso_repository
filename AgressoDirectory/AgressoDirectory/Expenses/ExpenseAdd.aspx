<%@ Page Language="C#" ClientIDMode="Static" MasterPageFile="~/AgressoEmployee.Master" AutoEventWireup="true" CodeBehind="ExpenseAdd.aspx.cs" Inherits="AgressoDirectory.Expenses.ExpenseAdd" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="cphbody" runat="server">
    <!DOCTYPE html>

    <html>
    <head>
        <title>AddExpense</title>
        <link href="../Content/Stylesheet/Style.css" rel="stylesheet" />
        <link rel="stylesheet" type="text/css" href="../Content/Stylesheet/ListEmployeeStyleSheet.css" />
    </head>
    <body>
        <hr class="hr-red">
        <div id="section">
            <ul>
                <li><a href="../Employee/ListEmployee.aspx">ListEmployee</a></li>
                <li><a href="../Expenses/ExpenseDetail.aspx">ListExpenses</a></li>
                <%-- <li><a href="../Login/Login.aspx">LogOut</a>
			    </li>--%>
            </ul>
        </div>

           <asp:Label ID="lblSuccess" runat="server" ForeColor="Green" Text="Successfully submitted" Visible="false"></asp:Label>

        <asp:Label ID="lblmsg" runat="server" Visible="false" Text="you are not authorised to view the page please click on the following link below."></asp:Label>
        <br />



        <%--<form id="form1" runat="server">--%>
        <div id="dvExpense" runat="server">

            <table class="expenseAdd">
                <%--first row--%>
                <tr>
                    <td>Expense Type<span style="color: red;">*</span></td>
                    <td>
                        <asp:DropDownList ID="ddlExpenseType" runat="server" Width="213px">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddlExpenseType"
                            ErrorMessage="Please Select Approver Name" InitialValue="--Select--" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <%-- 2nd row--%>
                <tr>
                    <td>Amount <span style="color: red;">*</span></td>
                    <td>
                        <asp:TextBox ID="txtAmount" runat="server" Width="204px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter Amount" ControlToValidate="txtAmount" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Enter Valid Amount" ControlToValidate="txtAmount" ForeColor="Red" MaximumValue="50000" MinimumValue="0" Type="Currency"></asp:RangeValidator>
                    </td>
                </tr>

                <%-- 5th row--%>
                <tr>
                    <td>Approver<span style="color: red;">*</span></td>
                    <td>
                        <asp:DropDownList ID="ddlApprover" runat="server">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlApprover"
                            ErrorMessage="Please Select Approver Name" InitialValue="--Select Approver--" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <%-- 6th row--%>
                <tr>
                    <td>Project<span style="color: red;">*</span></td>
                    <td>
                        <asp:DropDownList ID="ddlProject" runat="server">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="ddlProject"
                            ErrorMessage="Please Select Approver Name" InitialValue="--Select--" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td>Comment<span style="color: red;">*</span>
                    </td>
                    <td>
                        <textarea id="txtApproverComment" runat="server" cols="30" rows="4"></textarea>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Please Enter Comment" ControlToValidate="txtApproverComment" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%--   <asp:Label ID="lblExpenseDocument" runat="server" Text="Expense Document"</asp:Label>--%>
                        Expense Document<span style="color: red;">*</span>
                    </td>
                    <td>
                        <asp:FileUpload ID="fuExpenseDocument" runat="server" accept=".png,.jpg,.jpeg,.gif" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Upload document here" ControlToValidate="fuExpenseDocument" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="regexValidator" runat="server"
                            ControlToValidate="fuExpenseDocument"
                            ErrorMessage="Only .jpg,.png,.jpeg,.gif Files are allowed"
                            ValidationExpression="(.*?)\.(jpg|jpeg|png|gif|JPG|JPEG|PNG|GIF)$" ForeColor="Red"></asp:RegularExpressionValidator>
                    </td>
                </tr>

                <%-- 6th row--%>
                <tr>

                    <td>
                        <asp:Button ID="btnSubmit" runat="server" Text="Save" OnClick="SubmitButton" />                     

                        <%--  <a href="ExpenseDetail.aspx"> Expenses List</a>--%>
                    </td>
                    <td>
                        <asp:Button ID="btncancel" runat="server" Text="Cancel" OnClick="CancelButton" CausesValidation="False" />
                    </td>
                </tr>
            </table>
            <p id="DataText" runat="server"></p>
        </div>
        <%--</form>--%>
    </body>
    </html>
</asp:Content>

