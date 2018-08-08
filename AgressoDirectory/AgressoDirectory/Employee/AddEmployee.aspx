<%@ Page Language="C#" ClientIDMode="Static" AutoEventWireup="true" MasterPageFile="~/AgressoEmployee.Master" CodeBehind="AddEmployee.aspx.cs" Inherits="AgressoDirectory.Employee.AddEmployee" %>

<asp:Content ID="contentAddEmployee" ContentPlaceHolderID="cphBody" runat="server">
    <%--<head runat="server">
    <title>AddEmployee</title>
</head>--%>
 <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html>
<%--        <div>
             <asp:Label ID="lblIsActive" runat="server" Text="IsActive"></asp:Label>
               <asp:RadioButtonList ID="radIsActive" RepeatDirection="Horizontal" runat="Server">
                 <asp:ListItem Text="Yes" Value="1"></asp:ListItem> 
                 <asp:ListItem Text="No" Value="0"></asp:ListItem> 
                    </asp:RadioButtonList>
        </div>--%>
  <head>
      <title>Add</title>
  <link rel="stylesheet" type="text/css" href="../Content/Stylesheet/AddEmployeeStyleSheet.css" />
  </head>  
<body>
     <hr class="hr-red">
		           <div id="section">
  			  <ul>
			    <li><a href="../Employee/ListEmployee.aspx">ListEmployee</a>
			    </li>
 			 </ul>
		</div>
    <div>
        <asp:Label ID="lblauth" runat="server" Text="You are not an authorised user"></asp:Label>
    </div>
    
    <div id="dvForm" class="center" runat="server" visible="false">
