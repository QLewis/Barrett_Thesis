<%@ Page Title="Dining Hall" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Register_Web_App._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h2>Dining Hall Web Application</h2>
        <p class="lead">This is going to be a cash register for my honors thesis
        </p>
        
    </div>
    <div class="form-group">
         <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
         <div class="col-md-10">
              <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
              <asp:RequiredFieldValidator runat="server" ControlToValidate="Email" CssClass="text-danger" ErrorMessage="The email field is required." />
         </div>
    </div>
    <div class="form-group">
          <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Password</asp:Label>
          <div class="col-md-10">
               <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="The password field is required." />
          </div>
    </div>
    <div class="form-group">
         <div class="col-md-offset-2 col-md-10">
               <!--CHANGED-->
               <div class="radiobutton">
                    <asp:RadioButton ID="StaffRadio" runat="server" Text="Staff"/>
                    <asp:RadioButton ID="StudentRadio" runat="server" Text="Student"/>
               </div>
         </div>
    </div>
    <div class="form-group">
         <div class="col-md-offset-2 col-md-10">
              <asp:Button runat="server" Text="Log in" CssClass="btn btn-default" />
         </div>
    </div>

   
    

</asp:Content>
