<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="crf8a.aspx.cs" Inherits="maamta_pw.crf8a" Culture="ar-DZ" %>
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


    <script type="text/javascript">
        function clicknext() {

            if (document.getElementById("txtq4").value == '' || document.getElementById("txtq4").value.length < 3) {
                alert("Enter Research Associate Code!")
                document.getElementById("txtq4").focus();
                return false;
            }
            else if (document.getElementById("txtq5").value == '' || document.getElementById("txtq5").value.length < 3) {
                alert("Enter Research Staff Code!")
                document.getElementById("txtq5").focus();
                return false;
            }
            else if (Validate(document.getElementById("<%=txtq14.ClientID%>")) == false) {
                alert("Select Q14 Value")
                return false;
            }
            else if ((document.getElementById("txtq15").value == '' || document.getElementById("txtq15").value.length < 2) || document.getElementById("txtq15").value < 1) {
                alert("Enter Age greater than 1 day!")
                document.getElementById("txtq15").focus();
                return false;
            }

            else if (document.getElementById("txtq17").value == '__-__-____' || document.getElementById("txtq17").value == '') {
                alert("Enter Date!")
                document.getElementById("txtq17").focus();
                return false;
            }
            else if (document.getElementById("txtq18").value == '' || document.getElementById("txtq18").value == '__:__') {
                alert("Enter Time!")
                document.getElementById("txtq18").focus();
                return false;
            }
            else if (document.getElementById("txtq19").value == '__-__-____' || document.getElementById("txtq19").value == '') {
                alert("Enter Date!")
                document.getElementById("txtq19").focus();
                return false;
            }
            else if (document.getElementById("txtq20").value == '' || document.getElementById("txtq20").value == '__:__') {
                alert("Enter Time!")
                document.getElementById("txtq20").focus();
                return false;
            } else if (document.getElementById("txtq21").value == '__-__-____' || document.getElementById("txtq21").value == '') {
                alert("Enter Date!")
                document.getElementById("txtq21").focus();
                return false;
            }
            else if (document.getElementById("txtq22").value == '' || document.getElementById("txtq22").value == '__:__') {
                alert("Enter Time!")
                document.getElementById("txtq22").focus();
                return false;
            } else if (document.getElementById("txtq23").value == '__-__-____' || document.getElementById("txtq23").value == '') {
                alert("Enter Date!")
                document.getElementById("txtq23").focus();
                return false;
            }
            else if (document.getElementById("txtq24").value == '' || document.getElementById("txtq24").value == '__:__') {
                alert("Enter Time!")
                document.getElementById("txtq24").focus();
                return false;
            }
            else if (document.getElementById("txtq25").value == '__-__-____' || document.getElementById("txtq25").value == '') {
                alert("Enter Date!")
                document.getElementById("txtq25").focus();
                return false;
            }
            else if (document.getElementById("txtq26").value == '' || document.getElementById("txtq26").value == '__:__') {
                alert("Enter Time!")
                document.getElementById("txtq26").focus();
                return false;
            }


        }

     
    </script>




</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>



