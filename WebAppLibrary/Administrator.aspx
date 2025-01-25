<%@ Page Title="Administrator" Language="C#" MasterPageFile="~/Site.Mobile.Master" AutoEventWireup="true" CodeBehind="Administrator.aspx.cs" Inherits="WebAppLibrary.Administrator" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-container">
        
        <!-- Search Section -->
        <h2>Search User</h2>
        <table>
            <tr>
                <td><asp:Label ID="lblSearchUserId" runat="server" Text="Enter User ID: "></asp:Label></td>
                <td><asp:TextBox ID="txtSearchUserId" runat="server"></asp:TextBox></td>
                <td><asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" /></td>
            </tr>
        </table>

        <!-- User Information Section (Hidden by default) -->
        <asp:Panel ID="pnlUserInfo" runat="server" Visible="false">
            <h3>User Information</h3>
            <table>
                <tr>
                    <td><b>First Name:</b></td>
                    <td><asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><b>Last Name:</b></td>
                    <td><asp:TextBox ID="txtLastName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><b>Role:</b></td>
                    <td>
                        <asp:DropDownList ID="ddlRole" runat="server">
                            <asp:ListItem Text="Admin" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Teacher" Value="2"></asp:ListItem>
                            <asp:ListItem Text="User" Value="3"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td><b>Phone:</b></td>
                    <td><asp:TextBox ID="txtPhone" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><b>Address:</b></td>
                    <td><asp:TextBox ID="txtAddress" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><b>Designation:</b></td>
                    <td><asp:TextBox ID="txtDesignation" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnUpdateUser" runat="server" Text="Update User" OnClick="btnUpdateUser_Click" />
                        <asp:Label ID="lblUpdateResult" runat="server" Text="" ForeColor="Green"></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:Panel>

        <hr />

        <!-- Delete Section -->
        <h2>Delete User</h2>
        <table>
            <tr>
                <td><asp:Label ID="lblDeleteUserId" runat="server" Text="Enter User ID to Delete: "></asp:Label></td>
                <td><asp:TextBox ID="txtDeleteUserId" runat="server"></asp:TextBox></td>
                <td><asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" /></td>
            </tr>
        </table>
        <asp:Label ID="lblDeleteResult" runat="server" Text="" ForeColor="Red"></asp:Label>

        <hr />

        <!-- Add User Section -->
        <h2>Add New User</h2>
<table>
    <!-- Remove User ID field from the form -->
    <tr>
        <td><asp:Label ID="lblNewFirstName" runat="server" Text="First Name: "></asp:Label></td>
        <td><asp:TextBox ID="txtNewFirstName" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td><asp:Label ID="lblNewLastName" runat="server" Text="Last Name: "></asp:Label></td>
        <td><asp:TextBox ID="txtNewLastName" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td><asp:Label ID="lblNewRole" runat="server" Text="Role: "></asp:Label></td>
        <td>
            <asp:DropDownList ID="ddlNewRole" runat="server">
                <asp:ListItem Text="Admin" Value="1"></asp:ListItem>
                <asp:ListItem Text="Teacher" Value="2"></asp:ListItem>
                <asp:ListItem Text="User" Value="3"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td><asp:Label ID="lblNewPhone" runat="server" Text="Phone: "></asp:Label></td>
        <td><asp:TextBox ID="txtNewPhone" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td><asp:Label ID="lblNewAddress" runat="server" Text="Address: "></asp:Label></td>
        <td><asp:TextBox ID="txtNewAddress" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td><asp:Label ID="lblNewDesignation" runat="server" Text="Designation: "></asp:Label></td>
        <td><asp:TextBox ID="txtNewDesignation" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Button ID="btnAddUser" runat="server" Text="Add User" OnClick="btnAddUser_Click" />
            <asp:Label ID="lblAddUserResult" runat="server" Text="" ForeColor="Green"></asp:Label>
        </td>
    </tr>
</table>

    </div>
</asp:Content>


