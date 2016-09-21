<%@ Page Title="注册" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Register.aspx.cs" Inherits="Web.Account.Register" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script language="javascript" type="text/javascript">
        $(function () {
            window.isHideBlock = true;
            $("#CreateUserButton").click(function () {
                if ($.trim($("#UserName").val()) == "") {
                    $(".failureNotification").text("请输入用户名"); return;
                }
                if ($.trim($("#Password").val()) == "") {
                    $(".failureNotification").text("请输入密码"); return;
                }
                if ($("#Password").val() != $("#ConfirmPassword").val()) {
                    $(".failureNotification").text("两次密码输入不一致"); return;
                }
                $.post("AccountAjax.asmx/Register", { "username": $("#UserName").val(), "passwd": $("#Password").val() }, function (data) {
                    if (data.success == 1) {
                        window.location.href = data.url;
                    } else if (data.success == 2) {
                        $(".failureNotification").text("用户名已存在");
                    }
                },"json");
            });
        });
    </script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        创建新帐户
    </h2>
    <p>
        使用以下表单创建新帐户。
    </p>
    <span class="failureNotification"></span>
    <div class="accountInfo">
        <fieldset class="register">
            <legend>帐户信息</legend>
            <p>
                <label for="UserName" id="UserNameLabel">
                    用户名:</label>
                <input type="text" value="" id="UserName" class="textEntry" />
            </p>
            <p>
                <label for="Password" id="PasswordLabel">
                    密码:</label>
                <input type="password" id="Password" class="passwordEntry" />
            </p>
            <p>
                <label for="ConfirmPassword" id="ConfirmPasswordLabel">
                    确认密码:</label>
                <input type="password" id="ConfirmPassword" class="passwordEntry" />
            </p>
        </fieldset>
        <p class="submitButton">
            <input type="button" value="创建用户" id="CreateUserButton" />
        </p>
    </div>
</asp:Content>
