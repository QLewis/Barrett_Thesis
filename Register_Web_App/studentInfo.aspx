<%@ Page Title="Student Info" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="studentInfo.aspx.cs" Inherits="Register_Web_App.Contact" %>

<%@ PreviousPageType VirtualPath="~/Default.aspx" %> 

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <h3>Hello <asp:Label ID="nameLabel" runat="server"></asp:Label>, you have:</h3>
    <h4><asp:Label ID="mealsLabel" runat="server"></asp:Label> meals left</h4>
    <h4><asp:Label ID="mgLabel" runat="server"></asp:Label> M&G remaining</h4>
    <h4><asp:Label ID="guestLabel" runat="server"></asp:Label> guest passes remaining</h4>

</asp:Content>
