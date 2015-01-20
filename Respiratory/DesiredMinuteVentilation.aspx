<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DesiredMinuteVentilation.aspx.cs" Inherits="Demo2015_1.Respiratory.DesiredMinuteVentilation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form id="Form1" runat="server">
<div class="container">
        <div class="jumbotron">
            <fieldset>
                <legend>Desire Minute Ventilation Calculator</legend>
                <div class="container">
                    <div class="row" align="center">
                        <div class="col-md-2"></div>
                        <div class="col-md-8">
                            <asp:Label ID="LabelEquation" runat="server" Text=""></asp:Label>
                        </div>                        
                        <div class="col-md-2"></div>
                    </div>
                    <div class="row" align="center">
                        <div class="col-md-2">
                            &nbsp;</div>
                        <div class="col-md-8">
                            <asp:Label ID="LabelDescription" runat="server" Text=""></asp:Label>
                        </div>                        
                        <div class="col-md-2"></div>
                    </div>
                    <div class="row" align="center">
                        <div class="col-md-12">
                            &nbsp;</div>
                    </div> 
                    <div class="row" align="center">
                        <div class="col-md-2">
                            &nbsp;<asp:RequiredFieldValidator 
                                ID="RequiredFieldValidator1" runat="server" 
                                ErrorMessage="RequiredFieldValidator" ControlToValidate="txtKnownPCO2"></asp:RequiredFieldValidator></div>
                        <div class="col-md-2">
                            Known_PCO2 
                            mmHG</div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtKnownPCO2" runat="server" Width="75px"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            Known_Minute_Ventilation (L)</div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtKnownMV" runat="server" Width="75px"></asp:TextBox>
                        </div>
                        <div class="col-md-2"><asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                                runat="server" ErrorMessage="RequiredFieldValidator" 
                                ControlToValidate="txtKnownMV"></asp:RequiredFieldValidator></div>
                    </div>
                    <div class="row" align="center">
                        <div class="col-md-2">
                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ErrorMessage="RequiredFieldValidator" ControlToValidate="txtDesiredCo2"></asp:RequiredFieldValidator></div>
                        <div class="col-md-2">
                            Desired_CO2&nbsp; mmHG</div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtDesiredCo2" runat="server" Width="75px"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            </div>
                        <div class="col-md-2">                            
                        </div>
                        <div class="col-md-2"></div>
                    </div> 
                    <div class="row" align="center">
                        <div class="col-md-12">
                        Desired_Minute_Ventilation<hr />
                        <asp:TextBox ID="txtDesiredMV" runat="server" Height="100px" ReadOnly="True" 
                                TextMode="MultiLine" Width="200px"></asp:TextBox></div>
                    </div>               
                   <div class="row" align="center">
                        <div class="col-md-12">
                            <asp:Button ID="btnAnalyze" runat="server" Text="Analyze" 
                                onclick="btnAnalyze_Click"/></div>
                    </div>
                </div>
            </fieldset>
        </div>
    </div>

    </form>

</asp:Content>
