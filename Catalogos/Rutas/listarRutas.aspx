<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="listarRutas.aspx.cs" Inherits="Transportes_3_capas_gen_7.Catalogos.Rutas.listarRutas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <h3>Lista de Rutas</h3>
            <asp:Button ID="Insert" runat="server" Text="Crear" CssClass="btn btn-primary btn-xs" Width="55px" OnClick="Insert_Click" />
        </div>
        <div class="row">
            <asp:GridView ID="GVRutas"
                runat="server"
                CssClass="table table-bordered table-striped table-condensed"
                AutoGenerateColumns="false"
                DataKeyNames="IdRuta"
                OnRowCommand="GVRutas_RowCommand"
                OnRowDeleting="GVRutas_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="IdRuta" HeaderText="ID Ruta" ItemStyle-Width="50px" ReadOnly="true" />
                    <asp:BoundField DataField="Distancia" HeaderText="Distancia" ItemStyle-Width="50px" ReadOnly="true" />
                    <asp:BoundField DataField="FechaSalida" HeaderText="Fecha Salida" ItemStyle-Width="50px" ReadOnly="true" />
                    <asp:BoundField DataField="FechaLlegadaEstimada" HeaderText="Fecha Llegada Estimada" ItemStyle-Width="50px" ReadOnly="true" />
                    <asp:BoundField DataField="FechaLlegadaReal" HeaderText="Fecha Llegada Real" ItemStyle-Width="50px" ReadOnly="true" />
                    <asp:BoundField DataField="CamionID" HeaderText="Camion ID" ItemStyle-Width="50px" ReadOnly="true" />
                    <asp:BoundField DataField="ChoferID" HeaderText="Chofer ID" ItemStyle-Width="50px" ReadOnly="true" />
                    <asp:BoundField DataField="DireccionOrigenID" HeaderText="Direccion Origen ID" ItemStyle-Width="50px" ReadOnly="true" />
                    <asp:BoundField DataField="DireccionDestinoID" HeaderText="Direccion Destino ID" ItemStyle-Width="50px" ReadOnly="true" />

                    <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="Editar" ShowHeader="true" Text="Editar" ControlStyle-CssClass="btn btn-primary btn-xs" ItemStyle-Width="50px" />

                    <asp:CommandField ButtonType="Button" HeaderText="Eliminar" ShowDeleteButton="true" ShowHeader="true"
                        ControlStyle-CssClass="btn btn-danger btn-xs" ItemStyle-Width="50px" />
                </Columns>
            </asp:GridView>
        </div>
    </div>

</asp:Content>
