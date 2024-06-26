<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListarViewRutas.aspx.cs" Inherits="Transportes_3_capas_gen_7.Catalogos.Rutas.ListarViewRutas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <h3>Lista de Rutas</h3>
            <asp:Button ID="Insertar" runat="server" Text="Crear" CssClass="btn btn-primary btn-xs" Width="55px" OnClick="Insertar_Click" />
        </div>
        <div class="row">
            <asp:GridView ID="GV_Rutas"
                runat="server"
                CssClass="table table-bordered table-striped table-condensed"
                AutoGenerateColumns="false"
                DataKeyNames="no"
                OnRowCommand="GV_Rutas_RowCommand"
                OnRowDeleting="GV_Rutas_RowDeleting">

                <Columns>
                    <asp:BoundField DataField="no" HeaderText="ID Ruta" ItemStyle-Width="50px" ReadOnly="true" />
                    <asp:BoundField DataField="Cargamento" HeaderText="cargamento" ItemStyle-Width="50px" ReadOnly="true" />
                    <asp:BoundField DataField="Origen" HeaderText="Origen" ItemStyle-Width="50px" ReadOnly="true" />
                    <asp:BoundField DataField="Destino" HeaderText="Destino" ItemStyle-Width="50px" ReadOnly="true" />
                    <asp:BoundField DataField="Chofer" HeaderText="Chofer" ItemStyle-Width="50px" ReadOnly="true" />
                    <asp:BoundField DataField="Camion" HeaderText="Camion" ItemStyle-Width="50px" ReadOnly="true" />
                    <asp:BoundField DataField="Salida" HeaderText="Salida" ItemStyle-Width="50px" ReadOnly="true" />
                    <asp:BoundField DataField="Llegada_Estimada" HeaderText="LLegada Estimada" ItemStyle-Width="50px" ReadOnly="true" />

                    <asp:ButtonField ButtonType="Button" HeaderText="Editar" CommandName="Select" ShowHeader="true" Text="Editar" ControlStyle-CssClass="btn btn-primary btn-xs" ItemStyle-Width="50px"/>


                    <asp:CommandField ButtonType="Button" HeaderText="Eliminar" ShowDeleteButton="true" ShowHeader="true" ControlStyle-CssClass="btn btn-danger btn-xs" ItemStyle-Width="50px" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
