<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Register</h1>
        <!-- I am just doing a basic form here. You should always add validation and a password check-->
        <table>
            <tr>
                <td>Last Name</td>
                <td>
                    <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox></td>
            </tr>
               <tr>
                <td>First Name</td>
                <td>
                    <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox></td>
            </tr>
               <tr>
                <td>Email</td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
            </tr>
               <tr>
                <td>Password</td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox></td>
            </tr>
               <tr>
                <td>Vehicle License Plate</td>
                <td>
                    <asp:TextBox ID="txtLicense" runat="server"></asp:TextBox></td>
            </tr>
               <tr>
                <td>Vehicle Make</td>
                <td>
                    <asp:TextBox ID="txtMake" runat="server"></asp:TextBox></td>
            </tr>
               <tr>
                <td>Vehicle Year (4 digits)</td>
                <td>
                    <asp:TextBox ID="txtYear" runat="server"></asp:TextBox></td>
            </tr>
               <tr>
                <td>
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" /></td>
                <td>
                    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                   </td>
            </tr>
        </table>
    <p>
        <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
        <asp:LinkButton ID="LinkButton1" runat="server">Log in</asp:LinkButton>
    </p>
        
    </div>
    </form>
</body>
</html>
