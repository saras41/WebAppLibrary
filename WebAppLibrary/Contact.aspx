<%@ Page Language="C#" EnableViewState="true" MasterPageFile="~/Site.Mobile.Master" AutoEventWireup="true" CodeBehind="Contact.aspx" Inherits="WebAppLibrary.Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        /* Center the contact container within the master page's content area */
        .contact-container {
            background-color: #ffffff;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
            max-width: 400px;
            margin: 30px auto; /* Center the box within the MainContent placeholder */
            text-align: center;
        }
        .contact-title {
            font-size: 24px;
            font-weight: bold;
            color: #333;
            margin-bottom: 15px;
        }
        .contact-details {
            font-size: 18px;
            color: #555;
            line-height: 1.6;
        }
        .contact-details span {
            display: block;
            font-weight: bold;
            color: #333;
            margin-top: 12px;
        }
        .contact-details a {
            color: #0066cc;
            text-decoration: none;
        }
        .contact-details a:hover {
            text-decoration: underline;
        }
    </style>

    <div class="contact-container">
        <div class="contact-title">Contact Information</div>
        <div class="contact-details">
            <span>Name:</span> Tanmay Saraswat
            <span>Address:</span> Grihapravesh Society, Noida
            <span>Email:</span> <a href="mailto:saraswat.tanmay4@gmail.com">saraswat.tanmay4@gmail.com</a>
            <span>Phone:</span> <a href="tel:+917704861506">7704861506</a>
        </div>
    </div>
</asp:Content>
