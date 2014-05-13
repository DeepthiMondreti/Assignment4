<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>Thank you</h2>
    <p>Is this information correct?</p>
    <!--******************************************************************
            On this page we set up lables to display the vlaues from the class
            which we will retrieve from the session variable
            *****************************************************************-->
    <p>
        
        <asp:Label ID="lblFirstName" runat="server" Text="Label"></asp:Label><br />
         <asp:Label ID="lblLastName" runat="server" Text="Label"></asp:Label><br />
         <asp:Label ID="lblPhone" runat="server" Text="Label"></asp:Label><br />
         <asp:Label ID="lblEmail" runat="server" Text="Label"></asp:Label><br />
         <asp:Label ID="lblDonation" runat="server" Text="Label"></asp:Label><br />
        <!--we also have two buttons to confirm or redo the information-->
        <asp:Button ID="btnYes" runat="server" Text="Yes" OnClick="btnYes_Click" /> <asp:Button ID="btnNo" runat="server" Text="No" OnClick="btnNo_Click" />
    </p>
</asp:Content>

