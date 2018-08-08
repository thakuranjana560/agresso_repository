<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/AgressoEmployee.Master" CodeBehind="ListEmployee.aspx.cs" Inherits="AgressoDirectory.Employee.ListEmployee" %>

<asp:Content ID="cnontentListEmployee" ContentPlaceHolderID="cphBody" runat="server">
<!DOCTYPE html>

<html>
<head>
    <title>ListEmployee</title>
    <link rel="stylesheet" type="text/css" href="../Content/Stylesheet/ListEmployeeStyleSheet.css" />
</head>
<body>
      <hr class="hr-red">
		           <div id="section">
  			  <ul>
                    <%if (Session["dsgcode"] != null && Convert.ToString(Session["dsgcode"]) == "L9")
                        {%><li><a href="../Employee/AddEmployee.aspx">AddEmployee</a>
                         </li><%}%>
			    <li><a href="../Expenses/ExpenseDetail.aspx">ListExpenses</a>
			    </li>
                    <%if (Session["dsgcode"] != null && Convert.ToString(Session["dsgcode"]) != "L9")
                   {%><li><a href="../Expenses/ExpenseAdd.aspx">AddExpeses</a>
                    </li><%}%>
			   <%-- <li><a href="../Login/Login.aspx">LogOut</a>
			    </li>--%>
 			 </ul>
		</div>
    <%--<form id="form1" runat="server">--%>
