<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="InitialVentSetting.aspx.cs" Inherits="Demo2015_1.Respiratory.InitialVentSetting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="Form1" runat="server">
    <div class="container">
        <div class="jumbotron">
            <fieldset class="responsive-fieldset">
                <legend>Initial Ventilator Settings Calculator</legend>
                <div class="container">
                    <div class="row" align="center">
                        <div class="col-md-2">
                            <asp:DropDownList ID="DropDownListM_F" runat="server">
                                <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                                <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="TextBoxHeight" runat="server" Width="75"></asp:TextBox>
                        </div>
                        
                        <div class="col-md-2">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ErrorMessage="RequiredFieldValidator" ControlToValidate="TextBoxHeight"></asp:RequiredFieldValidator></div>
                        <div class="col-md-2">
                            <asp:DropDownList ID="DropDownListInchesOrCm" runat="server">
                                <asp:ListItem Text="inches" Value="inches"></asp:ListItem>
                                <asp:ListItem Text="cm" Value="cm"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-2">Ideal Body Weight</div>
                        <div class="col-md-2">
                            <asp:Label ID="LabelIBW" runat="server" Text="IBW"></asp:Label>
                        </div>
                    </div>
                    <div class="row" align="center">
                        <div class="col-md-2">
                            &nbsp;
                        </div>
                        <div class="col-md-2">
                            1 ft = 12 inches
                        </div>
                        <div class="col-md-2">1 inch = 2.54 cm</div>
                        <div class="col-md-2">
                        &nbsp;
                        </div>
                        <div class="col-md-2">
                        &nbsp;
                        </div>
                        <div class="col-md-2">
                        &nbsp;
                        </div>
                    </div>
                    <div class="row" align="center">
                        <div class="col-md-12">&nbsp;</div>
                    </div>
                    <div class="row" align="center">
                        <div class="col-md-12">
                            <asp:Button ID="ButtonAnalyze" runat="server" Text="Solve" OnClick="ButtonAnalyze_Click" /></div>
                        </div>
                    <div class="row" align="center">
                        <div class="col-md-12">
                            <asp:Label ID="LabelErrorMsg" runat="server"></asp:Label>
                            &nbsp;</div>
                    </div>
                    <asp:Panel ID="PanelVentTable" runat="server" Visible="False">
                        <div class="table-responsive" id="ventTable">
                            <table class="table">
                                <tr>
                                    <th>
                                        5mL/kg
                                    </th>
                                    <th>
                                        6mL/kg
                                    </th>
                                    <th>
                                        7mL/kg
                                    </th>
                                    <th>
                                        8mL/kg
                                    </th>
                                    <th>
                                        9mL/kg
                                    </th>
                                    <th>
                                        10mL/kg
                                    </th>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label5ml" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label6ml" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label7ml" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label8ml" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label9ml" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label10ml" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </asp:Panel>
               </div>
            </fieldset>
        </div>
    </div>
    </form>
</asp:Content>
