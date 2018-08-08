<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile= "~/AgressoEmployee.Master" CodeBehind="Profile.aspx.cs" Inherits="AgressoDirectory.Expenses.Profile" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="cphbody" runat="server">
     <hr class="hr-red">
		           <div id="section">
  			  <ul>
                 <li><a href="../Employee/ListEmployee.aspx">ListEmployee</a></li>
			   
			   <%-- <li><a href="../Login/Login.aspx">LogOut</a>
			    </li>--%>
 			 </ul>
		</div>
       <%-- <form id="form1" runat="server">--%>
    <div id="dvProfile" runat="server">
            <link href="../Content/Stylesheet/Style.css" rel="stylesheet" />
            <table class="expenseAdd">
                <%--first row--%>
                <tr>
                    <td>
                        <asp:Label ID="lblFirstName" runat="server" Text="FirstName"></asp:Label>
                    </td>
                    <td>
                     <asp:TextBox ID="txtFirstName" runat="server" Width="204px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter First Name" ControlToValidate="txtFirstName" ForeColor="Red"></asp:RequiredFieldValidator>
                  
                       <asp:RegularExpressionValidator ID="revName" runat="server"
            ControlToValidate="txtFirstName"
            ErrorMessage="Only charachters are allowed." ForeColor="Red"
            ValidationExpression="^[A-Za-z\s]*$">
            </asp:RegularExpressionValidator>

                        </td>
                    <td>
                        <asp:Label ID="lblLastName" runat="server" Text=" LastName"></asp:Label>                   
                    </td>
                    <td>
                       <asp:TextBox ID="txtLastName" runat="server" Width="204px"></asp:TextBox>
                      
                        
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Enter Last Name" ControlToValidate="txtLastName" ForeColor="Red"></asp:RequiredFieldValidator>
                 
               <asp:RegularExpressionValidator ID="revLastName" runat="server"
             ControlToValidate="txtLastName"
             ErrorMessage="Only charachters are allowed." ForeColor="Red"
             ValidationExpression="^[A-Za-z\s]*$">
        </asp:RegularExpressionValidator>

                    </td>
               </tr>
        
                <%-- 2nd row--%>
                <tr>
                    <td>
                        <asp:Label ID="lblDesignation" runat="server" Text="Designation"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlDesignation" runat="server"  Width="213px">
                        </asp:DropDownList>   
                   </td>
                 
               </tr>
               <%-- 3rd row--%>
                <tr>
                     <td>
                        <asp:Label ID="lblEmailId" runat="server" Text=" EmailId"></asp:Label>                   
                    </td>
                    <td>
                       <asp:TextBox ID="txtEmailId" runat="server" Width="204px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please Enter Email ID" ControlToValidate="txtEmailId" ForeColor="Red"></asp:RequiredFieldValidator>
                     <asp:RegularExpressionValidator ID="revEmailID" runat="server" ControlToValidate="txtEmailId" ValidationGroup="update" ErrorMessage="Enter Valid Email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </td>
               </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="UpdateButton"   />
                         <asp:Label ID="lblUpdate" runat="server" ForeColor="Red" Text="Successfully Updated" Visible="false"></asp:Label>
                    </td>
                </tr>           
            </table>    
             <p id="DataText" runat="server"></p>
        </div>

    </asp:Content>


