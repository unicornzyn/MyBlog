<%@ Page Title="主页" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Web._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        列表
    </h2>
    <asp:Repeater runat="server" ID="rptList">
    <ItemTemplate>
    <p><a href="Item.aspx?id=<%#Eval("id") %>"><%#Eval("title") %></a><span style="padding-left:10px;"><%#Common.St.GetDateTimeString(Eval("addtime"))%></span></p>
    </ItemTemplate>
    </asp:Repeater>
</asp:Content>
