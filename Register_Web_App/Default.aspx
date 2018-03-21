<%@ Page Title="Dining Hall" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Register_Web_App._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h2>Dining Hall Web Application</h2>
        <p class="lead">This is going to be a cash register for my honors thesis
        </p>
        
    </div>
    <div>
        <asp:Label ID="Label1" runat="server" Text="Log In"></asp:Label>
        <br>
        <asp:RadioButton ID="Students" runat="server" Text="Student"/>
        <asp:RadioButton ID="Staff" runat="server" Text="Staff"/>
        <br>
        <asp:Label ID="Label2" runat="server" Text="Username:"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

        <br>
        <asp:Label ID="Label3" runat="server" Text="Password:"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    </div>

   
    

</asp:Content>