<%--        <div>
            <asp:Button ID="btnLogout" Text="Logout" runat="server" OnClick="btnLogout_Click" />
        </div>--%>
        <div class="scroll">
            <asp:GridView ID="grdListEmployee" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnRowCancelingEdit="GrdListEmployee_RowCancelingEdit" OnRowEditing="GrdListEmployee_RowEditing" Width="1291px" OnRowUpdating="GrdListEmployee_RowUpdating">
                <Columns>
                    <asp:TemplateField HeaderText="ID">
                        <ItemTemplate>
                          <asp:Label ID="lblId" runat="server" Text='<%#Eval("ID")%>' Visible="false" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="lblEditId" runat="server" Text='<%#Eval("ID") %>' Visible="false" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="First Name">
                        <ItemTemplate>
                            <%#Eval("FirstName")%>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEditFirstName" runat="server" Text='<%#Eval("FirstName")%>' MaxLength="150" Height="16px" Width="135px"/>
                            <asp:RequiredFieldValidator ID="rfvFirstName" ControlToValidate="txtEditFirstName" ValidationGroup="update" runat="server" ErrorMessage="Required first name" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revEditFirstName" runat="server"
                            ControlToValidate="txtEditFirstName"
                            ErrorMessage="      only charachters are allowed." ValidationGroup="update" ForeColor="Red"
                            ValidationExpression="^[A-Za-z]*$">
                           </asp:RegularExpressionValidator>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Last Name">
                        <ItemTemplate>
                            <%#Eval("LastName")%>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEditLastName" runat="server" Text='<%#Eval("LastName")%>' MaxLength="100"/>
                            <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ErrorMessage="Required last name" ControlToValidate="txtEditLastName" ValidationGroup="update" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revEditLastName" runat="server"
                             ControlToValidate="txtEditLastName"
                             ErrorMessage="only charachters are allowed." ValidationGroup="update" ForeColor="Red"
                             ValidationExpression="^[A-Za-z]*$">
                            </asp:RegularExpressionValidator>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Date Of Birth">
                        <ItemTemplate>
                            <%#String.Format("{0:dd/MM/yyyy}",Eval("DateOfBirth"))%>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEditDateOfBirth" runat="server"  Text='<%#String.Format("{0:dd/MM/yyyy}",Eval("DateOfBirth"))%>' />
                            <asp:RequiredFieldValidator ID="rfvEditDateOfBirth" runat="server" ControlToValidate="txtEditDateOfBirth" ValidationGroup="update" ForeColor="Red" ErrorMessage="Date of birth required."></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revEditDateOfBirth" runat="server" ValidationGroup="update" ForeColor="Red"
                             ControlToValidate="txtEditDateOfBirth" ErrorMessage="Enter correct date format in DD/MM/YYYY"
                             ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$"></asp:RegularExpressionValidator>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Emp Designation Code">
                        <ItemTemplate>
                            <%#Eval("EmpDesignationCode") %>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="drpEditDesignationCode" runat="server">
                                 <asp:ListItem Value="L14">Software Trainee Engineer</asp:ListItem>
                 <asp:ListItem Value="L13">Software Associate Engineer</asp:ListItem>
                 <asp:ListItem Value="L12">software engineer</asp:ListItem>
                 <asp:ListItem Value="L11">Senior Software engineer</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvDesignationCode" ControlToValidate="drpEditDesignationCode" ValidationGroup="update" ForeColor="Red" runat="server" ErrorMessage="please select any one"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Gender">
                        <ItemTemplate>
                            <%#Eval("Gender")%>
                        </ItemTemplate>
                        <EditItemTemplate>
                              <asp:RadioButtonList ID="radEditGender" RepeatDirection="Horizontal" runat="server">
                                 <asp:ListItem Value="Male">Male</asp:ListItem>
                                 <asp:ListItem Value="Female">Female</asp:ListItem>
                                  <asp:ListItem Value="Other">Other</asp:ListItem>
                             </asp:RadioButtonList>
                            <%--<asp:TextBox ID="txtEditGender" runat="server" Text='<%#Eval("Gender") %>' MaxLength="10" />--%>
                            <asp:RequiredFieldValidator ID="rfvGender" runat="server" ControlToValidate="radEditGender" ValidationGroup="update" ForeColor="Red" ErrorMessage="Please select gender"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Address">
                        <ItemTemplate>
                            <%#Eval("Address")%>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEditAddress" runat="server" Text='<%#Eval("Address")%>'/>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Emp Country Code">
                        <ItemTemplate>
                            <%#Eval("EmpCountryCode")%>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="drpEditCountryCode" runat="server">
                              <asp:ListItem Value="1">India</asp:ListItem>
                              <asp:ListItem Value="2">Norway</asp:ListItem>
                            </asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Emp State Code">
                        <ItemTemplate>
                            <%#Eval("EmpStateCode")%>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="drpEditStateCode" runat="server">
                 <asp:ListItem Value="11">Himachal</asp:ListItem>
                 <asp:ListItem Value="12">Punjab</asp:ListItem>
                 <asp:ListItem Value="21">Oslo</asp:ListItem>
                 <asp:ListItem Value="22">Rogaland</asp:ListItem>
                 <asp:ListItem Value="31">Boston</asp:ListItem>
                 <asp:ListItem Value="32">LA</asp:ListItem>
                            </asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Emp City Code">
                        <ItemTemplate>
                            <%#Eval("EmpCityCode")%>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="drpEditCityCode" runat="server">
                                    <asp:ListItem Value="111">Manali</asp:ListItem>
                 <asp:ListItem Value="112">Kangra</asp:ListItem>
                 <asp:ListItem Value="121">Chandigarh</asp:ListItem>
                 <asp:ListItem Value="122">Mohali</asp:ListItem>
                 <asp:ListItem Value="211">bergan</asp:ListItem>
                 <asp:ListItem Value="212">tonsperg</asp:ListItem>
                 <asp:ListItem Value="221`">Sola</asp:ListItem>
                 <asp:ListItem Value="222">jorepeland</asp:ListItem>
                 <asp:ListItem Value="311">brookline</asp:ListItem>
                 <asp:ListItem Value="312">braintree</asp:ListItem>
                 <asp:ListItem Value="321">WestHollywood</asp:ListItem>
                 <asp:ListItem Value="322">longbeach</asp:ListItem>
                            </asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>
 <%--                   <asp:TemplateField HeaderText="Added Date">
                        <ItemTemplate>
                           <%#Eval("AddedDate")%>
                        </ItemTemplate>
                    </asp:templatefield>--%>
 <%--                   <asp:templatefield headertext="modified date">
                        <itemtemplate>
                            <%#Eval("modifieddate")%>
                        </itemtemplate>
                    </asp:templatefield>--%>
                    <asp:TemplateField HeaderText="Email ID">
                        <ItemTemplate>
                            <%#Eval("EmailID")%>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEditEmail" runat="server" Text='<%#Eval("EmailID")%>' MaxLength="50"/>
                            <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEditEmail" ValidationGroup="update" ErrorMessage="Enter valid email id" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ></asp:RegularExpressionValidator>
                        </EditItemTemplate>
                        
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Contact Number">
                        <ItemTemplate>
                            <%#Eval("MobileNumber")%>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEditMobileNumber" runat="server" Text='<%#Eval("MobileNumber") %>' MaxLength="10"/>
                            <asp:RegularExpressionValidator ID="revMobileNumber" runat="server"
     ControlToValidate="txtEditMobileNumber" ValidationGroup="update"
     ErrorMessage="Only numeric allowed." ForeColor="Red"
     ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                           <%-- <asp:CompareValidator ID="cmpvMobileNumber" runat="server" ErrorMessage="only numbers are allowed" ControlToValidate="txtEditMobileNumber" ValidationGroup="update" ForeColor="Red" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>--%>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Skills">
                        <ItemTemplate>
                            <%#Eval("Skills")%>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEditSkills" runat="server" Text='<%#Eval("Skills")%>' />
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Experience">
                        <ItemTemplate>
                            <%#Eval("TotalExperience") %> 
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEditExperience" runat="server" Text='<%#Eval("TotalExperience")%>' MaxLength="2"/>
                            <asp:RegularExpressionValidator ID="revExperience" runat="server"
     ControlToValidate="txtEditExperience" ValidationGroup="update"
     ErrorMessage="Only numeric allowed." ForeColor="Red"
     ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                            <%--<asp:CompareValidator ID="cmpv" runat="server" ControlToValidate="txtEditExperience" ValidationGroup="update" ErrorMessage="only numbers are allowed" Operator="DataTypeCheck" Type="Integer" ForeColor="Red"></asp:CompareValidator>--%>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Project">
                        <ItemTemplate>
                            <%#Eval("ProjectName")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Is Active">
                        <ItemTemplate>
                            <%#Eval("IsActive")%>
                        </ItemTemplate>
                         <EditItemTemplate>
                            <%-- <asp:TextBox ID="txtEditIsActive" runat="server" Text='<%#Eval("IsActive")%>' />--%>
                             <asp:RadioButtonList ID="radEditIsActive" RepeatDirection="Horizontal" runat="server">
                                 <asp:ListItem Value="1">Yes</asp:ListItem>
                                 <asp:ListItem Value="0">No</asp:ListItem>
                             </asp:RadioButtonList>
