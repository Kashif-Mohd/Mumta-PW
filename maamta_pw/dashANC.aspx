<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="dashANC.aspx.cs" Inherits="maamta_pw.dashANC" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--  <style>
        .mycheckbox {
            margin-right: 22px;
            font-size: 17px;
            font-family: Arial;
        }

        .btnChng {
            background-color: #4e94ba;
            border: 0px solid #2574A9;
            display: inline-block;
            cursor: pointer;
            color: white;
            font-family: arial;
            font-size: 16px;
            padding: 4px 28px;
            text-decoration: none;
            font-weight: bold;
        }

            /*.btnSrch:hover {
                background-color: #2574A9;
            }*/

            .btnChng:active {
                position: relative;
                top: 1px;
            }
    </style>--%>

    <style>
        .ball {
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

    <br>
    <br>
       <div class="ballaaa">

     <div style="background-color: #095e66; margin: 0 0 10px 10px; -moz-box-shadow: 0 6px 6px -6px gray; box-shadow: 0 6px 6px -6px gray;">
        <h1 style="text-align: center; margin-top: 10px; font-size: 28px; word-spacing: 5px; color: white; text-transform: capitalize; background-color: #55efc4; padding-top: 8px; padding-bottom: 7px; font-family: Arial"><b>ANC-Visit Team</b></h1>
    </div>

    <br>

    <div class="Mobile">
        <table style="width: 100%; font-size: 1em; color: #4f5963; text-align: left; margin-top: 10px;">
            <tr class="trCSS">
                <td class="TableColumn tdCSS">Total number of forms has been entered:</td>
                <th class=" tdCSS">
                    <asp:Label ID="lbeTotal" runat="server" Text="0"></asp:Label>
                </th>
            </tr>
            <tr class="trCSS">
                <td class="TableColumn tdCSS">Total duplicate DSSD on same date:</td>
                <th class=" tdCSS">
                    <asp:LinkButton ID="linkDuplicate" OnClick="Link_Duplicate" Text="0" runat="server"></asp:LinkButton>
                </th>
            </tr>
        </table>
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

    <div style="padding-left: 2%; margin-top: -5px;">

        <div style="color: #ff5533; font-size: 20px; font-family: Arial"><b><u>Team Status</u>:</b></div>

        <div style="width: 100%; overflow: auto; margin-top: 5px">
            <asp:GridView ID="GridView1" runat="server" EmptyDataText="No Record Found." CssClass="footable" ForeColor="#333333" AutoGenerateColumns="false" OnRowDataBound="OnRowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="Serial no.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                        <ItemStyle Width="2%" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="sra_name" HeaderText="User Name" />
                    <asp:BoundField DataField="total" HeaderText="Total Entered Form" />
                </Columns>


                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />

                <HeaderStyle BackColor="#00b894" ForeColor="white" Font-Bold="True" />
                <PagerSettings Position="TopAndBottom" Mode="NumericFirstLast" PreviousPageText="&amp;lt;" PageButtonCount="13" />
                <PagerStyle BackColor="#284775" ForeColor="White" CssClass="StylePager" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
        </div>
    </div>

           </div>

    <hr style="border-top: 1px solid #ccc; background: transparent;">
    

    <br>
</asp:Content>
