<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="crf8b.aspx.cs" Inherits="maamta_pw.crf8b" Culture="ar-DZ" %>
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
            if ($('#<%= txtq28.ClientID %> input:checked').val() == '5') {
                document.getElementById("TR_Q28").style.display = 'table-row';
            }
            if ($('#<%= txtq29.ClientID %> input:checked').val() == '2') {
                document.getElementById("TR_Q30").style.display = 'none';
                document.getElementById("TR_Q31_01").style.display = 'none';
                document.getElementById("TR_Q31_02").style.display = 'none';
                document.getElementById("TR_Q31_03").style.display = 'none';
            }
            if ($('#<%= txtq32.ClientID %> input:checked').val() == '6') {
                document.getElementById("TR_Q32").style.display = 'table-row';
            }
            if ($('#<%= txtq33.ClientID %> input:checked').val() == '2') {
                document.getElementById("TR_Q34").style.display = 'none';
                document.getElementById("TR_Q34_other").style.display = 'none';
                document.getElementById("txtq34").value = "";
            }

            var Q34_13 = document.getElementById('<%= chkQ34_13.ClientID %>');
            if (Q34_13.checked == true) {
                document.getElementById("TR_Q34_other").style.display = "table-row";
            }

            if ($('#<%= txtq35.ClientID %> input:checked').val() == '2') {
                document.getElementById("TR_Q36").style.display = 'none';
                document.getElementById("TR_Q36_other").style.display = 'none';
                document.getElementById("txtq36").value = "";
            }

            var Q36_09 = document.getElementById('<%= chkQ36_09.ClientID %>');
            if (Q36_09.checked == true) {
                document.getElementById("TR_Q36_other").style.display = "table-row";
            }


        }






        function getChkboxChecked_Q34(id) {
            var chk = document.getElementById(id);
            if (chk.checked && id == 'chkQ34_13') {
                document.getElementById("TR_Q34_other").style.display = "table-row";
            }
            else {
                document.getElementById("TR_Q34_other").style.display = "none";
                document.getElementById("txtq34").value = "";
            }
        }



        function getChkboxChecked_Q36(id) {
            var chk = document.getElementById(id);
            if (chk.checked && id == 'chkQ36_09') {
                document.getElementById("TR_Q36_other").style.display = "table-row";
            }
            else {
                document.getElementById("TR_Q36_other").style.display = "none";
                document.getElementById("txtq36").value = "";
            }
        }


        function RadioButton(id) {

            var selectedvalue = $('#<%= txtq28.ClientID %> input:checked').val();
            if (id == 'txtq28') {
                if (selectedvalue != "" && selectedvalue == "5") {
                    document.getElementById("TR_Q28").style.display = 'table-row';
                }
                else if (selectedvalue == "" || selectedvalue != "5") {
                    document.getElementById("TR_Q28").style.display = 'none';
                    document.getElementById("txtq28_other").value = "";
                }
            }


            var selectedvalue = $('#<%= txtq29.ClientID %> input:checked').val();
            if (id == 'txtq29') {
                if (selectedvalue != "" && selectedvalue != "2") {
                    document.getElementById("TR_Q30").style.display = 'table-row';
                    document.getElementById("TR_Q31_01").style.display = 'table-row';
                    document.getElementById("TR_Q31_02").style.display = 'table-row';
                    document.getElementById("TR_Q31_03").style.display = 'table-row';
                }
                else {
                    document.getElementById("TR_Q30").style.display = 'none';
                    document.getElementById("TR_Q31_01").style.display = 'none';
                    document.getElementById("TR_Q31_02").style.display = 'none';
                    document.getElementById("TR_Q31_03").style.display = 'none';

                    $('#<%= txtq30.ClientID %> input:checked').prop('checked', false);
                    document.getElementById("txtq31_min").value = "";
                    document.getElementById("txtq31_hr").value = "";
                    document.getElementById("txtq31_day").value = "";
                }
            }



            var selectedvalue = $('#<%= txtq32.ClientID %> input:checked').val();
            if (id == 'txtq32') {
                if (selectedvalue != "" && selectedvalue == "6") {
                    document.getElementById("TR_Q32").style.display = 'table-row';
                }
                else {
                    document.getElementById("TR_Q32").style.display = 'none';
                    document.getElementById("txtq32_other").value = "";
                }
            }


            var selectedvalue = $('#<%= txtq33.ClientID %> input:checked').val();
            if (id == 'txtq33') {
                if (selectedvalue != "" && selectedvalue == "1") {
                    document.getElementById("TR_Q34").style.display = 'table-row';
                    document.getElementById("TR_Q34_other").style.display = 'table-row';
                }
                else {
                    document.getElementById("TR_Q34").style.display = 'none';
                    document.getElementById("TR_Q34_other").style.display = 'none';
                    document.getElementById("txtq34_other").value = "";
                }
            }


            var selectedvalue = $('#<%= txtq35.ClientID %> input:checked').val();
            if (id == 'txtq35') {
                if (selectedvalue != "" && selectedvalue == "1") {
                    document.getElementById("TR_Q36").style.display = 'table-row';
                }
                else {
                    document.getElementById("TR_Q36").style.display = 'none';
                }
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






        function clicknext() {



            var Q34_01 = document.getElementById('<%= chkQ34_01.ClientID %>');
            var Q34_02 = document.getElementById('<%= chkQ34_02.ClientID %>');
            var Q34_03 = document.getElementById('<%= chkQ34_03.ClientID %>');
            var Q34_04 = document.getElementById('<%= chkQ34_04.ClientID %>');
            var Q34_05 = document.getElementById('<%= chkQ34_05.ClientID %>');
            var Q34_06 = document.getElementById('<%= chkQ34_06.ClientID %>');
            var Q34_07 = document.getElementById('<%= chkQ34_07.ClientID %>');
            var Q34_08 = document.getElementById('<%= chkQ34_08.ClientID %>');
            var Q34_09 = document.getElementById('<%= chkQ34_09.ClientID %>');
            var Q34_10 = document.getElementById('<%= chkQ34_10.ClientID %>');
            var Q34_11 = document.getElementById('<%= chkQ34_11.ClientID %>');
            var Q34_12 = document.getElementById('<%= chkQ34_12.ClientID %>');
            var Q34_13 = document.getElementById('<%= chkQ34_13.ClientID %>');


            var Q36_01 = document.getElementById('<%= chkQ36_01.ClientID %>');
            var Q36_02 = document.getElementById('<%= chkQ36_02.ClientID %>');
            var Q36_03 = document.getElementById('<%= chkQ36_03.ClientID %>');
            var Q36_04 = document.getElementById('<%= chkQ36_04.ClientID %>');
            var Q36_05 = document.getElementById('<%= chkQ36_05.ClientID %>');
            var Q36_06 = document.getElementById('<%= chkQ36_06.ClientID %>');
            var Q36_07 = document.getElementById('<%= chkQ36_07.ClientID %>');
            var Q36_08 = document.getElementById('<%= chkQ36_08.ClientID %>');
            var Q36_09 = document.getElementById('<%= chkQ36_09.ClientID %>');




            if (Validate(document.getElementById("<%=txtq27.ClientID%>")) == false) {
                alert("Select Q27 Value")
                return false;
            }
            else if (Validate(document.getElementById("<%=txtq28.ClientID%>")) == false) {
                alert("Select Q28 Value")
                return false;
            }
            else if ($('#<%= txtq28.ClientID %> input:checked').val() == '5' && (document.getElementById("txtq28_other").value == '' || document.getElementById("txtq28_other").value.length < 2)) {
                alert("Enter Other Code, 2 digit long!")
                document.getElementById("txtq28_other").focus();
                return false;
            }
                //else if (document.getElementsByName("txtq27").text == 5 && (document.getElementById("txtq27_other").value == '' || document.getElementById("txtq27_other").value.length < 2)) {
                //    alert("Enter Other Code, 2 digit long!")
                //    document.getElementById("txtq27_other").focus();
                //    return false;
                //}
            else if (Validate(document.getElementById("<%=txtq29.ClientID%>")) == false) {
                alert("Select Q29 Value")
                return false;
            }
            else if (Validate(document.getElementById("<%=txtq30.ClientID%>")) == false && $('#<%= txtq29.ClientID %> input:checked').val() == '1') {
                alert("Select Q30 Value")
                return false;
            }
            else if ((document.getElementById("txtq31_min").value == '' || document.getElementById("txtq31_min").value.length < 2) && $('#<%= txtq29.ClientID %> input:checked').val() == '1') {
                alert("Enter Minutes, 2 digit long!")
                document.getElementById("txtq31_min").focus();
                return false;
            }
            else if ((document.getElementById("txtq31_hr").value == '' || document.getElementById("txtq31_hr").value.length < 2) && $('#<%= txtq29.ClientID %> input:checked').val() == '1') {
                alert("Enter Hours, 2 digit long!")
                document.getElementById("txtq31_hr").focus();
                return false;
            }
            else if ((document.getElementById("txtq31_day").value == '' || document.getElementById("txtq31_day").value.length < 2) && $('#<%= txtq29.ClientID %> input:checked').val() == '1') {
                alert("Enter Days, 2 digit long!")
                document.getElementById("txtq31_day").focus();
                return false;
            }
            else if (Validate(document.getElementById("<%=txtq32.ClientID%>")) == false) {
                alert("Select Q32 Value")
                return false;
            }
            else if ($('#<%= txtq32.ClientID %> input:checked').val() == '6' && (document.getElementById("txtq32_other").value == '' || document.getElementById("txtq32_other").value.length < 2)) {
                alert("Enter Other Code, 2 digit long!")
                document.getElementById("txtq32_other").focus();
                return false;
            }
            else if (Validate(document.getElementById("<%=txtq33.ClientID%>")) == false) {
                alert("Select Q33 Value")
                return false;
            }
            else if ($('#<%= txtq33.ClientID %> input:checked').val() == '1' && (Q34_01.checked == false && Q34_02.checked == false && Q34_03.checked == false && Q34_04.checked == false && Q34_05.checked == false && Q34_06.checked == false && Q34_07.checked == false && Q34_08.checked == false && Q34_09.checked == false && Q34_10.checked == false && Q34_11.checked == false && Q34_12.checked == false && Q34_13.checked == false)) {
                alert("Select values from 1 to 13")
                document.getElementById("chkQ34_01").focus();
                return false;
            }
            else if (Q34_13.checked == true && (document.getElementById("txtq34").value == '' || document.getElementById("txtq34").value.length < 2)) {
                alert("Enter Value, 2 digit long!")
                document.getElementById("txtq34").focus();
                return false;
            }
            else if (Validate(document.getElementById("<%=txtq35.ClientID%>")) == false) {
              alert("Select Q35 Value")
              return false;
          }
          else if ($('#<%= txtq35.ClientID %> input:checked').val() == '1' && (Q36_01.checked == false && Q36_02.checked == false && Q36_03.checked == false && Q36_04.checked == false && Q36_05.checked == false && Q36_06.checked == false && Q36_07.checked == false && Q36_08.checked == false && Q36_09.checked == false)) {
              alert("Select values from 1 to 9")
              document.getElementById("chkQ36_01").focus();
              return false;
          }
          else if (Q36_09.checked == true && (document.getElementById("txtq36").value == '' || document.getElementById("txtq36").value.length < 2)) {
              alert("Enter Value, 2 digit long!")
              document.getElementById("txtq36").focus();
              return false;
          }
          else if (document.getElementById("txtq37a1dt").value == '' || document.getElementById("txtq37a1dt").value == '__-__-____') {
              alert("Enter Date of Q37a-1")
              document.getElementById("txtq37a1dt").focus();
              return false;
          }
          else if (document.getElementById("txtq37a1").value == '') {
              alert("Enter Details of Q37a-1")
              document.getElementById("txtq37a1").focus();
              return false;
          }


}
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--Entry Forms--%>

    <asp:Panel ID="Panel1" runat="server" DefaultButton="btnNext">
        <table style="width: 100%; color: #4f5963; text-align: left;">
            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="background-color: gray; color: white; text-align: center; font-size: 18px;">ADVERSE EVENT</td>
            </tr>
            <tr class="trCSS">
                <td class="TableColumn tdCSS">27. Who is affected by the adverse event?</td>
                <td class="Space tdCSS">
                    <asp:RadioButtonList ID="txtq27" runat="server" ClientIDMode="Static">
                        <asp:ListItem Text="&nbsp PW" Value="1" />
                        <asp:ListItem Text="&nbsp Fetus" Value="2" />
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr class="trCSS">
                <td class="TableColumn tdCSS">28. Who reported the adverse event?</td>
                <td class="Space tdCSS">
                    <asp:RadioButtonList ID="txtq28" runat="server" ClientIDMode="Static" onclick="RadioButton('txtq28')">
                        <asp:ListItem Text="&nbsp PW herself" Value="1" />
                        <asp:ListItem Text="&nbsp Research Team Member" Value="2" />
                        <asp:ListItem Text="&nbsp Any other member of the family" Value="3" />
                        <asp:ListItem Text="&nbsp Healthcare provider" Value="4" />
                        <asp:ListItem Text="&nbsp Others" Value="5" />
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr class="trCSS" id="TR_Q28" style="display: none">
                <td class="TableColumn tdCSS"></td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq28_other" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="other" runat="server"></asp:TextBox></td>
            </tr>

            <tr class="trCSS">
                <td class="TableColumn tdCSS">29. Suspicion of SAEs with some trial intervention</td>
                <td class="Space tdCSS">
                    <asp:RadioButtonList ID="txtq29" runat="server" ClientIDMode="Static" onclick="RadioButton('txtq29')">
                        <asp:ListItem Text="&nbsp Yes" Value="1" />
                        <asp:ListItem Text="&nbsp No (skip to Q32)" Value="2" />
                    </asp:RadioButtonList>
                </td>
            </tr>



            <tr class="trCSS" id="TR_Q30">
                <td class="TableColumn tdCSS">30. According to PW, is this adverse event occurs after intervention?</td>
                <td class="Space tdCSS">
                    <asp:RadioButtonList ID="txtq30" runat="server" ClientIDMode="Static">
                        <asp:ListItem Text="&nbsp BEP" Value="1" />
                        <asp:ListItem Text="&nbsp Azithromycin" Value="2" />
                        <asp:ListItem Text="&nbsp Choline" Value="3" />
                        <asp:ListItem Text="&nbsp Nicotinamide" Value="4" />
                    </asp:RadioButtonList>
                </td>
            </tr>

            <tr class="trCSS" id="TR_Q31_01">
                <td class="TableColumn tdCSS">31. How soon after having the intervention, the adverse event occurred?</td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq31_min" ClientIDMode="Static" onkeypress="return OnlyNumeric(event)" type="text" Font-Size="Medium" Height="2.1em" placeholder="minutes" MaxLength="2" runat="server"></asp:TextBox></td>
            </tr>
            <tr class="trCSS" id="TR_Q31_02">
                <td class="TableColumn tdCSS"></td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq31_hr" ClientIDMode="Static" onkeypress="return OnlyNumeric(event)" type="text" Font-Size="Medium" Height="2.1em" placeholder="hours" MaxLength="2" runat="server"></asp:TextBox></td>
            </tr>
            <tr class="trCSS" id="TR_Q31_03">
                <td class="TableColumn tdCSS"></td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq31_day" ClientIDMode="Static" onkeypress="return OnlyNumeric(event)" type="text" Font-Size="Medium" Height="2.1em" placeholder="days" MaxLength="2" runat="server"></asp:TextBox></td>
            </tr>



            <tr class="trCSS">
                <td class="TableColumn tdCSS">32. Description of event</td>
                <td class="Space tdCSS">
                    <asp:RadioButtonList ID="txtq32" runat="server" ClientIDMode="Static" onclick="RadioButton('txtq32')">
                        <asp:ListItem Text="&nbsp Rash" Value="1" />
                        <asp:ListItem Text="&nbsp Severe diarrhea" Value="2" />
                        <asp:ListItem Text="&nbsp Nausea" Value="3" />
                        <asp:ListItem Text="&nbsp Vomiting" Value="4" />
                        <asp:ListItem Text="&nbsp Abdominal discomfort" Value="5" />
                        <asp:ListItem Text="&nbsp Other" Value="6" />
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr class="trCSS" id="TR_Q32" style="display: none">
                <td class="TableColumn tdCSS"></td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq32_other" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="other" runat="server"></asp:TextBox></td>
            </tr>




            <tr class="trCSS">
                <td class="TableColumn tdCSS">33. Any risk identified during ANC</td>
                <td class="Space tdCSS">
                    <asp:RadioButtonList ID="txtq33" runat="server" ClientIDMode="Static" onclick="RadioButton('txtq33')">
                        <asp:ListItem Text="&nbsp Yes" Value="1" />
                        <asp:ListItem Text="&nbsp No (skip to Q35)" Value="2" />
                    </asp:RadioButtonList>
                </td>
            </tr>


            <tr class="trCSS" id="TR_Q34">
                <td class="TableColumn tdCSS">34. SAEs during antenatal period (From medical/ANC records)</td>
                <td class="Space tdCSS" style="font-size: 15px;">
                    <asp:CheckBox ID="chkQ34_01" Text="&emsp;1.	PIH" runat="server" ClientIDMode="Static" /><br />
                    <asp:CheckBox ID="chkQ34_02" Text="&emsp;2.	Preeclampsia" runat="server" ClientIDMode="Static" /><br />
                    <asp:CheckBox ID="chkQ34_03" Text="&emsp;3.	Eclampsia" runat="server" ClientIDMode="Static" /><br />
                    <asp:CheckBox ID="chkQ34_04" Text="&emsp;4.	Risk of preterm birth" runat="server" ClientIDMode="Static" /><br />
                    <asp:CheckBox ID="chkQ34_05" Text="&emsp;5.	Preterm labor" runat="server" ClientIDMode="Static" /><br />
                    <asp:CheckBox ID="chkQ34_06" Text="&emsp;6.	Gestational diabetes" runat="server" ClientIDMode="Static" /><br />
                    <asp:CheckBox ID="chkQ34_07" Text="&emsp;7.	Respiratory distress" runat="server" ClientIDMode="Static" /><br />
                    <asp:CheckBox ID="chkQ34_08" Text="&emsp;8.	Severe vomiting" runat="server" ClientIDMode="Static" /><br />
                    <asp:CheckBox ID="chkQ34_09" Text="&emsp;9.	COVID-19 positive" runat="server" ClientIDMode="Static" /><br />
                    <asp:CheckBox ID="chkQ34_10" Text="&emsp;10. Severe anaemia - required blood transfusion" runat="server" ClientIDMode="Static" /><br />
                    <asp:CheckBox ID="chkQ34_11" Text="&emsp;11. Severe Jaundice" runat="server" ClientIDMode="Static" /><br />
                    <asp:CheckBox ID="chkQ34_12" Text="&emsp;12. Accident" runat="server" ClientIDMode="Static" /><br />
                    <asp:CheckBox ID="chkQ34_13" Text="&emsp;13. Other (Specify)" runat="server" ClientIDMode="Static" onclick="getChkboxChecked_Q34('chkQ34_13')" /><br />
                </td>
            </tr>
            <tr class="trCSS" id="TR_Q34_other" style="display: none">
                <td class="TableColumn tdCSS"></td>
                <td class="TableColumn tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq34" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="code" MaxLength="3" runat="server"></asp:TextBox></td>
            </tr>







            <tr class="trCSS">
                <td class="TableColumn tdCSS">35. Any risk identified during intrapartum period</td>
                <td class="Space tdCSS">
                    <asp:RadioButtonList ID="txtq35" runat="server" ClientIDMode="Static" onclick="RadioButton('txtq35')">
                        <asp:ListItem Text="&nbsp Yes" Value="1" />
                        <asp:ListItem Text="&nbsp No (skip to Q37)" Value="2" />
                    </asp:RadioButtonList>
                </td>
            </tr>





            <tr class="trCSS" id="TR_Q36">
                <td class="TableColumn tdCSS">36. Physician’s diagnosis </td>
                <td class="Space tdCSS" style="font-size: 15px;">
                    <asp:CheckBox ID="chkQ36_01" Text="&emsp;1.	PIH" runat="server" ClientIDMode="Static" /><br />
                    <asp:CheckBox ID="chkQ36_02" Text="&emsp;2.	Preeclampsia" runat="server" ClientIDMode="Static" /><br />
                    <asp:CheckBox ID="chkQ36_03" Text="&emsp;3.	Eclampsia" runat="server" ClientIDMode="Static" /><br />
                    <asp:CheckBox ID="chkQ36_04" Text="&emsp;4.	Obstructed labor" runat="server" ClientIDMode="Static" /><br />
                    <asp:CheckBox ID="chkQ36_05" Text="&emsp;5.	Prolong labor" runat="server" ClientIDMode="Static" /><br />
                    <asp:CheckBox ID="chkQ36_06" Text="&emsp;6.	Severe bleeding" runat="server" ClientIDMode="Static" /><br />
                    <asp:CheckBox ID="chkQ36_07" Text="&emsp;7.	Cord prolapse" runat="server" ClientIDMode="Static" /><br />
                    <asp:CheckBox ID="chkQ36_08" Text="&emsp;8.	Shock" runat="server" ClientIDMode="Static" /><br />
                    <asp:CheckBox ID="chkQ36_09" Text="&emsp;9. Other (Specify)" runat="server" ClientIDMode="Static" onclick="getChkboxChecked_Q36('chkQ36_09')" /><br />
                </td>
            </tr>
            <tr class="trCSS" id="TR_Q36_other" style="display: none">
                <td class="TableColumn tdCSS"></td>
                <td class="TableColumn tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq36" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="code" MaxLength="3" runat="server"></asp:TextBox></td>
            </tr>










            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="background-color: gray; color: white; text-align: center; font-size: 16px">Q37a. Details of adverse event reported and actions which were taken
                   
                    <br />
                    (Either observed by the research team or information given by trial participant or someone else)
                   
                    <br />
                    What were the initial and series of symptoms or complain which appeared – follow the sequence?
                </td>
            </tr>

            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <asp:TextBox CssClass="form-control input" ID="txtq37a1dt" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Date q37a-(1)" runat="server"></asp:TextBox></td>
                <cc1:MaskedEditExtender ID="MaskedEditExtender11" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtq37a1dt" />
            </tr>
            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <textarea id="txtq37a1" runat="server" style="height: 50px; width: 80%;" placeholder="q37a-(1)"></textarea></td>
            </tr>




            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <asp:TextBox CssClass="form-control input" ID="txtq37a2dt" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Date q37a-(2)" runat="server"></asp:TextBox></td>
                <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtq37a2dt" />
            </tr>
            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <textarea id="txtq37a2" runat="server" style="height: 50px; width: 80%;" placeholder="q37a-(2)"></textarea></td>
            </tr>



            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <asp:TextBox CssClass="form-control input" ID="txtq37a3dt" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Date q37a-(3)" runat="server"></asp:TextBox></td>
                <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtq37a3dt" />
            </tr>
            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <textarea id="txtq37a3" runat="server" style="height: 50px; width: 80%;" placeholder="q37a-(3)"></textarea></td>
            </tr>



            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <asp:TextBox CssClass="form-control input" ID="txtq37a4dt" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Date q37a-(4)" runat="server"></asp:TextBox></td>
                <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtq37a4dt" />
            </tr>
            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <textarea id="txtq37a4" runat="server" style="height: 50px; width: 80%;" placeholder="q37a-(4)"></textarea></td>
            </tr>



            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <asp:TextBox CssClass="form-control input" ID="txtq37a5dt" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Date q37a-(5)" runat="server"></asp:TextBox></td>
                <cc1:MaskedEditExtender ID="MaskedEditExtender4" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtq37a5dt" />
            </tr>
            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <textarea id="txtq37a5" runat="server" style="height: 50px; width: 80%;" placeholder="q37a-(5)"></textarea></td>
            </tr>



            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <asp:TextBox CssClass="form-control input" ID="txtq37a6dt" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Date q37a-(6)" runat="server"></asp:TextBox></td>
                <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtq37a6dt" />
            </tr>
            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <textarea id="txtq37a6" runat="server" style="height: 50px; width: 80%;" placeholder="q37a-(6)"></textarea></td>
            </tr>



            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <asp:TextBox CssClass="form-control input" ID="txtq37a7dt" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Date q37a-(7)" runat="server"></asp:TextBox></td>
                <cc1:MaskedEditExtender ID="MaskedEditExtender6" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtq37a7dt" />
            </tr>
            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <textarea id="txtq37a7" runat="server" style="height: 50px; width: 80%;" placeholder="q37a-(7)"></textarea></td>
            </tr>



            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <asp:TextBox CssClass="form-control input" ID="txtq37a8dt" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Date q37a-(8)" runat="server"></asp:TextBox></td>
                <cc1:MaskedEditExtender ID="MaskedEditExtender7" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtq37a8dt" />
            </tr>
            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <textarea id="txtq37a8" runat="server" style="height: 50px; width: 80%;" placeholder="q37a-(8)"></textarea></td>
            </tr>



            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <asp:TextBox CssClass="form-control input" ID="txtq37a9dt" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Date q37a-(9)" runat="server"></asp:TextBox></td>
                <cc1:MaskedEditExtender ID="MaskedEditExtender17" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtq37a9dt" />
            </tr>
            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <textarea id="txtq37a9" runat="server" style="height: 50px; width: 80%;" placeholder="q37a-(9)"></textarea></td>
            </tr>




            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <asp:TextBox CssClass="form-control input" ID="txtq37a10dt" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Date q37a-(10)" runat="server"></asp:TextBox></td>
                <cc1:MaskedEditExtender ID="MaskedEditExtender18" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtq37a10dt" />
            </tr>
            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <textarea id="txtq37a10" runat="server" style="height: 50px; width: 80%;" placeholder="q37a-(10)"></textarea></td>
            </tr>





            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <asp:TextBox CssClass="form-control input" ID="txtq37a11dt" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Date q37a-(11)" runat="server"></asp:TextBox></td>
                <cc1:MaskedEditExtender ID="MaskedEditExtender26" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtq37a11dt" />
            </tr>
            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <textarea id="txtq37a11" runat="server" style="height: 50px; width: 80%;" placeholder="q37a-(11)"></textarea></td>
            </tr>


            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <asp:TextBox CssClass="form-control input" ID="txtq37a12dt" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Date q37a-(12)" runat="server"></asp:TextBox></td>
                <cc1:MaskedEditExtender ID="MaskedEditExtender27" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtq37a12dt" />
            </tr>
            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <textarea id="txtq37a12" runat="server" style="height: 50px; width: 80%;" placeholder="q37a-(12)"></textarea></td>
            </tr>


            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <asp:TextBox CssClass="form-control input" ID="txtq37a13dt" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Date q37a-(13)" runat="server"></asp:TextBox></td>
                <cc1:MaskedEditExtender ID="MaskedEditExtender28" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtq37a13dt" />
            </tr>
            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <textarea id="txtq37a13" runat="server" style="height: 50px; width: 80%;" placeholder="q37a-(13)"></textarea></td>
            </tr>


            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <asp:TextBox CssClass="form-control input" ID="txtq37a14dt" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Date q37a-(14)" runat="server"></asp:TextBox></td>
                <cc1:MaskedEditExtender ID="MaskedEditExtender29" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtq37a14dt" />
            </tr>
            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <textarea id="txtq37a14" runat="server" style="height: 50px; width: 80%;" placeholder="q37a-(14)"></textarea></td>
            </tr>


            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <asp:TextBox CssClass="form-control input" ID="txtq37a15dt" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Date q37a-(15)" runat="server"></asp:TextBox></td>
                <cc1:MaskedEditExtender ID="MaskedEditExtender30" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtq37a15dt" />
            </tr>
            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <textarea id="txtq37a15" runat="server" style="height: 50px; width: 80%;" placeholder="q37a-(15)"></textarea></td>
            </tr>









            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="background-color: gray; color: white; text-align: center; font-size: 16px">Q37b. What action/s was taken after suspected adverse event.                    
                </td>
            </tr>


            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <asp:TextBox CssClass="form-control input" ID="txtq37b1dt" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Date q37b-(1)" runat="server"></asp:TextBox></td>
                <cc1:MaskedEditExtender ID="MaskedEditExtender8" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtq37b1dt" />
            </tr>
            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <textarea id="txtq37b1" runat="server" style="height: 50px; width: 80%;" placeholder="q37b-(1)"></textarea></td>
            </tr>



            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <asp:TextBox CssClass="form-control input" ID="txtq37b2dt" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Date q37b-(2)" runat="server"></asp:TextBox></td>
                <cc1:MaskedEditExtender ID="MaskedEditExtender9" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtq37b2dt" />
            </tr>
            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <textarea id="txtq37b2" runat="server" style="height: 50px; width: 80%;" placeholder="q37b-(2)"></textarea></td>
            </tr>


            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <asp:TextBox CssClass="form-control input" ID="txtq37b3dt" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Date q37b-(3)" runat="server"></asp:TextBox></td>
                <cc1:MaskedEditExtender ID="MaskedEditExtender10" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtq37b3dt" />
            </tr>
            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <textarea id="txtq37b3" runat="server" style="height: 50px; width: 80%;" placeholder="q37b-(3)"></textarea></td>
            </tr>


            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <asp:TextBox CssClass="form-control input" ID="txtq37b4dt" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Date q37b-(4)" runat="server"></asp:TextBox></td>
                <cc1:MaskedEditExtender ID="MaskedEditExtender12" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtq37b4dt" />
            </tr>
            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <textarea id="txtq37b4" runat="server" style="height: 50px; width: 80%;" placeholder="q37b-(4)"></textarea></td>
            </tr>



            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <asp:TextBox CssClass="form-control input" ID="txtq37b5dt" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Date q37b-(5)" runat="server"></asp:TextBox></td>
                <cc1:MaskedEditExtender ID="MaskedEditExtender13" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtq37b5dt" />
            </tr>
            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <textarea id="txtq37b5" runat="server" style="height: 50px; width: 80%;" placeholder="q37b-(5)"></textarea></td>
            </tr>


            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <asp:TextBox CssClass="form-control input" ID="txtq37b6dt" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Date q37b-(6)" runat="server"></asp:TextBox></td>
                <cc1:MaskedEditExtender ID="MaskedEditExtender14" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtq37b6dt" />
            </tr>
            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <textarea id="txtq37b6" runat="server" style="height: 50px; width: 80%;" placeholder="q37b-(6)"></textarea></td>
            </tr>


            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <asp:TextBox CssClass="form-control input" ID="txtq37b7dt" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Date q37b-(7)" runat="server"></asp:TextBox></td>
                <cc1:MaskedEditExtender ID="MaskedEditExtender15" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtq37b7dt" />
            </tr>
            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <textarea id="txtq37b7" runat="server" style="height: 50px; width: 80%;" placeholder="q37b-(7)"></textarea></td>
            </tr>



            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <asp:TextBox CssClass="form-control input" ID="txtq37b8dt" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Date q37b-(8)" runat="server"></asp:TextBox></td>
                <cc1:MaskedEditExtender ID="MaskedEditExtender16" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtq37b8dt" />
            </tr>
            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <textarea id="txtq37b8" runat="server" style="height: 50px; width: 80%;" placeholder="q37b-(8)"></textarea></td>
            </tr>


            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <asp:TextBox CssClass="form-control input" ID="txtq37b9dt" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Date q37b-(9)" runat="server"></asp:TextBox></td>
                <cc1:MaskedEditExtender ID="MaskedEditExtender19" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtq37b9dt" />
            </tr>
            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <textarea id="txtq37b9" runat="server" style="height: 50px; width: 80%;" placeholder="q37b-(9)"></textarea></td>
            </tr>



            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <asp:TextBox CssClass="form-control input" ID="txtq37b10dt" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Date q37b-(10)" runat="server"></asp:TextBox></td>
                <cc1:MaskedEditExtender ID="MaskedEditExtender20" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtq37b10dt" />
            </tr>
            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <textarea id="txtq37b10" runat="server" style="height: 50px; width: 80%;" placeholder="q37b-(10)"></textarea></td>
            </tr>


            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <asp:TextBox CssClass="form-control input" ID="txtq37b11dt" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Date q37b-(11)" runat="server"></asp:TextBox></td>
                <cc1:MaskedEditExtender ID="MaskedEditExtender21" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtq37b11dt" />
            </tr>
            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <textarea id="txtq37b11" runat="server" style="height: 50px; width: 80%;" placeholder="q37b-(11)"></textarea></td>
            </tr>


            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <asp:TextBox CssClass="form-control input" ID="txtq37b12dt" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Date q37b-(12)" runat="server"></asp:TextBox></td>
                <cc1:MaskedEditExtender ID="MaskedEditExtender22" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtq37b12dt" />
            </tr>
            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <textarea id="txtq37b12" runat="server" style="height: 50px; width: 80%;" placeholder="q37b-(12)"></textarea></td>
            </tr>


            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <asp:TextBox CssClass="form-control input" ID="txtq37b13dt" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Date q37b-(13)" runat="server"></asp:TextBox></td>
                <cc1:MaskedEditExtender ID="MaskedEditExtender23" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtq37b13dt" />
            </tr>
            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <textarea id="txtq37b13" runat="server" style="height: 50px; width: 80%;" placeholder="q37b-(13)"></textarea></td>
            </tr>


            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <asp:TextBox CssClass="form-control input" ID="txtq37b14dt" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Date q37b-(14)" runat="server"></asp:TextBox></td>
                <cc1:MaskedEditExtender ID="MaskedEditExtender24" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtq37b14dt" />
            </tr>
            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <textarea id="txtq37b14" runat="server" style="height: 50px; width: 80%;" placeholder="q37b-(14)"></textarea></td>
            </tr>


            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <asp:TextBox CssClass="form-control input" ID="txtq37b15dt" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Date q37b-(15)" runat="server"></asp:TextBox></td>
                <cc1:MaskedEditExtender ID="MaskedEditExtender25" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtq37b15dt" />
            </tr>
            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <textarea id="txtq37b15" runat="server" style="height: 50px; width: 80%;" placeholder="q37b-(15)"></textarea></td>
            </tr>


        </table>


        <br />
        <div class="buttonWeb">
            <asp:Button ID="btnNext" runat="server" Text="Next" class="btn btn-theme btn-lg btn-block" OnClick="next_Click" OnClientClick="return clicknext();" />
        </div>

        <br />
        <br />

    </asp:Panel>

</asp:Content>
