<%@ Page Language="C#" MasterPageFile="~/Site.Mobile.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebAppLibrary.Login" %>

<asp:Content ContentPlaceHolderID="HeadContent" runat="server">
    <title>Login</title>
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div class="content">
        <h2>Login to Your Account</h2>

        <table>
            <tr>
                <td><asp:Label ID="LabelPhoneNumber" runat="server" Text="Phone Number"></asp:Label></td>
                <td><asp:TextBox ID="txtPhoneNumber" runat="server" placeholder="Enter Phone Number"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label ID="LabelPassword" runat="server" Text="Password"></asp:Label></td>
                <td><asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="Enter Password"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label ID="LabelRole" runat="server" Text="Role"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="ddlRole" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="asp-btn" OnClick="LoginUser" /></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label></td>
            </tr>
        </table>
    </div>
</asp:Content>
