<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="dashboardCRF8.aspx.cs" Inherits="maamta_pw.dashboardCRF8" %>

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
    <div style="padding-left: 2%; margin-top: 25px;">
        <div style="color: #ff6b6b; font-size: 22px; width: 100%">
            ADVERSE EVENTS (CRF-8 Form):
            <asp:Label ID="lbeDateFromTo" ForeColor="#10ac84" Font-Size="17px" Font-Bold="true" runat="server" Text=""></asp:Label>
        </div>
        <hr style="border-top: 1px solid #ccc; background: transparent; margin-top: -3px"/>

        <div id="divExportButton" runat="server" style="text-align: right; margin-top: -17px">
            <button type="button" id="Button1" class="btn btn-success" runat="server" style="height: 38px; background-color: green" onserverclick="btnExport_Click">
                Export &nbsp<span class="glyphicon glyphicon-export"></span>
            </button>
        </div>

        <%--Search Button--%>
        <div id="divSearch" runat="server" class="col-lg-4 col-lg-offset-4" style="margin-bottom: 10px; margin-top: -10px;">


            <div id="imaginary_container" style="margin-top: 10px">
                <div class="input-group stylish-input-group">
                    <asp:TextBox ID="txtdssid" CssClass="form-control txtboxx" ClientIDMode="Static" runat="server" placeholder="DSSID or STUDY-ID" MaxLength="11" ForeColor="Black"></asp:TextBox>
                    <span class="input-group-addon">
                        <button type="submit" id="btnSearch" runat="server" style="height: 20px" onserverclick="btnSearch_Click">
                            <span class="glyphicon glyphicon-search"></span>
                        </button>
                    </span>
                </div>
            </div>

        </div>





        <div style="width: 100%; height: 460px; overflow: scroll; margin-top: 20px">
            <asp:GridView ID="GridView1" runat="server" EmptyDataText="No Record Found." AllowPaging="True" PageSize="200" OnPageIndexChanging="GridView1_PageIndexChanging" CssClass="footable" AllowSorting="false" ForeColor="#333333" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:LinkButton ID="Link_id" OnClick="Link_CRF8_id" Text='Edit' runat="server" ToolTip="Edit Details" CommandArgument='<%#Eval("id")%>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Serial no.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                        <ItemStyle Width="2%" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="study_id" HeaderText="study_id" />
                    <asp:BoundField DataField="q2" HeaderText="q2" />
                    <asp:BoundField DataField="q3" HeaderText="q3" />
                    <asp:BoundField DataField="q4" HeaderText="q4" />
                    <asp:BoundField DataField="q5" HeaderText="q5" />
                    <asp:BoundField DataField="q6" HeaderText="q6" />
                    <asp:BoundField DataField="q7" HeaderText="q7" />
                    <asp:BoundField DataField="dssid" HeaderText="dssid" />
                    <asp:BoundField DataField="q14" HeaderText="q14" />
                    <asp:BoundField DataField="q15" HeaderText="q15" />
                    <asp:BoundField DataField="q16" HeaderText="q16" />
                    <asp:BoundField DataField="q17" HeaderText="q17" />
                    <asp:BoundField DataField="q18" HeaderText="q18" />
                    <asp:BoundField DataField="q19" HeaderText="q19" />
                    <asp:BoundField DataField="q20" HeaderText="q20" />
                    <asp:BoundField DataField="q21" HeaderText="q21" />
                    <asp:BoundField DataField="q22" HeaderText="q22" />
                    <asp:BoundField DataField="q23" HeaderText="q23" />
                    <asp:BoundField DataField="q24" HeaderText="q24" />
                    <asp:BoundField DataField="q25" HeaderText="q25" />
                    <asp:BoundField DataField="q26" HeaderText="q26" />
                    <asp:BoundField DataField="q27" HeaderText="q27" />
                    <asp:BoundField DataField="q28" HeaderText="q28" />
                    <asp:BoundField DataField="q28_other" HeaderText="q28_other" />
                    <asp:BoundField DataField="q29" HeaderText="q29" />
                    <asp:BoundField DataField="q30" HeaderText="q30" />
                    <asp:BoundField DataField="q31_minutes" HeaderText="q31_minutes" />
                    <asp:BoundField DataField="q31_hours" HeaderText="q31_hours" />
                    <asp:BoundField DataField="q31_days" HeaderText="q31_days" />
                    <asp:BoundField DataField="q32" HeaderText="q32" />
                    <asp:BoundField DataField="q32_other" HeaderText="q32_other" />
                    <asp:BoundField DataField="q33" HeaderText="q33" />
                    <asp:BoundField DataField="q34_01" HeaderText="q34_01" />
                    <asp:BoundField DataField="q34_02" HeaderText="q34_02" />
                    <asp:BoundField DataField="q34_03" HeaderText="q34_03" />
                    <asp:BoundField DataField="q34_04" HeaderText="q34_04" />
                    <asp:BoundField DataField="q34_05" HeaderText="q34_05" />
                    <asp:BoundField DataField="q34_06" HeaderText="q34_06" />
                    <asp:BoundField DataField="q34_07" HeaderText="q34_07" />
                    <asp:BoundField DataField="q34_08" HeaderText="q34_08" />
                    <asp:BoundField DataField="q34_09" HeaderText="q34_09" />
                    <asp:BoundField DataField="q34_10" HeaderText="q34_10" />
                    <asp:BoundField DataField="q34_11" HeaderText="q34_11" />
                    <asp:BoundField DataField="q34_12" HeaderText="q34_12" />
                    <asp:BoundField DataField="q34_13" HeaderText="q34_13" />
                    <asp:BoundField DataField="q34_13_other" HeaderText="q34_13_other" />
                    <asp:BoundField DataField="q35" HeaderText="q35" />
                    <asp:BoundField DataField="q36_01" HeaderText="q36_01" />
                    <asp:BoundField DataField="q36_02" HeaderText="q36_02" />
                    <asp:BoundField DataField="q36_03" HeaderText="q36_03" />
                    <asp:BoundField DataField="q36_04" HeaderText="q36_04" />
                    <asp:BoundField DataField="q36_05" HeaderText="q36_05" />
                    <asp:BoundField DataField="q36_06" HeaderText="q36_06" />
                    <asp:BoundField DataField="q36_07" HeaderText="q36_07" />
                    <asp:BoundField DataField="q36_08" HeaderText="q36_08" />
                    <asp:BoundField DataField="q36_09" HeaderText="q36_09" />
                    <asp:BoundField DataField="q36_09_other" HeaderText="q36_09_other" />
                    <asp:BoundField DataField="q37a_1dt" HeaderText="q37a_1dt" />
                    <asp:BoundField DataField="q37a_1" HeaderText="q37a_1" />
                    <asp:BoundField DataField="q37a_2dt" HeaderText="q37a_2dt" />
                    <asp:BoundField DataField="q37a_2" HeaderText="q37a_2" />
                    <asp:BoundField DataField="q37a_3dt" HeaderText="q37a_3dt" />
                    <asp:BoundField DataField="q37a_3" HeaderText="q37a_3" />
                    <asp:BoundField DataField="q37a_4dt" HeaderText="q37a_4dt" />
                    <asp:BoundField DataField="q37a_4" HeaderText="q37a_4" />
                    <asp:BoundField DataField="q37a_5dt" HeaderText="q37a_5dt" />
                    <asp:BoundField DataField="q37a_5" HeaderText="q37a_5" />
                    <asp:BoundField DataField="q37a_6dt" HeaderText="q37a_6dt" />
                    <asp:BoundField DataField="q37a_6" HeaderText="q37a_6" />
                    <asp:BoundField DataField="q37a_7dt" HeaderText="q37a_7dt" />
                    <asp:BoundField DataField="q37a_7" HeaderText="q37a_7" />
                    <asp:BoundField DataField="q37a_8dt" HeaderText="q37a_8dt" />
                    <asp:BoundField DataField="q37a_8" HeaderText="q37a_8" />
                    <asp:BoundField DataField="q37a_9dt" HeaderText="q37a_9dt" />
                    <asp:BoundField DataField="q37a_9" HeaderText="q37a_9" />
                    <asp:BoundField DataField="q37a_10dt" HeaderText="q37a_10dt" />
                    <asp:BoundField DataField="q37a_10" HeaderText="q37a_10" />
                    <asp:BoundField DataField="q37a_11dt" HeaderText="q37a_11dt" />
                    <asp:BoundField DataField="q37a_11" HeaderText="q37a_11" />
                    <asp:BoundField DataField="q37a_12dt" HeaderText="q37a_12dt" />
                    <asp:BoundField DataField="q37a_12" HeaderText="q37a_12" />
                    <asp:BoundField DataField="q37a_13dt" HeaderText="q37a_13dt" />
                    <asp:BoundField DataField="q37a_13" HeaderText="q37a_13" />
                    <asp:BoundField DataField="q37a_14dt" HeaderText="q37a_14dt" />
                    <asp:BoundField DataField="q37a_14" HeaderText="q37a_14" />
                    <asp:BoundField DataField="q37a_15dt" HeaderText="q37a_15dt" />
                    <asp:BoundField DataField="q37a_15" HeaderText="q37a_15" />
                    <asp:BoundField DataField="q37b_1dt" HeaderText="q37b_1dt" />
                    <asp:BoundField DataField="q37b_1" HeaderText="q37b_1" />
                    <asp:BoundField DataField="q37b_2dt" HeaderText="q37b_2dt" />
                    <asp:BoundField DataField="q37b_2" HeaderText="q37b_2" />
                    <asp:BoundField DataField="q37b_3dt" HeaderText="q37b_3dt" />
                    <asp:BoundField DataField="q37b_3" HeaderText="q37b_3" />
                    <asp:BoundField DataField="q37b_4dt" HeaderText="q37b_4dt" />
                    <asp:BoundField DataField="q37b_4" HeaderText="q37b_4" />
                    <asp:BoundField DataField="q37b_5dt" HeaderText="q37b_5dt" />
                    <asp:BoundField DataField="q37b_5" HeaderText="q37b_5" />
                    <asp:BoundField DataField="q37b_6dt" HeaderText="q37b_6dt" />
                    <asp:BoundField DataField="q37b_6" HeaderText="q37b_6" />
                    <asp:BoundField DataField="q37b_7dt" HeaderText="q37b_7dt" />
                    <asp:BoundField DataField="q37b_7" HeaderText="q37b_7" />
                    <asp:BoundField DataField="q37b_8dt" HeaderText="q37b_8dt" />
                    <asp:BoundField DataField="q37b_8" HeaderText="q37b_8" />
                    <asp:BoundField DataField="q37b_9dt" HeaderText="q37b_9dt" />
                    <asp:BoundField DataField="q37b_9" HeaderText="q37b_9" />
                    <asp:BoundField DataField="q37b_10dt" HeaderText="q37b_10dt" />
                    <asp:BoundField DataField="q37b_10" HeaderText="q37b_10" />
                    <asp:BoundField DataField="q37b_11dt" HeaderText="q37b_11dt" />
                    <asp:BoundField DataField="q37b_11" HeaderText="q37b_11" />
                    <asp:BoundField DataField="q37b_12dt" HeaderText="q37b_12dt" />
                    <asp:BoundField DataField="q37b_12" HeaderText="q37b_12" />
                    <asp:BoundField DataField="q37b_13dt" HeaderText="q37b_13dt" />
                    <asp:BoundField DataField="q37b_13" HeaderText="q37b_13" />
                    <asp:BoundField DataField="q37b_14dt" HeaderText="q37b_14dt" />
                    <asp:BoundField DataField="q37b_14" HeaderText="q37b_14" />
                    <asp:BoundField DataField="q37b_15dt" HeaderText="q37b_15dt" />
                    <asp:BoundField DataField="q37b_15" HeaderText="q37b_15" />
                    <asp:BoundField DataField="q38" HeaderText="q38" />
                    <asp:BoundField DataField="q38_other" HeaderText="q38_other" />
                    <asp:BoundField DataField="q39_01" HeaderText="q39_01" />
                    <asp:BoundField DataField="q39_02" HeaderText="q39_02" />
                    <asp:BoundField DataField="q39_03" HeaderText="q39_03" />
                    <asp:BoundField DataField="q39_04" HeaderText="q39_04" />
                    <asp:BoundField DataField="q39_05" HeaderText="q39_05" />
                    <asp:BoundField DataField="q39_06" HeaderText="q39_06" />
                    <asp:BoundField DataField="q39_07" HeaderText="q39_07" />
                    <asp:BoundField DataField="q39_08" HeaderText="q39_08" />
                    <asp:BoundField DataField="q40" HeaderText="q40" />
                    <asp:BoundField DataField="q40_other" HeaderText="q40_other" />
                    <asp:BoundField DataField="q41" HeaderText="q41" />
                    <asp:BoundField DataField="q42" HeaderText="q42" />
                    <asp:BoundField DataField="q43" HeaderText="q43" />
                    <asp:BoundField DataField="q44" HeaderText="q44" />
                    <asp:BoundField DataField="STATUS" HeaderText="STATUS" />
                    <asp:BoundField DataField="entry_nm" HeaderText="entry_nm" />
                    <asp:BoundField DataField="entry_dt" HeaderText="entry_dt" />
                    <asp:BoundField DataField="update_nm" HeaderText="update_nm" />
                    <asp:BoundField DataField="update_dt" HeaderText="update_dt" />
                </Columns>

                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#33d9b2" ForeColor="white" Font-Bold="True" Height="30px" HorizontalAlign="Center" />
                <PagerStyle BackColor="#576574" ForeColor="White" CssClass="StylePager" />
                <PagerSettings Position="TopAndBottom" Mode="NumericFirstLast" PreviousPageText="&amp;lt;" PageButtonCount="13" />

                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>




            <asp:GridView ID="GridView2" runat="server" EmptyDataText="No Record Found." CssClass="footable" AllowSorting="false" ForeColor="#333333" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="Serial no.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                        <ItemStyle Width="2%" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="id" HeaderText="id" />
                    <asp:BoundField DataField="study_id" HeaderText="study_id" />
                    <asp:BoundField DataField="q2" HeaderText="q2" />
                    <asp:BoundField DataField="q3" HeaderText="q3" />
                    <asp:BoundField DataField="q4" HeaderText="q4" />
                    <asp:BoundField DataField="q5" HeaderText="q5" />
                    <asp:BoundField DataField="q6" HeaderText="q6" />
                    <asp:BoundField DataField="q7" HeaderText="q7" />
                    <asp:BoundField DataField="dssid" HeaderText="dssid" />
                    <asp:BoundField DataField="q14" HeaderText="q14" />
                    <asp:BoundField DataField="q15" HeaderText="q15" />
                    <asp:BoundField DataField="q16" HeaderText="q16" />
                    <asp:BoundField DataField="q17" HeaderText="q17" />
                    <asp:BoundField DataField="q18" HeaderText="q18" />
                    <asp:BoundField DataField="q19" HeaderText="q19" />
                    <asp:BoundField DataField="q20" HeaderText="q20" />
                    <asp:BoundField DataField="q21" HeaderText="q21" />
                    <asp:BoundField DataField="q22" HeaderText="q22" />
                    <asp:BoundField DataField="q23" HeaderText="q23" />
                    <asp:BoundField DataField="q24" HeaderText="q24" />
                    <asp:BoundField DataField="q25" HeaderText="q25" />
                    <asp:BoundField DataField="q26" HeaderText="q26" />
                    <asp:BoundField DataField="q27" HeaderText="q27" />
                    <asp:BoundField DataField="q28" HeaderText="q28" />
                    <asp:BoundField DataField="q28_other" HeaderText="q28_other" />
                    <asp:BoundField DataField="q29" HeaderText="q29" />
                    <asp:BoundField DataField="q30" HeaderText="q30" />
                    <asp:BoundField DataField="q31_minutes" HeaderText="q31_minutes" />
                    <asp:BoundField DataField="q31_hours" HeaderText="q31_hours" />
                    <asp:BoundField DataField="q31_days" HeaderText="q31_days" />
                    <asp:BoundField DataField="q32" HeaderText="q32" />
                    <asp:BoundField DataField="q32_other" HeaderText="q32_other" />
                    <asp:BoundField DataField="q33" HeaderText="q33" />
                    <asp:BoundField DataField="q34_01" HeaderText="q34_01" />
                    <asp:BoundField DataField="q34_02" HeaderText="q34_02" />
                    <asp:BoundField DataField="q34_03" HeaderText="q34_03" />
                    <asp:BoundField DataField="q34_04" HeaderText="q34_04" />
                    <asp:BoundField DataField="q34_05" HeaderText="q34_05" />
                    <asp:BoundField DataField="q34_06" HeaderText="q34_06" />
                    <asp:BoundField DataField="q34_07" HeaderText="q34_07" />
                    <asp:BoundField DataField="q34_08" HeaderText="q34_08" />
                    <asp:BoundField DataField="q34_09" HeaderText="q34_09" />
                    <asp:BoundField DataField="q34_10" HeaderText="q34_10" />
                    <asp:BoundField DataField="q34_11" HeaderText="q34_11" />
                    <asp:BoundField DataField="q34_12" HeaderText="q34_12" />
                    <asp:BoundField DataField="q34_13" HeaderText="q34_13" />
                    <asp:BoundField DataField="q34_13_other" HeaderText="q34_13_other" />
                    <asp:BoundField DataField="q35" HeaderText="q35" />
                    <asp:BoundField DataField="q36_01" HeaderText="q36_01" />
                    <asp:BoundField DataField="q36_02" HeaderText="q36_02" />
                    <asp:BoundField DataField="q36_03" HeaderText="q36_03" />
                    <asp:BoundField DataField="q36_04" HeaderText="q36_04" />
                    <asp:BoundField DataField="q36_05" HeaderText="q36_05" />
                    <asp:BoundField DataField="q36_06" HeaderText="q36_06" />
                    <asp:BoundField DataField="q36_07" HeaderText="q36_07" />
                    <asp:BoundField DataField="q36_08" HeaderText="q36_08" />
                    <asp:BoundField DataField="q36_09" HeaderText="q36_09" />
                    <asp:BoundField DataField="q36_09_other" HeaderText="q36_09_other" />
                    <asp:BoundField DataField="q37a_1dt" HeaderText="q37a_1dt" />
                    <asp:BoundField DataField="q37a_1" HeaderText="q37a_1" />
                    <asp:BoundField DataField="q37a_2dt" HeaderText="q37a_2dt" />
                    <asp:BoundField DataField="q37a_2" HeaderText="q37a_2" />
                    <asp:BoundField DataField="q37a_3dt" HeaderText="q37a_3dt" />
                    <asp:BoundField DataField="q37a_3" HeaderText="q37a_3" />
                    <asp:BoundField DataField="q37a_4dt" HeaderText="q37a_4dt" />
                    <asp:BoundField DataField="q37a_4" HeaderText="q37a_4" />
                    <asp:BoundField DataField="q37a_5dt" HeaderText="q37a_5dt" />
                    <asp:BoundField DataField="q37a_5" HeaderText="q37a_5" />
                    <asp:BoundField DataField="q37a_6dt" HeaderText="q37a_6dt" />
                    <asp:BoundField DataField="q37a_6" HeaderText="q37a_6" />
                    <asp:BoundField DataField="q37a_7dt" HeaderText="q37a_7dt" />
                    <asp:BoundField DataField="q37a_7" HeaderText="q37a_7" />
                    <asp:BoundField DataField="q37a_8dt" HeaderText="q37a_8dt" />
                    <asp:BoundField DataField="q37a_8" HeaderText="q37a_8" />
                    <asp:BoundField DataField="q37a_9dt" HeaderText="q37a_9dt" />
                    <asp:BoundField DataField="q37a_9" HeaderText="q37a_9" />
                    <asp:BoundField DataField="q37a_10dt" HeaderText="q37a_10dt" />
                    <asp:BoundField DataField="q37a_10" HeaderText="q37a_10" />
                    <asp:BoundField DataField="q37a_11dt" HeaderText="q37a_11dt" />
                    <asp:BoundField DataField="q37a_11" HeaderText="q37a_11" />
                    <asp:BoundField DataField="q37a_12dt" HeaderText="q37a_12dt" />
                    <asp:BoundField DataField="q37a_12" HeaderText="q37a_12" />
                    <asp:BoundField DataField="q37a_13dt" HeaderText="q37a_13dt" />
                    <asp:BoundField DataField="q37a_13" HeaderText="q37a_13" />
                    <asp:BoundField DataField="q37a_14dt" HeaderText="q37a_14dt" />
                    <asp:BoundField DataField="q37a_14" HeaderText="q37a_14" />
                    <asp:BoundField DataField="q37a_15dt" HeaderText="q37a_15dt" />
                    <asp:BoundField DataField="q37a_15" HeaderText="q37a_15" />
                    <asp:BoundField DataField="q37b_1dt" HeaderText="q37b_1dt" />
                    <asp:BoundField DataField="q37b_1" HeaderText="q37b_1" />
                    <asp:BoundField DataField="q37b_2dt" HeaderText="q37b_2dt" />
                    <asp:BoundField DataField="q37b_2" HeaderText="q37b_2" />
                    <asp:BoundField DataField="q37b_3dt" HeaderText="q37b_3dt" />
                    <asp:BoundField DataField="q37b_3" HeaderText="q37b_3" />
                    <asp:BoundField DataField="q37b_4dt" HeaderText="q37b_4dt" />
                    <asp:BoundField DataField="q37b_4" HeaderText="q37b_4" />
                    <asp:BoundField DataField="q37b_5dt" HeaderText="q37b_5dt" />
                    <asp:BoundField DataField="q37b_5" HeaderText="q37b_5" />
                    <asp:BoundField DataField="q37b_6dt" HeaderText="q37b_6dt" />
                    <asp:BoundField DataField="q37b_6" HeaderText="q37b_6" />
                    <asp:BoundField DataField="q37b_7dt" HeaderText="q37b_7dt" />
                    <asp:BoundField DataField="q37b_7" HeaderText="q37b_7" />
                    <asp:BoundField DataField="q37b_8dt" HeaderText="q37b_8dt" />
                    <asp:BoundField DataField="q37b_8" HeaderText="q37b_8" />
                    <asp:BoundField DataField="q37b_9dt" HeaderText="q37b_9dt" />
                    <asp:BoundField DataField="q37b_9" HeaderText="q37b_9" />
                    <asp:BoundField DataField="q37b_10dt" HeaderText="q37b_10dt" />
                    <asp:BoundField DataField="q37b_10" HeaderText="q37b_10" />
                    <asp:BoundField DataField="q37b_11dt" HeaderText="q37b_11dt" />
                    <asp:BoundField DataField="q37b_11" HeaderText="q37b_11" />
                    <asp:BoundField DataField="q37b_12dt" HeaderText="q37b_12dt" />
                    <asp:BoundField DataField="q37b_12" HeaderText="q37b_12" />
                    <asp:BoundField DataField="q37b_13dt" HeaderText="q37b_13dt" />
                    <asp:BoundField DataField="q37b_13" HeaderText="q37b_13" />
                    <asp:BoundField DataField="q37b_14dt" HeaderText="q37b_14dt" />
                    <asp:BoundField DataField="q37b_14" HeaderText="q37b_14" />
                    <asp:BoundField DataField="q37b_15dt" HeaderText="q37b_15dt" />
                    <asp:BoundField DataField="q37b_15" HeaderText="q37b_15" />
                    <asp:BoundField DataField="q38" HeaderText="q38" />
                    <asp:BoundField DataField="q38_other" HeaderText="q38_other" />
                    <asp:BoundField DataField="q39_01" HeaderText="q39_01" />
                    <asp:BoundField DataField="q39_02" HeaderText="q39_02" />
                    <asp:BoundField DataField="q39_03" HeaderText="q39_03" />
                    <asp:BoundField DataField="q39_04" HeaderText="q39_04" />
                    <asp:BoundField DataField="q39_05" HeaderText="q39_05" />
                    <asp:BoundField DataField="q39_06" HeaderText="q39_06" />
                    <asp:BoundField DataField="q39_07" HeaderText="q39_07" />
                    <asp:BoundField DataField="q39_08" HeaderText="q39_08" />
                    <asp:BoundField DataField="q40" HeaderText="q40" />
                    <asp:BoundField DataField="q40_other" HeaderText="q40_other" />
                    <asp:BoundField DataField="q41" HeaderText="q41" />
                    <asp:BoundField DataField="q42" HeaderText="q42" />
                    <asp:BoundField DataField="q43" HeaderText="q43" />
                    <asp:BoundField DataField="q44" HeaderText="q44" />
                    <asp:BoundField DataField="STATUS" HeaderText="STATUS" />
                    <asp:BoundField DataField="entry_nm" HeaderText="entry_nm" />
                    <asp:BoundField DataField="entry_dt" HeaderText="entry_dt" />
                    <asp:BoundField DataField="update_nm" HeaderText="update_nm" />
                    <asp:BoundField DataField="update_dt" HeaderText="update_dt" />
                </Columns>


            </asp:GridView>
        </div>
    </div>
</asp:Content>
