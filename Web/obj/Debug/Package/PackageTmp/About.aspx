<%@ Page Title="关于我们" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="About.aspx.cs" Inherits="Web.About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
<script language="javascript" type="text/javascript">
    $(function () { window.isHideBlock = true; });
</script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        关于
    </h2>
    <p>
        自建网站，逐步完善。
    </p>
    <h3>V1.0.0</h3>
    <p>EntityFramework + 示例样式 + 列表页 + 文章页</p>
    <h3>V1.0.1</h3>
    <p>访问计数器 + 标签 + 收藏链接 + 注册 + 登录</p>
</asp:Content>
