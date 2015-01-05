<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="CCIBusinesspartner.Reports" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 25px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   <telerik:RadScriptManager runat="server" ID="RadScriptManager1" />
    <table style="width:100%;">
        <tr>
            <td class="auto-style1">
                <fieldset>
                    <legend>Business Partner's Report</legend>
                    <br />
                    <asp:ImageButton ID="ImageButton1" runat="server" Height="41px" ImageUrl="~/images.png" Width="59px" OnClick="ImageButton1_Click" />
                <telerik:RadGrid ID="RadGrid1" runat="server">
                     <ExportSettings IgnorePaging="true" OpenInNewWindow="true">
                <Pdf PageHeight="210mm" PageWidth="297mm" DefaultFontFamily="Arial Unicode MS" PageTopMargin="45mm"
                    BorderStyle="Medium" BorderColor="#666666">
                </Pdf>
                         
            </ExportSettings>
                    
                </telerik:RadGrid>
                    </fieldset>
            </td>
        </tr>
        <tr>
            <td>
                <fieldset>
                    <legend> Event's Report</legend>

                    <br />
                    <asp:ImageButton ID="ImageButton2" runat="server" Height="41px" ImageUrl="~/images.png" OnClick="ImageButton2_Click" Width="59px" />

                <telerik:RadGrid ID="RadGrid2" runat="server">
                    <ExportSettings IgnorePaging="true" OpenInNewWindow="true">
                <Pdf PageHeight="210mm" PageWidth="297mm" DefaultFontFamily="Arial Unicode MS" PageTopMargin="45mm"
                    BorderStyle="Medium" BorderColor="#666666">
                </Pdf>
            </ExportSettings>
                </telerik:RadGrid>
                    </fieldset>
            </td>
        </tr>
        <tr>
            <td>
                <fieldset>
                    <legend>Point of Contact's Report</legend>
                    <br />
                    <asp:ImageButton ID="ImageButton3" runat="server" Height="41px" ImageUrl="~/images.png" Width="59px" OnClick="ImageButton3_Click" />
                <telerik:RadGrid ID="RadGrid3" runat="server">
                    <ExportSettings IgnorePaging="true" OpenInNewWindow="true">
                <Pdf PageHeight="210mm" PageWidth="297mm" DefaultFontFamily="Arial Unicode MS" PageTopMargin="45mm"
                    BorderStyle="Medium" BorderColor="#666666">
                </Pdf>
            </ExportSettings>
                </telerik:RadGrid>
                    </fieldset>
            </td>
        </tr>
    </table>
</asp:Content>
