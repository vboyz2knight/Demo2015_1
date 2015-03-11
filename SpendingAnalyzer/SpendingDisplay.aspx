<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SpendingDisplay.aspx.cs" Inherits="Demo2015_1.SpendingAnalyzer.SpendingAnyalyzerDisplay" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="NoData" runat="server">
            <asp:Label ID="lblNoData" runat="server" Text="There are no data in the Database."></asp:Label>
        </asp:View>
        <asp:View ID="HasData" runat="server">
            <form id="Form1" runat="server">
                <div class="container">
                    <nav class="navbar navbar-default" role="navigation">
         <div class="container-fluid">
            <!-- Brand and toggle get grouped for better mobile display -->
            <div class="navbar-header">
              <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-2">
                <span class="sr-only">Toggle navigation</span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
              </button>
              <a class="navbar-brand" href="#">Spending Analyzer</a>
            </div>

            <!-- Collect the nav links, forms, and other content for toggling -->
            <div class="collapse navbar-collapse navbar-left" id="bs-example-navbar-collapse-2">
              <ul class="nav navbar-nav">
                <li class="active"><button class="navbar-button btn-info btn">Latest 1 mo.</button></li>
                <li class="active"><button class="navbar-button btn-info btn">Latest 3 mo.</button></li>
                <li class="active"><button class="navbar-button btn-info btn">Latest 6 mo.</button></li>
                <li class="active"><button class="navbar-button btn-info btn">Current Year</button></li>
                <li class="active"><button class="navbar-button btn-info btn">Date Range</button></li>
                <li class="active"><asp:Button ID="btnAddData" runat="server" Text="Add Data" class="navbar-button btn-info btn" OnClick="btnAddData_Click"></asp:Button></li>
              </ul>
            </div><!-- /.navbar-collapse -->
        </div><!-- /.container-fluid -->
                </div>
                <hr />
                <div class="container">
                    <div class="row">
                        <div class="col-md-6">
                            <button class="navbar-button btn-info btn">Reset</button>
                            <asp:Chart ID="Chart1" runat="server" Height="300px" BackImageAlignment="Center" Width="300px" OnClick="Chart1_Click">
                                <Series>
                                    <asp:Series ChartType="Pie" Name="Series1" Legend="Legend1">
                                    </asp:Series>
                                </Series>
                                <ChartAreas>
                                    <asp:ChartArea Name="ChartArea1">
                                        <Area3DStyle Enable3D="True" />
                                    </asp:ChartArea>
                                </ChartAreas>
                                <Legends>
                                    <asp:Legend Name="Legend1">
                                    </asp:Legend>
                                </Legends>
                                <Titles>
                                    <asp:Title Alignment="TopLeft" Name="Title1" Text="Spending by Category">
                                    </asp:Title>
                                </Titles>
                            </asp:Chart>
                        </div>
                        <div class="col-md-6">
                            <div class="container">
                                <div class="container-fluid">
                                    <h3>Datas from A to B.</h3>
                                </div>
                                <br />
                                <div class="container-fluid">Total spendings: 123.</div>
                                <br />
                                <div class="container-fluid">Total income: 123.</div>
                                <br />

                                <div class="container-fluid">Top 3 Spending categories:</div>
                                <ul>
                                    <li>1</li>
                                    <li>2</li>
                                    <li>3</li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
                <hr />
                <div class="container">
                    <div class="row">
                        <div class="col-md-12">
                            <asp:GridView ID="GridView1" runat="server" AllowSorting="True"></asp:GridView>
                        </div>
                    </div>
                </div>
            </form>
        </asp:View>
    </asp:MultiView>

</asp:Content>
