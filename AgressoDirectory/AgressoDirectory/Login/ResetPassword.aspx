<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="AgressoDirectory.Login.ResetPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <asp:Label ID="lblEmail" Text="Enter Email Address" runat="server"></asp:Label>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </div>
            <br />
            <div>
                <asp:LinkButton ID="btnLoginPage" runat="server" Text="Back to login page" PostBackUrl="~/Login/Login.aspx"></asp:LinkButton>
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="BtnSubmit_Click" />
             </div>
        </div>
    </form>
</body>
</html>
