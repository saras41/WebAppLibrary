<%@ Page Language="C#" EnableViewState="true" MasterPageFile="~/Site.Mobile.Master" AutoEventWireup="true" CodeBehind="LibraryMember.aspx.cs" Inherits="WebAppLibrary.LibraryMember" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-container">
        <h2>Library Member - Book Details</h2>

        <!-- Search section -->
        <div class="search-section">
            <h3>Search Book</h3>
            <table>
                <tr>
                    <td><asp:Label ID="LabelSearchBookID" runat="server" Text="Book ID"></asp:Label></td>
                    <td><asp:TextBox ID="txtSearchBookID" runat="server"></asp:TextBox></td>
                    <td><asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" /></td>
                </tr>
            </table>
            <asp:Label ID="lblSearchResult" runat="server" ForeColor="Green"></asp:Label>
        </div>

        <!-- Update Book Info section -->
        <asp:Panel ID="pnlUpdateBook" runat="server" Visible="false">
            <h3>Update Book Details</h3>
            <table>
                <tr>
                    <td><asp:Label ID="LabelBookName" runat="server" Text="Book Name"></asp:Label></td>
                    <td><asp:TextBox ID="txtUpdateBookName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="LabelBookDesc" runat="server" Text="Book Description"></asp:Label></td>
                    <td><asp:TextBox ID="txtUpdateBookDesc" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Button ID="btnUpdateBook" runat="server" Text="Update Book" OnClick="btnUpdateBook_Click" /></td>
                </tr>
            </table>
            <asp:Label ID="lblUpdateResult" runat="server" ForeColor="Green"></asp:Label>
        </asp:Panel>

        <!-- Delete Book section -->
        <div class="delete-section">
            <h3>Delete Book</h3>
            <table>
                <tr>
                    <td><asp:Label ID="LabelDeleteBookID" runat="server" Text="Book ID"></asp:Label></td>
                    <td><asp:TextBox ID="txtDeleteBookID" runat="server"></asp:TextBox></td>
                    <td><asp:Button ID="btnDeleteBook" runat="server" Text="Delete Book" OnClick="btnDeleteBook_Click" /></td>
                </tr>
            </table>
            <asp:Label ID="lblDeleteResult" runat="server" ForeColor="Green"></asp:Label>
        </div>
    </div>
</asp:Content>