<div>
    
    <div>
        <asp:HiddenField ID="hfId" runat="server" />
        <asp:Label ID="lblmessage" runat="server" Text="Employee Created" ForeColor="Blue" Font-Bold="true" Visible="false"></asp:Label>
    </div>
    <br />
        <div>
            <asp:Label ID="lblFirstName" runat="server" Text="First Name"></asp:Label>
            <asp:TextBox ID="txtFirstName" runat="server" MaxLength="150" ></asp:TextBox>
            <asp:RegularExpressionValidator ID="revFirstName" runat="server"
            ControlToValidate="txtFirstName"
            ErrorMessage="Only charachters are allowed." ValidationGroup="submit" ForeColor="Red"
            ValidationExpression="^[A-Za-z\s]*$">
            </asp:RegularExpressionValidator>
            <asp:Label ID="lblLastName" runat="server" Text="Last Name"></asp:Label>
            <asp:TextBox ID="txtLastName" runat="server" MaxLength="100"></asp:TextBox>
        <asp:RegularExpressionValidator ID="revLastName" runat="server"
             ControlToValidate="txtLastName"
             ErrorMessage="Only charachters are allowed." ValidationGroup="submit" ForeColor="Red"
             ValidationExpression="^[A-Za-z\s]*$">
        </asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ValidationGroup="submit" ControlToValidate="txtLastName" ErrorMessage="Last name required" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ValidationGroup="submit" ControlToValidate="txtFirstName" ErrorMessage="Enter First Name" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <br />
        <div>
        </div>
        <br />
        <div>
             <asp:Label ID="lblGender" runat="server" Text="Gender"></asp:Label>
             <asp:RadioButtonList ID="radGender" RepeatDirection="Horizontal" runat="Server">
                 <asp:ListItem Text="Male" Value="Male"></asp:ListItem> 
                 <asp:ListItem Text="Female" Value="Female"></asp:ListItem> 
                 <asp:ListItem Text="Other" Value="Other"></asp:ListItem>
                    </asp:RadioButtonList>
             <asp:RequiredFieldValidator ID="rfvGender" runat="server" ValidationGroup="submit" ControlToValidate="radGender" ErrorMessage="Please Select Gender" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <br />
        <div>
             <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
             <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
             <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ValidationGroup="submit" ControlToValidate="txtAddress" ErrorMessage="Address Field Required" ForeColor="Red"></asp:RequiredFieldValidator>
             <asp:Label ID="lblDesignationCode" runat="server" Text="Designation"></asp:Label>
                    <asp:DropDownList ID="drpDesignationCode" runat="server">
                 <asp:ListItem Value="L14">Software Trainee Engineer</asp:ListItem>
                 <asp:ListItem Value="L13">Software Associate Engineer</asp:ListItem>
                 <asp:ListItem Value="L12">software engineer</asp:ListItem>
                 <asp:ListItem Value="L11">Senior Software engineer</asp:ListItem>
             </asp:DropDownList>
        </div>
        <br />
        <div>
        </div>
        <br />
        <div>
             <asp:Label ID="lblSkills" runat="server" Text="Skills"></asp:Label>
             <asp:TextBox ID="txtSkills" runat="server"></asp:TextBox>
             <asp:RequiredFieldValidator ID="rfvSkills" runat="server" ControlToValidate="txtSkills" ValidationGroup="submit" ErrorMessage="Skills Required" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <br />
        <div>
             <asp:Label ID="lblDateOfBirth" runat="server" Text="Date Of Birth"></asp:Label> 
            <asp:TextBox ID="txtDateOfBirth" runat="server"></asp:TextBox>
            
             <asp:Button ID="btnDateOfBirth" runat="server" Text="Select" OnClick="BtnDateOfBirth_Click"  CausesValidation="false"/>
             <asp:Calendar ID="calDateOfBirth" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px" OnSelectionChanged="CalDateOfBirth_SelectionChanged" Visible="False">
                 <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                 <NextPrevStyle VerticalAlign="Bottom" />
                 <OtherMonthDayStyle ForeColor="#808080" />
                 <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                 <SelectorStyle BackColor="#CCCCCC" />
                 <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                 <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                 <WeekendDayStyle BackColor="#FFFFCC" />
             </asp:Calendar>
            
             <asp:RequiredFieldValidator ID="rfvDateOfBirth" runat="server" ValidationGroup="submit" ControlToValidate="txtDateOfBirth" ErrorMessage="Please select date" ForeColor="Red"></asp:RequiredFieldValidator>
            
            <asp:RegularExpressionValidator ID="revDateOfBirth" runat="server" ValidationGroup="submit" ForeColor="Red"
ControlToValidate="txtDateOfBirth" ErrorMessage="Enter correct date format in DD/MM/YYYY"
ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$"></asp:RegularExpressionValidator>

        </div>
        <br />
        <div>
             <asp:Label ID="lblExperience" runat="server" Text="Experience"></asp:Label>
          <asp:DropDownList ID="drpExperience" runat="server" >
              <asp:ListItem Value="2">One year</asp:ListItem>
              <asp:ListItem Value="1">Two years</asp:ListItem>
              <asp:ListItem Value="4">Three years</asp:ListItem>
              <asp:ListItem Value="3">Four years</asp:ListItem>
              <asp:ListItem Value="6">Five Years</asp:ListItem>
              <asp:ListItem Value="5">Six Years</asp:ListItem>
          </asp:DropDownList>
        </div>
        <br />
        <div>
             <asp:Label ID="lblCountryCode" runat="server" Text="Country Code"></asp:Label>
             <asp:DropDownList ID="drpCountryCode" runat="server">
                 <asp:ListItem Value="1">India</asp:ListItem>
                 <asp:ListItem Value="2">Norway</asp:ListItem>
                 <asp:ListItem>U.S.A</asp:ListItem>
             </asp:DropDownList>
        </div>
        <br />
        <div>
             <asp:Label ID="lblStateCode" runat="server" Text="State Code"></asp:Label>
             <asp:DropDownList ID="drpStateCode" runat="server">
                 <asp:ListItem Value="11">Himachal</asp:ListItem>
                 <asp:ListItem Value="12">Punjab</asp:ListItem>
                 <asp:ListItem Value="21">Oslo</asp:ListItem>
                 <asp:ListItem Value="22">Rogaland</asp:ListItem>
                 <asp:ListItem Value="31">Boston</asp:ListItem>
                 <asp:ListItem Value="32">LA</asp:ListItem>
             </asp:DropDownList>
        </div>
        <br />
        <div>
             <asp:Label ID="lblCityCode" runat="server" Text="City Code"></asp:Label>
             <asp:DropDownList ID="drpCityCode" runat="server">
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
        </div>

