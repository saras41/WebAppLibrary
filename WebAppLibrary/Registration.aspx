
<%@ Page Title="Registration" Language="C#" MasterPageFile="~/Site.Mobile.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="WebAppLibrary.Registration" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Registration Form</title>
</asp:Content>--%>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Registration Form (No <form> tag needed) -->
    <div class="form-container">
        <table>
            <tr>
                <td><asp:Label ID="Label3" runat="server" Text="First Name"></asp:Label></td>
                <td><asp:TextBox ID="txtFIRST_NAME" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label ID="Label2" runat="server" Text="Last Name"></asp:Label></td>
                <td><asp:TextBox ID="txtLAST_NAME" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label ID="Label5" runat="server" Text="Role"></asp:Label></td>
                <td><asp:DropDownList runat="server" ID="ddlRole" AutoPostBack="true" Width="100%"></asp:DropDownList></td>
            </tr>
            <tr>
                <td><asp:Label ID="Label6" runat="server" Text="Password"></asp:Label></td>
                <td><asp:TextBox ID="txtPASSWORD" runat="server" TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label ID="Label7" runat="server" Text="Phone"></asp:Label></td>
                <td><asp:TextBox ID="txtPHONE" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label ID="Label8" runat="server" Text="Address"></asp:Label></td>
                <td><asp:TextBox ID="txtADDRESS" runat="server" TextMode="MultiLine"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label ID="Label9" runat="server" Text="Designation"></asp:Label></td>
                <td><asp:TextBox ID="txtDESIGNATION" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
