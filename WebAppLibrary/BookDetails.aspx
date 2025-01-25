<%@ Page Language="C#" MasterPageFile="~/Site.Mobile.Master" AutoEventWireup="true" CodeBehind="BookDetails.aspx.cs" Inherits="WebAppLibrary.BookDetails" %>

<%--<asp:Content ContentPlaceHolderID="HeadContent" runat="server">
    <title>Book Details</title>
</asp:Content>--%>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-container">
      
            <table>
                <tr>
                    <td><asp:Label ID="LabelBookID" runat="server" Text="Book ID"></asp:Label></td>
                    <td><asp:TextBox ID="txtBOOK_ID" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="LabelBookName" runat="server" Text="Book Name"></asp:Label></td>
                    <td><asp:TextBox ID="txtBOOK_NAME" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="LabelBookDesc" runat="server" Text="Book Description"></asp:Label></td>
                    <td><asp:TextBox ID="txtBOOK_DESC" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="LabelIsActive" runat="server" Text="Is Active"></asp:Label></td>
                    <td><asp:CheckBox ID="chkIS_ACTIVE" runat="server" /></td>
                </tr>
                <tr>
                    <td><asp:Label ID="LabelCreatedBy" runat="server" Text="Created By"></asp:Label></td>
                    <td><asp:TextBox ID="txtCREATED_BY" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                    </td>
                </tr>
            </table>
       
    </div>
</asp:Content>
