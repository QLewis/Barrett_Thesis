<%@ Page Title="Dining Hall" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Register_Web_App._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h2>Dining Hall Web Application</h2>
        <p class="lead">This is going to be a cash register for my honors thesis
        </p>
        
    </div>
    <div class="form-group">
         <asp:Label runat="server" CssClass="col-md-2 control-label">Username</asp:Label>
         <div class="col-md-10">
              <asp:TextBox runat="server" ID="UserName" CssClass="form-control" />
              <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName" CssClass="text-danger" ErrorMessage="The username field is required." />
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
               <div class="radiobutton">
                    <asp:RadioButtonList ID="staffOrStudentList" runat="server">
                        <asp:ListItem>Staff</asp:ListItem>
                        <asp:ListItem>Student</asp:ListItem>
                    </asp:RadioButtonList>
                   <asp:Label ID="testLabel" runat="server">Test XML</asp:Label>
               </div>
         </div>
    </div>
    <div class="form-group">
         <div class="col-md-offset-2 col-md-10">
              <asp:Button ID="logInButton" runat="server" Text="Log in" CssClass="btn btn-default" OnClick="logInButton_Click" />
         </div>
    </div>

   
    

</asp:Content>
