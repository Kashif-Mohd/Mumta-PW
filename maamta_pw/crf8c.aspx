<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="crf8c.aspx.cs" Inherits="maamta_pw.crf8c" %>
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

            .tdCSS, th {
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

        window.onload = function () {
            if ($('#<%= txtq38.ClientID %> input:checked').val() == '3') {
                document.getElementById("TR_Q38").style.display = 'table-row';
            }
            if ($('#<%= txtq40.ClientID %> input:checked').val() == '5') {
                document.getElementById("TR_Q40").style.display = 'table-row';
            }
        }



        function Validate(rb) {
            var rb;
            var radio = rb.getElementsByTagName("input");
            var isChecked = false;
            for (var i = 0; i < radio.length; i++) {
                if (radio[i].checked) {
                    isChecked = true;
                    break;
                }
            }
            return isChecked;
        }





        function RadioButton(id) {

            var selectedvalue = $('#<%= txtq38.ClientID %> input:checked').val();
            if (id == 'txtq38') {
                if (selectedvalue != "" && selectedvalue == "3") {
                    document.getElementById("TR_Q38_other").style.display = 'table-row';
                }
                else if (selectedvalue == "" || selectedvalue != "5") {
                    document.getElementById("TR_Q38_other").style.display = 'none';
                    document.getElementById("txtq38_other").value = "";
                }
            }

            var selectedvalue = $('#<%= txtq40.ClientID %> input:checked').val();
            if (id == 'txtq40') {
                if (selectedvalue != "" && selectedvalue == "5") {
                    document.getElementById("TR_Q40_other").style.display = 'table-row';
                }
                else if (selectedvalue == "" || selectedvalue != "5") {
                    document.getElementById("TR_Q40_other").style.display = 'none';
                    document.getElementById("TR_Q40_other").value = "";
                }
            }

        }






        function clicknext() {


            var Q39_01 = document.getElementById('<%= chkQ39_01.ClientID %>');
            var Q39_02 = document.getElementById('<%= chkQ39_02.ClientID %>');
            var Q39_03 = document.getElementById('<%= chkQ39_03.ClientID %>');
            var Q39_04 = document.getElementById('<%= chkQ39_04.ClientID %>');
            var Q39_05 = document.getElementById('<%= chkQ39_05.ClientID %>');
            var Q39_06 = document.getElementById('<%= chkQ39_06.ClientID %>');
            var Q39_07 = document.getElementById('<%= chkQ39_07.ClientID %>');
            var Q39_08 = document.getElementById('<%= chkQ39_08.ClientID %>');




            if (Validate(document.getElementById("<%=txtq38.ClientID%>")) == false) {
                alert("Select Q38 Value")
                return false;
            }
            else if ($('#<%= txtq38.ClientID %> input:checked').val() == '3' && (document.getElementById("txtq38_other").value == '' || document.getElementById("txtq38_other").value.length < 2)) {
                alert("Enter Other Code, 2 digit long!")
                document.getElementById("txtq38_other").focus();
                return false;
            }
            else if (Q39_01.checked == false && Q39_02.checked == false && Q39_03.checked == false && Q39_04.checked == false && Q39_05.checked == false && Q39_06.checked == false && Q39_07.checked == false && Q39_08.checked == false) {
                alert("Select values from 1 to 8")
                document.getElementById("chkQ39_01").focus();
                return false;
            }
            else if (Validate(document.getElementById("<%=txtq40.ClientID%>")) == false) {
                alert("Select Q40 Value")
                return false;
            }
            else if ($('#<%= txtq40.ClientID %> input:checked').val() == '5' && (document.getElementById("txtq40_other").value == '' || document.getElementById("txtq40_other").value.length < 2)) {
                alert("Enter Other Code, 2 digit long!")
                document.getElementById("txtq40_other").focus();
                return false;
            }
            else if (Validate(document.getElementById("<%=txtq41.ClientID%>")) == false) {
                alert("Select Q41 Value")
                return false;
            }
            else if (document.getElementById("txtq42").value == '' || document.getElementById("txtq42").value == '__-__-____') {
                alert("Enter Date of fatal event")
                document.getElementById("txtq42").focus();
                return false;
            }
            else if (document.getElementById("txtq43").value == '' || document.getElementById("txtq43").value == '__:__') {
                alert("Enter Time of fatal event")
                document.getElementById("txtq43").focus();
                return false;
            }

}
    </script>


</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server" DefaultButton="btnNext" Visible="true">
        <table style="width: 100%; color: #4f5963; text-align: left;">
            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="background-color: gray; color: white; text-align: center; font-size: 18px;">ADVERSE EVENT</td>
            </tr>

            <tr class="trCSS">
                <td class="TableColumn tdCSS">38. Where did the adverse event happen?</td>
                <td class="Space tdCSS">
                    <asp:RadioButtonList ID="txtq38" runat="server" ClientIDMode="Static" onclick="RadioButton('txtq38')">
                        <asp:ListItem Text="&nbsp At home" Value="1" />
                        <asp:ListItem Text="&nbsp At health care Centre/clinic/hospital" Value="2" />
                        <asp:ListItem Text="&nbsp Others" Value="3" />
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr class="trCSS" id="TR_Q38_other" style="display: none">
                <td class="TableColumn tdCSS"></td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq38_other" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="other" runat="server"></asp:TextBox></td>
            </tr>


            <tr class="trCSS" id="TR_Q39">
                <td class="TableColumn tdCSS">39. Classify severity or seriousness of adverse events</td>
                <td class="Space tdCSS" style="font-size: 15px;">
                    <asp:CheckBox ID="chkQ39_01" Text="&emsp;1.	IV therapy was given" runat="server" ClientIDMode="Static" /><br />
                    <asp:CheckBox ID="chkQ39_02" Text="&emsp;2.	Hospitalization" runat="server" ClientIDMode="Static" /><br />
                    <asp:CheckBox ID="chkQ39_03" Text="&emsp;3.	Life Threatening" runat="server" ClientIDMode="Static" /><br />
                    <asp:CheckBox ID="chkQ39_04" Text="&emsp;4.	Maternal death" runat="server" ClientIDMode="Static" /><br />
                    <asp:CheckBox ID="chkQ39_05" Text="&emsp;5.	Intrapartum stillbirth" runat="server" ClientIDMode="Static" /><br />
                    <asp:CheckBox ID="chkQ39_06" Text="&emsp;6.	Antepartum stillbirth" runat="server" ClientIDMode="Static" /><br />
                    <asp:CheckBox ID="chkQ39_07" Text="&emsp;7.	Miscarriage" runat="server" ClientIDMode="Static" /><br />
                    <asp:CheckBox ID="chkQ39_08" Text="&emsp;8.	Abortion" runat="server" ClientIDMode="Static" /><br />
                </td>
            </tr>



            <tr class="trCSS">
                <td class="TableColumn tdCSS">40. What was the action taken in terms of trial intervention?</td>
                <td class="Space tdCSS">
                    <asp:RadioButtonList ID="txtq40" runat="server" ClientIDMode="Static" onclick="RadioButton('txtq40')">
                        <asp:ListItem Text="&nbsp Intervention continued" Value="1" />
                        <asp:ListItem Text="&nbsp Intervention hold" Value="2" />
                        <asp:ListItem Text="&nbsp Discontinued" Value="3" />
                        <asp:ListItem Text="&nbsp Not applicable" Value="4" />
                        <asp:ListItem Text="&nbsp Others" Value="5" />
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr class="trCSS" id="TR_Q40_other" style="display: none">
                <td class="TableColumn tdCSS"></td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq40_other" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="other" runat="server"></asp:TextBox></td>
            </tr>
            <tr class="trCSS">
                <td class="TableColumn tdCSS">41. Outcome of event</td>
                <td class="Space tdCSS">
                    <asp:RadioButtonList ID="txtq41" runat="server" ClientIDMode="Static">
                        <asp:ListItem Text="&nbsp Improved" Value="1" />
                        <asp:ListItem Text="&nbsp Persistent" Value="2" />
                        <asp:ListItem Text="&nbsp Worsened with time" Value="3" />
                        <asp:ListItem Text="&nbsp Fatality" Value="4" />
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr class="trCSS">
                <td class="TableColumn tdCSS">Q42. Date of fatal event (88-88-8888) if not applicable</td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq42" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Date" runat="server"></asp:TextBox></td>
                <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtq42" />
            </tr>
            <tr class="trCSS">
                <td class="TableColumn tdCSS">Q43. Time of fatal event</td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq43" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Time" runat="server"></asp:TextBox></td>
                <cc1:MaskedEditExtender ID="MaskedEditExtender4" runat="server" Mask="99:99" MaskType="Time" TargetControlID="txtq43" />
            </tr>
            <tr class="trCSS">
                <td class="TableColumn tdCSS">Q44. Place of fatal event</td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq44" ClientIDMode="Static" readonly="true" type="text" Font-Size="Medium" Height="2.1em" placeholder="Place of Fetal (Extract from CRF6b)" runat="server"></asp:TextBox></td>
            </tr>



        </table>


        <br />
        <div class="buttonWeb">
            <asp:Button ID="btnNext" runat="server" Text="SUBMIT" class="btn btn-theme btn-lg btn-block" OnClick="next_Click" OnClientClick="return clicknext();" />
        </div>

        <br />
        <br />

    </asp:Panel>

</asp:Content>
