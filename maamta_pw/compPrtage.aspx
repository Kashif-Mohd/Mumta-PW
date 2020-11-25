<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="compPrtage.aspx.cs" Inherits="maamta_pw.compPrtage" %>

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
            LNS Compliance Cumulative Percentage:
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

            <asp:Chart ID="Chart1" runat="server" Width="1000" Height="400px">
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

                    <asp:Title Name="Top" Text="Compliance (Cumulative)" Font="Arial Rounded MT Bold, 18pt, ">
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
                        <asp:BoundField DataField="arm" HeaderText="ARM" />
                        <asp:BoundField DataField="last_DOV" HeaderText="Last DOV" />
                        <asp:BoundField DataField="Consumed_LNS" HeaderText="Consumed LNS" />
                        <asp:BoundField DataField="Need_to_be_used" HeaderText="Need to be used LNS" />
                        <asp:BoundField DataField="Cumulative" HeaderText="Percentage" />
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
                        <asp:BoundField DataField="arm" HeaderText="ARM" />
                        <asp:BoundField DataField="last_DOV" HeaderText="Last DOV" />
                        <asp:BoundField DataField="Consumed_LNS" HeaderText="Consumed LNS" />
                        <asp:BoundField DataField="Need_to_be_used" HeaderText="Need to be used LNS" />
                        <asp:BoundField DataField="Cumulative" HeaderText="Percentage" />
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
                        <asp:BoundField DataField="arm" HeaderText="ARM" />
                        <asp:BoundField DataField="last_DOV" HeaderText="Last DOV" />
                        <asp:BoundField DataField="Consumed_LNS" HeaderText="Consumed LNS" />
                        <asp:BoundField DataField="Need_to_be_used" HeaderText="Need to be used LNS" />
                        <asp:BoundField DataField="Cumulative" HeaderText="Percentage" />
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
                        <asp:BoundField DataField="arm" HeaderText="ARM" />
                        <asp:BoundField DataField="last_DOV" HeaderText="Last DOV" />
                        <asp:BoundField DataField="Consumed_LNS" HeaderText="Consumed LNS" />
                        <asp:BoundField DataField="Need_to_be_used" HeaderText="Need to be used LNS" />
                        <asp:BoundField DataField="Cumulative" HeaderText="Percentage" />
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
                        <asp:BoundField DataField="arm" HeaderText="ARM" />
                        <asp:BoundField DataField="last_DOV" HeaderText="Last DOV" />
                        <asp:BoundField DataField="Consumed_LNS" HeaderText="Consumed LNS" />
                        <asp:BoundField DataField="Need_to_be_used" HeaderText="Need to be used LNS" />
                        <asp:BoundField DataField="Cumulative" HeaderText="Percentage" />
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
                                        <asp:TextBox ID="txtCalndrDate_LNS" Font-Bold="true" Font-Size="16px" ClientIDMode="Static" CssClass="txtboxx" Height="32px" runat="server" Width="8.0em"></asp:TextBox>
                                <asp:ImageButton ID="btnCalndrDate" ImageUrl="~/assets/img/calendar1.png" CssClass="calanderButton" runat="server" />
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtCalndrDate_LNS" PopupButtonID="btnCalndrDate" Format="dd-MM-yyyy" />
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
                        <asp:BoundField DataField="ARM" HeaderText="ARM" />
                        <asp:BoundField DataField="CRF4_Attempt" HeaderText="CRF4 Attempt" />
                        <asp:BoundField DataField="CRF4_Complete" HeaderText="CRF4 Complete" />
                        <asp:BoundField DataField="Consumed_LNS" HeaderText="Consumed LNS" />
                        <asp:BoundField DataField="Need_to_be_used" HeaderText="Need to be used LNS" />
                        <asp:BoundField DataField="Cumulative" HeaderText="Cumulative Maamta Compliance" />
                        <asp:BoundField DataField="Pregnancy_Status" HeaderText="Status" />
                        <asp:BoundField DataField="gestational_age" HeaderText="Gestational Age" />

                        <asp:BoundField DataField="date_of_registration" HeaderText="Date of Registration" />
                        <asp:BoundField DataField="last_DOV" HeaderText="Last DOV" />

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
                        <asp:BoundField DataField="ARM" HeaderText="ARM" />
                        <asp:BoundField DataField="CRF4_Attempt" HeaderText="CRF4 Attempt" />
                        <asp:BoundField DataField="CRF4_Complete" HeaderText="CRF4 Complete" />
                        <asp:BoundField DataField="Consumed_LNS" HeaderText="Consumed LNS" />
                        <asp:BoundField DataField="Need_to_be_used" HeaderText="Need to be used LNS" />
                        <asp:BoundField DataField="date_of_registration" HeaderText="Date of Registration" />
                        <asp:BoundField DataField="last_DOV" HeaderText="Last DOV" />
                        <asp:BoundField DataField="Cumulative" HeaderText="LNS Cumulative" />
                        <asp:BoundField DataField="last_DOV_date" HeaderText="Last DOV (Seleted Date)" />
                        <asp:BoundField DataField="Cumulative_date" HeaderText="LNS Cumulative (Selected Date)" />
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
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
