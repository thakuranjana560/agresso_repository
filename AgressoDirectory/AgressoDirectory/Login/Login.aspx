<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AgressoDirectory.Login.Login" %>
    <!DOCTYPE html>

    <html>
<head runat="server">
    <title>Login</title>
     <link rel="stylesheet" type="text/css" href="../Content/Stylesheet/LoginStyleSheet.css" />
</head>
<body style="height: 287px">
    <link rel="stylesheet" type="text/css" href="Styles/Login.css" />
    <form id="form1" class="center" runat="server">
    
            <div class="header">
                 <img id="imgLogo" class="logo" src="~/Content/Images/logo.png" alt="EVRY" runat="server"/>
            </div>
            <div class="expenselogin">
                <div class="displaytxt">
            <div>
                <asp:Label ID="lblUserName" Text="Username" runat="server" />
                <asp:TextBox ID="txtUsername" runat="server" />
                </div>
            <div>
                <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUsername" ValidationGroup="login" ErrorMessage="Username Required" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revUsername" runat="server" ControlToValidate="txtUsername" ValidationGroup="login"
    ErrorMessage="Spaces are not allowed in Username" ForeColor="Red" ValidationExpression="[^\s]+" />
            </div>
            <div>
                <asp:Label ID="lblPassword" Text="Password" runat="server" />
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" />
             </div>
            <div>
                <asp:RequiredFieldValidator ID="rfvPassword" ControlToValidate="txtPassword" ValidationGroup="login" runat="server" ErrorMessage="Password Required" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="rev" runat="server" ControlToValidate="txtPassword" ValidationGroup="login"
    ErrorMessage="Spaces are not allowed in Password" ValidationExpression="[^\s]+" ForeColor="Red" />
            </div>
                
            <div>
                <asp:Label ID="lblIncorrectUserCredentials" runat="server" ForeColor="Red" Text="Incorrect User Credentials"></asp:Label>
            </div>
                    </div>
            <br />
                 <div class="displaybtn">
            <div>
                <asp:Button ID="btnLogin" Text="Login" ValidationGroup="login" runat="server" OnClick="btnLogin_Click" />
            </div>
                     <br />
            <div>
                <asp:LinkButton ID="lkbtnForgetPassword" runat="server" Text="Forget Password?" PostBackUrl="~/Login/ResetPassword.aspx"></asp:LinkButton>
            </div>
                </div>
            </div>
    </form>
</body>
</html>