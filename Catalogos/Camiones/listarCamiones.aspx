﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="listarCamiones.aspx.cs" Inherits="Transportes_3_capas_gen_7.Catalagos.Camiones.listarCamiones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div calss="row">
            <h3>Lista de Camiones</h3>
            <%--Botón de Agregar--%>
            <p>
                <i class="bi bi-x-diamond-fill"></i>
                <asp:Button ID="Insertar" runat="server" Text="Agregar" CssClass="btn btn-primary btn-xs" Width="85px" OnClick="Insertar_Click" />
            </p>
            <a class="btn btn-primary btn-xs" href="/catalogos/Camiones/FormularioCamion.aspx">
                <i class="bi bi-x-diamond-fill"></i>
                Agregar

            </a>
        </div>

        <div class="row">
            <%--GridView(controls de ASP, Web Foomrs)--%>
            <asp:GridView
                ID="GVCamiones"
                runat="server"
                CssClass="table table-bordered table-striped table-condensed"
                AutoGenerateColumns="false"
                DataKeyNames="IdCamion"
                OnRowDeleting="GVCamiones_RowDeleting"
                OnRowCommand="GVCamiones_RowCommand"
                OnRowEditing="GVCamiones_RowEditing"
                OnRowUpdating="GVCamiones_RowUpdating"
                OnRowCancelingEdit="GVCamiones_RowCancelingEdit">

                <Columns>
                    <asp:BoundField DataField="IdCamion" HeaderText="Número de Camión" ItemStyle-Width="50px" ReadOnly="true" />

                    <asp:BoundField DataField="Matricula" HeaderText="Matrícula" ItemStyle-Width="85px" />

                    <asp:BoundField DataField="TipoCamion" HeaderText="Tipo_Camion" ItemStyle-Width="85px" />

                    <asp:TemplateField HeaderText="disponibilidad" ItemStyle-Width="50px">

                        <ItemTemplate>
                            <div style="width: 100%">
                                <div style="width: 25%; margin: 0 auto">
                                    <asp:CheckBox ID="chkDisponible" runat="server"
                                        Checked='<%#Eval("Disponibilidad")%>' Enabled="false" />
                                </div>
                            </div>
                        </ItemTemplate>

                        <EditItemTemplate>
                            <div style="width: 100%">
                                <div style="width: 25%; margin: 0 auto">
                                    <asp:CheckBox ID="chkEditDisponible" runat="server"
                                        Checked='<%#Eval("Disponibilidad")%>' />
                                </div>
                            </div>
                        </EditItemTemplate>

                    </asp:TemplateField>

                    <asp:BoundField DataField="UrlFoto" HeaderText="UrlFoto" ItemStyle-Width="85px" />
                    <asp:ImageField HeaderText="Foto" ReadOnly="true" ItemStyle-Width="120px" ControlStyle-Height="120px" ControlStyle-Width="120px" DataImageUrlField="UrlFoto">
                    </asp:ImageField>


                    <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="1" Text="Ver Detalles" ControlStyle-CssClass="btn btn-primary btn-xs" ItemStyle-Width="50px" />
                    <asp:CommandField ButtonType="Button" HeaderText="2" ShowEditButton="true" ShowHeader="true" ControlStyle-CssClass="btn btn-warning btn-xs" ItemStyle-Width="50px" />
                    <asp:CommandField ButtonType="Button" HeaderText="2" ShowDeleteButton="true" ShowHeader="true" ControlStyle-CssClass="btn btn-danger btn-xs" ItemStyle-Width="50px" />

                </Columns>

            </asp:GridView>
        </div>
    </div>
</asp:Content>
