<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="labinvestigationEdit.aspx.cs" Inherits="maamta_pw.labinvestigationEdit" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /*change Color of Radio Button*/

        .textDropDownCSS {
            font-size: 1.0em;
            font-family: Calibri;
            Height: 2.3em;
            color: #16a085;
        }

        .RomanEnglish {
            color: #BE90D4;
            margin-top: 0.5em;
        }

        /* For Label CSS */
        .labelCSS {
            font-family: Calibri;
            font-size: 1.1em;
            color: #446CB3;
            /*#3A539B*/
        }

        /* For Textbox CSS */
        .textBoxCSS {
            font-size: 1em;
            font-family: Calibri;
            Height: 2.4em;
            color: #446CB3;
        }


        /* For First Column of Table (Questions)*/
        .TableColumn {
            color: black;
            font-family: Trebuchet MS;
            font-size: 1.2em;
            height: auto;
        }

        /* For Last Column of Table Row Distance*/
        .Space {
            margin-bottom: 1.5%;
        }

        /* Radio Button Space */
        .RadioSpace label {
            font-family: Calibri;
            margin-left: 10px;
            color: #486591;
            font-size: 1em;
        }



        /* For Mobile Browser*/
        @media only screen and (max-width: 40em) {

            thead th {
                display: none;
            }

            td[data-th]:before {
                content: attr(data-th);
            }



            /* own design*/
            table {
                border-collapse: collapse;
                width: 100%;
            }

            .trCSS {
                border-bottom: 1px solid #ddd;
            }

            .tdCSS {
                margin-top: 1em;
                display: block;
                font-family: Trebuchet MS;
                text-align: center;
            }

            .Mobile {
                width: 90%;
                padding-left: 7%;
            }

            .ColumTOP {
                padding-top: 2.2em;
            }

            .ColumBOTTOM {
                padding-bottom: 1em;
            }
        }







        /* For Web Browser*/

        @media only screen and (min-width: 40em) {
            .buttonWeb {
                width: 22%;
                margin-left: 38%;
            }

            table {
                border-collapse: collapse;
                width: 100%;
            }

            .tdCSS {
                width: 50%;
                padding: 7px;
                text-align: left;
                border-bottom: 1px solid #ddd;
            }

            .Mobile {
                padding-left: 5%;
                text-align: center;
                width: 95%;
            }

            .trCSS {
                height: 50px;
            }
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="divBackButton" runat="server" style="margin-top: 5px; font-size: 18px; margin-bottom: 15px">
        <button type="submit" id="btnBack" runat="server" onserverclick="btnBack_Click" class="transparentButton logout">
            <span class="glyphicon glyphicon-chevron-left"></span>Back
        </button>
    </div>
    <asp:Panel ID="Panel1" runat="server" DefaultButton="btnSubmit">
        <hr />
        <div class="Mobile">
            <table style="width: 100%; font-size: 1em; color: #4f5963; text-align: left;">


                <tr class="trCSS">
                    <td class="TableColumn tdCSS">Randomization ID</td>
                    <td class="Space tdCSS">
                        <asp:TextBox CssClass="form-control input-lg" ReadOnly="true" ID="txtRandomid" ClientIDMode="Static" Style="text-transform: uppercase;" type="text" Font-Size="Medium" Height="2.1em" placeholder="random id" MaxLength="6" runat="server"></asp:TextBox></td>
                </tr>
                <tr class="trCSS">
                    <td class="TableColumn tdCSS">Woman Name</td>
                    <td class="Space tdCSS">
                        <asp:TextBox CssClass="form-control input-lg" ReadOnly="true" ID="txtwomannm" ClientIDMode="Static" Style="text-transform: uppercase;" type="text" Font-Size="Medium" Height="2.1em" placeholder="random id" MaxLength="6" runat="server"></asp:TextBox></td>
                </tr>
                <tr class="trCSS">
                    <td class="TableColumn tdCSS">Husband Name</td>
                    <td class="Space tdCSS">
                        <asp:TextBox CssClass="form-control input-lg" ReadOnly="true" ID="txthusbandnm" ClientIDMode="Static" Style="text-transform: uppercase;" type="text" Font-Size="Medium" Height="2.1em" placeholder="random id" MaxLength="6" runat="server"></asp:TextBox></td>
                </tr>
                <tr class="trCSS">
                    <td class="TableColumn tdCSS">Description</td>
                    <td class="Space tdCSS">
                        <asp:TextBox CssClass="form-control input-lg" ReadOnly="true" ID="txtDescription" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="none" runat="server"></asp:TextBox></td>
                </tr>








                <tr class="trCSS" style="font-size: 17px; background-color: whitesmoke">
                    <td class="TableColumn tdCSS" colspan="2" style="text-align: center;">During Enrollment</td>
                </tr>


                <%--for enrollment_urine--%>
                <tr class="trCSS">
                    <td class="TableColumn tdCSS">Enrollment Urine</td>

                    <td class="Space tdCSS">
                        <%--Start    Date checks--%>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:UpdateProgress ID="updateProgress2" runat="server">
                                    <ProgressTemplate>
                                        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.75;">
                                            <span style="border-width: 0px; border-radius: 10px; position: fixed; padding: 4%; color: white; background-color: #33D9B2; font-size: 36px; left: 40%; top: 40%;">Loading ...</span>
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                <div class="Mobile" id="Div2" runat="server">
                                    <table style="width: 100%; margin-bottom: 15px">
                                        <tr>
                                            <td class="tddd">
                                                <asp:TextBox ID="txtenrollment_urine" Enabled="false" Font-Bold="true" Font-Size="16px" ClientIDMode="Static" CssClass="txtboxx" placeholder="dd-MM-yyyy" Height="32px" runat="server" Width="8.3em"></asp:TextBox>
                                                <asp:ImageButton ID="imgenrollment_urine" ImageUrl="~/assets/img/calendar1.png" CssClass="calanderButton" runat="server" />
                                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtenrollment_urine" PopupButtonID="imgenrollment_urine" Format="dd-MM-yyyy" />
                                                <asp:CheckBox ID="chk_enrollment_urine" runat="server" OnCheckedChanged="enrollment_urine_CheckedChanged" AutoPostBack="true" CssClass="mycheckbox" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <%--End   Date checks--%>
                    </td>
                </tr>



                <%--for enrollment_hb--%>
                <tr class="trCSS">
                    <td class="TableColumn tdCSS">Enrollment HB</td>

                    <td class="Space tdCSS">
                        <%--Start    Date checks--%>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:UpdateProgress ID="updateProgress1" runat="server">
                                    <ProgressTemplate>
                                        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.75;">
                                            <span style="border-width: 0px; border-radius: 10px; position: fixed; padding: 4%; color: white; background-color: #33D9B2; font-size: 36px; left: 40%; top: 40%;">Loading ...</span>
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                <div class="Mobile" id="Div1" runat="server">
                                    <table style="width: 100%; margin-bottom: 15px">
                                        <tr>
                                            <td class="tddd">
                                                <asp:TextBox ID="txtenrollment_hb" Enabled="false" Font-Bold="true" Font-Size="16px" ClientIDMode="Static" CssClass="txtboxx" placeholder="dd-MM-yyyy" Height="32px" runat="server" Width="8.3em"></asp:TextBox>
                                                <asp:ImageButton ID="imgenrollment_hb" ImageUrl="~/assets/img/calendar1.png" CssClass="calanderButton" runat="server" />
                                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtenrollment_hb" PopupButtonID="imgenrollment_hb" Format="dd-MM-yyyy" />
                                                <asp:CheckBox ID="chk_enrollment_hb" runat="server" OnCheckedChanged="enrollment_hb_CheckedChanged" AutoPostBack="true" CssClass="mycheckbox" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <%--End   Date checks--%>
                    </td>
                </tr>



                <%--for enrollment_serum--%>
                <tr class="trCSS">
                    <td class="TableColumn tdCSS">Enrollment Serum</td>

                    <td class="Space tdCSS">
                        <%--Start    Date checks--%>
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <asp:UpdateProgress ID="updateProgress3" runat="server">
                                    <ProgressTemplate>
                                        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.75;">
                                            <span style="border-width: 0px; border-radius: 10px; position: fixed; padding: 4%; color: white; background-color: #33D9B2; font-size: 36px; left: 40%; top: 40%;">Loading ...</span>
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                <div class="Mobile" id="Div3" runat="server">
                                    <table style="width: 100%; margin-bottom: 15px">
                                        <tr>
                                            <td class="tddd">
                                                <asp:TextBox ID="txtenrollment_serum" Enabled="false" Font-Bold="true" Font-Size="16px" ClientIDMode="Static" CssClass="txtboxx" placeholder="dd-MM-yyyy" Height="32px" runat="server" Width="8.3em"></asp:TextBox>
                                                <asp:ImageButton ID="imgenrollment_serum" ImageUrl="~/assets/img/calendar1.png" CssClass="calanderButton" runat="server" />
                                                <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtenrollment_serum" PopupButtonID="imgenrollment_serum" Format="dd-MM-yyyy" />
                                                <asp:CheckBox ID="chk_enrollment_serum" runat="server" OnCheckedChanged="enrollment_serum_CheckedChanged" AutoPostBack="true" CssClass="mycheckbox" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <%--End   Date checks--%>
                    </td>
                </tr>



                <%--for enrollment_plasma_niacin--%>
                <tr class="trCSS">
                    <td class="TableColumn tdCSS">Enrollment Plasma Niacin</td>

                    <td class="Space tdCSS">
                        <%--Start    Date checks--%>
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>
                                <asp:UpdateProgress ID="updateProgress4" runat="server">
                                    <ProgressTemplate>
                                        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.75;">
                                            <span style="border-width: 0px; border-radius: 10px; position: fixed; padding: 4%; color: white; background-color: #33D9B2; font-size: 36px; left: 40%; top: 40%;">Loading ...</span>
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                <div class="Mobile" id="Div4" runat="server">
                                    <table style="width: 100%; margin-bottom: 15px">
                                        <tr>
                                            <td class="tddd">
                                                <asp:TextBox ID="txtenrollment_plasma_niacin" Enabled="false" Font-Bold="true" Font-Size="16px" ClientIDMode="Static" CssClass="txtboxx" placeholder="dd-MM-yyyy" Height="32px" runat="server" Width="8.3em"></asp:TextBox>
                                                <asp:ImageButton ID="imgenrollment_plasma_niacin" ImageUrl="~/assets/img/calendar1.png" CssClass="calanderButton" runat="server" />
                                                <cc1:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtenrollment_plasma_niacin" PopupButtonID="imgenrollment_plasma_niacin" Format="dd-MM-yyyy" />
                                                <asp:CheckBox ID="chk_enrollment_plasma_niacin" runat="server" OnCheckedChanged="enrollment_plasma_niacin_CheckedChanged" AutoPostBack="true" CssClass="mycheckbox" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <%--End   Date checks--%>
                    </td>
                </tr>








                <tr class="trCSS" style="font-size: 17px; background-color: whitesmoke">
                    <td class="TableColumn tdCSS" colspan="2" style="text-align: center;">Speciman 19 Weeks</td>
                </tr>


                <%--for 19_wks_plasma--%>
                <tr class="trCSS">
                    <td class="TableColumn tdCSS">19 Weeks Plasma</td>

                    <td class="Space tdCSS">
                        <%--Start    Date checks--%>
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                            <ContentTemplate>
                                <asp:UpdateProgress ID="updateProgress5" runat="server">
                                    <ProgressTemplate>
                                        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.75;">
                                            <span style="border-width: 0px; border-radius: 10px; position: fixed; padding: 4%; color: white; background-color: #33D9B2; font-size: 36px; left: 40%; top: 40%;">Loading ...</span>
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                <div class="Mobile" id="Div5" runat="server">
                                    <table style="width: 100%; margin-bottom: 15px">
                                        <tr>
                                            <td class="tddd">
                                                <asp:TextBox ID="txt19_wks_plasma" Enabled="false" Font-Bold="true" Font-Size="16px" ClientIDMode="Static" CssClass="txtboxx" placeholder="dd-MM-yyyy" Height="32px" runat="server" Width="8.3em"></asp:TextBox>
                                                <asp:ImageButton ID="img19_wks_plasma" ImageUrl="~/assets/img/calendar1.png" CssClass="calanderButton" runat="server" />
                                                <cc1:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txt19_wks_plasma" PopupButtonID="img19_wks_plasma" Format="dd-MM-yyyy" />
                                                <asp:CheckBox ID="chk_19_wks_plasma" runat="server" OnCheckedChanged="chk19_wks_plasma_CheckedChanged" AutoPostBack="true" CssClass="mycheckbox" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <%--End   Date checks--%>
                    </td>
                </tr>











                <tr class="trCSS" style="font-size: 17px; background-color: whitesmoke">
                    <td class="TableColumn tdCSS" colspan="2" style="text-align: center;">Speciman 32 Weeks</td>
                </tr>


                <%--for 32_wks_urine--%>
                <tr class="trCSS">
                    <td class="TableColumn tdCSS">32 Weeks Urine</td>

                    <td class="Space tdCSS">
                        <%--Start    Date checks--%>
                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                            <ContentTemplate>
                                <asp:UpdateProgress ID="updateProgress6" runat="server">
                                    <ProgressTemplate>
                                        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.75;">
                                            <span style="border-width: 0px; border-radius: 10px; position: fixed; padding: 4%; color: white; background-color: #33D9B2; font-size: 36px; left: 40%; top: 40%;">Loading ...</span>
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                <div class="Mobile" id="Div6" runat="server">
                                    <table style="width: 100%; margin-bottom: 15px">
                                        <tr>
                                            <td class="tddd">
                                                <asp:TextBox ID="txt32_wks_urine" Enabled="false" Font-Bold="true" Font-Size="16px" ClientIDMode="Static" CssClass="txtboxx" placeholder="dd-MM-yyyy" Height="32px" runat="server" Width="8.3em"></asp:TextBox>
                                                <asp:ImageButton ID="img32_wks_urine" ImageUrl="~/assets/img/calendar1.png" CssClass="calanderButton" runat="server" />
                                                <cc1:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="txt32_wks_urine" PopupButtonID="img32_wks_urine" Format="dd-MM-yyyy" />
                                                <asp:CheckBox ID="chk_32_wks_urine" runat="server" OnCheckedChanged="chk32_wks_urine_CheckedChanged" AutoPostBack="true" CssClass="mycheckbox" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <%--End   Date checks--%>
                    </td>
                </tr>
                <%--for 32_wks_hb--%>
                <tr class="trCSS">
                    <td class="TableColumn tdCSS">32 Weeks HB</td>

                    <td class="Space tdCSS">
                        <%--Start    Date checks--%>
                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                            <ContentTemplate>
                                <asp:UpdateProgress ID="updateProgress7" runat="server">
                                    <ProgressTemplate>
                                        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.75;">
                                            <span style="border-width: 0px; border-radius: 10px; position: fixed; padding: 4%; color: white; background-color: #33D9B2; font-size: 36px; left: 40%; top: 40%;">Loading ...</span>
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                <div class="Mobile" id="Div7" runat="server">
                                    <table style="width: 100%; margin-bottom: 15px">
                                        <tr>
                                            <td class="tddd">
                                                <asp:TextBox ID="txt32_wks_hb" Enabled="false" Font-Bold="true" Font-Size="16px" ClientIDMode="Static" CssClass="txtboxx" placeholder="dd-MM-yyyy" Height="32px" runat="server" Width="8.3em"></asp:TextBox>
                                                <asp:ImageButton ID="img32_wks_hb" ImageUrl="~/assets/img/calendar1.png" CssClass="calanderButton" runat="server" />
                                                <cc1:CalendarExtender ID="CalendarExtender7" runat="server" TargetControlID="txt32_wks_hb" PopupButtonID="img32_wks_hb" Format="dd-MM-yyyy" />
                                                <asp:CheckBox ID="chk_32_wks_hb" runat="server" OnCheckedChanged="chk32_wks_hb_CheckedChanged" AutoPostBack="true" CssClass="mycheckbox" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <%--End   Date checks--%>
                    </td>
                </tr>

                <%--for 32_wks_serum--%>
                <tr class="trCSS">
                    <td class="TableColumn tdCSS">32 Weeks Serum</td>

                    <td class="Space tdCSS">
                        <%--Start    Date checks--%>
                        <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                            <ContentTemplate>
                                <asp:UpdateProgress ID="updateProgress8" runat="server">
                                    <ProgressTemplate>
                                        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.75;">
                                            <span style="border-width: 0px; border-radius: 10px; position: fixed; padding: 4%; color: white; background-color: #33D9B2; font-size: 36px; left: 40%; top: 40%;">Loading ...</span>
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                <div class="Mobile" id="Div8" runat="server">
                                    <table style="width: 100%; margin-bottom: 15px">
                                        <tr>
                                            <td class="tddd">
                                                <asp:TextBox ID="txt32_wks_serum" Enabled="false" Font-Bold="true" Font-Size="16px" ClientIDMode="Static" CssClass="txtboxx" placeholder="dd-MM-yyyy" Height="32px" runat="server" Width="8.3em"></asp:TextBox>
                                                <asp:ImageButton ID="img32_wks_serum" ImageUrl="~/assets/img/calendar1.png" CssClass="calanderButton" runat="server" />
                                                <cc1:CalendarExtender ID="CalendarExtender8" runat="server" TargetControlID="txt32_wks_serum" PopupButtonID="img32_wks_serum" Format="dd-MM-yyyy" />
                                                <asp:CheckBox ID="chk_32_wks_serum" runat="server" OnCheckedChanged="chk32_wks_serum_CheckedChanged" AutoPostBack="true" CssClass="mycheckbox" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <%--End   Date checks--%>
                    </td>
                </tr>


                <%--for 32_wks_plasma_proteomic--%>
                <tr class="trCSS">
                    <td class="TableColumn tdCSS">32 Weeks Plasma Proteomic</td>

                    <td class="Space tdCSS">
                        <%--Start    Date checks--%>
                        <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                            <ContentTemplate>
                                <asp:UpdateProgress ID="updateProgress9" runat="server">
                                    <ProgressTemplate>
                                        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.75;">
                                            <span style="border-width: 0px; border-radius: 10px; position: fixed; padding: 4%; color: white; background-color: #33D9B2; font-size: 36px; left: 40%; top: 40%;">Loading ...</span>
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                <div class="Mobile" id="Div9" runat="server">
                                    <table style="width: 100%; margin-bottom: 15px">
                                        <tr>
                                            <td class="tddd">
                                                <asp:TextBox ID="txt32_wks_plasma_proteomic" Enabled="false" Font-Bold="true" Font-Size="16px" ClientIDMode="Static" CssClass="txtboxx" placeholder="dd-MM-yyyy" Height="32px" runat="server" Width="8.3em"></asp:TextBox>
                                                <asp:ImageButton ID="img32_wks_plasma_proteomic" ImageUrl="~/assets/img/calendar1.png" CssClass="calanderButton" runat="server" />
                                                <cc1:CalendarExtender ID="CalendarExtender9" runat="server" TargetControlID="txt32_wks_plasma_proteomic" PopupButtonID="img32_wks_plasma_proteomic" Format="dd-MM-yyyy" />
                                                <asp:CheckBox ID="chk_32_wks_plasma_proteomic" runat="server" OnCheckedChanged="chk32_wks_plasma_proteomic_CheckedChanged" AutoPostBack="true" CssClass="mycheckbox" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <%--End   Date checks--%>
                    </td>
                </tr>


                <%--for 32_wks_plasma_niacin--%>
                <tr class="trCSS">
                    <td class="TableColumn tdCSS">32 Weeks Plasma Niacin</td>

                    <td class="Space tdCSS">
                        <%--Start    Date checks--%>
                        <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                            <ContentTemplate>
                                <asp:UpdateProgress ID="updateProgress10" runat="server">
                                    <ProgressTemplate>
                                        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.75;">
                                            <span style="border-width: 0px; border-radius: 10px; position: fixed; padding: 4%; color: white; background-color: #33D9B2; font-size: 36px; left: 40%; top: 40%;">Loading ...</span>
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                <div class="Mobile" id="Div10" runat="server">
                                    <table style="width: 100%; margin-bottom: 15px">
                                        <tr>
                                            <td class="tddd">
                                                <asp:TextBox ID="txt32_wks_plasma_niacin" Enabled="false" Font-Bold="true" Font-Size="16px" ClientIDMode="Static" CssClass="txtboxx" placeholder="dd-MM-yyyy" Height="32px" runat="server" Width="8.3em"></asp:TextBox>
                                                <asp:ImageButton ID="img32_wks_plasma_niacin" ImageUrl="~/assets/img/calendar1.png" CssClass="calanderButton" runat="server" />
                                                <cc1:CalendarExtender ID="CalendarExtender10" runat="server" TargetControlID="txt32_wks_plasma_niacin" PopupButtonID="img32_wks_plasma_niacin" Format="dd-MM-yyyy" />
                                                <asp:CheckBox ID="chk_32_wks_plasma_niacin" runat="server" OnCheckedChanged="chk32_wks_plasma_niacin_CheckedChanged" AutoPostBack="true" CssClass="mycheckbox" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <%--End   Date checks--%>
                    </td>
                </tr>



                <tr class="trCSS" style="font-size: 17px; background-color: whitesmoke">
                    <td class="TableColumn tdCSS" colspan="2" style="text-align: center;">Cord Blood after Delivery</td>
                </tr>



                <%--for Cord Blood after Delivery--%>
                <tr class="trCSS">
                    <td class="TableColumn tdCSS">Cord Blood Collection</td>

                    <td class="Space tdCSS">
                        <%--Start    Date checks--%>
                        <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                            <ContentTemplate>
                                <asp:UpdateProgress ID="updateProgress11" runat="server">
                                    <ProgressTemplate>
                                        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.75;">
                                            <span style="border-width: 0px; border-radius: 10px; position: fixed; padding: 4%; color: white; background-color: #33D9B2; font-size: 36px; left: 40%; top: 40%;">Loading ...</span>
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                <div class="Mobile" id="Div11" runat="server">
                                    <table style="width: 100%; margin-bottom: 15px">
                                        <tr>
                                            <td class="tddd">
                                                <asp:TextBox ID="txtcord_blood_delivery_dt" Enabled="false" Font-Bold="true" Font-Size="16px" ClientIDMode="Static" CssClass="txtboxx" placeholder="dd-MM-yyyy" Height="32px" runat="server" Width="8.3em"></asp:TextBox>
                                                <asp:ImageButton ID="imgcord_blood_delivery_dt" ImageUrl="~/assets/img/calendar1.png" CssClass="calanderButton" runat="server" />
                                                <cc1:CalendarExtender ID="CalendarExtender11" runat="server" TargetControlID="txtcord_blood_delivery_dt" PopupButtonID="imgcord_blood_delivery_dt" Format="dd-MM-yyyy" />
                                                <asp:CheckBox ID="chk_cord_blood_delivery" runat="server" OnCheckedChanged="chkcord_blood_delivery_CheckedChanged" AutoPostBack="true" CssClass="mycheckbox" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tddd" style="padding-top:10px;">
                                                <asp:TextBox Enabled="false"  ID="txtcord_blood_delivery_tm" ClientIDMode="Static" type="text" CssClass="txtboxx" Font-Size="Medium" Width="7.5em" Height="2.1em" placeholder="Time" runat="server"></asp:TextBox></td>
                                            <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99:99" MaskType="Time" TargetControlID="txtcord_blood_delivery_tm" />
                                            </td>

                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <%--End   Date checks--%>
                    </td>
                </tr>








            </table>
            <br />
            <div class="buttonWeb">

                <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-theme btn-lg btn-block" OnClick="submit_Click" OnClientClick="return clicknext();" />
            </div>

            <br />
            <br />
        </div>
    </asp:Panel>

</asp:Content>