<%--<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtContactNumber" ErrorMessage="Enter numbers only" ForeColor="Red" Operator="DataTypeCheck" Type="integer"></asp:CompareValidator>--%>
        <br />
       <div>
             <asp:Label ID="lblEmailID" runat="server" Text="Email ID"></asp:Label>
             <asp:TextBox ID="txtEmailID" runat="server" MaxLength="50"></asp:TextBox>
             <asp:RequiredFieldValidator ID="rfvEmailID" runat="server" ControlToValidate="txtEmailID" ErrorMessage="Email Required" ValidationGroup="submit" ForeColor="Red"></asp:RequiredFieldValidator>
             <asp:RegularExpressionValidator ID="revEmailID" runat="server" ControlToValidate="txtEmailID" ValidationGroup="submit" ErrorMessage="Enter Valid Email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        </div>
        <br />
        <div>
             <asp:Label ID="lblContactNumber" runat="server" Text="Contact Number"></asp:Label>
             <asp:TextBox ID="txtContactNumber" runat="server" MaxLength="10"></asp:TextBox>
             <asp:RequiredFieldValidator ID="rfvContactNumber" runat="server" ValidationGroup="submit" ControlToValidate="txtContactNumber" ErrorMessage="Please enter the contact nymber" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revContactNumber" runat="server"
     ControlToValidate="txtContactNumber"
     ErrorMessage="Only numeric allowed." ValidationGroup="submit" ForeColor="Red"
     ValidationExpression="^[0-9]*$">
</asp:RegularExpressionValidator>
             <%-- <asp:LinkButton ID="lkbtnListEmployee" PostBackUrl="~/ListEmployee.aspx" runat="server" Text="List Employees" />--%>
        </div>
        <br />
    <div>
        <asp:Label ID="lblProject" runat="server" Text="Project Name"></asp:Label>
        <asp:DropDownList ID="drpProject" runat="server"></asp:DropDownList>
        <asp:RequiredFieldValidator ID="rfvProject" runat="server" ValidationGroup="submit" ControlToValidate="drpProject" ErrorMessage="Please select project" ForeColor="Red"></asp:RequiredFieldValidator>
    </div>
    <br />
        <div>
            <asp:Button ID="btnSubmit" runat="server" ValidationGroup="submit" Text="Submit" OnClick="Btnsubmit_Click" />
        </div>
         <br />
        <div>
        <%--    <asp:HyperLink ID="hlbtnListEmployee" NavigateUrl="../Employee/ListEmployee.aspx" runat="server" Text="List Employees" />
            <%-- <asp:Button ID="btnRedirectList" runat="server" Text="View List Of Employees" OnClick="BtnRedirectList_Click" />--%>           <%-- <asp:Button ID="btnRedirectList" runat="server" Text="View List Of Employees" OnClick="BtnRedirectList_Click" />--%>
         <%--   <asp:Button ID="btnLogOut" runat="server" OnClick="btnLogOut_Click" Text="LogOut" />--%>
        </div>
    <div>
        <asp:Button ID="btnUpd" runat="server" Text="update" Visible="false" OnClick="btnUpd_Click" /> <%---only for task completion working functionality---!>--%> 
    </div>
</div>
    </div>
</body>
</html>
    </asp:Content>
