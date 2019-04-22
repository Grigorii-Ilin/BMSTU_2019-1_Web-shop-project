<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ManageProductTypes.aspx.cs" Inherits="web_shop_v2.Pages.Management.ManageProductTypes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        Наименование:</p>
    <p>
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Подтвердить" />
    </p>
    <p>
        <asp:Label ID="lblResult" runat="server"></asp:Label>
    </p>
</asp:Content>
