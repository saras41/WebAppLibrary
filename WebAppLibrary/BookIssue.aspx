<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookIssue.aspx.cs" Inherits="WebAppLibrary.BookIssue" %>

<!DOCTYPE html>
<html>
<head>
    <title>Book Issue</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <label for="txtBOOK_ID">Book ID:</label>
            <asp:TextBox ID="txtBOOK_ID" runat="server"></asp:TextBox><br />

            <label for="ddlIssuedTo">Issued To:</label>
            <asp:DropDownList ID="ddlIssuedTo" runat="server">
                <asp:ListItem Text="Select" Value=""></asp:ListItem>
                <asp:ListItem Text="Student" Value="Student"></asp:ListItem>
                <asp:ListItem Text="Teacher" Value="Teacher"></asp:ListItem>
                <asp:ListItem Text="Admin" Value="Admin"></asp:ListItem>
            </asp:DropDownList><br />

            <label for="txtIssueFromDate">Issue From Date:</label>
            <asp:TextBox ID="txtIssueFromDate" runat="server"></asp:TextBox><br />

            <label for="txtIssueToDate">Issue To Date:</label>
            <asp:TextBox ID="txtIssueToDate" runat="server"></asp:TextBox><br />

            <asp:Button ID="btnIssueBook" runat="server" Text="Issue Book" OnClick="btnIssueBook_Click" />
        </div>
    </form>
</body>
</html>
