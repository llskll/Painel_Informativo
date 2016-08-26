<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="VerPainel.aspx.cs" Inherits="CamadaInterface.VerPainel" %>
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
    <script src="jquery.js" type="text/javascript"></script>
    <script src="jquery.maskedinput.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript">

        
    
</script>
    <style type="text/css">
        #Titulo
        {
            height: 13px;
            width: 249px;
            width: 440px;
        }
        .style2
        {
            width: 581px;
        }
        .style3
        {
            width: 1476px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <table >
        <tr align="center">
            <td class="style2" colspan="2" >
                <h2>Painel Informativo</h2>
            </td>
        </tr>

        <tr align="center">
            <td class="style2" colspan="2" >
                <asp:DropDownList ID="DropDownListData" runat="server" 
                    DataSourceID="SqlDataSource1" DataTextField="data" DataValueField="data" 
                    Height="22px" Width="168px">
                </asp:DropDownList>
&nbsp;<asp:Button ID="ButtonCarregarPainel" runat="server" onclick="Button1_Click" 
                    Text="Ver Painel" />
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:SYSOConnectionString %>" 
                    SelectCommand="SELECT DISTINCT [data] FROM [painel]"></asp:SqlDataSource>
&nbsp;&nbsp;</td>
        </tr>

        <tr align="center">
            <td class="style3" >
                &nbsp;&nbsp;&nbsp; <asp:DropDownList ID="DropDownTurno" runat="server" Height="22px" Width="168px">
                    <asp:ListItem>Manha</asp:ListItem>
                    <asp:ListItem>Tarde</asp:ListItem>
                    <asp:ListItem>Noite</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="style2" >
                &nbsp;</td>
        </tr>

        <tr align="center">
            <td class="style2" colspan="2">
            
                
            
                <br />
            
                
            
        <asp:GridView ID="GridView1" runat="server" 
            AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None" 
            onpageindexchanging="GridView1_PageIndexChanging" PageSize="5" Width="540px">
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" 
                ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" 
                ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" 
                HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" 
                ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
                <br />
                <br />
            
                &nbsp;</td>
    </tr>
    </table>

<%--    select turma.codigo as Turma,sala.nome as Sala,
    funcionario.nome as Professor,disciplina.nomeDisciplina
     as Disciplina,curso.nome as Curso  from funcionario,turma,
     sala,painel,disciplina,curso where turma.idTurma=painel.idTurma
      and sala.idSala=painel.idSala and painel.matricula=funcionario.matricula and
       disciplina.idDisc= painel.idDisc and curso.idCurso=painel.idCurso and
        painel.data = order by painel.idPainel;--%>

</asp:Content>
