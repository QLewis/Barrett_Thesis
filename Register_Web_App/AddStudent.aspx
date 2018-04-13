<%@ Page Title="Add a Student" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddStudent.aspx.cs" Inherits="Register_Web_App.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Add a student's information</h4>
        <hr />

        <!-- Input the ID -->
        <div class="form-group">
            <asp:Label ID="idLabel" runat="server" CssClass="col-md-2 control-label"><strong>ID</strong></asp:Label>
            <div class="col-md-10">
              <asp:TextBox runat="server" ID="UserName" CssClass="form-control" />
              <asp:RequiredFieldValidator ControlToValidate="UserName" runat="server" CssClass="text-danger" ErrorMessage="The ID field is required." />
            </div>
        </div>

        <!-- Input the first name -->
        <div class="form-group">
            <asp:Label ID="firstLabel" runat="server" CssClass="col-md-2 control-label"><strong>First Name</strong></asp:Label>
            <div class="col-md-10">
              <asp:TextBox runat="server" ID="firstBox" CssClass="form-control" />
              <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName" CssClass="text-danger" ErrorMessage="The First Name field is required." />
            </div>
        </div>

        <!-- Input the last name -->
        <div class="form-group">
            <asp:Label ID="lastLabel" runat="server" CssClass="col-md-2 control-label"><strong>Last Name</strong></asp:Label>
            <div class="col-md-10">
              <asp:TextBox runat="server" ID="lastBox" CssClass="form-control" />
              <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName" CssClass="text-danger" ErrorMessage="The Last Name field is required." />
            </div>
        </div>

        <!-- RadioButtons to denote if Barrett or not -->
            <asp:Label runat="server">In Barrett?</asp:Label>
            <asp:RadioButtonList ID="barrettButtonList" runat="server">
                <asp:ListItem>Yes</asp:ListItem>
                <asp:ListItem>No</asp:ListItem>
            </asp:RadioButtonList>
        <!--Input the Password-->
        <!--<div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                    CssClass="text-danger" ErrorMessage="The password field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label">Confirm password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
            </div>
        </div>-->
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="CreateUser_Click" Text="Add Student" CssClass="btn btn-default" />
                <asp:Label runat="server" ForeColor="Red" ID="errorLabel"></asp:Label>
                <asp:Button ID="regButton" runat="server" OnClick="regButton_Click" Text="Back to Register" />
            </div>
        </div>
    </div>
</asp:Content>
