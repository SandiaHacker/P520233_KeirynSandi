using Logica.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P520233_KeirynSandi.Formularios
{
    public partial class FrmMovimientosInventarioDetalleProducto : Form
    {
        DataTable ListaProductos {  get; set; }
        DataTable ListaProductosConFiltro { get; set; }

        Logica.Models.Producto MiProduto { get; set; }



    public FrmMovimientosInventarioDetalleProducto()
        {
            InitializeComponent();

            ListaProductos = new DataTable();
            ListaProductosConFiltro = new DataTable();

            MiProduto = new Logica.Models.Producto();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if(Validar())
            {
                //EL DGV (LA PARTE GRAFICA TIENE DE FONDO UN DATA TABLE QUE LO ALIMETA)
                //COMO SE OCULTARON 3 COLUMNAS EN EL DGV, NO SE PODRA OBTENER EL  DATO QUE 
                //CONTIENEN. EN ESTE CASO SE USARÁ EL DATATABLE PARA OBTENER DICHOS DATOS
                //(COSTO, SUBTOTAL, %IVA)

                DataGridViewRow MiDgvFila = DgvLista.SelectedRows[0];
                int IDProducto = Convert.ToInt32(MiDgvFila.Cells["CProductoID"].Value);

                //UNA VEZ QUE TENEMOS EL ID DEL PRODUCTO, RECORREMOS EL DATATABLE
                //BUSCAMOS DICHO ID

                foreach (DataRow item in ListaProductos.Rows)
                {
                    if (IDProducto == Convert.ToInt32(item["ProductoID"]))
                    {
                        //CUANDO LA COMPARACION SEA CORRECTA, TENEMOS TODO LO NECESARIO PARA
                        //CREAR LA NUEVA FILA EN EL FORMULARIO DE MOVIMIENTO DE INVENTARIO

                        // 1. CREAMOS UN OBJETO DE LA FILA DEL FORMULARIO DE MOV DE INV

                        DataRow NuevaFila = Globales.ObjetosGlobales.MiFormularioMovimientos.DtListaDetalleProductos.NewRow();

                        NuevaFila["ProductoID"] = IDProducto;

                        NuevaFila["NombreProducto"] = item["NombreProducto"].ToString();

                        NuevaFila["CantidadMovimiento"] = Convert.ToDecimal(NtxtCantidad.Value);

                        NuevaFila["Costo"] = Convert.ToDecimal(item["Costo"]);

                        NuevaFila["SubTotal"] = Convert.ToDecimal(item["SubTotal"]);

                        //NECESITO HACER EL CALCULO DEL TOTAL DEL IMPUESTO, NO BASTA SOLO EL % DEL IVA
                        decimal TasaIVA = Convert.ToDecimal(item["TasaImpuesto"]);
                        decimal SubTotal = Convert.ToDecimal(item["SubTotal"]);
                        decimal TotalIVA = SubTotal * TasaIVA;
                        NuevaFila["TotalIVA"] = TotalIVA;

                        NuevaFila["PrecioUnitario"] = Convert.ToDecimal(item["PrecioUnitario"]);

                        NuevaFila["CodigoBarras"] = item["CodigoBarras"].ToString();

                        //UNA VEZ QUE TENEMOSS UNA NUEVA FILA CARGADA CON DATA, SE PROCEDE A ADJUNTARLA
                        //AL DATATABLE DEL DETALLE EL MOVIMIENTO Y CERRAMOS ESTTE FORM CON RESPUEST OK

                        Globales.ObjetosGlobales.MiFormularioMovimientos.DtListaDetalleProductos.Rows.Add(NuevaFila);

                        DialogResult = DialogResult.OK;

                        break;


                    }
                }


            }

        }

        private bool Validar()
        {
           bool R = false;

if (DgvLista.SelectedRows.Count == 1 && NtxtCantidad.Value > 0)
{
    R = true;
}
else
{
    //si no se seleccionó algo en la lista 
    if (DgvLista.SelectedRows.Count == 0)
    {
        MessageBox.Show("Debe seleccionar un producto de la lista", "Error de validación", MessageBoxButtons.OK);
        return false;
    }
    if (NtxtCantidad.Value <= 0)
    {
        MessageBox.Show("La cantidad no puede ser cero o negativa", "Error de validación", MessageBoxButtons.OK);
        return false;
    }
}
return R;
        }

        private void FrmMovimientosInventarioDetalleProducto_Load(object sender, EventArgs e)
        {
            LlenarLista();
        }

        private void LlenarLista()
        {
            ListaProductos = MiProduto.ListarEnMovimientoDetalleProducto();

            DgvLista.DataSource = ListaProductos;

            DgvLista.ClearSelection();

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
