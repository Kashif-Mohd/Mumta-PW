<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="dashboardRandom.aspx.cs" Inherits="maamta_pw.dashboardRandom" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .highlighted {
            color: Red !important;
            background-color: blue !important;
        }


        .ball {
            animation: bounce 1s infinite;
            animation-duration: 10s;
            -moz-animation: bounce 2s linear;
            -webkit-animation: bounce 2s linear;
        }

        @keyframes bounce {

            0% {
                transform: translateY(6px);
            }

            5% {
                transform: translateY(8px);
            }

            10% {
                transform: translateY(12px);
            }

            15% {
                transform: translateY(20px);
            }

            20% {
                transform: translateY(38px);
            }

            25% {
                transform: translateY(72px);
            }

            30% {
                transform: translateY(100px);
            }

            35% {
                transform: translateY(152px);
            }

            40% {
                transform: translateY(154px) scale(1.1, .9);
            }

            50% {
                transform: translateY(176px) scale(1.4, .6);
            }

            55% {
                transform: translateY(162px) scale(1.2, .8);
            }

            60% {
                transform: translateY(138px) scale(1.05, .95);
            }

            65% {
                transform: translateY(110px);
            }

            70% {
                transform: translateY(72px);
            }

            75% {
                transform: translateY(38px);
            }

            80% {
                transform: translateY(20px);
            }

            85% {
                transform: translateY(12px);
            }

            90% {
                transform: translateY(8px);
            }

            95% {
                transform: translateY(5px);
            }

            100% {
                transform: translateY(5px);
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div class="ballaaa">
        <div style="background-color: #095e66; margin: 0 0 10px 10px; -moz-box-shadow: 0 6px 6px -6px gray; box-shadow: 0 6px 6px -6px gray;">
            <h1 style="text-align: center; margin-top: 10px; font-size: 28px; word-spacing: 5px; color: white; text-transform: capitalize; background-color: #55efc4; padding-top: 8px; padding-bottom: 7px; font-family: Arial"><b>Randomization Team Performance</b></h1>
        </div>
        <table style="width: 40%; text-align: center; margin-left: 30%; color: white; border-collapse: collapse; margin-top: 40px; margin-bottom: 0px">
            <tr class="trCSS" style="padding: 10px">
                <td class="TableColumn" style="background-color: #8dd9fc; border-radius: 10px; font-size: 20px; text-align: center; padding: 10px;"><b>TOTAL ENROLLMENT</b><br />
                    <asp:Label ID="lbeTotalEnrollment" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>

        <div style="width: 100%; text-align: center; overflow: auto; margin-top: 0px">


            <asp:Chart ID="Chart2" runat="server" Width="1000" Height="400px">
                <Series>
                    <asp:Series Name="Series2">
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea2">
                        <AxisX Interval="1" TextOrientation="Rotated90">
                        </AxisX>
                    </asp:ChartArea>
                </ChartAreas>
                <Titles>
                    <asp:Title Docking="Left" Name="Left Title" Text="Total" Font="Arial Rounded MT Bold, 12pt, ">
                    </asp:Title>
                    <asp:Title Docking="Bottom" Name="Bottom Title" Text="Year" Font="Arial Rounded MT Bold, 12pt, ">
                    </asp:Title>
                    <asp:Title Name="Top" Text="Enrollment" Font="Arial Rounded MT Bold, 18pt, ">
                    </asp:Title>
                </Titles>
            </asp:Chart>

        </div>


    </div>


    <hr style="border-top: 1px solid #ccc; background: transparent;" />






    <div style="text-align: right; margin-top: 8px">

        <button type="button" id="btnExport" class="btn btn-success" runat="server" style="height: 38px" onserverclick="btnExport_Click">
            CRF-2 Report &nbsp<span class="glyphicon glyphicon-export"></span>
        </button>


        <button type="button" id="btnExport_CRF6_R1" class="btn btn-success" runat="server" style="height: 38px" onserverclick="btnExport_CRF6_R1_Click">
            CRF-6 Report (1) &nbsp<span class="glyphicon glyphicon-export"></span>
        </button>

        <button type="button" id="btnExport_CRF6_R2" class="btn btn-success" runat="server" style="height: 38px" onserverclick="btnExport_CRF6_R2_Click">
            CRF-6 Report (2) &nbsp<span class="glyphicon glyphicon-export"></span>
        </button>

    </div>



    <div style="text-align: center; margin-top: 10px;">
        <%-- <asp:CheckBox ID="CheckBox1" runat="server" Text="Disable Date" OnCheckedChanged="CheckBox1_CheckedChanged" AutoPostBack="true" CssClass="mycheckbox" />
                <br>--%>

        <asp:TextBox ID="txtCalndrDate" Font-Bold="true" Font-Size="16px" CssClass="txtboxx" Height="32px" runat="server" Width="8.0em"></asp:TextBox>
        <asp:ImageButton ID="btnCalndrDate" ImageUrl="~/assets/img/calendar1.png" CssClass="calanderButton" runat="server" />
        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtCalndrDate" PopupButtonID="btnCalndrDate" Format="dd-MM-yyyy" />
        &nbsp To &nbsp
                <asp:TextBox ID="txtCalndrDate1" Font-Bold="true" Font-Size="16px" CssClass="txtboxx" Height="32px" runat="server" Width="8.0em"></asp:TextBox>
        <asp:ImageButton ID="btnCalndrDate1" ImageUrl="~/assets/img/calendar1.png" CssClass="calanderButton" runat="server" />
        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtCalndrDate1" PopupButtonID="btnCalndrDate1" Format="dd-MM-yyyy" />
        <asp:Button ID="btnSearch" runat="server" class="btn btn-theme" OnClick="btnSearch_Click" Text="Search" />
    </div>




    <div style="padding-left: 1%; margin-top: -10px; width: 100%; overflow: auto">

        <div style="color: #ff6b6b; font-size: 20px; font-family: Arial"><b><u>Team Status</u>:</b></div>

        <br />
        <asp:GridView ID="GridView1" runat="server" EmptyDataText="No Record Found." CssClass="footable" ForeColor="#333333" AutoGenerateColumns="true">



            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#00b894" ForeColor="white" Font-Bold="True" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>



    </div>











    <%--Report: Date Wise--%>
    <asp:GridView ID="GridView5" runat="server" CssClass="footable" ForeColor="#333333" AutoGenerateColumns="true">
    </asp:GridView>

    <%--Report: Date without Date--%>
    <asp:GridView ID="GridView6" runat="server" CssClass="footable" ForeColor="#333333" AutoGenerateColumns="true">
    </asp:GridView>

    <%--ARM: Date Wise--%>
    <asp:GridView ID="GridView8" runat="server" CssClass="footable" ForeColor="#333333" AutoGenerateColumns="true">
    </asp:GridView>

    <%--ARM: without Date--%>
    <asp:GridView ID="GridView9" runat="server" CssClass="footable" ForeColor="#333333" AutoGenerateColumns="true">
    </asp:GridView>

    <asp:GridView ID="GridView10" runat="server" CssClass="footable" ForeColor="#333333" AutoGenerateColumns="true">
    </asp:GridView>






    <%--CRF6 Report1: Table-1 --%>
    <asp:GridView ID="GridView_CRF6_01" runat="server" CssClass="footable" ForeColor="#333333" AutoGenerateColumns="true">
    </asp:GridView>
    <%--CRF6 Report1: Table-2 --%>
    <asp:GridView ID="GridView_CRF6_02" runat="server" CssClass="footable" ForeColor="#333333" AutoGenerateColumns="true">
    </asp:GridView>
    <%--CRF6 Report1:  Table-3 --%>
    <asp:GridView ID="GridView_CRF6_03" runat="server" CssClass="footable" ForeColor="#333333" AutoGenerateColumns="true">
    </asp:GridView>
    <%--CRF6 Report1:  Table-4 --%>
    <asp:GridView ID="GridView_CRF6_04" runat="server" CssClass="footable" ForeColor="#333333" AutoGenerateColumns="true">
    </asp:GridView>
    <%--CRF6 Report1:  Table-7 --%>
    <asp:GridView ID="GridView_CRF6_07" runat="server" CssClass="footable" ForeColor="#333333" AutoGenerateColumns="true">
    </asp:GridView>
    <%--CRF6 Report1:  Table-8 --%>
    <asp:GridView ID="GridView_CRF6_08" runat="server" CssClass="footable" ForeColor="#333333" AutoGenerateColumns="true">
    </asp:GridView>







    <%--CRF6 Report2: Table-1 --%>
    <asp:GridView ID="GridView_CRF6_R2_01" runat="server" CssClass="footable" ForeColor="#333333" AutoGenerateColumns="true">
    </asp:GridView>
    <%--CRF6 Report2: Table-2 --%>
    <asp:GridView ID="GridView_CRF6_R2_02" runat="server" CssClass="footable" ForeColor="#333333" AutoGenerateColumns="true">
    </asp:GridView>
    <%--CRF6 Report2: Table-3 --%>
    <asp:GridView ID="GridView_CRF6_R2_03" runat="server" CssClass="footable" ForeColor="#333333" AutoGenerateColumns="true">
    </asp:GridView>
    <%--CRF6 Report2: Table-3 details --%>
    <asp:GridView ID="GridView_CRF6_R2_03_Details" runat="server" CssClass="footable" ForeColor="#333333" AutoGenerateColumns="true">
    </asp:GridView>
    <%--CRF6 Report2: Table-4 --%>
    <asp:GridView ID="GridView_CRF6_R2_04" runat="server" CssClass="footable" ForeColor="#333333" AutoGenerateColumns="true">
    </asp:GridView>
    <%--CRF6 Report2: Table-5 --%>
    <asp:GridView ID="GridView_CRF6_R2_05" runat="server" CssClass="footable" ForeColor="#333333" AutoGenerateColumns="true">
    </asp:GridView>



</asp:Content>
