<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="OpcaoDeConta.aspx.cs" Inherits="CamadaInterface.OpcaoDeConta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="keywords" content="SYSO - Painel Informativo" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="description" content="SYSO - Painel Informativo" />
    <link href="templatemo_style.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
        function clearText(field) {
            if (field.defaultValue == field.value) field.value = '';
            else if (field.value == '') field.value = field.defaultValue;
        }
    </script>
    <style type="text/css">

        .style6
    {
        width: 563px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td align="center" class="style6">
                <H2>Opções de Conta</H2></td>
        </tr>
        <tr>
            <td class="style6" >
                Senha atual<br />
                <asp:TextBox ID="TextBoxAtual" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <br />
                Nova senha
                <br />
                <asp:TextBox ID="TextBoxNovaSenha" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
            &nbsp;
                <br />
                <asp:Button ID="ButtonTrocarSenha" runat="server" Text="Trocar senha" 
                    onclick="ButtonTrocarSenha_Click" />
                <br />
                <asp:Label ID="LabelMsg" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
