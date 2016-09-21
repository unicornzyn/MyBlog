<%@ Page Title="登录" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="Web.Account.Login" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
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
    <h2>
        登录
    </h2>
    <p>
        请输入用户名和密码。 <a id="aRegister" href="Register.aspx">注册</a> 如果您没有帐户。
    </p>
    <span class="failureNotification"></span>
    <div class="accountInfo">
        <fieldset class="login">
            <legend>帐户信息</legend>
            <p>
                <label for="UserName" id="UserNameLabel">
                    用户名:</label>
                <input name="UserName" type="text" value="" id="UserName" class="textEntry" />
            </p>
            <p>
                <label for="Password" id="PasswordLabel">
                    密码:</label>
                <input name="Password" type="password" id="Password" class="passwordEntry" />
            </p>
        </fieldset>
        <p class="submitButton">
            <input type="button" name="LoginButton" value="登录" onclick="" id="LoginButton" />
        </p>
    </div>
</asp:Content>