<%--                         <asp:CheckBox ID="chkIsActive" runat="server" Checked='<%#Eval("IsActive") %>' />--%>
                             <asp:RequiredFieldValidator ID="rfvIsActive" runat="server" ControlToValidate="radEditIsActive" ValidationGroup="update" ForeColor="Red" ErrorMessage="please select"></asp:RequiredFieldValidator>
                         </EditItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:TemplateField>
                       <ItemTemplate>
                           <asp:Image ID="img" runat="server" />
                       </ItemTemplate>
                    </asp:TemplateField>--%>
                     <asp:TemplateField>
                        <ItemTemplate>
                            <%if (Session["dsgcode"] != null && Convert.ToString(Session["dsgcode"]) == "L9")
                                {%>
                            <asp:Button ID="lkbtnEdit" CommandName="edit" Text="  edit  " runat="server" />
                            <%}%>
                           <%--<asp:Button ID="btnEdit" CommandName="EditButton" Text="Update" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" runat="server" />--%>
                        </ItemTemplate>
                         <EditItemTemplate>
                             <asp:Button ID="lkbtnUpdate" ValidationGroup="update" CausesValidation="true" CommandName="update" Text="update" runat="server" />
                             <asp:Button ID="lkbtnCancel" CommandName="cancel" Text="cancel" runat="server" />
                         </EditItemTemplate>
                         </asp:TemplateField>
                  <%--  <asp:TemplateField>
                         <ItemTemplate>
                             <asp:Button ID="lkbtnDelete" CommandName="delete" Text="Deativate User" runat="server" />
                         </ItemTemplate>
                        </asp:TemplateField>--%>
                    
                </Columns>
                <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                <RowStyle BackColor="White" ForeColor="#330099" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                <SortedAscendingCellStyle BackColor="#FEFCEB" />
                <SortedAscendingHeaderStyle BackColor="#AF0101" />
                <SortedDescendingCellStyle BackColor="#F6F0C0" />
                <SortedDescendingHeaderStyle BackColor="#7E0000" />
            </asp:GridView>
        </div>
   <%-- </form>--%>
</body>
</html>
    </asp:Content>