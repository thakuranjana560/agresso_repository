<%@ Page Language="C#" MasterPageFile="~/AgressoEmployee.Master" AutoEventWireup="true" CodeBehind="ExpenseDetail.aspx.cs" Inherits="AgressoDirectory.Expenses.ExpenseDetail" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="cphbody" runat="server">
    <!DOCTYPE html>

    <html>
    <head>
        <title>ListExpense</title>
        <link rel="stylesheet" type="text/css" href="../Content/Stylesheet/ListEmployeeStyleSheet.css" />
    </head>
    <body>
        <hr class="hr-red">
        <div id="section">
            <ul>
                <%if (Session["dsgcode"] != null && Convert.ToString(Session["dsgcode"]) == "L9")
                    {%><li><a href="../Employee/AddEmployee.aspx">AddEmployee</a>
                        </li>
                <%}%>
                <li><a href="../Employee/ListEmployee.aspx">ListEmployee</a>
                </li>

                <%if (Session["dsgcode"] != null && Convert.ToString(Session["dsgcode"]) != "L9")
                    {%><li><a href="../Expenses/ExpenseAdd.aspx">AddExpeses</a>
                   </li>
                <%}%>
                <%-- <li><a href="../Login/Login.aspx">LogOut</a>
			    </li>--%>
            </ul>
        </div>



        <%--<form id="form1" runat="server">--%>
        <div id="dvExpenseDetail" runat="server">

            <div>
                <br />
                <br />
                <table style="width: 100%; align-content: center">
                    <tr>
                        <td><%--colspan="2" style="align-content: center"><b>Expense Details</b>--%>
                            <asp:Button ID="btnBack" Style="float: left" runat="server" Visible="false" Text="Add Expense" OnClick="AddExpense" /></td>
                    </tr>
                    <tr>
                        <td colspan="2">

                            <asp:GridView ID="ExpenseDetails" runat="server" Width="100%"
                                AutoGenerateColumns="false"
                                OnRowDeleting="ExpenseDetails_RowDeleting"
                                OnRowDataBound="ExpenseDetails_RowDataBound"
                                OnRowUpdating="ExpenseDetails_RowUpdating"
                                OnRowCancelingEdit="ExpenseDetails_RowCancelingEdit"
                                OnRowEditing="ExpenseDetails_RowEditing" >

                                <Columns>

                                    <asp:TemplateField HeaderText="ExpenseType">

                                        <ItemTemplate>

                                            <asp:Label ID="lblExpenseTypeId" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ExpenseType") %>'></asp:Label>


                                            <%--<a href="ExpenseAdd.aspx?id=<%#DataBinder.Eval(Container.DataItem, "Id") %>"><%#DataBinder.Eval(Container.DataItem, "ExpenseType") %></a>--%>
                                        </ItemTemplate>

                                        <EditItemTemplate>

                                            <asp:DropDownList ID="txtEditExpenseTypeId" runat="server"></asp:DropDownList>

                                        </EditItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Amount">

                                        <ItemTemplate>

                                            <asp:Label ID="lblAmount" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Amount") %>'></asp:Label>

                                        </ItemTemplate>

                                        <EditItemTemplate>


                                            <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Bind("Id") %>' />


                                            <asp:TextBox ID="txtEditAmount" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Amount") %>'></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter Amount" ControlToValidate="txtEditAmount" ForeColor="Red"></asp:RequiredFieldValidator>
                                            <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Enter Valid Amount" ControlToValidate="txtEditAmount" ForeColor="Red" MaximumValue="50000" MinimumValue="100" Type="Currency"></asp:RangeValidator>

                                        </EditItemTemplate>

                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="Approved Date">

                                        <ItemTemplate>

                                            <asp:Label ID="lblApprovedDate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ApprovedDate", "{0:d/M/yyyy}") %>'></asp:Label>

                                        </ItemTemplate>

                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtEditApprovedDate" type="date" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ApprovedDate", "{0:yyyy-MM-dd}") %>'></asp:TextBox>

                                        </EditItemTemplate>

                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Status">

                                        <ItemTemplate>

                                            <asp:Label ID="lblStatusId" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Status") %>'></asp:Label>

                                        </ItemTemplate>

                                        <EditItemTemplate>

                                            <asp:DropDownList ID="txtEdiStatusId" runat="server"></asp:DropDownList>

                                        </EditItemTemplate>



                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Approver">

                                        <ItemTemplate>

                                            <asp:Label ID="lblApproverId" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Name") %>'></asp:Label>

                                        </ItemTemplate>

                                        <EditItemTemplate>

                                            <asp:DropDownList ID="txtEditApproverId" runat="server"></asp:DropDownList>

                                        </EditItemTemplate>

                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Project">
                                        <ItemTemplate>
                                            <asp:Label ID="Id" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Id") %>'></asp:Label>
                                            <asp:Label ID="lblProjectCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ProjectType") %>'></asp:Label>

                                        </ItemTemplate>

                                        <EditItemTemplate>
                                            <%--<asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Bind("Id") %>' />--%>
                                            <asp:DropDownList ID="Project" runat="server"></asp:DropDownList>
                                        </EditItemTemplate>

                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Comment">

                                        <ItemTemplate>

                                            <asp:Label ID="lblApproverComment" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ApproverComment") %>'></asp:Label>

                                        </ItemTemplate>

                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtEditApproverComment" Text='<%#DataBinder.Eval(Container.DataItem, "ApproverComment") %>' TextMode="multiline" Columns="20" Rows="2" runat="server" />
                                        </EditItemTemplate>

                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="Action">

                                        <ItemTemplate>

                                            <asp:ImageButton ID="imgbtnEdit" runat="server" CommandName="Edit" ImageUrl="~/Content/Images/edit.png" Height="32px" Width="32px" />

                                            <asp:ImageButton ID="imgbtnDelete" runat="server" CommandName="Delete" ImageUrl="~/Content/Images/delete.png" Height="32px" Width="32px" OnClientClick="return confirm('Are you sure you want to delete this Expense?');" />

                                        </ItemTemplate>

                                        <EditItemTemplate>

                                            <asp:ImageButton ID="imgbtnUpdate" runat="server" CommandName="Update" ImageUrl="~/Content/Images/update.png" Height="32px" Width="32px" />

                                            <asp:ImageButton ID="imgbtnCancel" runat="server" CommandName="Cancel" ImageUrl="~/Content/Images/cancel.png" Height="32px" Width="32px" />
                                        </EditItemTemplate>

                                    </asp:TemplateField>

                                </Columns>
                                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                <SortedAscendingCellStyle BackColor="#FDF5AC" />
                                <SortedAscendingHeaderStyle BackColor="#4D0000" />
                                <SortedDescendingCellStyle BackColor="#FCF6C0" />
                                <SortedDescendingHeaderStyle BackColor="#820000" />
                            </asp:GridView>

                        </td>
                    </tr>

                </table>

            </div>

        </div>
    </body>
    </html>

</asp:Content>


