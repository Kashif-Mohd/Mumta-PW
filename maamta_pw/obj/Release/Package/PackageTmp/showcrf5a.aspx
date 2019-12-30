<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="showcrf5a.aspx.cs" Inherits="maamta_pw.showcrf5a" %>

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
            Home ANC Visits FORM 
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
                    <asp:BoundField DataField="form_crf_5a_id" HeaderText="form_crf_5a_id" />
                    <asp:TemplateField HeaderText="Study-ID">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkStudyID" OnClick="Link_StudyID" Text='<%#Eval("study_code") %>' runat="server" ToolTip="Form Detail" CommandArgument='<%#Eval("form_crf_5a_id")+","+ Eval("study_code")%>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="followup_num" HeaderText="followup_num" />
                    <asp:BoundField DataField="pw_crf5a_02" HeaderText="pw_crf5a_02" />
                    <asp:BoundField DataField="pw_crf5a_03" HeaderText="pw_crf5a_03" />
                    <asp:BoundField DataField="woman_nm" HeaderText="woman_nm" />
                    <asp:BoundField DataField="husband_nm" HeaderText="husband_nm" />
                    <asp:BoundField DataField="dssid" HeaderText="dssid" />
                    <asp:BoundField DataField="Site" HeaderText="Site" />
                    <asp:BoundField DataField="Para" HeaderText="Para" />
                    <asp:BoundField DataField="Block" HeaderText="Block" />
                    <asp:BoundField DataField="Struct" HeaderText="Struct" />
                    <asp:BoundField DataField="HH" HeaderText="HH" />
                    <asp:BoundField DataField="Wm_No" HeaderText="Wm_No" />
                    <asp:BoundField DataField="pw_crf5a_18" HeaderText="pw_crf5a_18" />
                    <asp:BoundField DataField="refused_reason" HeaderText="refused_reason" />
                    <asp:BoundField DataField="pw_crf5a_19" HeaderText="pw_crf5a_19" />
                    <asp:BoundField DataField="pw_crf5a_20" HeaderText="pw_crf5a_20" />
                    <asp:BoundField DataField="pw_crf5a_21" HeaderText="pw_crf5a_21" />
                    <asp:BoundField DataField="pw_crf5a_22" HeaderText="pw_crf5a_22" />
                    <asp:BoundField DataField="pw_crf5a_23" HeaderText="pw_crf5a_23" />
                    <asp:BoundField DataField="pw_crf5a_24" HeaderText="pw_crf5a_24" />
                    <asp:BoundField DataField="pw_crf5a_25" HeaderText="pw_crf5a_25" />
                    <asp:BoundField DataField="pw_crf5a_26" HeaderText="pw_crf5a_26" />
                    <asp:BoundField DataField="pw_crf5a_27a" HeaderText="pw_crf5a_27a" />
                    <asp:BoundField DataField="pw_crf5a_27b" HeaderText="pw_crf5a_27b" />
                    <asp:BoundField DataField="pw_crf5a_27c" HeaderText="pw_crf5a_27c" />
                    <asp:BoundField DataField="pw_crf5a_27d" HeaderText="pw_crf5a_27d" />
                    <asp:BoundField DataField="pw_crf5a_27e" HeaderText="pw_crf5a_27e" />
                    <asp:BoundField DataField="pw_crf5a_27f" HeaderText="pw_crf5a_27f" />
                    <asp:BoundField DataField="pw_crf5a_28" HeaderText="pw_crf5a_28" />
                    <asp:BoundField DataField="pw_crf5a_29a" HeaderText="pw_crf5a_29a" />
                    <asp:BoundField DataField="pw_crf5a_29b" HeaderText="pw_crf5a_29b" />
                    <asp:BoundField DataField="pw_crf5a_29c" HeaderText="pw_crf5a_29c" />
                    <asp:BoundField DataField="pw_crf5a_29d" HeaderText="pw_crf5a_29d" />
                    <asp:BoundField DataField="pw_crf5a_29e" HeaderText="pw_crf5a_29e" />
                    <asp:BoundField DataField="pw_crf5a_29f" HeaderText="pw_crf5a_29f" />
                    <asp:BoundField DataField="pw_crf5a_30" HeaderText="pw_crf5a_30" />
                    <asp:BoundField DataField="pw_crf5a_31" HeaderText="pw_crf5a_31" />
                    <asp:BoundField DataField="pw_crf5a_32" HeaderText="pw_crf5a_32" />
                    <asp:BoundField DataField="pw_crf5a_33" HeaderText="pw_crf5a_33" />
                    <asp:BoundField DataField="pw_crf5a_34" HeaderText="pw_crf5a_34" />
                    <asp:BoundField DataField="pw_crf5a_35" HeaderText="pw_crf5a_35" />
                    <asp:BoundField DataField="pw_crf5a_36" HeaderText="pw_crf5a_36" />
                    <asp:BoundField DataField="pw_crf5a_37" HeaderText="pw_crf5a_37" />
                    <asp:BoundField DataField="pw_crf5a_38" HeaderText="pw_crf5a_38" />
                    <asp:BoundField DataField="pw_crf5a_39a" HeaderText="pw_crf5a_39a" />
                    <asp:BoundField DataField="pw_crf5a_39b" HeaderText="pw_crf5a_39b" />
                    <asp:BoundField DataField="pw_crf5a_39c" HeaderText="pw_crf5a_39c" />
                    <asp:BoundField DataField="pw_crf5a_39d" HeaderText="pw_crf5a_39d" />
                    <asp:BoundField DataField="pw_crf5a_39e" HeaderText="pw_crf5a_39e" />
                    <asp:BoundField DataField="pw_crf5a_40" HeaderText="pw_crf5a_40" />
                    <asp:BoundField DataField="pw_crf5a_41" HeaderText="pw_crf5a_41" />
                    <asp:BoundField DataField="pw_crf5a_42" HeaderText="pw_crf5a_42" />
                    <asp:BoundField DataField="pw_crf5a_43" HeaderText="pw_crf5a_43" />
                    <asp:BoundField DataField="pw_crf5a_44" HeaderText="pw_crf5a_44" />
                    <asp:BoundField DataField="pw_crf5a_45" HeaderText="pw_crf5a_45" />
                    <asp:BoundField DataField="pw_crf5a_46" HeaderText="pw_crf5a_46" />
                    <asp:BoundField DataField="pw_crf5a_47" HeaderText="pw_crf5a_47" />
                    <asp:BoundField DataField="pw_crf5a_48" HeaderText="pw_crf5a_48" />
                    <asp:BoundField DataField="pw_crf5a_49" HeaderText="pw_crf5a_49" />
                    <asp:BoundField DataField="pw_crf5a_50" HeaderText="pw_crf5a_50" />
                    <asp:BoundField DataField="pw_crf5a_51" HeaderText="pw_crf5a_51" />
                    <asp:BoundField DataField="pw_crf5a_52" HeaderText="pw_crf5a_52" />
                    <asp:BoundField DataField="pw_crf5a_53" HeaderText="pw_crf5a_53" />
                    <asp:BoundField DataField="pw_crf5a_54" HeaderText="pw_crf5a_54" />
                    <asp:BoundField DataField="pw_crf5a_55" HeaderText="pw_crf5a_55" />
                    <asp:BoundField DataField="pw_crf5a_56" HeaderText="pw_crf5a_56" />
                    <asp:BoundField DataField="pw_crf5a_57" HeaderText="pw_crf5a_57" />
                    <asp:BoundField DataField="pw_crf5a_58" HeaderText="pw_crf5a_58" />
                    <asp:BoundField DataField="pw_crf5a_59" HeaderText="pw_crf5a_59" />
                    <asp:BoundField DataField="pw_crf5a_60" HeaderText="pw_crf5a_60" />
                    <asp:BoundField DataField="pw_crf5a_61" HeaderText="pw_crf5a_61" />
                    <asp:BoundField DataField="pw_crf5a_62" HeaderText="pw_crf5a_62" />
                    <asp:BoundField DataField="pw_crf5a_63" HeaderText="pw_crf5a_63" />
                    <asp:BoundField DataField="pw_crf5a_64" HeaderText="pw_crf5a_64" />
                    <asp:BoundField DataField="pw_crf5a_65" HeaderText="pw_crf5a_65" />
                    <asp:BoundField DataField="pw_crf5a_66" HeaderText="pw_crf5a_66" />
                    <asp:BoundField DataField="pw_crf5a_67" HeaderText="pw_crf5a_67" />
                    <asp:BoundField DataField="pw_crf5a_68" HeaderText="pw_crf5a_68" />
                    <asp:BoundField DataField="pw_crf5a_69" HeaderText="pw_crf5a_69" />
                    <asp:BoundField DataField="pw_crf5a_70" HeaderText="pw_crf5a_70" />
                    <asp:BoundField DataField="pw_crf5a_71" HeaderText="pw_crf5a_71" />
                    <asp:BoundField DataField="pw_crf5a_72a" HeaderText="pw_crf5a_72a" />
                    <asp:BoundField DataField="pw_crf5a_72b" HeaderText="pw_crf5a_72b" />
                    <asp:BoundField DataField="pw_crf5a_72c" HeaderText="pw_crf5a_72c" />
                    <asp:BoundField DataField="pw_crf5a_72d" HeaderText="pw_crf5a_72d" />
                    <asp:BoundField DataField="pw_crf5a_72e" HeaderText="pw_crf5a_72e" />
                    <asp:BoundField DataField="pw_crf5a_72f" HeaderText="pw_crf5a_72f" />
                    <asp:BoundField DataField="pw_crf5a_72g" HeaderText="pw_crf5a_72g" />
					<asp:BoundField DataField="pw_crf5a_73" HeaderText="pw_crf5a_73" />
