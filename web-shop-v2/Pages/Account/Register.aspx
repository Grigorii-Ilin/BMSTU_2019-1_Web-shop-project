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
        Имя :</p>
    <p>
        <asp:TextBox ID="txtFirstName" runat="server" CssClass="inputs"></asp:TextBox>
    </p>
    <p>
        Фамилия :</p>
    <p>
        <asp:TextBox ID="txtLastName" runat="server" CssClass="inputs"></asp:TextBox>
    </p>
    <p>
        Адрес :</p>
    <p>
        <asp:TextBox ID="txtAddress" runat="server" CssClass="inputs" TextMode="MultiLine"></asp:TextBox>
    </p>
    <p>
        Телефон :</p>
    <p>
        <asp:TextBox ID="txtPhone" runat="server" CssClass="inputs"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="btnConfirm" runat="server" CssClass="button" Text="Зарегистрироваться" OnClick="btnConfirm_Click" />
    </p>
    <p>
        &nbsp;</p>
</asp:Content>
