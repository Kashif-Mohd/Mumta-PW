<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="dashWorkerPerformance.aspx.cs" Inherits="maamta_pw.dashboardCompANC" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <style>
        .shakeee {
            animation: shake 0.5s;
            animation-iteration-count: infinite;
            -moz-animation: shake 1s linear;
            -webkit-animation: shake 1.2s linear;
        }

        @keyframes shake {
            0% {
                transform: translate(1px, 1px) rotate(0deg);
            }

            10% {
                transform: translate(-1px, -2px) rotate(-1deg);
            }

            20% {
                transform: translate(-3px, 0px) rotate(1deg);
            }

            30% {
                transform: translate(3px, 2px) rotate(0deg);
            }

            40% {
                transform: translate(1px, -1px) rotate(1deg);
            }

            50% {
                transform: translate(-1px, 2px) rotate(-1deg);
            }

            60% {
                transform: translate(-3px, 1px) rotate(0deg);
            }

            70% {
                transform: translate(3px, 1px) rotate(-1deg);
            }

            80% {
                transform: translate(-1px, -1px) rotate(1deg);
            }

            90% {
                transform: translate(1px, 2px) rotate(0deg);
            }

            100% {
                transform: translate(1px, -2px) rotate(-1deg);
            }
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">

        <ContentTemplate>

            <asp:UpdateProgress ID="updateProgress" runat="server">
                <ProgressTemplate>
                    <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.75;">
                        <span style="border-width: 0px; border-radius: 10px; position: fixed; padding: 4%; color: white; background-color: #A3CB38; font-size: 36px; left: 40%; top: 40%;">Loading ...</span>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>


            <div style="background-color: #095e66; margin: 0 0 10px 10px; -moz-box-shadow: 0 6px 6px -6px gray; box-shadow: 0 6px 6px -6px gray;">
                <h1 style="text-align: center; margin-top: 10px; font-size: 28px; word-spacing: 5px; color: white; text-transform: capitalize; background-color: #55efc4; padding-top: 8px; padding-bottom: 7px; font-family: Arial"><b>Worker Performance</b></h1>
            </div>

            <div style="text-align: center; margin-top: 30px;">

                <asp:TextBox ID="txtCalndrDate" Font-Bold="true" Font-Size="16px" CssClass="txtboxx" Height="32px" runat="server" Width="8.0em"></asp:TextBox>
                <asp:ImageButton ID="btnCalndrDate" ImageUrl="~/assets/img/calendar1.png" CssClass="calanderButton" runat="server" />
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtCalndrDate" PopupButtonID="btnCalndrDate" Format="dd-MM-yyyy" />
                &nbsp To &nbsp
                <asp:TextBox ID="txtCalndrDate1" Font-Bold="true" Font-Size="16px" CssClass="txtboxx" Height="32px" runat="server" Width="8.0em"></asp:TextBox>
                <asp:ImageButton ID="btnCalndrDate1" ImageUrl="~/assets/img/calendar1.png" CssClass="calanderButton" runat="server" />
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtCalndrDate1" PopupButtonID="btnCalndrDate1" Format="dd-MM-yyyy" />
                <asp:Button ID="btnSearch" runat="server" class="btn btn-theme" OnClick="btnSearch_Click" Text="Search" />
            </div>






            <table style="width: 40%; text-align: center; margin-left: 30%; color: white; border-collapse: collapse; margin-top: 40px; margin-bottom: 0px">
                <tr class="trCSS" style="padding: 10px">
                    <td class="TableColumn" style="background-color: #8dd9fc; border-radius: 10px; font-size: 20px; text-align: center; padding: 10px;"><b>LNS Compliance (4) and Home ANC visits (5a)</b>
                    </td>
                </tr>
            </table>

            <div style="width: 100%; text-align: center; overflow: auto; margin-top: 30px">

                <asp:Chart ID="Chart1" runat="server" Width="1100" Height="400px" BorderSkin-BorderColor="Black" Palette="SemiTransparent">
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                    </ChartAreas>
                    <Legends>
                        <asp:Legend Name="Legend1" Title="Tab User" Font="Microsoft Sans Serif, 10.25pt" TitleFont="Arial Rounded MT Bold, 12.25pt">
                        </asp:Legend>
                    </Legends>
                    <Titles>
                        <asp:Title Docking="Left" Name="Left Title" Text="Total" Font="Arial Rounded MT Bold, 12pt, ">
                        </asp:Title>
                        <asp:Title Docking="Bottom" Name="Bottom Title" Text="Forms" Font="Arial Rounded MT Bold, 12pt, ">
                        </asp:Title>
                        <asp:Title Name="Top" Text="User Performance" Font="Arial Rounded MT Bold, 18pt, ">
                        </asp:Title>
                    </Titles>
                </asp:Chart>

            </div>


            <hr style="border-top: 1px solid #ccc; background: transparent;">


             <table style="width: 40%; text-align: center; margin-left: 30%; color: white; border-collapse: collapse; margin-top: 40px; margin-bottom: 0px">
                <tr class="trCSS" style="padding: 10px">
                    <td class="TableColumn" style="background-color: #8dd9fc; border-radius: 10px; font-size: 20px; text-align: center; padding: 10px;"><b>Anthro Form (5c) AND Outcome Anthro (6a, 6b)</b>
                    </td>
                </tr>
            </table>

            <div style="width: 100%; text-align: center; overflow: auto; margin-top: 30px">

                <asp:Chart ID="Chart2" runat="server" Width="1100" Height="400px" BorderSkin-BorderColor="Black" Palette="SemiTransparent">
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea2"></asp:ChartArea>
                    </ChartAreas>
                    <Legends>
                        <asp:Legend Name="Legend2" Title="Tab User" Font="Microsoft Sans Serif, 10.25pt" TitleFont="Arial Rounded MT Bold, 12.25pt">
                        </asp:Legend>
                    </Legends>
                    <Titles>
                        <asp:Title Docking="Left" Name="Left Title" Text="Total" Font="Arial Rounded MT Bold, 12pt, ">
                        </asp:Title>
                        <asp:Title Docking="Bottom" Name="Bottom Title" Text="Forms" Font="Arial Rounded MT Bold, 12pt, ">
                        </asp:Title>
                        <asp:Title Name="Top" Text="User Performance" Font="Arial Rounded MT Bold, 18pt, ">
                        </asp:Title>
                    </Titles>
                </asp:Chart>

            </div>


            <hr style="border-top: 1px solid #ccc; background: transparent;">

             <table style="width: 40%; text-align: center; margin-left: 30%; color: white; border-collapse: collapse; margin-top: 40px; margin-bottom: 0px">
                <tr class="trCSS" style="padding: 10px">
                    <td class="TableColumn" style="background-color: #8dd9fc; border-radius: 10px; font-size: 20px; text-align: center; padding: 10px;"><b>Choline and Nicotinamide (4b)</b>
                    </td>
                </tr>
            </table>

            <div style="width: 100%; text-align: center; overflow: auto; margin-top: 30px">

                <asp:Chart ID="Chart3" runat="server" Width="1100" Height="400px" BorderSkin-BorderColor="Black" Palette="SemiTransparent">
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea3"></asp:ChartArea>
                    </ChartAreas>
                    <Legends>
                        <asp:Legend Name="Legend3" Title="Tab User" Font="Microsoft Sans Serif, 10.25pt" TitleFont="Arial Rounded MT Bold, 12.25pt">
                        </asp:Legend>
                    </Legends>
                    <Titles>
                        <asp:Title Docking="Left" Name="Left Title" Text="Total" Font="Arial Rounded MT Bold, 12pt, ">
                        </asp:Title>
                        <asp:Title Docking="Bottom" Name="Bottom Title" Text="Forms" Font="Arial Rounded MT Bold, 12pt, ">
                        </asp:Title>
                        <asp:Title Name="Top" Text="User Performance" Font="Arial Rounded MT Bold, 18pt, ">
                        </asp:Title>
                    </Titles>
                </asp:Chart>

            </div>




            <br>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
