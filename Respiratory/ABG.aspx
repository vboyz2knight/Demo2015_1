<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ABG.aspx.cs" Inherits="Demo2015_1.Respiratory.ABG" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form id="Form1" runat="server">
    <div class="container">
        <div class="jumbotron">
            <fieldset>
                <legend>ABG Interpreter</legend>
                <div class="container">
                    <div class="row" align="center">
                        <div class="col-md-2">
                            &nbsp;</div>
                        <div class="col-md-2">
                            PH</div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtPH" runat="server" Width="75px"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            7.35-7.45</div>
                        <div class="col-md-2">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="txtPH" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-2"></div>
                    </div>
                    <div class="row" align="center">
                        <div class="col-md-2">
                            &nbsp;</div>
                        <div class="col-md-2">
                            CO2
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtCo2" runat="server" Width="75px"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            35-45 mmHG</div>
                        <div class="col-md-2">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="txtCo2" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-2"></div>
                    </div>
                    <div class="row" align="center">
                        <div class="col-md-2">
                            &nbsp;</div>
                        <div class="col-md-2">
                            HCO3</div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtHco3" runat="server" Width="75px"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            22-26 mEq/L</div>
                        <div class="col-md-2">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ControlToValidate="txtHco3" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-2"></div>
                    </div>
                    <div class="row" align="center">
                        <div class="col-md-2">
                            &nbsp;</div>
                        <div class="col-md-2">
                            PO2</div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtPO2" runat="server" Width="75px"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            80-100 mmHG</div>
                        <div class="col-md-2">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                ControlToValidate="txtPO2" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-2"> </div>
                    </div>
                    <div class="row" align="center">
                        <div class="col-md-12">
                            &nbsp;</div>
                    </div>
                    <div class="row" align="center">
                        <div class="col-md-12">
                            <asp:TextBox ID="txtABGResult" runat="server" TextMode="MultiLine" 
                                Width="200px" ReadOnly="True"
                                Height="100px"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row" align="center">
                        <div class="col-md-12">
                            <asp:Button ID="btnAnalyze" runat="server" Text="Analyze ABG" 
                                onclick="btnAnalyzeABG_Click" /></div>
                    </div>
                </div>
            </fieldset>
        </div>
    </div>

    </form>

</asp:Content>
