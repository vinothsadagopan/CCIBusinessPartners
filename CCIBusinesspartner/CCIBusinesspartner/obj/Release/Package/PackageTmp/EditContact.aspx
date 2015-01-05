<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditContact.aspx.cs" Inherits="CCIBusinesspartner.EditContact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 33px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function confirmdelete()
        {
            var r = confirm("Are you sure,you want to delete the event?");
            if(r==true)
            {
                return true;
            }
            else {
                return false;
            }
        }
    </script>
    <ajaxToolkit:ToolkitScriptManager ID="ToolScriptManager1" runat="server" ></ajaxToolkit:ToolkitScriptManager>
    <fieldset>
        <legend>Edit Contact</legend>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    
        
       <ContentTemplate> 
    <table style="width:100%;">
        <tr>
            <td>First Name</td>
            <td>
                <asp:TextBox ID="Txtfirstname" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Txtfirstname" ErrorMessage="Please fill the first name" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Last Name</td>
            <td>
                <asp:TextBox ID="Txtlastname" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Txtlastname" ErrorMessage="Please fill the last Name" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Contact Number</td>
            <td>
                <asp:TextBox ID="Txtcontactno" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Txtcontactno" ErrorMessage="Please fill the Contact Number" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Email ID</td>
            <td>
                <asp:TextBox ID="Txtemail" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Txtemail" ErrorMessage="Please fill the email id" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Company</td>
            <td>
                <asp:Label ID="Lblaccountname" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Button ID="Button1" runat="server" Text="Update Contact" OnClick="Button1_Click" />
            </td>
            <td class="auto-style1">
                <asp:Button ID="Button2" runat="server" Text="Delete Contact" OnClientClick="confirmdelete()" OnClick="Button2_Click" />
                &nbsp;&nbsp;
                <asp:Button ID="Button3" runat="server" CausesValidation="False" OnClick="Button3_Click" Text=" Cancel" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
        
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
        </Triggers>
        </asp:UpdatePanel>
        </fieldset>
</asp:Content>
