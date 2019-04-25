<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="web_shop_v2.Pages.Account.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <asp:Literal ID="litStatus" runat="server"></asp:Literal>
    </p>
    <p>
        Электронная почта:</p>
    <p>
        <asp:TextBox ID="txtLogin" runat="server" CssClass="inputs" TextMode="Email"></asp:TextBox>
    </p>
    <p>
        Пароль:</p>
    <p>
        <asp:TextBox ID="txtPasword" runat="server" CssClass="inputs" TextMode="Password"></asp:TextBox>
    </p>
    <p>
        Подтвердить пароль:</p>
    <p>
        <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="inputs" TextMode="Password"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="btnConfirm" runat="server" CssClass="button" Text="Button" OnClick="btnConfirm_Click" />
    </p>
    <p>
        &nbsp;</p>
</asp:Content>
