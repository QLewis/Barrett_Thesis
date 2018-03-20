<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Register_Web_App.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="MealLabel" runat="server" Text="Meal"></asp:Label>
        <asp:Label ID="TimeLabel" runat="server" Text="TimeStamp"></asp:Label>
        <br>
        <asp:ListView ID="ListView1" runat="server"></asp:ListView>
        <p>Student: <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Label ID="Label1" runat="server" Text="">GuestPasses</asp:Label>
            <br>
            <asp:Button ID="Button1" runat="server" Text="Button" />
            <asp:Button ID="Button2" runat="server" Text="Button" />
            <asp:Button ID="Button3" runat="server" Text="Button" />
            <br>
            <asp:Button ID="Button4" runat="server" Text="Button" />
            <asp:Button ID="Button5" runat="server" Text="Button" />
            <asp:Button ID="Button6" runat="server" Text="Button" />
            <br>
            <asp:Button ID="Button7" runat="server" Text="Button" />
            <asp:Button ID="Button8" runat="server" Text="Button" />
            <asp:Button ID="Button9" runat="server" Text="Button" />
        </p>
    </div>

    </form>
</body>
</html>
