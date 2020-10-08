<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="labinvestigation.aspx.cs" Inherits="maamta_pw.labinvestigation" %>
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


    <div style="padding-left: 2%; margin-top: 15px;">
        <div style="color: #ff6b6b; font-size: 22px; width: 100%">
            LAB Investigation:
            <asp:Label ID="lbeDateFromTo" ForeColor="#10ac84" Font-Size="17px" Font-Bold="true" runat="server" Text=""></asp:Label>
        </div>
        <hr style="border-top: 1px solid #ccc; background: transparent; margin-top: -3px">

        <div id="divExportButton" runat="server" style="text-align: right; margin-top: -17px">
            <button type="button" id="Button1" class="btn btn-success" runat="server" style="height: 38px" onserverclick="btnExport_Click">
                Export &nbsp<span class="glyphicon glyphicon-export"></span>
            </button>
            <button type="button" id="Button3" class="btn btn-success" runat="server" style="height: 38px" onserverclick="btnReportPending_Click">
                Specimen Pending &nbsp<span class="glyphicon glyphicon-export"></span>
            </button>
        </div>

        <%--Search Button--%>

        <div id="Div2" runat="server" class="col-lg-4 col-lg-offset-4" style="margin-bottom: 10px; margin-top: 7px;">
            <asp:DropDownList ID="DropDownListWeeks" CssClass="form-control textDropDownCSS" data-style="btn-primary" runat="server">
                <asp:ListItem Value="0">Select Weeks of Pregnancy</asp:ListItem>
                <asp:ListItem Value="19">19 Weeks or Less</asp:ListItem>
                <asp:ListItem Value="32">32 Weeks or Less</asp:ListItem>
            </asp:DropDownList>
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
                <div class="Mobile">
                    <table style="width: 100%; text-align: center; margin-left: 1%; margin-bottom: 15px">
                        <tr>
                            <td class="tddd">
                                <asp:TextBox ID="txtCalndrDate" Font-Bold="true" Font-Size="16px" ClientIDMode="Static" CssClass="txtboxx" Height="32px" runat="server" Width="8.0em"></asp:TextBox>
                                <asp:ImageButton ID="btnCalndrDate" ImageUrl="~/assets/img/calendar1.png" CssClass="calanderButton" runat="server" />
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtCalndrDate" PopupButtonID="btnCalndrDate" Format="dd-MM-yyyy" />
                                &nbsp To &nbsp
                                <asp:TextBox ID="txtCalndrDate1" Font-Bold="true" Font-Size="16px" CssClass="txtboxx" Height="32px" runat="server" Width="8.0em"></asp:TextBox>
                                <asp:ImageButton ID="btnCalndrDate1" ImageUrl="~/assets/img/calendar1.png" CssClass="calanderButton" runat="server" />
                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtCalndrDate1" PopupButtonID="btnCalndrDate1" Format="dd-MM-yyyy" />
                                <asp:Button ID="btnSearch" runat="server" class="btn btn-theme" OnClick="btnSearch_Click" Text="Search" />

                            </td>
                        </tr>
                    </table>
                </div>


                <%--End   Date checks--%>


                <div style="width: 100%; height: 460px; overflow: scroll; margin-top: 20px">
                    <asp:GridView ID="GridView1" runat="server" EmptyDataText="No Record Found." AllowPaging="True" PageSize="200" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDataBound="OnRowDataBound" CssClass="footable" AllowSorting="false" ForeColor="#333333" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Link_id" OnClick="Link_EditForm" Text='Edit' runat="server" ToolTip="enter Lab Information" CommandArgument='<%#Eval("Randomization_ID")%>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Serial no.">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                                <ItemStyle Width="2%" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="study_code" HeaderText="study_code" />
                            <asp:BoundField DataField="Randomization_ID" HeaderText="Randomization_ID" />
                            <asp:BoundField DataField="dssid" HeaderText="dssid" />
                            <asp:BoundField DataField="Block" HeaderText="Block" />
                            <asp:BoundField DataField="woman_nm" HeaderText="woman_nm" />
                            <asp:BoundField DataField="husband_nm" HeaderText="husband_nm" />
                            <asp:BoundField DataField="Enrollment" HeaderText="Enrollment" />
                            <asp:BoundField DataField="ARM" HeaderText="ARM" />
                            <asp:BoundField DataField="19_weeks" HeaderText="19_weeks" />
                            <asp:BoundField DataField="32_weeks" HeaderText="32_weeks" />
                            <asp:BoundField DataField="HB_FR_Vit_D_at_enrollment_and_week_32" HeaderText="HB, Ferritin, Vitamin-D at Enrollment and week 32" />
                            <asp:BoundField DataField="Description" HeaderText="Description" />
                            <asp:BoundField DataField="" HeaderText="" />
                            <asp:BoundField DataField="enrollment_urine" HeaderText="Enrollment Urine" />
                            <asp:BoundField DataField="enrollment_urine_Weeks" HeaderText="Enrollment Urine Weeks" />
                            <asp:BoundField DataField="enrollment_hb" HeaderText="Enrollment HB" />
                            <asp:BoundField DataField="enrollment_hb_Weeks" HeaderText="Enrollment HB Weeks" />
                            <asp:BoundField DataField="enrollment_serum" HeaderText="Enrollment Serum" />
                            <asp:BoundField DataField="enrollment_serum_Weeks" HeaderText="Enrollment Serum Weeks" />
                            <asp:BoundField DataField="enrollment_plasma_niacin" HeaderText="Enrollment Plasma Niacin" />
                            <asp:BoundField DataField="enrollment_plasma_niacin_Weeks" HeaderText="Enrollment Plasma Niacin Weeks" />
                            <asp:BoundField DataField="19_wks_plasma" HeaderText="19 wks Plasma" />
                            <asp:BoundField DataField="19_wks_plasma_Weeks" HeaderText="19 wks Plasma Weeks" />
                            <asp:BoundField DataField="32_wks_urine" HeaderText="32 wks Urine" />
                            <asp:BoundField DataField="32_wks_urine_Weeks" HeaderText="32 wks Urine Weeks" />
                            <asp:BoundField DataField="32_wks_hb" HeaderText="32 wks HB" />
                            <asp:BoundField DataField="32_wks_hb_Weeks" HeaderText="32 wks HB Weeks" />
                            <asp:BoundField DataField="32_wks_serum" HeaderText="32 wks Serum" />
                            <asp:BoundField DataField="32_wks_serum_Weeks" HeaderText="32 wks Serum Weeks" />
                            <asp:BoundField DataField="32_wks_plasma_proteomic" HeaderText="32 wks Plasma Proteomic" />
                            <asp:BoundField DataField="32_wks_plasma_proteomic_Weeks" HeaderText="32 wks Plasma Proteomic Weeks" />
                            <asp:BoundField DataField="32_wks_plasma_niacin" HeaderText="32 wks Plasma Niacin" />
                            <asp:BoundField DataField="32_wks_plasma_niacin_Weeks" HeaderText="32 wks Plasma Niacin Weeks" />
                            <asp:BoundField DataField="cord_blood_dt" HeaderText="Cord Blood Collecting Date" />
                            <asp:BoundField DataField="cord_blood_tm" HeaderText="Cord Blood Collecting Time" />
                            <asp:BoundField DataField="Duration_Cord_Blood" HeaderText="Duration Cord Blood" />
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



                    <asp:GridView ID="GridView2" runat="server" EmptyDataText="No Record Found." CssClass="footable" AllowSorting="false" ForeColor="#333333" AutoGenerateColumns="false">
                        <Columns>
                         
                            <asp:TemplateField HeaderText="Serial no.">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                                <ItemStyle Width="2%" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="study_code" HeaderText="study_code" />
                            <asp:BoundField DataField="Randomization_ID" HeaderText="Randomization_ID" />
                            <asp:BoundField DataField="dssid" HeaderText="dssid" />
                            <asp:BoundField DataField="Block" HeaderText="Block" />
                            <asp:BoundField DataField="woman_nm" HeaderText="woman_nm" />
                            <asp:BoundField DataField="husband_nm" HeaderText="husband_nm" />
                            <asp:BoundField DataField="Enrollment" HeaderText="Enrollment" />
                            <asp:BoundField DataField="ARM" HeaderText="ARM" />
                            <asp:BoundField DataField="19_weeks" HeaderText="19_weeks" />
                            <asp:BoundField DataField="32_weeks" HeaderText="32_weeks" />
                            <asp:BoundField DataField="HB_FR_Vit_D_at_enrollment_and_week_32" HeaderText="HB, Ferritin, Vitamin-D at Enrollment and week 32" />
                            <asp:BoundField DataField="Description" HeaderText="Description" />
                            <asp:BoundField DataField="enrollment_urine" HeaderText="Enrollment Urine" />
                            <asp:BoundField DataField="enrollment_urine_Weeks" HeaderText="Enrollment Urine Weeks" />
                            <asp:BoundField DataField="enrollment_hb" HeaderText="Enrollment HB" />
                            <asp:BoundField DataField="enrollment_hb_Weeks" HeaderText="Enrollment HB Weeks" />
                            <asp:BoundField DataField="enrollment_serum" HeaderText="Enrollment Serum" />
                            <asp:BoundField DataField="enrollment_serum_Weeks" HeaderText="Enrollment Serum Weeks" />
                            <asp:BoundField DataField="enrollment_plasma_niacin" HeaderText="Enrollment Plasma Niacin" />
                            <asp:BoundField DataField="enrollment_plasma_niacin_Weeks" HeaderText="Enrollment Plasma Niacin Weeks" />
                            <asp:BoundField DataField="19_wks_plasma" HeaderText="19 wks Plasma" />
                            <asp:BoundField DataField="19_wks_plasma_Weeks" HeaderText="19 wks Plasma Weeks" />
                            <asp:BoundField DataField="32_wks_urine" HeaderText="32 wks Urine" />
                            <asp:BoundField DataField="32_wks_urine_Weeks" HeaderText="32 wks Urine Weeks" />
                            <asp:BoundField DataField="32_wks_hb" HeaderText="32 wks HB" />
                            <asp:BoundField DataField="32_wks_hb_Weeks" HeaderText="32 wks HB Weeks" />
                            <asp:BoundField DataField="32_wks_serum" HeaderText="32 wks Serum" />
                            <asp:BoundField DataField="32_wks_serum_Weeks" HeaderText="32 wks Serum Weeks" />
                            <asp:BoundField DataField="32_wks_plasma_proteomic" HeaderText="32 wks Plasma Proteomic" />
                            <asp:BoundField DataField="32_wks_plasma_proteomic_Weeks" HeaderText="32 wks Plasma Proteomic Weeks" />
                            <asp:BoundField DataField="32_wks_plasma_niacin" HeaderText="32 wks Plasma Niacin" />
                            <asp:BoundField DataField="32_wks_plasma_niacin_Weeks" HeaderText="32 wks Plasma Niacin Weeks" />
                            <asp:BoundField DataField="cord_blood_dt" HeaderText="Cord Blood Collecting Date" />
                            <asp:BoundField DataField="cord_blood_tm" HeaderText="Cord Blood Collecting Time" />
                            <asp:BoundField DataField="Duration_Cord_Blood" HeaderText="Duration Cord Blood" />
                        </Columns>
                    </asp:GridView>
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>



       


        <asp:GridView ID="GridView5" runat="server" CssClass="footable" ForeColor="#333333" AutoGenerateColumns="true">
        </asp:GridView>
    </div>
</asp:Content>
