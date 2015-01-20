<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="tmp.aspx.cs" Inherits="Demo2015_1.SpendingAnalyzer.tmp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form id="Form1" runat="server">
            <asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="false" ClientIDMode="Static" />
            <br />
            <br />
            <button type="submit" ID="Button1" class="btn btn-primary" >Add Data</button>
            <!--<asp:Button ID="Button1" runat="server" Text="Upload Selected File(s)" />-->
</form>
    <!--Uploading Files Using ASP.NET Web Forms, Generic Handler and jQuery-->
    <script src="/Scripts/jquery-1.9.1.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $("#Button1").click(function (evt) {
                alert("1");
                var fileUpload = $("#FileUpload1").get(0);
                var files = fileUpload.files;
                alert("2");
                var data = new FormData();
                for (var i = 0; i < files.length; i++) {
                    data.append(files[i].name, files[i]);
                }
                alert("3");
                var options = {};
                options.url = "FileUploadHandler.ashx";
                options.type = "POST";
                options.data = data;
                options.contentType = false;
                options.processData = false;
                options.success = function (result) { alert(result); };
                options.error = function (err) { alert(err.statusText); };
                alert("4");
                $.ajax(options);

                evt.preventDefault();
            });
        });
</script>

</asp:Content>