<asp:BoundField DataField="pw_crf5a_74" HeaderText="pw_crf5a_74" />
<asp:BoundField DataField="pw_crf5a_75" HeaderText="pw_crf5a_75" />
<asp:BoundField DataField="pw_crf5a_76a" HeaderText="pw_crf5a_76a" />
<asp:BoundField DataField="pw_crf5a_76b" HeaderText="pw_crf5a_76b" />
<asp:BoundField DataField="pw_crf5a_76c" HeaderText="pw_crf5a_76c" />
<asp:BoundField DataField="pw_crf5a_76d" HeaderText="pw_crf5a_76d" />
<asp:BoundField DataField="pw_crf5a_76e" HeaderText="pw_crf5a_76e" />
<asp:BoundField DataField="pw_crf5a_76f" HeaderText="pw_crf5a_76f" />
<asp:BoundField DataField="pw_crf5a_76g" HeaderText="pw_crf5a_76g" />

					
					
					
                    <asp:BoundField DataField="pw_crf5a_77" HeaderText="pw_crf5a_77" />
                    <asp:BoundField DataField="pw_crf5a_78" HeaderText="pw_crf5a_78" />
                    <asp:BoundField DataField="pw_crf5a_79" HeaderText="pw_crf5a_79" />
                    <asp:BoundField DataField="pw_crf5a_80" HeaderText="pw_crf5a_80" />
                    <asp:BoundField DataField="pw_crf5a_81" HeaderText="pw_crf5a_81" />
                    <asp:BoundField DataField="pw_crf5a_82" HeaderText="pw_crf5a_82" />
                    <asp:BoundField DataField="pw_crf5a_83" HeaderText="pw_crf5a_83" />
                    <asp:BoundField DataField="pw_crf5a_84" HeaderText="pw_crf5a_84" />
                    <asp:BoundField DataField="pw_crf5a_85" HeaderText="pw_crf5a_85" />
                    <asp:BoundField DataField="pw_crf5a_86a" HeaderText="pw_crf5a_86a" />
                    <asp:BoundField DataField="pw_crf5a_86b" HeaderText="pw_crf5a_86b" />
                    <asp:BoundField DataField="pw_crf5a_86c" HeaderText="pw_crf5a_86c" />
                    <asp:BoundField DataField="pw_crf5a_86d" HeaderText="pw_crf5a_86d" />
                    <asp:BoundField DataField="pw_crf5a_86e" HeaderText="pw_crf5a_86e" />
                    <asp:BoundField DataField="pw_crf5a_86f" HeaderText="pw_crf5a_86f" />
                    <asp:BoundField DataField="pw_crf5a_86g" HeaderText="pw_crf5a_86g" />
                    <asp:BoundField DataField="pw_crf5a_86h" HeaderText="pw_crf5a_86h" />
                    <asp:BoundField DataField="pw_crf5a_86i" HeaderText="pw_crf5a_86i" />
                    <asp:BoundField DataField="pw_crf5a_86j" HeaderText="pw_crf5a_86j" />
                    <asp:BoundField DataField="pw_crf5a_86k" HeaderText="pw_crf5a_86k" />
                    <asp:BoundField DataField="pw_crf5a_86l" HeaderText="pw_crf5a_86l" />
                    <asp:BoundField DataField="pw_crf5a_86m" HeaderText="pw_crf5a_86m" />
                    <asp:BoundField DataField="pw_crf5a_86n" HeaderText="pw_crf5a_86n" />
                    <asp:BoundField DataField="pw_crf5a_86o" HeaderText="pw_crf5a_86o" />
                    <asp:BoundField DataField="pw_crf5a_86p" HeaderText="pw_crf5a_86p" />
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
                    <asp:BoundField DataField="form_crf_5a_id" HeaderText="form_crf_5a_id" />
                    <asp:BoundField DataField="study_code" HeaderText="study_code" />
                    <asp:BoundField DataField="followup_num" HeaderText="followup_num" />
                    <asp:BoundField DataField="pw_crf5a_02" HeaderText="pw_crf5a_02" />
                    <asp:BoundField DataField="pw_crf5a_03" HeaderText="pw_crf5a_03" />
                    <asp:BoundField DataField="woman_nm" HeaderText="woman_nm" />
                    <asp:BoundField DataField="husband_nm" HeaderText="husband_nm" />
                    <asp:BoundField DataField="dssid" HeaderText="dssid" />
                    <asp:BoundField DataField="Site" HeaderText="Site" />
                    <asp:BoundField DataField="Para" HeaderText="Para" />
                    <asp:BoundField DataField="Block" HeaderText="Block" />
                    <asp:BoundField DataField="Struct" HeaderText="Struct" />
                    <asp:BoundField DataField="HH" HeaderText="HH" />
                    <asp:BoundField DataField="Wm_No" HeaderText="Wm_No" />
                    <asp:BoundField DataField="pw_crf5a_18" HeaderText="pw_crf5a_18" />
                    <asp:BoundField DataField="refused_reason" HeaderText="refused_reason" />
                    <asp:BoundField DataField="pw_crf5a_19" HeaderText="pw_crf5a_19" />
                    <asp:BoundField DataField="pw_crf5a_20" HeaderText="pw_crf5a_20" />
                    <asp:BoundField DataField="pw_crf5a_21" HeaderText="pw_crf5a_21" />
                    <asp:BoundField DataField="pw_crf5a_22" HeaderText="pw_crf5a_22" />
                    <asp:BoundField DataField="pw_crf5a_23" HeaderText="pw_crf5a_23" />
                    <asp:BoundField DataField="pw_crf5a_24" HeaderText="pw_crf5a_24" />
                    <asp:BoundField DataField="pw_crf5a_25" HeaderText="pw_crf5a_25" />
                    <asp:BoundField DataField="pw_crf5a_26" HeaderText="pw_crf5a_26" />
                    <asp:BoundField DataField="pw_crf5a_27a" HeaderText="pw_crf5a_27a" />
                    <asp:BoundField DataField="pw_crf5a_27b" HeaderText="pw_crf5a_27b" />
                    <asp:BoundField DataField="pw_crf5a_27c" HeaderText="pw_crf5a_27c" />
                    <asp:BoundField DataField="pw_crf5a_27d" HeaderText="pw_crf5a_27d" />
                    <asp:BoundField DataField="pw_crf5a_27e" HeaderText="pw_crf5a_27e" />
                    <asp:BoundField DataField="pw_crf5a_27f" HeaderText="pw_crf5a_27f" />
                    <asp:BoundField DataField="pw_crf5a_28" HeaderText="pw_crf5a_28" />
                    <asp:BoundField DataField="pw_crf5a_29a" HeaderText="pw_crf5a_29a" />
                    <asp:BoundField DataField="pw_crf5a_29b" HeaderText="pw_crf5a_29b" />
                    <asp:BoundField DataField="pw_crf5a_29c" HeaderText="pw_crf5a_29c" />
                    <asp:BoundField DataField="pw_crf5a_29d" HeaderText="pw_crf5a_29d" />
                    <asp:BoundField DataField="pw_crf5a_29e" HeaderText="pw_crf5a_29e" />
                    <asp:BoundField DataField="pw_crf5a_29f" HeaderText="pw_crf5a_29f" />
                    <asp:BoundField DataField="pw_crf5a_30" HeaderText="pw_crf5a_30" />
                    <asp:BoundField DataField="pw_crf5a_31" HeaderText="pw_crf5a_31" />
                    <asp:BoundField DataField="pw_crf5a_32" HeaderText="pw_crf5a_32" />
                    <asp:BoundField DataField="pw_crf5a_33" HeaderText="pw_crf5a_33" />
                    <asp:BoundField DataField="pw_crf5a_34" HeaderText="pw_crf5a_34" />
                    <asp:BoundField DataField="pw_crf5a_35" HeaderText="pw_crf5a_35" />
                    <asp:BoundField DataField="pw_crf5a_36" HeaderText="pw_crf5a_36" />
                    <asp:BoundField DataField="pw_crf5a_37" HeaderText="pw_crf5a_37" />
                    <asp:BoundField DataField="pw_crf5a_38" HeaderText="pw_crf5a_38" />
                    <asp:BoundField DataField="pw_crf5a_39a" HeaderText="pw_crf5a_39a" />
                    <asp:BoundField DataField="pw_crf5a_39b" HeaderText="pw_crf5a_39b" />
                    <asp:BoundField DataField="pw_crf5a_39c" HeaderText="pw_crf5a_39c" />
                    <asp:BoundField DataField="pw_crf5a_39d" HeaderText="pw_crf5a_39d" />
                    <asp:BoundField DataField="pw_crf5a_39e" HeaderText="pw_crf5a_39e" />
                    <asp:BoundField DataField="pw_crf5a_40" HeaderText="pw_crf5a_40" />
                    <asp:BoundField DataField="pw_crf5a_41" HeaderText="pw_crf5a_41" />
                    <asp:BoundField DataField="pw_crf5a_42" HeaderText="pw_crf5a_42" />
                    <asp:BoundField DataField="pw_crf5a_43" HeaderText="pw_crf5a_43" />
                    <asp:BoundField DataField="pw_crf5a_44" HeaderText="pw_crf5a_44" />
                    <asp:BoundField DataField="pw_crf5a_45" HeaderText="pw_crf5a_45" />
                    <asp:BoundField DataField="pw_crf5a_46" HeaderText="pw_crf5a_46" />
                    <asp:BoundField DataField="pw_crf5a_47" HeaderText="pw_crf5a_47" />
                    <asp:BoundField DataField="pw_crf5a_48" HeaderText="pw_crf5a_48" />
                    <asp:BoundField DataField="pw_crf5a_49" HeaderText="pw_crf5a_49" />
                    <asp:BoundField DataField="pw_crf5a_50" HeaderText="pw_crf5a_50" />
                    <asp:BoundField DataField="pw_crf5a_51" HeaderText="pw_crf5a_51" />
                    <asp:BoundField DataField="pw_crf5a_52" HeaderText="pw_crf5a_52" />
                    <asp:BoundField DataField="pw_crf5a_53" HeaderText="pw_crf5a_53" />
                    <asp:BoundField DataField="pw_crf5a_54" HeaderText="pw_crf5a_54" />
                    <asp:BoundField DataField="pw_crf5a_55" HeaderText="pw_crf5a_55" />
                    <asp:BoundField DataField="pw_crf5a_56" HeaderText="pw_crf5a_56" />
                    <asp:BoundField DataField="pw_crf5a_57" HeaderText="pw_crf5a_57" />
                    <asp:BoundField DataField="pw_crf5a_58" HeaderText="pw_crf5a_58" />
                    <asp:BoundField DataField="pw_crf5a_59" HeaderText="pw_crf5a_59" />
                    <asp:BoundField DataField="pw_crf5a_60" HeaderText="pw_crf5a_60" />
                    <asp:BoundField DataField="pw_crf5a_61" HeaderText="pw_crf5a_61" />
                    <asp:BoundField DataField="pw_crf5a_62" HeaderText="pw_crf5a_62" />
                    <asp:BoundField DataField="pw_crf5a_63" HeaderText="pw_crf5a_63" />
                    <asp:BoundField DataField="pw_crf5a_64" HeaderText="pw_crf5a_64" />
                    <asp:BoundField DataField="pw_crf5a_65" HeaderText="pw_crf5a_65" />
                    <asp:BoundField DataField="pw_crf5a_66" HeaderText="pw_crf5a_66" />
                    <asp:BoundField DataField="pw_crf5a_67" HeaderText="pw_crf5a_67" />
                    <asp:BoundField DataField="pw_crf5a_68" HeaderText="pw_crf5a_68" />
                    <asp:BoundField DataField="pw_crf5a_69" HeaderText="pw_crf5a_69" />
                    <asp:BoundField DataField="pw_crf5a_70" HeaderText="pw_crf5a_70" />
                    <asp:BoundField DataField="pw_crf5a_71" HeaderText="pw_crf5a_71" />
                    <asp:BoundField DataField="pw_crf5a_72a" HeaderText="pw_crf5a_72a" />
                    <asp:BoundField DataField="pw_crf5a_72b" HeaderText="pw_crf5a_72b" />
                    <asp:BoundField DataField="pw_crf5a_72c" HeaderText="pw_crf5a_72c" />
                    <asp:BoundField DataField="pw_crf5a_72d" HeaderText="pw_crf5a_72d" />
                    <asp:BoundField DataField="pw_crf5a_72e" HeaderText="pw_crf5a_72e" />
                    <asp:BoundField DataField="pw_crf5a_72f" HeaderText="pw_crf5a_72f" />
                    <asp:BoundField DataField="pw_crf5a_72g" HeaderText="pw_crf5a_72g" />
