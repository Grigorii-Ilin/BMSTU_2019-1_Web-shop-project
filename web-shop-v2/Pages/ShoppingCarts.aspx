<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ShoppingCarts.aspx.cs" Inherits="web_shop_v2.Pages.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:panel id="pnlShoppingCarts" runat="server"></asp:panel>

    <table>
        <tr>
            <td><b>Сумма заказа: </b></td>
            <td>
                <asp:literal ID="litSumOrders" runat="server"></asp:literal>
            </td>
        </tr>
        <tr>
            <td><b>Доставка: </b></td>
            <td>
                100 ₽
            </td>
        </tr>
        <tr>
            <td><b>Итого: </b></td>
            <td>
                <asp:literal ID="litTotal" runat="server"></asp:literal>
            </td>
        </tr>
        <tr>
            <td> 
                <asp:linkbutton  ID="lbtContinueShopping" runat="server" PostBackUrl="~/Index.aspx">Продолжить просмотр</asp:linkbutton>
                или
                <asp:button ID="btnCheckOut"  runat="server" PostBackUrl="~/Pages/Success.aspx"
                    CssClass="button" width="250px" text="Заказать!" />
            </td>
        </tr>
    </table>
</asp:Content>
