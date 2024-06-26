<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListarUsuarios.aspx.cs" Inherits="Transportes_3_capas_gen_7.Catalogos.Usuarios.ListarUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <h3>Lista de Usuarios</h3>
            <asp:Button ID="Insertar" runat="server" Text="Crear" CssClass="btn btn-primary btn-xs" Width="55px" OnClick="Insertar_Click" />
        </div>
        <div class="row">
            <asp:GridView ID="GVUsuarios"
                runat="server"
                CssClass="table table-bordered table-striped table-condensed"
                AutoGenerateColumns="false"
                DataKeyNames="ID_User"
                OnRowCommand="GVUsuarios_RowCommand"
                OnRowDeleting="GVUsuarios_RowDeleting">

                <Columns>
                    <asp:BoundField DataField="ID_User" HeaderText="# Usuario" ItemStyle-Width="50px" ReadOnly="true" />
                    <asp:BoundField DataField="Nickname" HeaderText="Nickname" ItemStyle-Width="50px" ReadOnly="true" />
                    <asp:BoundField DataField="Estatus" HeaderText="Estatus" ItemStyle-Width="50px" ReadOnly="true" />
                    <asp:BoundField DataField="Rol" HeaderText="Rol" ItemStyle-Width="50px" ReadOnly="true" />

                    <asp:ButtonField ButtonType="Button" HeaderText="Editar" CommandName="Select" ShowHeader="true" Text="Editar" ControlStyle-CssClass="btn btn-primary btn-xs" ItemStyle-Width="50px" />

                    <asp:CommandField ButtonType="Button" HeaderText="Eliminar" ShowDeleteButton="true" ShowHeader="true" ControlStyle-CssClass="btn btn-danger btn-xs" ItemStyle-Width="50px" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
