<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Item.aspx.cs" Inherits="Web.Item" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script src="/js/showdown.min.js" type="text/javascript"></script>
<style type="text/css">
.tbhid{display:none;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h2><%=title%></h2>
<small style="padding-left:120px;"><%=addtime%></small>
<asp:TextBox runat="server" ID="hidcontent" CssClass="tbhid" TextMode="MultiLine" />
<div id="main"></div>

 <script language="javascript" type="text/javascript">
     var converter = new showdown.Converter();
     $("#main").html(converter.makeHtml($("#hidcontent").val()));
</script>
<hr />
<div>
<h2><a href="#divreply">发表评论</a></h2>
<div id="divReview">

</div>
<div>
<a name="divreply" id="divreply"></a>
<p>昵称：<input id="txtNick" value="游客" /></p>
<p>内容：<textarea id="txtContent" cols="60" rows="5" style="vertical-align:top;"></textarea></p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input value="提交评论" type="button" id="btnSubmit" /></p>
</div>
</div>
<script type="text/javascript" language="javascript">
    $(function () {
        var id=<%=id%>;
        $("#btnSubmit").click( function () {
            var nick = $("#txtNick").val();
            var content = $("#txtContent").val();
            if ($.trim(nick) == "" || $.trim(content) == "") { return; }
            $.post("ajax.asmx/SaveReply", {id:id,nick:nick,content:content},function(data){$("#txtContent").val("");bind();});
        });
        bind();
        function bind() {            
            $.getJSON("ajax.asmx/GetReply",{id:id},function(data){
                $("#divReview").html("");
                $.map(data,function(n,i){
                   $("#divReview").append("<p>#"+(i+1)+"楼&nbsp;["+n.Nick+"]&nbsp;&nbsp;"+n.AddTime+"<br />"+converter.makeHtml(n.Content)+"</p>");
                });
            });
        }
    });
</script>
</asp:Content>
