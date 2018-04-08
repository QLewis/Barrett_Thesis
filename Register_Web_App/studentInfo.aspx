<%@ Page Title="Student Info" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="studentInfo.aspx.cs" Inherits="Register_Web_App.Contact" %>

<%@ PreviousPageType VirtualPath="~/Default.aspx" %> 

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3><asp:Label ID="infoLabel" runat="server"></asp:Label></h3>

</asp:Content>
