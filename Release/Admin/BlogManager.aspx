<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BlogManager.aspx.cs" Inherits="Web.Admin.BlogManager"
    ValidateRequest="false" %>

<!DOCTYPE html>
<html lang="zh-CN">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
    <title>后台编辑页</title>
    <link href="/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery-3.1.0.min.js" type="text/javascript"></script>
    <script src="/js/bootstrap.min.js" type="text/javascript"></script>
    <script src="/js/showdown.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            var converter = new showdown.Converter();
            $("#txtContent").on("input", function () {
                $("#divPreview").html(converter.makeHtml($("#txtContent").val()));
            });
        });  
    </script>
</head>
<body>
    <div class="container">
        <form id="form1" runat="server" role="form" class="form-horizontal">
        <div class="form-group">
        <div class="col-sm-2"></div>
        <div class="col-sm-10"><h3>编辑文章</h3></div>
        
        </div>
        <div class="form-group">
            <label for="ddTags" class="col-sm-2 control-label">
                标签</label>
            <div class="col-sm-10">
                <asp:DropDownList CssClass="form-control" runat="server" ID="ddTags">
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <label for="txtTitle" class="col-sm-2 control-label">
                标题</label>
            <div class="col-sm-10">
                <asp:TextBox runat="server" ID="txtTitle" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
         <div class="form-group">
            <label for="txtContent" class="col-sm-2 control-label">
                正文</label>
            <div class="col-sm-10">
                <div style="width:100%;">
                    <div style="width:50%;float:left;">
                    <asp:TextBox runat="server" TextMode="MultiLine" Width="100%" Rows="27" ID="txtContent"></asp:TextBox>
                    </div>
                    <div style="width:49%;max-height:550px;overflow:auto;float:right;" id="divPreview">
                   
                    </div>
                    <div style="clear:both;"></div>
                </div>   
            </div>
        </div>
        <div class="form-group text-center">
            <asp:Button runat="server" ID="btnSave" CssClass="btn btn-success" Text="保 存" OnClick="btnSave_Click" />
        </div>
        </form>
    </div>
</body>
</html>
