<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UploadFile.aspx.cs" Inherits="Demo2015_1.SpendingAnalyzer.UploadFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form role="form" runat="server">
  <div class="form-group">
      <label for="lblDescription">Please upload your *.csv file[s]</label>
      <asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="True" />
      <asp:Label ID="lblError" runat="server" Text="" ForeColor="red"></asp:Label>
      <asp:Label ID="lblSuccess" runat="server" Text="" ForeColor="Green"></asp:Label>
  </div>
  <div class="form-group">
      <asp:CheckBoxList ID="CheckBoxListUploadFiles" runat="server" ViewStateMode="Enabled"></asp:CheckBoxList>
      <asp:Button ID="btnRemoveCheckFile" runat="server" Text="Remove Checked File[s]" OnClick="btnRemoveCheckFile_Click" /><br />
      <asp:Label ID="lblSuccessDeleteFile" runat="server" Text="" ForeColor="green"></asp:Label>
      <asp:Label ID="lblErrorOfCheckBoxList" runat="server" Text="" ForeColor="red"></asp:Label>
  </div>
        <asp:Button ID="btnUpload" class="btn btn-default" runat="server" Text="Upload" OnClick="btnUpload_Click" />
        <asp:Button ID="btnAnalyzeUploadData" class="btn btn-default" runat="server" Text="Analyze Upload Data[s]" OnClick="btnAnalyzeUploadData_Click" />
        <asp:Label ID="lblErrorAnalyze" runat="server" Text="" ForeColor="red"></asp:Label>
</form>
</asp:Content>
