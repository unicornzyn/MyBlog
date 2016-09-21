<%@ Page Title="登录" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="Web.Account.Login" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        body
        {
            padding-top: 40px;
            padding-bottom: 40px;
            background-color: #eee;
        }
        
        .form-signin
        {
            max-width: 330px;
            padding: 15px;
            margin: 0 auto;
        }
        .form-signin .form-signin-heading, .form-signin .checkbox
        {
            margin-bottom: 10px;
        }
        .form-signin .checkbox
        {
            font-weight: normal;
        }
        .form-signin .form-control
        {
            position: relative;
            height: auto;
            -webkit-box-sizing: border-box;
            -moz-box-sizing: border-box;
            box-sizing: border-box;
            padding: 10px;
            font-size: 16px;
        }
        .form-signin .form-control:focus
        {
            z-index: 2;
        }
        .form-signin input[type="email"]
        {
            margin-bottom: -1px;
            border-bottom-right-radius: 0;
            border-bottom-left-radius: 0;
        }
        .form-signin input[type="password"]
        {
            margin-bottom: 10px;
            border-top-left-radius: 0;
            border-top-right-radius: 0;
        }
    </style>
    <script language="javascript" type="text/javascript">
        $(function () {
            window.isHideBlock = true;
            $("#LoginButton").click(function () {
                if ($.trim($("#UserName").val()) == "") {
                    $(".failureNotification").text("请输入用户名"); return;
                }
                if ($.trim($("#Password").val()) == "") {
                    $(".failureNotification").text("请输入密码"); return;
                }
                $.post("AccountAjax.asmx/Login", { "username": $("#UserName").val(), "passwd": $("#Password").val() }, function (data) {
                    if (data.success == 1) {
                        window.location.href = data.url;
                    } else if (data.success == 2) {
                        $(".failureNotification").text("用户名或密码错误");
                    }
                }, "json");
            });
        });
    </script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="form-signin">
        <h2>
            登录
        </h2>
        <p>
            请输入用户名和密码。 <%--<a id="aRegister" href="Register.aspx">注册</a> 如果您没有帐户。--%>
        </p>
        <span class="failureNotification"></span>
        <input type="text" id="UserName" class="form-control" placeholder="用户名" required autofocus />
        <input type="password" id="Password" class="form-control" placeholder="密码" required />
        <button class="btn btn-lg btn-primary btn-block" id="LoginButton" type="button">
            登 录</button>
    </div>
</asp:Content>
