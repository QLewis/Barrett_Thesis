<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Register_Web_App._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Barrett Register</h1>
        <p class="lead">This is going to be a cash register for my honors thesis</p>
    </div>

    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <!--1st row has the log in label-->
                <tr>
                    <td colspan="6" style="text-align:center; vertical-align:top">
                        <asp:Label ID="Label1" runat="server" Font-Bold="true" Font-Size="XX-Large" Font-Underline="true" Text="Log In"> </asp:Label>
                    </td>
                </tr>
                <!--2nd row will take in userID-->
                <tr>
                    <td></td>
                    <td style="text-align:center">
                        <asp:Label ID="Label2" runat="server" Font-Size="X-Large" Text="UserID"></asp:Label>
                    </td>
                    <td style="text-align:center">
                        <asp:TextBox ID="TextBox1" runat="server" Height="34px" Width="182px"></asp:TextBox>
                    </td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                <!--3rd Row will take password-->
                <tr>
                    <td></td>
                    <td style="text-align:center">
                        <asp:Label ID="Label3" runat="server" Font-Size="X-Large" Text="Password"></asp:Label>
                    </td>
                    <td style="text-align:center">
                        <asp:TextBox ID="TextBox2" runat="server" Height="34px" Width="182px"></asp:TextBox>
                    </td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                <!--4th Row has button-->
                <tr>
                    <td></td>
                    <td></td>
                    <td style="text-align: center">
                        
                        <asp:Button ID="Button1" runat="server" Text="Log In" Width="133px" />
                        
                    </td>
                </tr>
            </table>
        </div>
    </form>
    

</asp:Content>
