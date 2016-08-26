<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Consultar_Alterar_Exluir.aspx.cs" Inherits="CamadaInterface.Consultar_Alterar_Exluir" %>
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
        .style2
        {
            width: 513px;
        }
        .style3
        {
            width: 513px;
            height: 105px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="style1" style="width: 550px">
<tr align="center">
    <td class="style2" ><h2 style="width: 539px; margin-bottom: 1px">Administrar Painel</h2>
    </td>
</tr>
        <tr>
            <td class="style2">
                Data<br />
                <asp:DropDownList ID="DropDownDsemana" runat="server" 
                    DataSourceID="SqlDataSourceData" DataTextField="data" DataValueField="data" 
                    Height="22px" Width="168px">
                </asp:DropDownList>
&nbsp;<asp:Button ID="ButtonConsultar" runat="server" Height="23px" Text="Consultar" 
                    onclick="ButtonConsultar_Click" />
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                Turno<br />
                <asp:DropDownList ID="DropDownTurno" runat="server" Height="22px" Width="168px">
                    <asp:ListItem>Manha</asp:ListItem>
                    <asp:ListItem>Tarde</asp:ListItem>
                    <asp:ListItem>Noite</asp:ListItem>
                </asp:DropDownList>
                <br />
                
                    <tr>
                        <td class="style2">
                            Codigo<br />
                            <asp:TextBox ID="TextBoxCodigo" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                
                    <tr>
                        <td class="style2">
                            Sala<br />
                            <asp:DropDownList ID="DropDownListSala" runat="server" 
                                DataSourceID="SqlDataSource2" DataTextField="nome" DataValueField="idSala" Height="22px" Width="168px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            Turma<br />
                            <asp:DropDownList ID="DropDownListTurma" runat="server" 
                                DataSourceID="SqlDataSource3" DataTextField="codigo" 
                                DataValueField="idTurma" Height="22px" Width="168px" AutoPostBack="True">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            Curso<br />
                            <asp:DropDownList ID="DropDownListCurso" runat="server" 
                                DataSourceID="SqlDataSource4" DataTextField="nome" 
                                DataValueField="idCurso" AutoPostBack="True" Enabled="False">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            Disciplina<br />
                            <asp:DropDownList ID="DropDownListDisciplina" runat="server" 
                                DataSourceID="SqlDataSource5" DataTextField="nomeDisciplina" 
                                DataValueField="idDisc" Height="22px" Width="168px" AutoPostBack="True">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            Professor<br />
                            <asp:DropDownList ID="DropDownListProfessor" runat="server" 
                                DataSourceID="SqlDataSource6" DataTextField="nome" 
                                DataValueField="matricula" Height="22px" Width="168px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <asp:Button ID="ButtonAlterar" runat="server" Text="Alterar" 
                                onclick="ButtonAlterar_Click" />
                            &nbsp;<asp:Button ID="ButtonExcluir" runat="server" onclick="ButtonExcluir_Click" 
                                Text="Excluir" style="width: 60px" />
                            <br />
                <asp:Label ID="LabelMsg" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                    </tr>
                
            </td>
        </tr>
                    <tr align="center">
                        <td class="style3" align="center">
                                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                                        AutoGenerateColumns="False" AutoGenerateSelectButton="True" CellPadding="4" 
                                        DataKeyNames="painel" ForeColor="#333333" GridLines="None" 
                                        onpageindexchanging="GridView1_PageIndexChanging" 
                                        onselectedindexchanged="GridView1_SelectedIndexChanged" PageIndex="5" 
                                        PageSize="5" style="margin-right: 1px">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:BoundField DataField="Cod" HeaderText="Codigo" SortExpression="Cod" />
                                            <asp:TemplateField HeaderText="Sala" SortExpression="sala">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("sala") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:DropDownList ID="DropDownListSala" runat="server" 
                                                        DataSourceID="SqlDataSource1" DataTextField="nome" DataValueField="idSala">
                                                    </asp:DropDownList>
                                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                                        ConnectionString="<%$ ConnectionStrings:SYSOConnectionString %>" 
                                                        SelectCommand="select nome,idSala from sala"></asp:SqlDataSource>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Turma" SortExpression="turma">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("turma") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Curso" SortExpression="curso">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("curso") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Disciplina" SortExpression="disciplina">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("disciplina") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Professor" SortExpression="professor">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("professor") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EditRowStyle BackColor="#2461BF" />
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#EFF3FB" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                    </asp:GridView>
                            </td>
                    </tr>
                
        <tr>
            <td align="center" class="style2">
                <asp:SqlDataSource ID="SqlDataSourceData" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:SYSOConnectionString4 %>" 
                    SelectCommand="SELECT DISTINCT [data] FROM [painel]"></asp:SqlDataSource>
                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:SYSOConnectionString %>" 
                                SelectCommand="SELECT [nome], [idSala] FROM [sala]"></asp:SqlDataSource>
                            <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:SYSOConnectionString %>" 
                                SelectCommand="SELECT [idTurma], [codigo] FROM [turma]"></asp:SqlDataSource>
                            <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:SYSOConnectionString %>" 
                                
                    SelectCommand="SELECT [nome], [idCurso] FROM [curso] WHERE ([idCurso] = @idCurso)">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="DropDownListTurma" Name="idCurso" 
                                        PropertyName="SelectedValue" Type="Int32" />
                                </SelectParameters>
                </asp:SqlDataSource>
                            <asp:SqlDataSource ID="SqlDataSource5" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:SYSOConnectionString %>" 
                                
                    SelectCommand="SELECT [idDisc], [nomeDisciplina] FROM [disciplina] WHERE (([idCurso] = @idCurso) AND ([idCurso] = @idCurso2))">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="DropDownListCurso" Name="idCurso" 
                                        PropertyName="SelectedValue" Type="Int32" />
                                    <asp:ControlParameter ControlID="DropDownListTurma" Name="idCurso2" 
                                        PropertyName="SelectedValue" Type="Int32" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                            <asp:SqlDataSource ID="SqlDataSource6" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:SYSOConnectionString %>" 
                                SelectCommand="SELECT [nome], [matricula] FROM [funcionario] WHERE ([cargo] = @cargo)">
                                <SelectParameters>
                                    <asp:QueryStringParameter DefaultValue="Professor" Name="cargo" 
                                        QueryStringField="Professor" Type="String" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </td>
        </tr>
    </table>
</asp:Content>
