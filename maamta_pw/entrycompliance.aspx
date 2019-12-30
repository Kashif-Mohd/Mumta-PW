<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="entrycompliance.aspx.cs" Inherits="maamta_pw.entrycompliance" Culture="ar-DZ" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        function clicknext() {

            if (document.getElementById("txtDOV").value == '' || document.getElementById("txtDOV").value == '__-__-____') {
                alert("Enter Date of Attempt!")
                document.getElementById("txtDOV").focus();
                return false;
            }
            else if (document.getElementById("txtEmptySac").value == '') {
                alert("Enter Maamta Empty Sachet!")
                document.getElementById("txtEmptySac").focus();
                return false;
            }
            else if (document.getElementById("txtActualEmptySac").value == '') {
                alert("Enter Actual Maamta Empty Sachet!")
                document.getElementById("txtActualEmptySac").focus();
                return false;
            }
        }
    </script>



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

            .tdCSS, .th {
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

            .th, .tdCSS {
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
    <div>



        <div style="background-color: #095e66; margin: 0 0 10px 10px; -moz-box-shadow: 0 6px 6px -6px gray; box-shadow: 0 6px 6px -6px gray;">
            <h2 style="text-align: center; margin-top: 10px; font-size: 26px; color: white; text-transform: capitalize; background-color: #55efc4; padding-top: 6px; padding-bottom: 5px; font-family: Arial">
                <b>Compliance (Empty Sachet)</b></h2>
        </div>



        <asp:Panel ID="Panel2" runat="server">


            <div class="col-lg-4 col-lg-offset-4" style="margin-bottom: 10px; margin-top: 10px;">
                <div id="Div1" style="margin-top: 10px">
                    <div class="input-group stylish-input-group">
                        <asp:TextBox ID="txtSearchStudyID" CssClass="form-control txtboxx" ClientIDMode="Static" runat="server" placeholder="Study ID" MaxLength="11" ForeColor="Black"></asp:TextBox>
                        <span class="input-group-addon">
                            <button type="submit" id="btnSearch" runat="server" style="height: 20px" onserverclick="btnSearch_Click">
                                <span class="glyphicon glyphicon-search"></span>
                            </button>
                        </span>
                    </div>
                </div>
            </div>


            <div style="width: 100%; height: 425px; overflow: scroll; margin-top: 20px">
                <asp:GridView ID="GridView1" runat="server" EmptyDataText="No Record Found." CssClass="footable" AllowSorting="false" ForeColor="#333333" AutoGenerateColumns="false">
                    <Columns>
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="Link_id" OnClick="Link_EditForm" Text='Open' runat="server" ToolTip="Enter Record" CommandArgument='<%#Eval("study_code")+","+ Eval("dssid")+","+ Eval("DOV")%>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="study_code" HeaderText="Study ID" />
                        <asp:BoundField DataField="dssid" HeaderText="DSSID" />
                        <asp:BoundField DataField="woman_nm" HeaderText="Woman Name" />
                        <asp:BoundField DataField="husband_nm" HeaderText="Husband Name" />
                        <asp:BoundField DataField="pw_crf_3a_2" HeaderText="Date of Enrollment" />
                    </Columns>

                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#33d9b2" ForeColor="white" Font-Bold="True" Height="40px" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
            </div>
        </asp:Panel>




        <asp:Panel ID="Panel1" runat="server" DefaultButton="btnSubmit" Visible="false">


            <br />
            <div class="Mobile">
                <table style="width: 100%; font-size: 1em; color: #4f5963; text-align: left;">


                    <tr class="trCSS">
                        <td class="TableColumn tdCSS">Study ID</td>
                        <td class="Space tdCSS">
                            <asp:TextBox CssClass="form-control input-lg" ID="txtStudyID" ReadOnly="true" ClientIDMode="Static" Style="text-transform: uppercase" type="text" Font-Size="Medium" Height="2.1em" placeholder="study id" MaxLength="15" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr class="trCSS">
                        <td class="TableColumn tdCSS">DSSID</td>
                        <td class="Space tdCSS">
                            <asp:TextBox CssClass="form-control input-lg" ID="txtDSSID" ReadOnly="true" Style="text-transform: uppercase" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="dssid" MaxLength="11" runat="server"></asp:TextBox></td>
                    </tr>

                    <tr class="trCSS">
                        <td class="TableColumn tdCSS">Date of Previous Visit / Enrollment</td>
                        <td class="Space tdCSS">
                            <asp:TextBox CssClass="form-control input-lg" ID="txtLastDOV" ReadOnly="true" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Last DOV" MaxLength="25" runat="server"></asp:TextBox></td>
                        <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtLastDOV" />
                    </tr>
                    <tr class="trCSS">
                        <td class="TableColumn tdCSS">Date of Visit</td>
                        <td class="Space tdCSS">
                            <asp:TextBox CssClass="form-control input-lg" ID="txtDOV" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="DOV" MaxLength="25" runat="server"></asp:TextBox></td>
                        <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtDOV" />
                    </tr>

                    <tr class="trCSS">
                        <td class="TableColumn tdCSS">Empty Sachet</td>
                        <td class="Space tdCSS">
                            <asp:TextBox CssClass="form-control input-lg" ID="txtEmptySac" type="tel" ClientIDMode="Static" Font-Size="Medium" MaxLength="5" Height="2.1em" placeholder="eg. 13.5" runat="server"></asp:TextBox></td>
                    </tr>

                    <tr class="trCSS">
                        <td class="TableColumn tdCSS">Actual Empty Sachet</td>
                        <td class="Space tdCSS">
                            <asp:TextBox CssClass="form-control input-lg" ID="txtActualEmptySac" type="tel" ClientIDMode="Static" Font-Size="Medium" MaxLength="5" Height="2.1em" placeholder="eg. 15" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr class="trCSS">
                        <td class="TableColumn tdCSS">Remarks</td>
                        <td class="Space tdCSS">
                            <textarea id="txtremarks" runat="server"></textarea>
                        </td>
                    </tr>
                </table>
                <br />
                <br />
                <div class="buttonWeb">
                    <asp:Button ID="btnSubmit" runat="server" Text="SUBMIT" class="btn btn-theme btn-lg btn-block" OnClick="submit_Click" OnClientClick="return clicknext();" />
                </div>

                <br />
                <br />
            </div>
        </asp:Panel>



    </div>
</asp:Content>
