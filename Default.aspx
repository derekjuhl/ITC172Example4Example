<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>Login</h1>
        <table>
            <tr>
                <td>User Name</td>
                <td>
                    <asp:TextBox ID="txtUser" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Password</td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Button ID="btnLogin" runat="server" Text="Log in" OnClick="btnLogin_Click"/></td>
                <td>
                    <asp:Label ID="lblError" runat="server" Text=""></asp:Label> </td>
            </tr>
           
        </table>
        <p>
            <asp:LinkButton ID="lbRegister" runat="server">Register</asp:LinkButton></p>
    </div>
    </form>
</body>
</html>
