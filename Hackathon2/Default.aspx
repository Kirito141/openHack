<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Hackathon2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <p>
    <br />
</p>
<p>
    <asp:Label ID="Label1" runat="server" Text="ProductList"></asp:Label>
</p>
<p>
    <asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataSource1" DataKeyNames="ImageID">
             <ItemTemplate>
                 <div class="list">
                     <table style="width: 9%; float: left;">
                         <tr><td><asp:Image ID="Label3" runat="server" Height="116px" width="90px" ImageUrl='<%# Eval("IMG") %>' /></td></tr>
                         <tr><td><span>ImageID:</span> <asp:Label ID="Label2" runat="server" Text='<%# Eval("ImageID") %>' /></td></tr>
                         <tr><td><span>ImageName:</span> <asp:Label ID="Label4" runat="server" Text='<%# Eval("ImageName") %>' /></td></tr>
                         <tr><td><span>Size:</span> <asp:Label ID="Label5" runat="server" Text='<%# Eval("Size") %>' /></td></tr>
                     </table>
                 </div>
        </ItemTemplate>

    </asp:ListView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HackathonIMGConnectionString %>" SelectCommand="SELECT * FROM [Imagedetails]"></asp:SqlDataSource>
</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>


</asp:Content>
