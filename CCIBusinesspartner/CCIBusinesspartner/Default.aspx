<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="CCIBusinesspartner._Default" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
   <fieldset>
       <legend> Welcome</legend>
     <h3> This Application helps to keep track of events that is going to take place with the business partner in the University. 

        This also helps the user to store point of contacts of various business partners, generate reports and email  business partners regarding the events taking place in the University</h3>
    </fieldset>
       <p>
        Number Of Business Partners : <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </p>
        <asp:Panel ID="Panel1" runat="server" Visible="True">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
            <fieldset>
                <legend>Partners</legend>
                <telerik:RadGrid ID="RadGrid1" runat="server"></telerik:RadGrid>
            </fieldset>
                </ContentTemplate>
            
        </asp:UpdatePanel>
    </asp:Panel>
</asp:Content>
