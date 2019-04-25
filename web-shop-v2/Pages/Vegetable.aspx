<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Vegetable.aspx.cs" Inherits="web_shop_v2.Pages.Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td rowspan="3">
                <asp:Image ID="imgProduct" runat="server" CssClass="detailsImage" /></td>
            <td>
                <h2>
                    <asp:Label ID="lblTitle" runat="server" Text="Label"></asp:Label></h2>
                <hr />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblDescription" runat="server" CssClass="detailsDescription"></asp:Label></td>
            <td>
                <asp:Label ID="lblPrice" runat="server" CssClass="detailsPrice"></asp:Label><br />
                Вес:
                <input type="number" step="0.1" min="1.0"max ="60.0" value="0.0" name="inpAmount"> кг.<br />
                <asp:Button ID="btnAddToCart" runat="server" CssClass="button" OnClick="btnAddToCart_Click" Text="Добавить в корзину" />
                <br />
                <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
                </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblAviable" runat="server" Text="Доступно 60 кг." CssClass="productPriceAndAviable"></asp:Label></td>
        </tr>
    </table>
</asp:Content>
