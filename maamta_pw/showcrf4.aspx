<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="showcrf4.aspx.cs" Inherits="maamta_pw.showcrf4" %>

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
        /* For Web Browser*/

        @media only screen and (min-width: 40em) {

            .Mobile {
                padding-left: 20%;
                text-align: center;
                width: 75%;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div style="padding-left: 2%; margin-top: 15px;">

        <div style="color: #ff6b6b; font-size: 22px; width: 100%">
            MUMTA Compliance Form: 
            <asp:Label ID="lbeDateFromTo" ForeColor="#10ac84" Font-Size="17px" Font-Bold="true" runat="server" Text=""></asp:Label>
        </div>
        <hr style="border-top: 1px solid #ccc; background: transparent; margin-top: -3px">

        <div id="divExportButton" runat="server" style="text-align: right; margin-top: -17px">
            <button type="button" id="Button1" class="btn btn-success" runat="server" style="height: 38px" onserverclick="btnExport_Click">
                Export &nbsp<span class="glyphicon glyphicon-export"></span>
            </button>
        </div>

        <%--Search Button--%>
        <div id="divSearch" runat="server" class="col-lg-4 col-lg-offset-4" style="margin-bottom: 10px; margin-top: 0px;">

            <div id="imaginary_container" style="margin-top: 10px">
                <div class="input-group stylish-input-group">
                    <asp:TextBox ID="txtdssid" CssClass="form-control txtboxx" ClientIDMode="Static" runat="server" placeholder="DSSID" MaxLength="11" ForeColor="Black"></asp:TextBox>
                    <span class="input-group-addon">
                        <button type="submit" id="btnSearch" runat="server" style="height: 20px" onserverclick="btnSearch_Click">
                            <span class="glyphicon glyphicon-search"></span>
                        </button>
                    </span>
                </div>
            </div>
        </div>



        <%--Start    Date checks--%>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:UpdateProgress ID="updateProgress" runat="server">
                    <ProgressTemplate>
                        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.75;">
                            <span style="border-width: 0px; border-radius: 10px; position: fixed; padding: 4%; color: white; background-color: #33D9B2; font-size: 36px; left: 40%; top: 40%;">Loading ...</span>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <div class="Mobile" id="calendar" runat="server">
                    <table style="width: 100%; text-align: center; margin-left: 6%; margin-bottom: 15px">
                        <tr>
                            <td class="tddd">
                                <asp:TextBox ID="txtCalndrDate" Font-Bold="true" Font-Size="16px" ClientIDMode="Static" CssClass="txtboxx" Height="32px" runat="server" Width="8.0em"></asp:TextBox>
                                <asp:ImageButton ID="btnCalndrDate" ImageUrl="~/assets/img/calendar1.png" CssClass="calanderButton" runat="server" />
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtCalndrDate" PopupButtonID="btnCalndrDate" Format="dd-MM-yyyy" />
                                &nbsp To &nbsp
                                <asp:TextBox ID="txtCalndrDate1" Font-Bold="true" Font-Size="16px" CssClass="txtboxx" Height="32px" runat="server" Width="8.0em"></asp:TextBox>
                                <asp:ImageButton ID="btnCalndrDate1" ImageUrl="~/assets/img/calendar1.png" CssClass="calanderButton" runat="server" />
                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtCalndrDate1" PopupButtonID="btnCalndrDate1" Format="dd-MM-yyyy" />
                                &nbsp &nbsp 
                          <asp:CheckBox ID="CheckBox1" runat="server" Text="Disable" OnCheckedChanged="CheckBox1_CheckedChanged" AutoPostBack="true" CssClass="mycheckbox" />
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        <%--End   Date checks--%>





        <div style="width: 100%; height: 490px; overflow: scroll; margin-top: 10px">
            <asp:GridView ID="GridView1" runat="server" EmptyDataText="No Record Found." AllowPaging="True" PageSize="200" OnPageIndexChanging="GridView1_PageIndexChanging" CssClass="footable" AllowSorting="false" ForeColor="#333333" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="Serial no.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                        <ItemStyle Width="2%" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="form_crf_4_id" HeaderText="form_crf_4_id" />
                    <asp:TemplateField HeaderText="Study-ID">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkStudyID" OnClick="Link_StudyID" Text='<%#Eval("study_code") %>' runat="server" ToolTip="Form Detail" CommandArgument='<%#Eval("form_crf_4_id")+","+ Eval("study_code")%>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="followup_num" HeaderText="followup_num" />
                    <asp:BoundField DataField="pw_crf4_2" HeaderText="pw_crf4_2" />
                    <asp:BoundField DataField="pw_crf4_3" HeaderText="pw_crf4_3" />
                    <asp:BoundField DataField="woman_nm" HeaderText="woman_nm" />
                    <asp:BoundField DataField="husband_nm" HeaderText="husband_nm" />
                    <asp:BoundField DataField="dssid" HeaderText="dssid" />
                    <asp:BoundField DataField="Site" HeaderText="Site" />
                    <asp:BoundField DataField="Para" HeaderText="Para" />
                    <asp:BoundField DataField="Block" HeaderText="Block" />
                    <asp:BoundField DataField="Struct" HeaderText="Struct" />
                    <asp:BoundField DataField="HH" HeaderText="HH" />
                    <asp:BoundField DataField="Wm_No" HeaderText="Wm_No" />
                    <asp:BoundField DataField="pw_crf4_18" HeaderText="pw_crf4_18" />
                    <asp:BoundField DataField="refused_reason" HeaderText="refused_reason" />
                    <asp:BoundField DataField="pw_crf4_19" HeaderText="pw_crf4_19" />
                    <asp:BoundField DataField="pw_crf4_20" HeaderText="pw_crf4_20" />
                    <asp:BoundField DataField="pw_crf4_21" HeaderText="pw_crf4_21" />
                    <asp:BoundField DataField="pw_crf4_22a" HeaderText="pw_crf4_22a" />
                    <asp:BoundField DataField="pw_crf4_22b" HeaderText="pw_crf4_22b" />
                    <asp:BoundField DataField="pw_crf4_23" HeaderText="pw_crf4_23" />
                    <asp:BoundField DataField="pw_crf4_24" HeaderText="pw_crf4_24" />
                    <asp:BoundField DataField="pw_crf4_25" HeaderText="pw_crf4_25" />
                    <asp:BoundField DataField="pw_crf4_26" HeaderText="pw_crf4_26" />
                    <asp:BoundField DataField="pw_crf4_27" HeaderText="pw_crf4_27" />
                    <asp:BoundField DataField="pw_crf4_28" HeaderText="pw_crf4_28" />
                    <asp:BoundField DataField="pw_crf4_29" HeaderText="pw_crf4_29" />
                    <asp:BoundField DataField="pw_crf4_30" HeaderText="pw_crf4_30" />
                    <asp:BoundField DataField="pw_crf4_31" HeaderText="pw_crf4_31" />
                    <asp:BoundField DataField="pw_crf4_32a" HeaderText="pw_crf4_32a" />
                    <asp:BoundField DataField="pw_crf4_32b" HeaderText="pw_crf4_32b" />
                    <asp:BoundField DataField="pw_crf4_32c" HeaderText="pw_crf4_32c" />
                    <asp:BoundField DataField="pw_crf4_32d" HeaderText="pw_crf4_32d" />
                    <asp:BoundField DataField="pw_crf4_32e" HeaderText="pw_crf4_32e" />
                    <asp:BoundField DataField="pw_crf4_32f" HeaderText="pw_crf4_32f" />
                    <asp:BoundField DataField="pw_crf4_33" HeaderText="pw_crf4_33" />
                    <asp:BoundField DataField="pw_crf4_34a" HeaderText="pw_crf4_34a" />
                    <asp:BoundField DataField="pw_crf4_34b" HeaderText="pw_crf4_34b" />
                    <asp:BoundField DataField="pw_crf4_34c" HeaderText="pw_crf4_34c" />
                    <asp:BoundField DataField="pw_crf4_34d" HeaderText="pw_crf4_34d" />
                    <asp:BoundField DataField="pw_crf4_34e" HeaderText="pw_crf4_34e" />
                    <asp:BoundField DataField="pw_crf4_35a" HeaderText="pw_crf4_35a" />
                    <asp:BoundField DataField="pw_crf4_35b" HeaderText="pw_crf4_35b" />
                    <asp:BoundField DataField="pw_crf4_35c" HeaderText="pw_crf4_35c" />
                    <asp:BoundField DataField="pw_crf4_35d" HeaderText="pw_crf4_35d" />
                    <asp:BoundField DataField="pw_crf4_35e" HeaderText="pw_crf4_35e" />
                    <asp:BoundField DataField="pw_crf4_35f" HeaderText="pw_crf4_35f" />
                    <asp:BoundField DataField="pw_crf4_35g" HeaderText="pw_crf4_35g" />
                    <asp:BoundField DataField="pw_crf4_35h" HeaderText="pw_crf4_35h" />
                    <asp:BoundField DataField="pw_crf4_35i" HeaderText="pw_crf4_35i" />
                    <asp:BoundField DataField="pw_crf4_35j" HeaderText="pw_crf4_35j" />
                    <asp:BoundField DataField="pw_crf4_36" HeaderText="pw_crf4_36" />
                    <asp:BoundField DataField="counsil_start_time" HeaderText="counsil_start_time" />
                    <asp:BoundField DataField="counsil_end_time" HeaderText="counsil_end_time" />
                    <asp:BoundField DataField="sra_name" HeaderText="sra_name" />
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








            <asp:GridView ID="GridView2" runat="server" CssClass="footable" ForeColor="#333333" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="Serial no.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                        <ItemStyle Width="2%" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="form_crf_4_id" HeaderText="form_crf_4_id" />
                    <asp:BoundField DataField="study_code" HeaderText="study_code" />
                    <asp:BoundField DataField="followup_num" HeaderText="followup_num" />
                    <asp:BoundField DataField="pw_crf4_2" HeaderText="pw_crf4_2" />
                    <asp:BoundField DataField="pw_crf4_3" HeaderText="pw_crf4_3" />
                    <asp:BoundField DataField="woman_nm" HeaderText="woman_nm" />
                    <asp:BoundField DataField="husband_nm" HeaderText="husband_nm" />
                    <asp:BoundField DataField="dssid" HeaderText="dssid" />
                    <asp:BoundField DataField="Site" HeaderText="Site" />
                    <asp:BoundField DataField="Para" HeaderText="Para" />
                    <asp:BoundField DataField="Block" HeaderText="Block" />
                    <asp:BoundField DataField="Struct" HeaderText="Struct" />
                    <asp:BoundField DataField="HH" HeaderText="HH" />
                    <asp:BoundField DataField="Wm_No" HeaderText="Wm_No" />
                    <asp:BoundField DataField="pw_crf4_18" HeaderText="pw_crf4_18" />
                    <asp:BoundField DataField="refused_reason" HeaderText="refused_reason" />
                    <asp:BoundField DataField="pw_crf4_19" HeaderText="pw_crf4_19" />
                    <asp:BoundField DataField="pw_crf4_20" HeaderText="pw_crf4_20" />
                    <asp:BoundField DataField="pw_crf4_21" HeaderText="pw_crf4_21" />
                    <asp:BoundField DataField="pw_crf4_22a" HeaderText="pw_crf4_22a" />
                    <asp:BoundField DataField="pw_crf4_22b" HeaderText="pw_crf4_22b" />
                    <asp:BoundField DataField="pw_crf4_23" HeaderText="pw_crf4_23" />
                    <asp:BoundField DataField="pw_crf4_24" HeaderText="pw_crf4_24" />
                    <asp:BoundField DataField="pw_crf4_25" HeaderText="pw_crf4_25" />
                    <asp:BoundField DataField="pw_crf4_26" HeaderText="pw_crf4_26" />
                    <asp:BoundField DataField="pw_crf4_27" HeaderText="pw_crf4_27" />
                    <asp:BoundField DataField="pw_crf4_28" HeaderText="pw_crf4_28" />
                    <asp:BoundField DataField="pw_crf4_29" HeaderText="pw_crf4_29" />
                    <asp:BoundField DataField="pw_crf4_30" HeaderText="pw_crf4_30" />
                    <asp:BoundField DataField="pw_crf4_31" HeaderText="pw_crf4_31" />
                    <asp:BoundField DataField="pw_crf4_32a" HeaderText="pw_crf4_32a" />
                    <asp:BoundField DataField="pw_crf4_32b" HeaderText="pw_crf4_32b" />
                    <asp:BoundField DataField="pw_crf4_32c" HeaderText="pw_crf4_32c" />
                    <asp:BoundField DataField="pw_crf4_32d" HeaderText="pw_crf4_32d" />
                    <asp:BoundField DataField="pw_crf4_32e" HeaderText="pw_crf4_32e" />
                    <asp:BoundField DataField="pw_crf4_32f" HeaderText="pw_crf4_32f" />
                    <asp:BoundField DataField="pw_crf4_33" HeaderText="pw_crf4_33" />
                    <asp:BoundField DataField="pw_crf4_34a" HeaderText="pw_crf4_34a" />
                    <asp:BoundField DataField="pw_crf4_34b" HeaderText="pw_crf4_34b" />
                    <asp:BoundField DataField="pw_crf4_34c" HeaderText="pw_crf4_34c" />
                    <asp:BoundField DataField="pw_crf4_34d" HeaderText="pw_crf4_34d" />
                    <asp:BoundField DataField="pw_crf4_34e" HeaderText="pw_crf4_34e" />
                    <asp:BoundField DataField="pw_crf4_35a" HeaderText="pw_crf4_35a" />
                    <asp:BoundField DataField="pw_crf4_35b" HeaderText="pw_crf4_35b" />
                    <asp:BoundField DataField="pw_crf4_35c" HeaderText="pw_crf4_35c" />
                    <asp:BoundField DataField="pw_crf4_35d" HeaderText="pw_crf4_35d" />
                    <asp:BoundField DataField="pw_crf4_35e" HeaderText="pw_crf4_35e" />
                    <asp:BoundField DataField="pw_crf4_35f" HeaderText="pw_crf4_35f" />
                    <asp:BoundField DataField="pw_crf4_35g" HeaderText="pw_crf4_35g" />
                    <asp:BoundField DataField="pw_crf4_35h" HeaderText="pw_crf4_35h" />
                    <asp:BoundField DataField="pw_crf4_35i" HeaderText="pw_crf4_35i" />
                    <asp:BoundField DataField="pw_crf4_35j" HeaderText="pw_crf4_35j" />
                    <asp:BoundField DataField="pw_crf4_36" HeaderText="pw_crf4_36" />
                    <asp:BoundField DataField="counsil_start_time" HeaderText="counsil_start_time" />
                    <asp:BoundField DataField="counsil_end_time" HeaderText="counsil_end_time" />
                    <asp:BoundField DataField="sra_name" HeaderText="sra_name" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