<asp:BoundField DataField="pw_crf5a_73" HeaderText="pw_crf5a_73" />
<asp:BoundField DataField="pw_crf5a_74" HeaderText="pw_crf5a_74" />
<asp:BoundField DataField="pw_crf5a_75" HeaderText="pw_crf5a_75" />
<asp:BoundField DataField="pw_crf5a_76a" HeaderText="pw_crf5a_76a" />
<asp:BoundField DataField="pw_crf5a_76b" HeaderText="pw_crf5a_76b" />
<asp:BoundField DataField="pw_crf5a_76c" HeaderText="pw_crf5a_76c" />
<asp:BoundField DataField="pw_crf5a_76d" HeaderText="pw_crf5a_76d" />
<asp:BoundField DataField="pw_crf5a_76e" HeaderText="pw_crf5a_76e" />
<asp:BoundField DataField="pw_crf5a_76f" HeaderText="pw_crf5a_76f" />
					<asp:BoundField DataField="pw_crf5a_76g" HeaderText="pw_crf5a_76g" />
                    <asp:BoundField DataField="pw_crf5a_77" HeaderText="pw_crf5a_77" />
                    <asp:BoundField DataField="pw_crf5a_78" HeaderText="pw_crf5a_78" />
                    <asp:BoundField DataField="pw_crf5a_79" HeaderText="pw_crf5a_79" />
                    <asp:BoundField DataField="pw_crf5a_80" HeaderText="pw_crf5a_80" />
                    <asp:BoundField DataField="pw_crf5a_81" HeaderText="pw_crf5a_81" />
                    <asp:BoundField DataField="pw_crf5a_82" HeaderText="pw_crf5a_82" />
                    <asp:BoundField DataField="pw_crf5a_83" HeaderText="pw_crf5a_83" />
                    <asp:BoundField DataField="pw_crf5a_84" HeaderText="pw_crf5a_84" />
                    <asp:BoundField DataField="pw_crf5a_85" HeaderText="pw_crf5a_85" />
                    <asp:BoundField DataField="pw_crf5a_86a" HeaderText="pw_crf5a_86a" />
                    <asp:BoundField DataField="pw_crf5a_86b" HeaderText="pw_crf5a_86b" />
                    <asp:BoundField DataField="pw_crf5a_86c" HeaderText="pw_crf5a_86c" />
                    <asp:BoundField DataField="pw_crf5a_86d" HeaderText="pw_crf5a_86d" />
                    <asp:BoundField DataField="pw_crf5a_86e" HeaderText="pw_crf5a_86e" />
                    <asp:BoundField DataField="pw_crf5a_86f" HeaderText="pw_crf5a_86f" />
                    <asp:BoundField DataField="pw_crf5a_86g" HeaderText="pw_crf5a_86g" />
                    <asp:BoundField DataField="pw_crf5a_86h" HeaderText="pw_crf5a_86h" />
                    <asp:BoundField DataField="pw_crf5a_86i" HeaderText="pw_crf5a_86i" />
                    <asp:BoundField DataField="pw_crf5a_86j" HeaderText="pw_crf5a_86j" />
                    <asp:BoundField DataField="pw_crf5a_86k" HeaderText="pw_crf5a_86k" />
                    <asp:BoundField DataField="pw_crf5a_86l" HeaderText="pw_crf5a_86l" />
                    <asp:BoundField DataField="pw_crf5a_86m" HeaderText="pw_crf5a_86m" />
                    <asp:BoundField DataField="pw_crf5a_86n" HeaderText="pw_crf5a_86n" />
                    <asp:BoundField DataField="pw_crf5a_86o" HeaderText="pw_crf5a_86o" />
                    <asp:BoundField DataField="pw_crf5a_86p" HeaderText="pw_crf5a_86p" />
                    <asp:BoundField DataField="counsil_start_time" HeaderText="counsil_start_time" />
                    <asp:BoundField DataField="counsil_end_time" HeaderText="counsil_end_time" />
                    <asp:BoundField DataField="sra_name" HeaderText="sra_name" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>

