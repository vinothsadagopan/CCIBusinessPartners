<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="new event.aspx.cs" Inherits="CCIBusinesspartner.new_event" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
    <style type="text/css">
        .auto-style1 {
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolScriptManager1" runat="server" ></ajaxToolkit:ToolkitScriptManager>
     <fieldset>
        <legend>Create Event</legend>
         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
             <ContentTemplate>
    <table style="width:100%;">
        <tr>
            <td class="auto-style1">Event Name</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please fill the event name" ControlToValidate="TextBox1" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Event Date</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID ="TextBox2" PopupButtonID="ImageButton1" Format="yyyy-MM-dd"></ajaxToolkit:CalendarExtender>
                <asp:ImageButton ID="ImageButton1" runat="server" Height="25px" ImageUrl="~/images.jpg" Width="30px" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please fill the event Date" ControlToValidate="TextBox2" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Event Timings</td>
            <td>
                <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="True">
                    <asp:ListItem>Please Select</asp:ListItem>
                    <asp:ListItem>8:00:00</asp:ListItem>
                    <asp:ListItem>9:00:00</asp:ListItem>
                    <asp:ListItem>10:00:00</asp:ListItem>
                    <asp:ListItem>11:00:00</asp:ListItem>
                    <asp:ListItem>12:00:00</asp:ListItem>
                    <asp:ListItem>13:00:00</asp:ListItem>
                    <asp:ListItem>14:00:00</asp:ListItem>
                    <asp:ListItem>15:00:00</asp:ListItem>
                    <asp:ListItem>16:00:00</asp:ListItem>
                    <asp:ListItem>17:00:00</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Company</td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="129px" AutoPostBack="true">
                    <asp:ListItem>Please Select</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Contact Person</td>
            <td>
                <asp:DropDownList ID="DropDownList2" runat="server">
                    <asp:ListItem>Please Select</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Button ID="Button1" runat="server" Text="Create Event" OnClick="Button1_Click" />
            </td>
            <td>
                <asp:Button ID="Button2" runat="server" Text="Cancel" CausesValidation="False" OnClick="Button2_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style1" colspan="2">
                <asp:Label ID="Label1" runat="server" Text="Label" Visible="false"></asp:Label>
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
