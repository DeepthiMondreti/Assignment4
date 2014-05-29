<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>Please Donate</h2>
    <!--**********************************************************************
        create a table for the input form. the validation objects here will only work if you
        change the web config file to turn off Unobtrusive validation mode which uses JQuery
        *************************************************************************-->
    <table>
        <tr>
            <td>First Name</td>
            <td>
                <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox></td>
            <td>&nbsp;</td>
        </tr>
            <tr>
            <td>Last Name</td>
            <td>
                <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLastName" ErrorMessage="Last Name is required" Display="None"></asp:RequiredFieldValidator>
                </td>
        </tr>
            <tr>
            <td>Phone</td>
            <td>
                <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox></td>
            <td></td>
        </tr>
            <tr>
            <td>Email</td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtEmail" Display="None" ErrorMessage="Must enter a Email"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Invalid email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="None"></asp:RegularExpressionValidator>
                </td>
        </tr>
            <tr>
            <td>Enter a Password</td>
            <td>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox></td>
            <td>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPassword" Display="None" ErrorMessage="Must enter a password"></asp:RequiredFieldValidator>   
                </td>
        </tr>

            <tr>
            <td>donation</td>
            <td>
                <asp:TextBox ID="txtDonation" runat="server"></asp:TextBox></td>
            <td>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtDonation" ErrorMessage="Must be a valid number" Operator="DataTypeCheck" Type="Double" Display="None"></asp:CompareValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDonation" Display="None" ErrorMessage="Must enter a donation"></asp:RequiredFieldValidator>
                </td>
        </tr>
            <tr>
            <td>
                <asp:Button ID="Button1" runat="server" Text="submit" OnClick="Button1_Click" /></td>
            <td>
                <asp:Label ID="lblError" runat="server" Text="Label"></asp:Label>
            </td>
                <td>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
                </td>
        </tr>
    </table>
</asp:Content>