<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="padding-left: 2%; margin-top: 5px;">

        <div style="color: #ff6b6b; font-size: 22px; width: 100%">
            Adverse Events Reporting Form (CRF-8):
        </div>
        <hr style="border-top: 1px solid #ccc; margin-top: 3px">

        <%--Search Woman by DSSID--%>

        <div runat="server" id="forSearch">
            <div id="divSearch" runat="server" class="col-lg-4 col-lg-offset-4" style="margin-bottom: 10px; margin-top: -10px;">
                <div id="imaginary_container" style="margin-top: 10px">
                    <div class="input-group stylish-input-group">
                        <asp:TextBox ID="txtdssid" CssClass="form-control txtboxx" ClientIDMode="Static" runat="server" placeholder="DSSID (or) Study-ID" MaxLength="11" ForeColor="Black"></asp:TextBox>
                        <span class="input-group-addon">
                            <button type="submit" id="btnSearch" runat="server" style="height: 20px" onserverclick="btnSearch_Click">
                                <span class="glyphicon glyphicon-search"></span>
                            </button>
                        </span>
                    </div>
                </div>
            </div>
            <div style="width: 100%; height: 440px; overflow: scroll; margin-top: 40px">
                <asp:GridView ID="GridView1" runat="server" EmptyDataText="No Record Found." AllowPaging="True" PageSize="200" CssClass="footable" OnPageIndexChanging="GridView1_PageIndexChanging" AllowSorting="false" ForeColor="#333333" AutoGenerateColumns="false" Width="100%">
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
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="Link_id" OnClick="Link_OpenForm" Text='Open Form' runat="server" ToolTip="Add Adverse Event Form" CommandArgument='<%#Eval("study_code")+","+ Eval("dssid")+","+ Eval("woman_nm")+","+ Eval("husband_nm")+","+ Eval("pw_crf_3a_2")%>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
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



        <%--Entry Forms--%>
        <div runat="server" id="forEntry" visible="false">

            <asp:Panel ID="Panel2" runat="server" DefaultButton="btnchk" Visible="true">

                <table border="1" style="text-align: center; width: 100%; margin-top: 20px; background-color: gray; border: 1px solid #BFBFBF; color: #2C3E50; font-family: Tahoma;">

                    <tr style="height: 55px; font-family: Calibri; font-size: small; color: white;">
                        <td style="font-weight: 600;" class="auto-style2">Study ID</td>
                        <td style="text-align: left; padding-left: 15px; padding-right: 15px;" class="auto-style8">
                            <asp:TextBox CssClass="form-control input-lg" ID="txtStudyID" runat="server" Height="2.1em" placeholder="study id" ReadOnly="true" ForeColor="Black"></asp:TextBox>
                        </td>
                        <td style="font-weight: 600" class="auto-style13">Q17. Adverse event was observed / start date</td>
                        <td style="text-align: left; padding-left: 15px; padding-right: 15px;" class="auto-style8">
                            <asp:TextBox CssClass="form-control input-lg" ID="txtQ17DateStart" type="text" Font-Size="Medium" Height="2.1em" placeholder="Date" runat="server"></asp:TextBox>
                            <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtQ17DateStart" />
                        </td>
                        <td class="auto-style9">
                            <asp:Button ID="btnchk" class="btn-primary btn-sm" Width="80px" runat="server" Text="Check" OnClick="checkButton_Click" />
                        </td>
                    </tr>

                </table>
            </asp:Panel>


            <asp:Panel ID="Panel1" runat="server" DefaultButton="btnNext" Visible="false">

                <div class="Mobile">
                    <table style="width: 100%; font-size: 1em; color: #4f5963; text-align: left;">


                        <tr class="trCSS">
                            <td class="TableColumn tdCSS">Q4. Research Specialist code</td>
                            <td class="Space tdCSS">
                                <asp:TextBox CssClass="form-control input-lg" ID="txtq4" Style="text-transform: uppercase" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="code" MaxLength="3" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr class="trCSS">
                            <td class="TableColumn tdCSS">Q5. Reported by Research Associate code</td>
                            <td class="Space tdCSS">
                                <asp:TextBox CssClass="form-control input-lg" ID="txtq5" Style="text-transform: uppercase" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="code" MaxLength="3" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr class="trCSS">
                            <td class="TableColumn tdCSS">Q6. Woman Name</td>
                            <td class="Space tdCSS">
                                <asp:TextBox CssClass="form-control input-lg" ID="txtq6WomanNm" ReadOnly="true" Style="text-transform: uppercase" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" onkeypress="return onlyAlphabets()" placeholder="woman name" MaxLength="25" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr class="trCSS">
                            <td class="TableColumn tdCSS">Q7. Husband Name</td>
                            <td class="Space tdCSS">
                                <asp:TextBox CssClass="form-control input-lg" ID="txtq7HusbandNm" ReadOnly="true" Style="text-transform: uppercase" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" onkeypress="return onlyAlphabets()" placeholder="husband name" MaxLength="25" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr class="trCSS">
                            <td class="TableColumn tdCSS">DSS Address</td>
                            <td class="Space tdCSS">
                                <asp:TextBox CssClass="form-control input-lg" ID="txtdssidQ8toQ13" ReadOnly="true" ClientIDMode="Static" Font-Size="Medium" Height="2.1em" placeholder="dssid" runat="server"></asp:TextBox></td>
                        </tr>

                        <tr class="trCSS">
                            <td class="TableColumn tdCSS">Q14. Follow-up Status</td>
                            <td class="Space tdCSS">
                                <asp:RadioButtonList ID="txtq14" runat="server" ClientIDMode="Static" onclick="RadioButton('txtq14')">
                                    <asp:ListItem Text="&nbsp Ongoing" Value="1" />
                                    <asp:ListItem Text="&nbsp At the time of Delivery" Value="2" />
                                </asp:RadioButtonList>
                            </td>
                        </tr>


                        <tr class="trCSS">
                            <td class="TableColumn tdCSS">Q15. Date of Enrollment</td>
                            <td class="Space tdCSS">
                                <asp:TextBox CssClass="form-control input-lg" ID="txtq15" ReadOnly="true" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Date" runat="server"></asp:TextBox></td>
                        </tr>


                        <tr class="trCSS">
                            <td class="TableColumn tdCSS">Q17. Date when adverse event was observed / start date</td>
                            <td class="Space tdCSS">
                                <asp:TextBox CssClass="form-control input-lg" ID="txtq17" ReadOnly="true" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Date" runat="server"></asp:TextBox></td>
                            <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtq17" />
                        </tr>
                        <tr class="trCSS">
                            <td class="TableColumn tdCSS">Q18. Time of event observed (24 hr clock) / start time</td>
                            <td class="Space tdCSS">
                                <asp:TextBox CssClass="form-control input-lg" ID="txtq18" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Time" runat="server"></asp:TextBox></td>
                            <cc1:MaskedEditExtender ID="MaskedEditExtender4" runat="server" Mask="99:99" MaskType="Time" TargetControlID="txtq18" />
                        </tr>
                        <tr class="trCSS">
                            <td class="TableColumn tdCSS">Q19. Date when adverse event was stopped</td>
                            <td class="Space tdCSS">
                                <asp:TextBox CssClass="form-control input-lg" ID="txtq19" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Date" runat="server"></asp:TextBox></td>
                            <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtq19" />
                        </tr>
                        <tr class="trCSS">
                            <td class="TableColumn tdCSS">Q20. Time of event stopped</td>
                            <td class="Space tdCSS">
                                <asp:TextBox CssClass="form-control input-lg" ID="txtq20" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Time" runat="server"></asp:TextBox></td>
                            <cc1:MaskedEditExtender ID="MaskedEditExtender6" runat="server" Mask="99:99" MaskType="Time" TargetControlID="txtq20" />
                        </tr>
                        <tr class="trCSS">
                            <td class="TableColumn tdCSS">Q21. Date when adverse event was reported</td>
                            <td class="Space tdCSS">
                                <asp:TextBox CssClass="form-control input-lg" ID="txtq21" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Date" runat="server"></asp:TextBox></td>
                            <cc1:MaskedEditExtender ID="MaskedEditExtender7" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtq21" />
                        </tr>
                        <tr class="trCSS">
                            <td class="TableColumn tdCSS">Q22. Time of event reported</td>
                            <td class="Space tdCSS">
                                <asp:TextBox CssClass="form-control input-lg" ID="txtq22" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Time" runat="server"></asp:TextBox></td>
                            <cc1:MaskedEditExtender ID="MaskedEditExtender8" runat="server" Mask="99:99" MaskType="Time" TargetControlID="txtq22" />
                        </tr>
                        <tr class="trCSS">
                            <td class="TableColumn tdCSS">Q23. Date of informing Research specialist</td>
                            <td class="Space tdCSS">
                                <asp:TextBox CssClass="form-control input-lg" ID="txtq23" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Date" runat="server"></asp:TextBox></td>
                            <cc1:MaskedEditExtender ID="MaskedEditExtender9" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtq23" />
                        </tr>
                        <tr class="trCSS">
                            <td class="TableColumn tdCSS">Q24. Time of informing  Research specialist (24 hr clock)</td>
                            <td class="Space tdCSS">
                                <asp:TextBox CssClass="form-control input-lg" ID="txtq24" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Time" runat="server"></asp:TextBox></td>
                            <cc1:MaskedEditExtender ID="MaskedEditExtender10" runat="server" Mask="99:99" MaskType="Time" TargetControlID="txtq24" />
                        </tr>
                        <tr class="trCSS">
                            <td class="TableColumn tdCSS">Q25. Date of informing PI's</td>
                            <td class="Space tdCSS">
                                <asp:TextBox CssClass="form-control input-lg" ID="txtq25" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Date" runat="server"></asp:TextBox></td>
                            <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtq25" />
                        </tr>
                        <tr class="trCSS">
                            <td class="TableColumn tdCSS">Q26. Time of informing PI's</td>
                            <td class="Space tdCSS">
                                <asp:TextBox CssClass="form-control input-lg" ID="txtq26" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Time" runat="server"></asp:TextBox></td>
                            <cc1:MaskedEditExtender ID="MaskedEditExtender13" runat="server" Mask="99:99" MaskType="Time" TargetControlID="txtq26" />
                        </tr>


                    </table>
                    <br />
                    <div class="buttonWeb">

                        <asp:Button ID="btnNext" runat="server" Text="Next" class="btn btn-theme btn-lg btn-block" OnClick="next_Click" OnClientClick="return clicknext();" />
                    </div>

                    <br />
                    <br />
                </div>
            </asp:Panel>

        </div>
    </div>

</asp:Content>
