<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="showcrf2.aspx.cs" Inherits="maamta_pw.showcrf2" %>

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
            Trial Eligibility Form:
            <asp:Label ID="lbeDateFromTo" ForeColor="#10ac84" Font-Size="17px" Font-Bold="true" runat="server" Text=""></asp:Label>
        </div>
        <hr style="border-top: 1px solid #ccc; background: transparent; margin-top: -3px" />

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
                    <asp:BoundField DataField="unique_id" HeaderText="unique_id" />
                    <asp:BoundField DataField="vr_id" HeaderText="vr_id" />
                    <asp:BoundField DataField="crf2_id" HeaderText="crf2_id" />
                    <asp:TemplateField HeaderText="Assisment ID">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkAssis" OnClick="Link_Assis" Text='<%#Eval("assis_id") %>' runat="server" ToolTip="Form Detail" CommandArgument='<%#Eval("crf2_id")+","+ Eval("assis_id")%>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="pw_crf2_2" HeaderText="pw_crf2_2" />
                    <asp:BoundField DataField="pw_crf2_3" HeaderText="pw_crf2_3" />
                    <asp:BoundField DataField="woman_nm" HeaderText="woman_nm" />
                    <asp:BoundField DataField="husband_nm" HeaderText="husband_nm" />
                    <asp:BoundField DataField="dssid" HeaderText="dssid" />
                    <asp:BoundField DataField="Site" HeaderText="Site" />
                    <asp:BoundField DataField="Para" HeaderText="Para" />
                    <asp:BoundField DataField="Block" HeaderText="Block" />
                    <asp:BoundField DataField="Struct" HeaderText="Struct" />
                    <asp:BoundField DataField="HH" HeaderText="HH" />
                    <asp:BoundField DataField="Wm_No" HeaderText="Wm_No" />
                    <asp:BoundField DataField="pw_crf2_17" HeaderText="pw_crf2_17" />
                    <asp:BoundField DataField="pw_crf2_17_reason" HeaderText="pw_crf2_17_reason" />
                    <asp:BoundField DataField="pw_crf2_18" HeaderText="pw_crf2_18" />
                    <asp:BoundField DataField="pw_crf2_19" HeaderText="pw_crf2_19" />
                    <asp:BoundField DataField="pw_crf2_20" HeaderText="pw_crf2_20" />
                    <asp:BoundField DataField="pw_crf2_21_weeks" HeaderText="pw_crf2_21_weeks" />
                    <asp:BoundField DataField="pw_crf2_21_days" HeaderText="pw_crf2_21_days" />
                    <asp:BoundField DataField="pw_crf2_25" HeaderText="pw_crf2_25" />
                    <asp:BoundField DataField="pw_crf2_27" HeaderText="pw_crf2_27" />
                    <asp:BoundField DataField="pw_crf2_29" HeaderText="pw_crf2_29" />
                    <asp:BoundField DataField="pw_crf2_30" HeaderText="pw_crf2_30" />
                    <asp:BoundField DataField="pw_crf2_31" HeaderText="pw_crf2_31" />
                    <asp:BoundField DataField="pw_crf2_32" HeaderText="pw_crf2_32" />
                    <asp:BoundField DataField="pw_crf2_33" HeaderText="pw_crf2_33" />
                    <asp:BoundField DataField="pw_crf2_34" HeaderText="pw_crf2_34" />
                    <asp:BoundField DataField="pw_crf2_35" HeaderText="pw_crf2_35" />
                    <asp:BoundField DataField="pw_crf2_36" HeaderText="pw_crf2_36" />
                    <asp:BoundField DataField="pw_crf2_37" HeaderText="pw_crf2_37" />
                    <asp:BoundField DataField="pw_crf2_38" HeaderText="pw_crf2_38" />
                    <asp:BoundField DataField="pw_crf2_39_a" HeaderText="pw_crf2_39_a" />
                    <asp:BoundField DataField="pw_crf2_39_b" HeaderText="pw_crf2_39_b" />
                    <asp:BoundField DataField="pw_crf2_39_c" HeaderText="pw_crf2_39_c" />
                    <asp:BoundField DataField="pw_crf2_39_d" HeaderText="pw_crf2_39_d" />
                    <asp:BoundField DataField="pw_crf2_39_e" HeaderText="pw_crf2_39_e" />
                    <asp:BoundField DataField="pw_crf2_39_f" HeaderText="pw_crf2_39_f" />
                    <asp:BoundField DataField="pw_crf2_39_g" HeaderText="pw_crf2_39_g" />
                    <asp:BoundField DataField="pw_crf2_39_h" HeaderText="pw_crf2_39_h" />
                    <asp:BoundField DataField="pw_crf2_40" HeaderText="pw_crf2_40" />
                    <asp:BoundField DataField="pw_crf2_41" HeaderText="pw_crf2_41" />
                    <asp:BoundField DataField="pw_crf2_42" HeaderText="pw_crf2_42" />
                    <asp:BoundField DataField="pw_crf2_42_reason" HeaderText="pw_crf2_42_reason" />
                    <asp:BoundField DataField="pw_crf2_43" HeaderText="pw_crf2_43" />
                    <asp:BoundField DataField="pw_crf2_43_reason" HeaderText="pw_crf2_43_reason" />
                    <asp:BoundField DataField="pw_crf2_44" HeaderText="pw_crf2_44" />
                    <asp:BoundField DataField="pw_crf2_45" HeaderText="pw_crf2_45" />
                    <asp:BoundField DataField="pw_crf2_46" HeaderText="pw_crf2_46" />
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
                    <asp:BoundField DataField="unique_id" HeaderText="unique_id" />
                    <asp:BoundField DataField="vr_id" HeaderText="vr_id" />
                    <asp:BoundField DataField="crf2_id" HeaderText="crf2_id" />
                    <asp:BoundField DataField="assis_id" HeaderText="assis_id" />
                    <asp:BoundField DataField="pw_crf2_2" HeaderText="pw_crf2_2" />
                    <asp:BoundField DataField="pw_crf2_3" HeaderText="pw_crf2_3" />
                    <asp:BoundField DataField="woman_nm" HeaderText="woman_nm" />
                    <asp:BoundField DataField="husband_nm" HeaderText="husband_nm" />
                    <asp:BoundField DataField="dssid" HeaderText="dssid" />
                    <asp:BoundField DataField="Site" HeaderText="Site" />
                    <asp:BoundField DataField="Para" HeaderText="Para" />
                    <asp:BoundField DataField="Block" HeaderText="Block" />
                    <asp:BoundField DataField="Struct" HeaderText="Struct" />
                    <asp:BoundField DataField="HH" HeaderText="HH" />
                    <asp:BoundField DataField="Wm_No" HeaderText="Wm_No" />
                    <asp:BoundField DataField="pw_crf2_17" HeaderText="pw_crf2_17" />
                    <asp:BoundField DataField="pw_crf2_17_reason" HeaderText="pw_crf2_17_reason" />
                    <asp:BoundField DataField="pw_crf2_18" HeaderText="pw_crf2_18" />
                    <asp:BoundField DataField="pw_crf2_19" HeaderText="pw_crf2_19" />
                    <asp:BoundField DataField="pw_crf2_20" HeaderText="pw_crf2_20" />
                    <asp:BoundField DataField="pw_crf2_21_weeks" HeaderText="pw_crf2_21_weeks" />
                    <asp:BoundField DataField="pw_crf2_21_days" HeaderText="pw_crf2_21_days" />
                    <asp:BoundField DataField="pw_crf2_25" HeaderText="pw_crf2_25" />
                    <asp:BoundField DataField="pw_crf2_27" HeaderText="pw_crf2_27" />
                    <asp:BoundField DataField="pw_crf2_29" HeaderText="pw_crf2_29" />
                    <asp:BoundField DataField="pw_crf2_30" HeaderText="pw_crf2_30" />
                    <asp:BoundField DataField="pw_crf2_31" HeaderText="pw_crf2_31" />
                    <asp:BoundField DataField="pw_crf2_32" HeaderText="pw_crf2_32" />
                    <asp:BoundField DataField="pw_crf2_33" HeaderText="pw_crf2_33" />
                    <asp:BoundField DataField="pw_crf2_34" HeaderText="pw_crf2_34" />
                    <asp:BoundField DataField="pw_crf2_35" HeaderText="pw_crf2_35" />
                    <asp:BoundField DataField="pw_crf2_36" HeaderText="pw_crf2_36" />
                    <asp:BoundField DataField="pw_crf2_37" HeaderText="pw_crf2_37" />
                    <asp:BoundField DataField="pw_crf2_38" HeaderText="pw_crf2_38" />
                    <asp:BoundField DataField="pw_crf2_39_a" HeaderText="pw_crf2_39_a" />
                    <asp:BoundField DataField="pw_crf2_39_b" HeaderText="pw_crf2_39_b" />
                    <asp:BoundField DataField="pw_crf2_39_c" HeaderText="pw_crf2_39_c" />
                    <asp:BoundField DataField="pw_crf2_39_d" HeaderText="pw_crf2_39_d" />
                    <asp:BoundField DataField="pw_crf2_39_e" HeaderText="pw_crf2_39_e" />
                    <asp:BoundField DataField="pw_crf2_39_f" HeaderText="pw_crf2_39_f" />
                    <asp:BoundField DataField="pw_crf2_39_g" HeaderText="pw_crf2_39_g" />
                    <asp:BoundField DataField="pw_crf2_39_h" HeaderText="pw_crf2_39_h" />
                    <asp:BoundField DataField="pw_crf2_40" HeaderText="pw_crf2_40" />
                    <asp:BoundField DataField="pw_crf2_41" HeaderText="pw_crf2_41" />
                    <asp:BoundField DataField="pw_crf2_42" HeaderText="pw_crf2_42" />
                    <asp:BoundField DataField="pw_crf2_42_reason" HeaderText="pw_crf2_42_reason" />
                    <asp:BoundField DataField="pw_crf2_43" HeaderText="pw_crf2_43" />
                    <asp:BoundField DataField="pw_crf2_43_reason" HeaderText="pw_crf2_43_reason" />
                    <asp:BoundField DataField="pw_crf2_44" HeaderText="pw_crf2_44" />
                    <asp:BoundField DataField="pw_crf2_45" HeaderText="pw_crf2_45" />
                    <asp:BoundField DataField="pw_crf2_46" HeaderText="pw_crf2_46" />
                    <asp:BoundField DataField="sra_name" HeaderText="sra_name" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
