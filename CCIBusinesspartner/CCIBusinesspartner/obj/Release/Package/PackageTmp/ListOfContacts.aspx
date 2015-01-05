<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListOfContacts.aspx.cs" Inherits="CCIBusinesspartner.Contacts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolScriptManager1" runat="server" ></ajaxToolkit:ToolkitScriptManager>
    <%--<fieldset>
        <legend>List Of Contacts</legend>
    </fieldset>--%><table style="width: 100%;">
        <tr>
            <td><fieldset>
                <legend> List Of Contacts</legend>
                <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" DataKeyNames="contact_id">
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
                                    <asp:BoundField DataField="contact_id" HeaderText=" No" /> 
                                    <asp:BoundField DataField="contact_firstname" HeaderText="First Name" />
                                    <asp:BoundField DataField="contact_lastname" HeaderText="Last Name" />
                                    <asp:BoundField DataField="contact_number" HeaderText="Ph-no" />
                                     <asp:BoundField DataField="contact_email" HeaderText="E-mail" />
                                    <asp:BoundField DataField="account_name" HeaderText="Partner Account" />
                                    <asp:TemplateField HeaderText="Edit Contact">
                                        <ItemTemplate>
                                        <asp:LinkButton ID="lnkedit" runat="server" OnClick="lnkedit_click" >Edit</asp:LinkButton>
                                        
                                        </ItemTemplate>
                                        
                                    </asp:TemplateField>

                                    
                    </Columns>
                </asp:GridView>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td>
                <fieldset>
                    <legend>New Contact </legend>
                <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="#004040" NavigateUrl="~/NewContact.aspx">Click Here to Create New Contact  -&gt;</asp:HyperLink>
                    </fieldset>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
