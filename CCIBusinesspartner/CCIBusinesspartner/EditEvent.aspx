<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditEvent.aspx.cs" Inherits="CCIBusinesspartner.EditEvent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
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
        <legend>Edit Event</legend>
         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
             <ContentTemplate>
    <table style="width:100%;">
        <tr>
            <td class="auto-style1">Event Name</td>
            <td>
                <asp:TextBox ID="Txteventname" runat="server" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Txteventname" ErrorMessage="Please fill the event name" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Event Date</td>
            <td>
                <asp:TextBox ID="Txteventdate" runat="server"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID ="Txteventdate" PopupButtonID="ImageButton1" Format="yyyy-MM-dd"></ajaxToolkit:CalendarExtender>
                <asp:ImageButton ID="ImageButton1" runat="server" Height="25px" ImageUrl="~/images.jpg" Width="30px" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Txteventdate" ErrorMessage="Please fill the Date" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Event Timings</td>
            <td>
                <asp:TextBox ID="Txttimings" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Company</td>
            <td>
                <asp:Label ID="Lablcompany" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Contact Person</td>
            <td>
                <asp:Label ID="LblContactPerson" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Button ID="Button1" runat="server" Text="Update Event" OnClick="Button1_Click"  />
            </td>
            <td>
                <asp:Button ID="Button2" runat="server" Text="Delete Event" OnClick="Button2_Click"  OnClientClick="confirmdelete()"/>
                &nbsp;
                <asp:Button ID="Button3" runat="server" CausesValidation="False" OnClick="Button3_Click" Text="Cancel" />
            </td>
        </tr>
        <tr>
            <td class="auto-style1" colspan="2">
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>
                 </ContentTemplate>
             <Triggers>
                 <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
             </Triggers>
             </asp:UpdatePanel>
        </fieldset>

</asp:Content>
