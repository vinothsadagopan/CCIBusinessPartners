<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EventManager.aspx.cs" Inherits="CCIBusinesspartner.EventManager" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
    <style type="text/css">
        .auto-style1 {
            width: 325px;
        }
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:ScriptManager ID="ScriptManager1" runat="server" ></asp:ScriptManager>
    
    <table style="width:100%;">
        <tr>
            <td class="auto-style1">
                <fieldset>
                    <legend>Calendar</legend>
                <telerik:RadCalendar ID="RadCalendar1" Runat="server" EnableWeekends="True" FastNavigationNextText="&amp;lt;&amp;lt;"  OnDayRender="RadCalendar1_DayRender" OnSelectionChanged="RadCalendar1_SelectionChanged" AutoPostBack="True" EnableMultiSelect="False">
                    <SpecialDays>
                        <telerik:RadCalendarDay Date="" Repeatable="Today">
                            <ItemStyle CssClass="rcToday" />
                        </telerik:RadCalendarDay>
                    </SpecialDays>
<WeekendDayStyle CssClass="rcWeekend"></WeekendDayStyle>

<CalendarTableStyle CssClass="rcMainTable"></CalendarTableStyle>

<OtherMonthDayStyle CssClass="rcOtherMonth"></OtherMonthDayStyle>

<OutOfRangeDayStyle CssClass="rcOutOfRange"></OutOfRangeDayStyle>

<DisabledDayStyle CssClass="rcDisabled"></DisabledDayStyle>

<SelectedDayStyle CssClass="rcSelected"></SelectedDayStyle>

<DayOverStyle CssClass="rcHover"></DayOverStyle>

<FastNavigationStyle CssClass="RadCalendarMonthView RadCalendarMonthView_Default"></FastNavigationStyle>

<ViewSelectorStyle CssClass="rcViewSel"></ViewSelectorStyle>
                </telerik:RadCalendar>
                <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="Please Select Dates marked in Red Color" Visible="False"></asp:Label>
                    </fieldset>
            </td>
            <td>
                <asp:Panel ID="Panel1" runat="server" Visible="False">
                    <fieldset>
                        <legend>List Of Events</legend>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:Label ID="Label2" runat="server" Text="Label" Visible="False"></asp:Label>
                            <asp:GridView ID="RadGrid1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" DataKeyNames="name,event_date,account_name,event_id">
                                <AlternatingRowStyle BackColor="White" />
                                <EditRowStyle BackColor="#7C6F57" />
                                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#E3EAEB" />
                                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                <SortedAscendingHeaderStyle BackColor="#246B61" />
                                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                <SortedDescendingHeaderStyle BackColor="#15524A" />
                                <Columns>
                                    <asp:BoundField DataField="event_id" HeaderText="Event No" /> 
                                    <asp:BoundField DataField="event_name" HeaderText="Event Name" />
                                    <asp:BoundField DataField="event_date" HeaderText="Event Date" />
                                    <asp:BoundField DataField="account_name" HeaderText="Account" />
                                     <asp:BoundField DataField="name" HeaderText="Contact Person" />
                                     <asp:TemplateField HeaderText="Send Reminder">
                                        <ItemTemplate>
                                        <asp:LinkButton ID="lnkRemind" runat="server" OnClick="LnkRemind_Click">Remind</asp:LinkButton>
                                        
                                        </ItemTemplate>
                                         </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Edit Event">
                                        <ItemTemplate>
                                        <asp:LinkButton ID="lnkedit" runat="server" OnClick="Lnkedit_Click">Edit</asp:LinkButton>
                                        
                                        </ItemTemplate>
                                        
                                    </asp:TemplateField>


                                         <%--<asp:CommandField ShowEditButton="true" />
                                      <asp:CommandField ShowDeleteButton="true" />--%>
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                        
                    </asp:UpdatePanel>
                  </fieldset>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Panel ID="PnlNewEvent"  runat="server">
                    <fieldset>
                        <legend>New Event </legend>
                <asp:LinkButton ID="LinkButton1" runat="server" BackColor="#339966" OnClick="LinkButton1_Click">Click Here to Create a New Event</asp:LinkButton>
               </fieldset>
                         </asp:Panel>
                     </td>
        </tr>
    </table>
    

    
</asp:Content>
