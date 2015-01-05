<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListAccount.aspx.cs" Inherits="CCIBusinesspartner.ListAccount" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" DataKeyNames="account_id">
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
                                    <asp:BoundField DataField="account_id" HeaderText="Account No" /> 
                                    <asp:BoundField DataField="account_name" HeaderText=" Name" />
                                    <asp:BoundField DataField="date_created" HeaderText=" Date " />
                                    <asp:BoundField DataField="city" HeaderText="City" />
                                     <asp:BoundField DataField="domain" HeaderText="Domain" />
                                    <asp:BoundField DataField="technology" HeaderText="Technology" />
             <asp:TemplateField HeaderText="Edit Account">
                                        <ItemTemplate>
                                        <asp:LinkButton ID="lnkedit" runat="server" OnClick="Lnkedit_Click">Edit</asp:LinkButton>
                                        
                                        </ItemTemplate>
                                        
                                    </asp:TemplateField>

             </Columns>
    </asp:GridView>
    
    
    
    
        </asp:Content>
