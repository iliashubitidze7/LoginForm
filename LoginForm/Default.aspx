<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LoginForm.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="FirstNamebtn" runat="server" Text="FirstName"></asp:Label>&nbsp
            <asp:TextBox ID="FirstNameTextbox" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="LastNamebtn" runat="server" Text="LastName"></asp:Label>&nbsp
            <asp:TextBox ID="LastNameTextBox" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="LoginBtn" runat="server" Text="Log in" OnClick="LoginBtn_Click" />
        </div>
    </form>
</body>
</html>
