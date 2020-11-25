<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="NicotinamidePrtage.aspx.cs" Inherits="maamta_pw.NicotinamidePrtage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* For DropDown CSS */
        .textDropDownCSS {
            font-size: 1.2em;
            font-family: Calibri;
            Height: 2.4em;
            color: #16a085;
        }


        .btnChng {
            border: 0px solid #2574A9;
            display: inline-block;
            cursor: pointer;
            font-family: arial;
            font-size: 16px;
            padding: 4px 28px;
            text-decoration: none;
            font-weight: bold;
        }

            .btnChng:active {
                position: relative;
                top: 1px;
            }



        .StylePager {
            border-radius: 5px;
            text-align: left;
        }

            .StylePager a:hover {
                background-color: #33d9b2;
                margin-right: 3px;
                padding: 3px;
                border-radius: 3px;
            }

            .StylePager a {
                padding: 3px;
                margin-right: 3px;
            }

            .StylePager span {
                background: #FF4081;
                padding: 4px;
                border-radius: 3px;
                margin-right: 3px;
            }


        /* For Mobile Browser*/
        @media only screen and (max-width: 40em) {
            tddd, thhh {
                margin-top: 0.8em;
                display: block;
                text-align: center;
            }

            .Mobile {
                width: 90%;
                padding-left: 7%;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="padding-left: 2%; margin-top: 15px;">

        <div style="color: #ff6b6b; font-size: 22px; width: 100%">
            Nicotinamide Cumulative Percentage:
        </div>
        <hr style="border-top: 1px solid #ccc; background: transparent; margin-top: -3px">




        <table style="text-align: center; width: 100%; font-family: Tahoma; margin-top: -17px">
            <tr>
                <td>
                    <asp:Button ID="btnGraph" OnClick="btnGraph_Click" CssClass="btnChng" runat="server" Text="Graph" Width="100%" Style="text-align: center; border-bottom-left-radius: 14px; border-top-left-radius: 14px; margin-top: 10px; text-transform: capitalize; padding-top: 7px; padding-bottom: 6px" />
                </td>
                <td>
                    <asp:Button ID="btnForms" OnClick="btnForms_Click" CssClass="btnChng" runat="server" Text="Data" Width="100%" Style="text-align: center; border-bottom-right-radius: 14px; border-top-right-radius: 14px; margin-top: 10px; text-transform: capitalize; padding-top: 7px; padding-bottom: 6px" />
                </td>
            </tr>
        </table>







        <div style="width: 100%; text-align: center; overflow: auto; margin-top: 30px" id="divGraph" runat="server">

            <asp:Chart ID="Chart1" runat="server" Width="1000" Height="400px" Visible="true">
                <Series>
                    <asp:Series Name="Series1">
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                </ChartAreas>
                <Titles>
                    <asp:Title Docking="Left" Name="Left Title" Text="Total" Font="Arial Rounded MT Bold, 12pt, ">
                    </asp:Title>
                    <asp:Title Docking="Bottom" Name="Bottom Title" Text="Percentage" Font="Arial Rounded MT Bold, 12pt, ">
                    </asp:Title>

                    <asp:Title Name="Top" Text="Nicotinamide (Cumulative)" Font="Arial Rounded MT Bold, 18pt, ">
                    </asp:Title>
                </Titles>
            </asp:Chart>


            <hr style="border-top: 1px solid #ccc; background: transparent; margin-top: 0px">

            <table style="text-align: center; width: 100%; font-family: Tahoma; margin-top: -17px">
                <tr>
                    <td>
                        <asp:Button ID="btnGridViewGraphR1" OnClick="btnGridViewGraphR1_Click" CssClass="btnChng" runat="server" Text="Greater than 75.0%" Width="100%" Style="text-align: center; border-bottom-left-radius: 14px; border-top-left-radius: 14px; margin-top: 10px; text-transform: capitalize; padding-top: 7px; padding-bottom: 6px" />
                    </td>
                    <td>
                        <asp:Button ID="btnGridViewGraphR2" OnClick="btnGridViewGraphR2_Click" CssClass="btnChng" runat="server" Text="70.0% to 74.9%" Width="100%" Style="text-align: center; margin-top: 10px; text-transform: capitalize; padding-top: 7px; padding-bottom: 6px" />
                    </td>
                    <td>
                        <asp:Button ID="btnGridViewGraphR3" OnClick="btnGridViewGraphR3_Click" CssClass="btnChng" runat="server" Text="60.0% to 69.9%" Width="100%" Style="text-align: center; margin-top: 10px; text-transform: capitalize; padding-top: 7px; padding-bottom: 6px" />
                    </td>
                    <td>
                        <asp:Button ID="btnGridViewGraphR4" OnClick="btnGridViewGraphR4_Click" CssClass="btnChng" runat="server" Text="50.1% to 59.9%" Width="100%" Style="text-align: center; margin-top: 10px; text-transform: capitalize; padding-top: 7px; padding-bottom: 6px" />
                    </td>
                    <td>
                        <asp:Button ID="btnGridViewGraphR5" OnClick="btnGridViewGraphR5_Click" CssClass="btnChng" runat="server" Text="Less and equal than 50.0%" Width="100%" Style="text-align: center; border-bottom-right-radius: 14px; border-top-right-radius: 14px; margin-top: 10px; text-transform: capitalize; padding-top: 7px; padding-bottom: 6px" />
                    </td>
                </tr>
            </table>




            <div id="divGridViewGraphR1" runat="server" style="width: 100%; height: 450px; overflow: scroll; margin-top: 20px">
                <asp:GridView ID="GridViewGraphR1" runat="server" EmptyDataText="No Record Found." AllowPaging="True" PageSize="200" OnPageIndexChanging="GridViewGraphR1_PageIndexChanging" CssClass="footable" AllowSorting="false" ForeColor="#333333" AutoGenerateColumns="false">
                    <Columns>
                        <asp:TemplateField HeaderText="Serial no.">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                            <ItemStyle Width="2%" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="study_code" HeaderText="Study ID" />
                        <asp:BoundField DataField="dssid" HeaderText="DSSID" />
                        <asp:BoundField DataField="woman_nm" HeaderText="Woman Name" />
                        <asp:BoundField DataField="husband_nm" HeaderText="Husband Name" />
                        <asp:BoundField DataField="last_DOV" HeaderText="Last DOV" />
                        <asp:BoundField DataField="Consumed_Nicotinamide" HeaderText="Consumed Nicotinamide" />
                        <asp:BoundField DataField="Need_to_be_used" HeaderText="Need to be used Nicotinamide" />
                        <asp:BoundField DataField="Percentage" HeaderText="Percentage" />
                        <asp:BoundField DataField="Pregnancy_Status" HeaderText="Status" />
                        <asp:BoundField DataField="gestational_age" HeaderText="Gestational Age" />
                    </Columns>

                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#33d9b2" ForeColor="white" Font-Bold="True" Height="40px" />
                    <PagerStyle BackColor="#576574" ForeColor="White" CssClass="StylePager" />
                    <PagerSettings Position="TopAndBottom" Mode="NumericFirstLast" PreviousPageText="&amp;lt;" PageButtonCount="13" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
            </div>



            <div id="divGridViewGraphR2" visible="false" runat="server" style="width: 100%; height: 450px; overflow: scroll; margin-top: 20px">
                <asp:GridView ID="GridViewGraphR2" runat="server" EmptyDataText="No Record Found." AllowPaging="True" PageSize="200" OnPageIndexChanging="GridViewGraphR2_PageIndexChanging" CssClass="footable" AllowSorting="false" ForeColor="#333333" AutoGenerateColumns="false">
                    <Columns>
                        <asp:TemplateField HeaderText="Serial no.">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                            <ItemStyle Width="2%" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="study_code" HeaderText="Study ID" />
                        <asp:BoundField DataField="dssid" HeaderText="DSSID" />
                        <asp:BoundField DataField="woman_nm" HeaderText="Woman Name" />
                        <asp:BoundField DataField="husband_nm" HeaderText="Husband Name" />
                        <asp:BoundField DataField="last_DOV" HeaderText="Last DOV" />
                        <asp:BoundField DataField="Consumed_Nicotinamide" HeaderText="Consumed Nicotinamide" />
                        <asp:BoundField DataField="Need_to_be_used" HeaderText="Need to be used Nicotinamide" />
                        <asp:BoundField DataField="Percentage" HeaderText="Percentage" />
                        <asp:BoundField DataField="Pregnancy_Status" HeaderText="Status" />
                        <asp:BoundField DataField="gestational_age" HeaderText="Gestational Age" />
                    </Columns>

                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#33d9b2" ForeColor="white" Font-Bold="True" Height="40px" />
                    <PagerStyle BackColor="#576574" ForeColor="White" CssClass="StylePager" />
                    <PagerSettings Position="TopAndBottom" Mode="NumericFirstLast" PreviousPageText="&amp;lt;" PageButtonCount="13" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
            </div>



            <div id="divGridViewGraphR3" visible="false" runat="server" style="width: 100%; height: 450px; overflow: scroll; margin-top: 20px">
                <asp:GridView ID="GridViewGraphR3" runat="server" EmptyDataText="No Record Found." AllowPaging="True" PageSize="200" OnPageIndexChanging="GridViewGraphR3_PageIndexChanging" CssClass="footable" AllowSorting="false" ForeColor="#333333" AutoGenerateColumns="false">
                    <Columns>
                        <asp:TemplateField HeaderText="Serial no.">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                            <ItemStyle Width="2%" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="study_code" HeaderText="Study ID" />
                        <asp:BoundField DataField="dssid" HeaderText="DSSID" />
                        <asp:BoundField DataField="woman_nm" HeaderText="Woman Name" />
                        <asp:BoundField DataField="husband_nm" HeaderText="Husband Name" />
                        <asp:BoundField DataField="last_DOV" HeaderText="Last DOV" />
                        <asp:BoundField DataField="Consumed_Nicotinamide" HeaderText="Consumed Nicotinamide" />
                        <asp:BoundField DataField="Need_to_be_used" HeaderText="Need to be used Nicotinamide" />
                        <asp:BoundField DataField="Percentage" HeaderText="Percentage" />
                        <asp:BoundField DataField="Pregnancy_Status" HeaderText="Status" />
                        <asp:BoundField DataField="gestational_age" HeaderText="Gestational Age" />
                    </Columns>

                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#33d9b2" ForeColor="white" Font-Bold="True" Height="40px" />
                    <PagerStyle BackColor="#576574" ForeColor="White" CssClass="StylePager" />
                    <PagerSettings Position="TopAndBottom" Mode="NumericFirstLast" PreviousPageText="&amp;lt;" PageButtonCount="13" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
            </div>



            <div id="divGridViewGraphR4" visible="false" runat="server" style="width: 100%; height: 450px; overflow: scroll; margin-top: 20px">
                <asp:GridView ID="GridViewGraphR4" runat="server" EmptyDataText="No Record Found." AllowPaging="True" PageSize="200" OnPageIndexChanging="GridViewGraphR4_PageIndexChanging" CssClass="footable" AllowSorting="false" ForeColor="#333333" AutoGenerateColumns="false">
                    <Columns>
                        <asp:TemplateField HeaderText="Serial no.">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                            <ItemStyle Width="2%" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="study_code" HeaderText="Study ID" />
                        <asp:BoundField DataField="dssid" HeaderText="DSSID" />
                        <asp:BoundField DataField="woman_nm" HeaderText="Woman Name" />
                        <asp:BoundField DataField="husband_nm" HeaderText="Husband Name" />
                        <asp:BoundField DataField="last_DOV" HeaderText="Last DOV" />
                        <asp:BoundField DataField="Consumed_Nicotinamide" HeaderText="Consumed Nicotinamide" />
                        <asp:BoundField DataField="Need_to_be_used" HeaderText="Need to be used Nicotinamide" />
                        <asp:BoundField DataField="Percentage" HeaderText="Percentage" />
                        <asp:BoundField DataField="Pregnancy_Status" HeaderText="Status" />
                        <asp:BoundField DataField="gestational_age" HeaderText="Gestational Age" />
                    </Columns>

                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#33d9b2" ForeColor="white" Font-Bold="True" Height="40px" />
                    <PagerStyle BackColor="#576574" ForeColor="White" CssClass="StylePager" />
                    <PagerSettings Position="TopAndBottom" Mode="NumericFirstLast" PreviousPageText="&amp;lt;" PageButtonCount="13" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
            </div>


            <div id="divGridViewGraphR5" visible="false" runat="server" style="width: 100%; height: 450px; overflow: scroll; margin-top: 20px">
                <asp:GridView ID="GridViewGraphR5" runat="server" EmptyDataText="No Record Found." AllowPaging="True" PageSize="200" OnPageIndexChanging="GridViewGraphR5_PageIndexChanging" CssClass="footable" AllowSorting="false" ForeColor="#333333" AutoGenerateColumns="false">
                    <Columns>
                        <asp:TemplateField HeaderText="Serial no.">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                            <ItemStyle Width="2%" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="study_code" HeaderText="Study ID" />
                        <asp:BoundField DataField="dssid" HeaderText="DSSID" />
                        <asp:BoundField DataField="woman_nm" HeaderText="Woman Name" />
                        <asp:BoundField DataField="husband_nm" HeaderText="Husband Name" />
                        <asp:BoundField DataField="last_DOV" HeaderText="Last DOV" />
                        <asp:BoundField DataField="Consumed_Nicotinamide" HeaderText="Consumed Nicotinamide" />
                        <asp:BoundField DataField="Need_to_be_used" HeaderText="Need to be used Nicotinamide" />
                        <asp:BoundField DataField="Percentage" HeaderText="Percentage" />
                        <asp:BoundField DataField="Pregnancy_Status" HeaderText="Status" />
                        <asp:BoundField DataField="gestational_age" HeaderText="Gestational Age" />
                    </Columns>

                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#33d9b2" ForeColor="white" Font-Bold="True" Height="40px" />
                    <PagerStyle BackColor="#576574" ForeColor="White" CssClass="StylePager" />
                    <PagerSettings Position="TopAndBottom" Mode="NumericFirstLast" PreviousPageText="&amp;lt;" PageButtonCount="13" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
            </div>





        </div>












        <div id="divForms" runat="server">

            <div id="divExportButton" runat="server" style="text-align: right; margin-top: 10px">
                <button type="button" id="Button1" class="btn btn-success" runat="server" style="height: 38px" onserverclick="btnExport_Click">
                    Export &nbsp<span class="glyphicon glyphicon-export"></span>
                </button>
            </div>

            <%--Search Button--%>
            <div id="divSearch" runat="server" class="col-lg-4 col-lg-offset-4" style="margin-bottom: 10px; margin-top: -10px;">




                <%--Start    Date checks--%>

                <div class="Mobile" id="calendar" runat="server">
                    <table style="width: 100%; text-align: center; margin-left: 6%; margin-bottom: 15px">
                        <tr>
                            <td class="tddd">&nbsp <b>DATE: </b>&nbsp
                                <asp:TextBox ID="txtCalndrDate_Nicotinamide" Font-Bold="true" Font-Size="16px" ClientIDMode="Static" CssClass="txtboxx" Height="32px" runat="server" Width="8.0em"></asp:TextBox>
                                <asp:ImageButton ID="btnCalndrDate" ImageUrl="~/assets/img/calendar1.png" CssClass="calanderButton" runat="server" />
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtCalndrDate_Nicotinamide" PopupButtonID="btnCalndrDate" Format="dd-MM-yyyy" />
                            </td>
                        </tr>
                    </table>
                </div>

                <%--End   Date checks--%>



                <div id="imaginary_container" style="margin-top: 10px">
                    <div class="input-group stylish-input-group">
                        <asp:TextBox ID="txtdssid" CssClass="form-control txtboxx" ClientIDMode="Static" runat="server" placeholder="Complete DSSID" MaxLength="11" ForeColor="Black"></asp:TextBox>
                        <span class="input-group-addon">
                            <button type="submit" id="btnSearch" runat="server" style="height: 20px" onserverclick="btnSearch_Click">
                                <span class="glyphicon glyphicon-search"></span>
                            </button>
                        </span>
                    </div>
                </div>

            </div>

            <div style="width: 100%; height: 450px; overflow: scroll; margin-top: 20px">
                <asp:GridView ID="GridView1" runat="server" EmptyDataText="No Record Found." OnRowDataBound="OnRowDataBound" AllowPaging="True" PageSize="200" OnPageIndexChanging="GridView1_PageIndexChanging" CssClass="footable" AllowSorting="false" ForeColor="#333333" AutoGenerateColumns="false">
                    <Columns>
                        <asp:TemplateField HeaderText="Serial no.">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                            <ItemStyle Width="2%" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="study_code" HeaderText="Study ID" />
                        <asp:BoundField DataField="dssid" HeaderText="DSSID" />
                        <asp:BoundField DataField="woman_nm" HeaderText="Woman Name" />
                        <asp:BoundField DataField="husband_nm" HeaderText="Husband Name" />
                        <asp:BoundField DataField="CRF4b_Attempt" HeaderText="CRF4b Attempt" />
                        <asp:BoundField DataField="CRF4b_Complete" HeaderText="CRF4b Complete" />
                        <asp:BoundField DataField="last_DOV" HeaderText="Last DOV" />
                        <asp:BoundField DataField="Consumed_Nicotinamide" HeaderText="Consumed Nicotinamide" />
                        <asp:BoundField DataField="Need_to_be_used" HeaderText="Need to be used Nicotinamide" />
                        <asp:BoundField DataField="Percentage" HeaderText="Cumulative Nicotinamide Percentage" />
                        <asp:BoundField DataField="Pregnancy_Status" HeaderText="Status" />
                        <asp:BoundField DataField="gestational_age" HeaderText="Gestational Age" />
                    </Columns>

                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#33d9b2" ForeColor="white" Font-Bold="True" Height="40px" />
                    <PagerStyle BackColor="#576574" ForeColor="White" CssClass="StylePager" />
                    <PagerSettings Position="TopAndBottom" Mode="NumericFirstLast" PreviousPageText="&amp;lt;" PageButtonCount="13" />

                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>




                <asp:GridView ID="GridView2" runat="server" EmptyDataText="No Record Found." OnRowDataBound="OnRowDataBound" CssClass="footable" AllowSorting="false" ForeColor="#333333" AutoGenerateColumns="false">
                    <Columns>
                        <asp:TemplateField HeaderText="Serial no.">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                            <ItemStyle Width="2%" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="study_code" HeaderText="Study ID" />
                        <asp:BoundField DataField="dssid" HeaderText="DSSID" />
                        <asp:BoundField DataField="woman_nm" HeaderText="Woman Name" />
                        <asp:BoundField DataField="husband_nm" HeaderText="Husband Name" />
                        <asp:BoundField DataField="CRF4b_Attempt" HeaderText="CRF4b Attempt" />
                        <asp:BoundField DataField="CRF4b_Complete" HeaderText="CRF4b Complete" />
                        <asp:BoundField DataField="Consumed_Nicotinamide" HeaderText="Consumed Nicotinamide" />
                        <asp:BoundField DataField="Need_to_be_used" HeaderText="Need to be used Nicotinamide" />
                        <asp:BoundField DataField="last_DOV" HeaderText="Last DOV" />
                        <asp:BoundField DataField="Percentage" HeaderText="Cumulative Nicotinamide Percentage" />
                        <asp:BoundField DataField="last_DOV_date" HeaderText="Last DOV (Seleted Date)" />
                        <asp:BoundField DataField="Percentage_date" HeaderText="Cumulative Nicotinamide Percentage (Seleted Date)" />
                        <asp:BoundField DataField="Pregnancy_Status" HeaderText="Status" />
                        <asp:BoundField DataField="gestational_age" HeaderText="Gestational Age" />
                        <asp:BoundField DataField="F1" HeaderText="F1" />
                        <asp:BoundField DataField="F2" HeaderText="F2" />
                        <asp:BoundField DataField="F3" HeaderText="F3" />
                        <asp:BoundField DataField="F4" HeaderText="F4" />
                        <asp:BoundField DataField="F5" HeaderText="F5" />
                        <asp:BoundField DataField="F6" HeaderText="F6" />
                        <asp:BoundField DataField="F7" HeaderText="F7" />
                        <asp:BoundField DataField="F8" HeaderText="F8" />
                        <asp:BoundField DataField="F9" HeaderText="F9" />
                        <asp:BoundField DataField="F10" HeaderText="F10" />
                        <asp:BoundField DataField="F11" HeaderText="F11" />
                        <asp:BoundField DataField="F12" HeaderText="F12" />
                        <asp:BoundField DataField="F13" HeaderText="F13" />
                        <asp:BoundField DataField="F14" HeaderText="F14" />
                        <asp:BoundField DataField="F15" HeaderText="F15" />
                        <asp:BoundField DataField="F16" HeaderText="F16" />
                        <asp:BoundField DataField="F17" HeaderText="F17" />
                        <asp:BoundField DataField="F18" HeaderText="F18" />
                        <asp:BoundField DataField="F19" HeaderText="F19" />
                        <asp:BoundField DataField="F20" HeaderText="F20" />
                        <asp:BoundField DataField="F21" HeaderText="F21" />
                        <asp:BoundField DataField="F22" HeaderText="F22" />
                        <asp:BoundField DataField="F23" HeaderText="F23" />
                        <asp:BoundField DataField="F24" HeaderText="F24" />
                        <asp:BoundField DataField="F25" HeaderText="F25" />
                        <asp:BoundField DataField="F26" HeaderText="F26" />
                        <asp:BoundField DataField="F27" HeaderText="F27" />
                        <asp:BoundField DataField="F28" HeaderText="F28" />
                        <asp:BoundField DataField="F29" HeaderText="F29" />
                        <asp:BoundField DataField="F30" HeaderText="F30" />
                        <asp:BoundField DataField="F31" HeaderText="F31" />
                        <asp:BoundField DataField="F32" HeaderText="F32" />
                        <asp:BoundField DataField="F33" HeaderText="F33" />
                        <asp:BoundField DataField="F34" HeaderText="F34" />
                        <asp:BoundField DataField="F35" HeaderText="F35" />
                        <asp:BoundField DataField="F36" HeaderText="F36" />
                        <asp:BoundField DataField="F37" HeaderText="F37" />
                        <asp:BoundField DataField="F38" HeaderText="F38" />
                        <asp:BoundField DataField="F39" HeaderText="F39" />
                        <asp:BoundField DataField="F40" HeaderText="F40" />
                        <asp:BoundField DataField="F41" HeaderText="F41" />
                        <asp:BoundField DataField="F42" HeaderText="F42" />
                        <asp:BoundField DataField="F43" HeaderText="F43" />
                        <asp:BoundField DataField="F44" HeaderText="F44" />
                        <asp:BoundField DataField="F45" HeaderText="F45" />
                        <asp:BoundField DataField="F46" HeaderText="F46" />
                        <asp:BoundField DataField="F47" HeaderText="F47" />
                        <asp:BoundField DataField="F48" HeaderText="F48" />
                        <asp:BoundField DataField="F49" HeaderText="F49" />
                        <asp:BoundField DataField="F50" HeaderText="F50" />
                        <asp:BoundField DataField="F51" HeaderText="F51" />
                        <asp:BoundField DataField="F52" HeaderText="F52" />
                        <asp:BoundField DataField="F53" HeaderText="F53" />
                        <asp:BoundField DataField="F54" HeaderText="F54" />
                        <asp:BoundField DataField="F55" HeaderText="F55" />
                        <asp:BoundField DataField="F56" HeaderText="F56" />
                        <asp:BoundField DataField="F57" HeaderText="F57" />
                        <asp:BoundField DataField="F58" HeaderText="F58" />
                        <asp:BoundField DataField="F59" HeaderText="F59" />
                        <asp:BoundField DataField="F60" HeaderText="F60" />
                        <asp:BoundField DataField="F61" HeaderText="F61" />
                        <asp:BoundField DataField="F62" HeaderText="F62" />
                        <asp:BoundField DataField="F63" HeaderText="F63" />
                        <asp:BoundField DataField="F64" HeaderText="F64" />
                        <asp:BoundField DataField="F65" HeaderText="F65" />
                        <asp:BoundField DataField="F66" HeaderText="F66" />
                        <asp:BoundField DataField="F67" HeaderText="F67" />
                        <asp:BoundField DataField="F68" HeaderText="F68" />
                        <asp:BoundField DataField="F69" HeaderText="F69" />
                        <asp:BoundField DataField="F70" HeaderText="F70" />
                        <asp:BoundField DataField="F71" HeaderText="F71" />
                        <asp:BoundField DataField="F72" HeaderText="F72" />
                        <asp:BoundField DataField="F73" HeaderText="F73" />
                        <asp:BoundField DataField="F74" HeaderText="F74" />
                        <asp:BoundField DataField="F75" HeaderText="F75" />
                        <asp:BoundField DataField="F76" HeaderText="F76" />
                        <asp:BoundField DataField="F77" HeaderText="F77" />
                        <asp:BoundField DataField="F78" HeaderText="F78" />
                        <asp:BoundField DataField="F79" HeaderText="F79" />
                        <asp:BoundField DataField="F80" HeaderText="F80" />
                        <asp:BoundField DataField="F81" HeaderText="F81" />
                        <asp:BoundField DataField="F82" HeaderText="F82" />
                        <asp:BoundField DataField="F83" HeaderText="F83" />
                        <asp:BoundField DataField="F84" HeaderText="F84" />
                        <asp:BoundField DataField="F85" HeaderText="F85" />
                        <asp:BoundField DataField="F86" HeaderText="F86" />
                        <asp:BoundField DataField="F87" HeaderText="F87" />
                        <asp:BoundField DataField="F88" HeaderText="F88" />
                        <asp:BoundField DataField="F89" HeaderText="F89" />
                        <asp:BoundField DataField="F90" HeaderText="F90" />
                        <asp:BoundField DataField="F91" HeaderText="F91" />
                        <asp:BoundField DataField="F92" HeaderText="F92" />
                        <asp:BoundField DataField="F93" HeaderText="F93" />
                        <asp:BoundField DataField="F94" HeaderText="F94" />
                        <asp:BoundField DataField="F95" HeaderText="F95" />
                        <asp:BoundField DataField="F96" HeaderText="F96" />
                        <asp:BoundField DataField="F97" HeaderText="F97" />
                        <asp:BoundField DataField="F98" HeaderText="F98" />
                        <asp:BoundField DataField="F99" HeaderText="F99" />
                        <asp:BoundField DataField="F100" HeaderText="F100" />
                        <asp:BoundField DataField="F101" HeaderText="F101" />
                        <asp:BoundField DataField="F102" HeaderText="F102" />
                        <asp:BoundField DataField="F103" HeaderText="F103" />
                        <asp:BoundField DataField="F104" HeaderText="F104" />
                        <asp:BoundField DataField="F105" HeaderText="F105" />
                        <asp:BoundField DataField="F106" HeaderText="F106" />
                        <asp:BoundField DataField="F107" HeaderText="F107" />
                        <asp:BoundField DataField="F108" HeaderText="F108" />
                        <asp:BoundField DataField="F109" HeaderText="F109" />
                        <asp:BoundField DataField="F110" HeaderText="F110" />
                        <asp:BoundField DataField="F111" HeaderText="F111" />
                        <asp:BoundField DataField="F112" HeaderText="F112" />
                        <asp:BoundField DataField="F113" HeaderText="F113" />
                        <asp:BoundField DataField="F114" HeaderText="F114" />
                        <asp:BoundField DataField="F115" HeaderText="F115" />
                        <asp:BoundField DataField="F116" HeaderText="F116" />
                        <asp:BoundField DataField="F117" HeaderText="F117" />
                        <asp:BoundField DataField="F118" HeaderText="F118" />
                        <asp:BoundField DataField="F119" HeaderText="F119" />
                        <asp:BoundField DataField="F120" HeaderText="F120" />
                        <asp:BoundField DataField="F121" HeaderText="F121" />
                        <asp:BoundField DataField="F122" HeaderText="F122" />
                        <asp:BoundField DataField="F123" HeaderText="F123" />
                        <asp:BoundField DataField="F124" HeaderText="F124" />
                        <asp:BoundField DataField="F125" HeaderText="F125" />
                        <asp:BoundField DataField="F126" HeaderText="F126" />
                        <asp:BoundField DataField="F127" HeaderText="F127" />
                        <asp:BoundField DataField="F128" HeaderText="F128" />
                        <asp:BoundField DataField="F129" HeaderText="F129" />
                        <asp:BoundField DataField="F130" HeaderText="F130" />
                        <asp:BoundField DataField="F131" HeaderText="F131" />
                        <asp:BoundField DataField="F132" HeaderText="F132" />
                        <asp:BoundField DataField="F133" HeaderText="F133" />
                        <asp:BoundField DataField="F134" HeaderText="F134" />
                        <asp:BoundField DataField="F135" HeaderText="F135" />
                        <asp:BoundField DataField="F136" HeaderText="F136" />
                        <asp:BoundField DataField="F137" HeaderText="F137" />
                        <asp:BoundField DataField="F138" HeaderText="F138" />
                        <asp:BoundField DataField="F139" HeaderText="F139" />
                        <asp:BoundField DataField="F140" HeaderText="F140" />
                        <asp:BoundField DataField="F141" HeaderText="F141" />
                        <asp:BoundField DataField="F142" HeaderText="F142" />
                        <asp:BoundField DataField="F143" HeaderText="F143" />
                        <asp:BoundField DataField="F144" HeaderText="F144" />
                        <asp:BoundField DataField="F145" HeaderText="F145" />
                        <asp:BoundField DataField="F146" HeaderText="F146" />
                        <asp:BoundField DataField="F147" HeaderText="F147" />
                        <asp:BoundField DataField="F148" HeaderText="F148" />
                        <asp:BoundField DataField="F149" HeaderText="F149" />
                        <asp:BoundField DataField="F150" HeaderText="F150" />
                        <asp:BoundField DataField="F151" HeaderText="F151" />
                        <asp:BoundField DataField="F152" HeaderText="F152" />
                        <asp:BoundField DataField="F153" HeaderText="F153" />
                        <asp:BoundField DataField="F154" HeaderText="F154" />
                        <asp:BoundField DataField="F155" HeaderText="F155" />
                        <asp:BoundField DataField="F156" HeaderText="F156" />
                        <asp:BoundField DataField="F157" HeaderText="F157" />
                        <asp:BoundField DataField="F158" HeaderText="F158" />
                        <asp:BoundField DataField="F159" HeaderText="F159" />
                        <asp:BoundField DataField="F160" HeaderText="F160" />
                        <asp:BoundField DataField="F161" HeaderText="F161" />
                        <asp:BoundField DataField="F162" HeaderText="F162" />
                        <asp:BoundField DataField="F163" HeaderText="F163" />
                        <asp:BoundField DataField="F164" HeaderText="F164" />
                        <asp:BoundField DataField="F165" HeaderText="F165" />
                        <asp:BoundField DataField="F166" HeaderText="F166" />
                        <asp:BoundField DataField="F167" HeaderText="F167" />
                        <asp:BoundField DataField="F168" HeaderText="F168" />
                        <asp:BoundField DataField="F169" HeaderText="F169" />
                        <asp:BoundField DataField="F170" HeaderText="F170" />
                        <asp:BoundField DataField="F171" HeaderText="F171" />
                        <asp:BoundField DataField="F172" HeaderText="F172" />
                        <asp:BoundField DataField="F173" HeaderText="F173" />
                        <asp:BoundField DataField="F174" HeaderText="F174" />
                        <asp:BoundField DataField="F175" HeaderText="F175" />
                        <asp:BoundField DataField="F176" HeaderText="F176" />
                        <asp:BoundField DataField="F177" HeaderText="F177" />
                        <asp:BoundField DataField="F178" HeaderText="F178" />
                        <asp:BoundField DataField="F179" HeaderText="F179" />
                        <asp:BoundField DataField="F180" HeaderText="F180" />
                        <asp:BoundField DataField="F181" HeaderText="F181" />
                        <asp:BoundField DataField="F182" HeaderText="F182" />
                        <asp:BoundField DataField="F183" HeaderText="F183" />
                        <asp:BoundField DataField="F184" HeaderText="F184" />
                        <asp:BoundField DataField="F185" HeaderText="F185" />
                        <asp:BoundField DataField="F186" HeaderText="F186" />
                        <asp:BoundField DataField="F187" HeaderText="F187" />
                        <asp:BoundField DataField="F188" HeaderText="F188" />
                        <asp:BoundField DataField="F189" HeaderText="F189" />
                        <asp:BoundField DataField="F190" HeaderText="F190" />
                        <asp:BoundField DataField="F191" HeaderText="F191" />
                        <asp:BoundField DataField="F192" HeaderText="F192" />
                        <asp:BoundField DataField="F193" HeaderText="F193" />
                        <asp:BoundField DataField="F194" HeaderText="F194" />
                        <asp:BoundField DataField="F195" HeaderText="F195" />
                        <asp:BoundField DataField="F196" HeaderText="F196" />
                        <asp:BoundField DataField="F197" HeaderText="F197" />
                        <asp:BoundField DataField="F198" HeaderText="F198" />
                        <asp:BoundField DataField="F199" HeaderText="F199" />
                        <asp:BoundField DataField="F200" HeaderText="F200" />
                        <asp:BoundField DataField="F201" HeaderText="F201" />
                        <asp:BoundField DataField="F202" HeaderText="F202" />
                        <asp:BoundField DataField="F203" HeaderText="F203" />
                        <asp:BoundField DataField="F204" HeaderText="F204" />
                        <asp:BoundField DataField="F205" HeaderText="F205" />
                        <asp:BoundField DataField="F206" HeaderText="F206" />
                        <asp:BoundField DataField="F207" HeaderText="F207" />
                        <asp:BoundField DataField="F208" HeaderText="F208" />
                        <asp:BoundField DataField="F209" HeaderText="F209" />
                        <asp:BoundField DataField="F210" HeaderText="F210" />
                        <asp:BoundField DataField="F211" HeaderText="F211" />
                        <asp:BoundField DataField="F212" HeaderText="F212" />
                        <asp:BoundField DataField="F213" HeaderText="F213" />
                        <asp:BoundField DataField="F214" HeaderText="F214" />
                        <asp:BoundField DataField="F215" HeaderText="F215" />
                        <asp:BoundField DataField="F216" HeaderText="F216" />
                        <asp:BoundField DataField="F217" HeaderText="F217" />
                        <asp:BoundField DataField="F218" HeaderText="F218" />
                        <asp:BoundField DataField="F219" HeaderText="F219" />
                        <asp:BoundField DataField="F220" HeaderText="F220" />
                        <asp:BoundField DataField="Date_F1" HeaderText="Date_F1" />
                        <asp:BoundField DataField="Date_F2" HeaderText="Date_F2" />
                        <asp:BoundField DataField="Date_F3" HeaderText="Date_F3" />
                        <asp:BoundField DataField="Date_F4" HeaderText="Date_F4" />
                        <asp:BoundField DataField="Date_F5" HeaderText="Date_F5" />
                        <asp:BoundField DataField="Date_F6" HeaderText="Date_F6" />
                        <asp:BoundField DataField="Date_F7" HeaderText="Date_F7" />
                        <asp:BoundField DataField="Date_F8" HeaderText="Date_F8" />
                        <asp:BoundField DataField="Date_F9" HeaderText="Date_F9" />
                        <asp:BoundField DataField="Date_F10" HeaderText="Date_F10" />
                        <asp:BoundField DataField="Date_F11" HeaderText="Date_F11" />
                        <asp:BoundField DataField="Date_F12" HeaderText="Date_F12" />
                        <asp:BoundField DataField="Date_F13" HeaderText="Date_F13" />
                        <asp:BoundField DataField="Date_F14" HeaderText="Date_F14" />
                        <asp:BoundField DataField="Date_F15" HeaderText="Date_F15" />
                        <asp:BoundField DataField="Date_F16" HeaderText="Date_F16" />
                        <asp:BoundField DataField="Date_F17" HeaderText="Date_F17" />
                        <asp:BoundField DataField="Date_F18" HeaderText="Date_F18" />
                        <asp:BoundField DataField="Date_F19" HeaderText="Date_F19" />
                        <asp:BoundField DataField="Date_F20" HeaderText="Date_F20" />
                        <asp:BoundField DataField="Date_F21" HeaderText="Date_F21" />
                        <asp:BoundField DataField="Date_F22" HeaderText="Date_F22" />
                        <asp:BoundField DataField="Date_F23" HeaderText="Date_F23" />
                        <asp:BoundField DataField="Date_F24" HeaderText="Date_F24" />
                        <asp:BoundField DataField="Date_F25" HeaderText="Date_F25" />
                        <asp:BoundField DataField="Date_F26" HeaderText="Date_F26" />
                        <asp:BoundField DataField="Date_F27" HeaderText="Date_F27" />
                        <asp:BoundField DataField="Date_F28" HeaderText="Date_F28" />
                        <asp:BoundField DataField="Date_F29" HeaderText="Date_F29" />
                        <asp:BoundField DataField="Date_F30" HeaderText="Date_F30" />
                        <asp:BoundField DataField="Date_F31" HeaderText="Date_F31" />
                        <asp:BoundField DataField="Date_F32" HeaderText="Date_F32" />
                        <asp:BoundField DataField="Date_F33" HeaderText="Date_F33" />
                        <asp:BoundField DataField="Date_F34" HeaderText="Date_F34" />
                        <asp:BoundField DataField="Date_F35" HeaderText="Date_F35" />
                        <asp:BoundField DataField="Date_F36" HeaderText="Date_F36" />
                        <asp:BoundField DataField="Date_F37" HeaderText="Date_F37" />
                        <asp:BoundField DataField="Date_F38" HeaderText="Date_F38" />
                        <asp:BoundField DataField="Date_F39" HeaderText="Date_F39" />
                        <asp:BoundField DataField="Date_F40" HeaderText="Date_F40" />
                        <asp:BoundField DataField="Date_F41" HeaderText="Date_F41" />
                        <asp:BoundField DataField="Date_F42" HeaderText="Date_F42" />
                        <asp:BoundField DataField="Date_F43" HeaderText="Date_F43" />
                        <asp:BoundField DataField="Date_F44" HeaderText="Date_F44" />
                        <asp:BoundField DataField="Date_F45" HeaderText="Date_F45" />
                        <asp:BoundField DataField="Date_F46" HeaderText="Date_F46" />
                        <asp:BoundField DataField="Date_F47" HeaderText="Date_F47" />
                        <asp:BoundField DataField="Date_F48" HeaderText="Date_F48" />
                        <asp:BoundField DataField="Date_F49" HeaderText="Date_F49" />
                        <asp:BoundField DataField="Date_F50" HeaderText="Date_F50" />
                        <asp:BoundField DataField="Date_F51" HeaderText="Date_F51" />
                        <asp:BoundField DataField="Date_F52" HeaderText="Date_F52" />
                        <asp:BoundField DataField="Date_F53" HeaderText="Date_F53" />
                        <asp:BoundField DataField="Date_F54" HeaderText="Date_F54" />
                        <asp:BoundField DataField="Date_F55" HeaderText="Date_F55" />
                        <asp:BoundField DataField="Date_F56" HeaderText="Date_F56" />
                        <asp:BoundField DataField="Date_F57" HeaderText="Date_F57" />
                        <asp:BoundField DataField="Date_F58" HeaderText="Date_F58" />
                        <asp:BoundField DataField="Date_F59" HeaderText="Date_F59" />
                        <asp:BoundField DataField="Date_F60" HeaderText="Date_F60" />
                        <asp:BoundField DataField="Date_F61" HeaderText="Date_F61" />
                        <asp:BoundField DataField="Date_F62" HeaderText="Date_F62" />
                        <asp:BoundField DataField="Date_F63" HeaderText="Date_F63" />
                        <asp:BoundField DataField="Date_F64" HeaderText="Date_F64" />
                        <asp:BoundField DataField="Date_F65" HeaderText="Date_F65" />
                        <asp:BoundField DataField="Date_F66" HeaderText="Date_F66" />
                        <asp:BoundField DataField="Date_F67" HeaderText="Date_F67" />
                        <asp:BoundField DataField="Date_F68" HeaderText="Date_F68" />
                        <asp:BoundField DataField="Date_F69" HeaderText="Date_F69" />
                        <asp:BoundField DataField="Date_F70" HeaderText="Date_F70" />
                        <asp:BoundField DataField="Date_F71" HeaderText="Date_F71" />
                        <asp:BoundField DataField="Date_F72" HeaderText="Date_F72" />
                        <asp:BoundField DataField="Date_F73" HeaderText="Date_F73" />
                        <asp:BoundField DataField="Date_F74" HeaderText="Date_F74" />
                        <asp:BoundField DataField="Date_F75" HeaderText="Date_F75" />
                        <asp:BoundField DataField="Date_F76" HeaderText="Date_F76" />
                        <asp:BoundField DataField="Date_F77" HeaderText="Date_F77" />
                        <asp:BoundField DataField="Date_F78" HeaderText="Date_F78" />
                        <asp:BoundField DataField="Date_F79" HeaderText="Date_F79" />
                        <asp:BoundField DataField="Date_F80" HeaderText="Date_F80" />
                        <asp:BoundField DataField="Date_F81" HeaderText="Date_F81" />
                        <asp:BoundField DataField="Date_F82" HeaderText="Date_F82" />
                        <asp:BoundField DataField="Date_F83" HeaderText="Date_F83" />
                        <asp:BoundField DataField="Date_F84" HeaderText="Date_F84" />
                        <asp:BoundField DataField="Date_F85" HeaderText="Date_F85" />
                        <asp:BoundField DataField="Date_F86" HeaderText="Date_F86" />
                        <asp:BoundField DataField="Date_F87" HeaderText="Date_F87" />
                        <asp:BoundField DataField="Date_F88" HeaderText="Date_F88" />
                        <asp:BoundField DataField="Date_F89" HeaderText="Date_F89" />
                        <asp:BoundField DataField="Date_F90" HeaderText="Date_F90" />
                        <asp:BoundField DataField="Date_F91" HeaderText="Date_F91" />
                        <asp:BoundField DataField="Date_F92" HeaderText="Date_F92" />
                        <asp:BoundField DataField="Date_F93" HeaderText="Date_F93" />
                        <asp:BoundField DataField="Date_F94" HeaderText="Date_F94" />
                        <asp:BoundField DataField="Date_F95" HeaderText="Date_F95" />
                        <asp:BoundField DataField="Date_F96" HeaderText="Date_F96" />
                        <asp:BoundField DataField="Date_F97" HeaderText="Date_F97" />
                        <asp:BoundField DataField="Date_F98" HeaderText="Date_F98" />
                        <asp:BoundField DataField="Date_F99" HeaderText="Date_F99" />
                        <asp:BoundField DataField="Date_F100" HeaderText="Date_F100" />
                        <asp:BoundField DataField="Date_F101" HeaderText="Date_F101" />
                        <asp:BoundField DataField="Date_F102" HeaderText="Date_F102" />
                        <asp:BoundField DataField="Date_F103" HeaderText="Date_F103" />
                        <asp:BoundField DataField="Date_F104" HeaderText="Date_F104" />
                        <asp:BoundField DataField="Date_F105" HeaderText="Date_F105" />
                        <asp:BoundField DataField="Date_F106" HeaderText="Date_F106" />
                        <asp:BoundField DataField="Date_F107" HeaderText="Date_F107" />
                        <asp:BoundField DataField="Date_F108" HeaderText="Date_F108" />
                        <asp:BoundField DataField="Date_F109" HeaderText="Date_F109" />
                        <asp:BoundField DataField="Date_F110" HeaderText="Date_F110" />
                        <asp:BoundField DataField="Date_F111" HeaderText="Date_F111" />
                        <asp:BoundField DataField="Date_F112" HeaderText="Date_F112" />
                        <asp:BoundField DataField="Date_F113" HeaderText="Date_F113" />
                        <asp:BoundField DataField="Date_F114" HeaderText="Date_F114" />
                        <asp:BoundField DataField="Date_F115" HeaderText="Date_F115" />
                        <asp:BoundField DataField="Date_F116" HeaderText="Date_F116" />
                        <asp:BoundField DataField="Date_F117" HeaderText="Date_F117" />
                        <asp:BoundField DataField="Date_F118" HeaderText="Date_F118" />
                        <asp:BoundField DataField="Date_F119" HeaderText="Date_F119" />
                        <asp:BoundField DataField="Date_F120" HeaderText="Date_F120" />
                        <asp:BoundField DataField="Date_F121" HeaderText="Date_F121" />
                        <asp:BoundField DataField="Date_F122" HeaderText="Date_F122" />
                        <asp:BoundField DataField="Date_F123" HeaderText="Date_F123" />
                        <asp:BoundField DataField="Date_F124" HeaderText="Date_F124" />
                        <asp:BoundField DataField="Date_F125" HeaderText="Date_F125" />
                        <asp:BoundField DataField="Date_F126" HeaderText="Date_F126" />
                        <asp:BoundField DataField="Date_F127" HeaderText="Date_F127" />
                        <asp:BoundField DataField="Date_F128" HeaderText="Date_F128" />
                        <asp:BoundField DataField="Date_F129" HeaderText="Date_F129" />
                        <asp:BoundField DataField="Date_F130" HeaderText="Date_F130" />
                        <asp:BoundField DataField="Date_F131" HeaderText="Date_F131" />
                        <asp:BoundField DataField="Date_F132" HeaderText="Date_F132" />
                        <asp:BoundField DataField="Date_F133" HeaderText="Date_F133" />
                        <asp:BoundField DataField="Date_F134" HeaderText="Date_F134" />
                        <asp:BoundField DataField="Date_F135" HeaderText="Date_F135" />
                        <asp:BoundField DataField="Date_F136" HeaderText="Date_F136" />
                        <asp:BoundField DataField="Date_F137" HeaderText="Date_F137" />
                        <asp:BoundField DataField="Date_F138" HeaderText="Date_F138" />
                        <asp:BoundField DataField="Date_F139" HeaderText="Date_F139" />
                        <asp:BoundField DataField="Date_F140" HeaderText="Date_F140" />
                        <asp:BoundField DataField="Date_F141" HeaderText="Date_F141" />
                        <asp:BoundField DataField="Date_F142" HeaderText="Date_F142" />
                        <asp:BoundField DataField="Date_F143" HeaderText="Date_F143" />
                        <asp:BoundField DataField="Date_F144" HeaderText="Date_F144" />
                        <asp:BoundField DataField="Date_F145" HeaderText="Date_F145" />
                        <asp:BoundField DataField="Date_F146" HeaderText="Date_F146" />
                        <asp:BoundField DataField="Date_F147" HeaderText="Date_F147" />
                        <asp:BoundField DataField="Date_F148" HeaderText="Date_F148" />
                        <asp:BoundField DataField="Date_F149" HeaderText="Date_F149" />
                        <asp:BoundField DataField="Date_F150" HeaderText="Date_F150" />
                        <asp:BoundField DataField="Date_F151" HeaderText="Date_F151" />
                        <asp:BoundField DataField="Date_F152" HeaderText="Date_F152" />
                        <asp:BoundField DataField="Date_F153" HeaderText="Date_F153" />
                        <asp:BoundField DataField="Date_F154" HeaderText="Date_F154" />
                        <asp:BoundField DataField="Date_F155" HeaderText="Date_F155" />
                        <asp:BoundField DataField="Date_F156" HeaderText="Date_F156" />
                        <asp:BoundField DataField="Date_F157" HeaderText="Date_F157" />
                        <asp:BoundField DataField="Date_F158" HeaderText="Date_F158" />
                        <asp:BoundField DataField="Date_F159" HeaderText="Date_F159" />
                        <asp:BoundField DataField="Date_F160" HeaderText="Date_F160" />
                        <asp:BoundField DataField="Date_F161" HeaderText="Date_F161" />
                        <asp:BoundField DataField="Date_F162" HeaderText="Date_F162" />
                        <asp:BoundField DataField="Date_F163" HeaderText="Date_F163" />
                        <asp:BoundField DataField="Date_F164" HeaderText="Date_F164" />
                        <asp:BoundField DataField="Date_F165" HeaderText="Date_F165" />
                        <asp:BoundField DataField="Date_F166" HeaderText="Date_F166" />
                        <asp:BoundField DataField="Date_F167" HeaderText="Date_F167" />
                        <asp:BoundField DataField="Date_F168" HeaderText="Date_F168" />
                        <asp:BoundField DataField="Date_F169" HeaderText="Date_F169" />
                        <asp:BoundField DataField="Date_F170" HeaderText="Date_F170" />
                        <asp:BoundField DataField="Date_F171" HeaderText="Date_F171" />
                        <asp:BoundField DataField="Date_F172" HeaderText="Date_F172" />
                        <asp:BoundField DataField="Date_F173" HeaderText="Date_F173" />
                        <asp:BoundField DataField="Date_F174" HeaderText="Date_F174" />
                        <asp:BoundField DataField="Date_F175" HeaderText="Date_F175" />
                        <asp:BoundField DataField="Date_F176" HeaderText="Date_F176" />
                        <asp:BoundField DataField="Date_F177" HeaderText="Date_F177" />
                        <asp:BoundField DataField="Date_F178" HeaderText="Date_F178" />
                        <asp:BoundField DataField="Date_F179" HeaderText="Date_F179" />
                        <asp:BoundField DataField="Date_F180" HeaderText="Date_F180" />
                        <asp:BoundField DataField="Date_F181" HeaderText="Date_F181" />
                        <asp:BoundField DataField="Date_F182" HeaderText="Date_F182" />
                        <asp:BoundField DataField="Date_F183" HeaderText="Date_F183" />
                        <asp:BoundField DataField="Date_F184" HeaderText="Date_F184" />
                        <asp:BoundField DataField="Date_F185" HeaderText="Date_F185" />
                        <asp:BoundField DataField="Date_F186" HeaderText="Date_F186" />
                        <asp:BoundField DataField="Date_F187" HeaderText="Date_F187" />
                        <asp:BoundField DataField="Date_F188" HeaderText="Date_F188" />
                        <asp:BoundField DataField="Date_F189" HeaderText="Date_F189" />
                        <asp:BoundField DataField="Date_F190" HeaderText="Date_F190" />
                        <asp:BoundField DataField="Date_F191" HeaderText="Date_F191" />
                        <asp:BoundField DataField="Date_F192" HeaderText="Date_F192" />
                        <asp:BoundField DataField="Date_F193" HeaderText="Date_F193" />
                        <asp:BoundField DataField="Date_F194" HeaderText="Date_F194" />
                        <asp:BoundField DataField="Date_F195" HeaderText="Date_F195" />
                        <asp:BoundField DataField="Date_F196" HeaderText="Date_F196" />
                        <asp:BoundField DataField="Date_F197" HeaderText="Date_F197" />
                        <asp:BoundField DataField="Date_F198" HeaderText="Date_F198" />
                        <asp:BoundField DataField="Date_F199" HeaderText="Date_F199" />
                        <asp:BoundField DataField="Date_F200" HeaderText="Date_F200" />
                        <asp:BoundField DataField="Date_F201" HeaderText="Date_F201" />
                        <asp:BoundField DataField="Date_F202" HeaderText="Date_F202" />
                        <asp:BoundField DataField="Date_F203" HeaderText="Date_F203" />
                        <asp:BoundField DataField="Date_F204" HeaderText="Date_F204" />
                        <asp:BoundField DataField="Date_F205" HeaderText="Date_F205" />
                        <asp:BoundField DataField="Date_F206" HeaderText="Date_F206" />
                        <asp:BoundField DataField="Date_F207" HeaderText="Date_F207" />
                        <asp:BoundField DataField="Date_F208" HeaderText="Date_F208" />
                        <asp:BoundField DataField="Date_F209" HeaderText="Date_F209" />
                        <asp:BoundField DataField="Date_F210" HeaderText="Date_F210" />
                        <asp:BoundField DataField="Date_F211" HeaderText="Date_F211" />
                        <asp:BoundField DataField="Date_F212" HeaderText="Date_F212" />
                        <asp:BoundField DataField="Date_F213" HeaderText="Date_F213" />
                        <asp:BoundField DataField="Date_F214" HeaderText="Date_F214" />
                        <asp:BoundField DataField="Date_F215" HeaderText="Date_F215" />
                        <asp:BoundField DataField="Date_F216" HeaderText="Date_F216" />
                        <asp:BoundField DataField="Date_F217" HeaderText="Date_F217" />
                        <asp:BoundField DataField="Date_F218" HeaderText="Date_F218" />
                        <asp:BoundField DataField="Date_F219" HeaderText="Date_F219" />
                        <asp:BoundField DataField="Date_F220" HeaderText="Date_F220" />

                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
