<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CategorizeNewData.aspx.cs" Inherits="Demo2015_1.SpendingAnalyzer.CategorizeNewData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form class="form-horizontal" role="form" runat="server">
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="ViewUserEnterCategory" runat="server">
                <div class="form-group">
                    <label for="lblInfo" class="col-sm-12 control-label">Please choose a phrase within the Description to uniquely identify which category to be in.</label>
                </div>
                <div class="form-group">
                    <label for="lblDescription" class="col-sm-2 control-label">Transaction Description</label>
                    <div class="col-sm-10">
                        <asp:Label ID="lblDescription" runat="server" Text="lblDescription"></asp:Label>
                    </div>
                </div>
                <div class="form-group" runat="server" id="InputFilterPhraseDiv" clientidmode="Static">
                    <label for="inputFilterPhrase" class="col-sm-2 control-label">Filter Phrase</label>
                    <div class="col-sm-5">
                        <asp:TextBox ID="inputFilterPhrase" runat="server" class="form-control" placeholder="Enter the filter phrase" ClientIDMode="Static"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group" runat="server" id="InputCategoryDiv">
                    <label for="CategoriesDropDownList" class="col-sm-2 control-label">Category</label>
                    <div class="col-sm-3">
                        <asp:DropDownList ID="CategoriesDropDownList" runat="server" class="form-control"></asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-sm-offset-2 col-sm-10">
                        <asp:Button ID="ButtonSubmit" runat="server" class="btn btn-default" Text="Submit" OnClick="ButtonSubmit_Click" />
                    </div>
                </div>
            </asp:View>
            <asp:View ID="ViewSummary" runat="server">
                <div class="form-groups">
                    <label for="lblInfo" class="col-sm-12 control-label">Your chosen filter phrase.</label>
                </div>
                <div class="form-group has-success">
                    <label for="lblDescription" class="col-sm-2 control-label">Transaction Description</label>
                    <div class="col-sm-10">
                        <asp:Label ID="lblDescriptionSummary" runat="server" Text="lblDescriptionSummary"></asp:Label>
                    </div>
                </div>
                <div class="form-group has-success">
                    <label for="lblFilter" class="col-sm-2 control-label">Filter Phrase</label>
                    <div class="col-sm-10">
                        <asp:Label ID="lblFilterPhraseSummary" runat="server" Text="lblFilterPhraseSummary"></asp:Label>
                    </div>
                </div>
                <div class="form-group has-success">
                    <label for="lblFilter" class="col-sm-2 control-label">Category</label>
                    <div class="col-sm-10">
                        <div class="container">
                            <asp:Label ID="lblInputCategorySummary" runat="server" Text="lblInputCategorySummary"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-sm-offset-2 col-sm-10">
                        <asp:Button ID="Back" runat="server" class="btn btn-default" Text="Back" OnClick="Back_Click"/>
                        <asp:Button ID="Confirm" runat="server" class="btn btn-default" Text="Confirm" OnClick="Confirm_Click" />
                    </div>
                </div>
            </asp:View>
        </asp:MultiView>
    </form>
    
</asp:Content>
