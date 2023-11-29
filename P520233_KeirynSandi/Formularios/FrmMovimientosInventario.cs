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
    public partial class FrmMovimientosInventario : Form
    {
       public Logica.Models.Movimiento MiMovimientoLocal {  get; set; }

       public DataTable DtListaDetalleProductos { get; set; }

       

        public FrmMovimientosInventario()
        {
            InitializeComponent();

            MiMovimientoLocal = new Logica.Models.Movimiento();
            DtListaDetalleProductos = new DataTable();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmMovimientosInventario_Load(object sender, EventArgs e)
        {
            MdiParent = Globales.ObjetosGlobales.MiFormularioPrincipal;
            CargarComboMovimiento();
            LimpiarFormulario();
        }

        private void CargarComboMovimiento()
        {
            Logica.Models.MovimientoTipo MiTipo = new Logica.Models.MovimientoTipo();

            DataTable dt = new DataTable();

            dt = MiTipo.Listar();

            if (dt != null && dt.Rows.Count > 0)
            {

                CboxTipo.ValueMember = "id";
                CboxTipo.DisplayMember = "Descripcion";

                CboxTipo.DataSource = dt;
                CboxTipo.SelectedIndex = -1;

            }
        }


        private void LimpiarFormulario()
        {
            DtpFecha.Value = DateTime.Now.Date;
            CboxTipo.SelectedIndex = -1;
            TxtAnotaciones.Clear();

            //EN ESTE CASO PARTICULAR EL DATATABLE QUE ALIMENTA EL DVG
            //DEBE TENER ESTRUCTURA, PERO NO DATOS INICIALMENTE 
            //CONCIDERANDO ESO, LLENAREMOS EL DATATAVLE CON EL ESQUEMA
            //DE LA CONSULTA DEL SP SPMOVIMIENTOCARGARDETALLE
            //ESTO PERMITE TENER EL DT SIN FILA, PERO  CON ESTRUCTURA, 
            //QUE PERMITE AGREGAR FILLAS PASTERIORMENTE

            DtListaDetalleProductos = MiMovimientoLocal.AsignarEsquemaDelDetalle();

            DgvListaDetalle.DataSource = DtListaDetalleProductos;

            //LIMPIAR LOS TOTALES

            LblTotalCosto.Text = "0";
            LblTotalGranTotal.Text = "0";
            LblTotalImpuestos.Text = "0";
            LblTotalSubTotal.Text = "0";

        }     



        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            //EL FORMULARIO QUE MUESTRA LA LISTA DE ITEMS, SE DEBE MOSTRAR EN ESTE
            //CASO PARTICULAR EN FORMATO DE DIALOGO, YA QUE QUEREMOS CORTAR TEMPORALMENTE
            //EL FUNCIONAMIENTO DEL FORM ACTUAL, HACER ALGO EN LE OTRO FORM Y ESPERAR 
            //UNA RESPUESTA

            Form FormDetalleProducto = new Formularios.FrmMovimientosInventarioDetalleProducto();

            DialogResult resp = FormDetalleProducto.ShowDialog();

            if (resp == DialogResult.OK) 
            {
                DgvListaDetalle.DataSource = DtListaDetalleProductos;

                Totalizar();


            }



        }

        private void Totalizar()
        {

            decimal Costo = 0;
            decimal Subtotal = 0;
            decimal TotalIVA = 0;
            decimal Total = 0;

            if (DtListaDetalleProductos != null && DtListaDetalleProductos.Rows.Count > 0)
            {
                foreach (DataRow item in DtListaDetalleProductos.Rows)
                {

                    decimal Cantidad = Convert.ToDecimal(item["CantidadMovimiento"]);

                    Costo += Convert.ToDecimal(item["Costo"]) * Cantidad;

                    Subtotal += Convert.ToDecimal(item["Subtotal"]) * Cantidad;

                    TotalIVA += Convert.ToDecimal(item["TotalIVA"]) * Cantidad;

                    Total += Subtotal + TotalIVA;
                }
            }

            LblTotalCosto.Text = string.Format("{0:C2}", Costo);
            LblTotalSubTotal.Text = string.Format("{0:C2}", Subtotal);
            LblTotalImpuestos.Text = string.Format("{0:C2}", TotalIVA);
            LblTotalGranTotal.Text = string.Format("{0:C2}", Total);

            
        }

        private void BtnAplicar_Click(object sender, EventArgs e)
        {
            if (ValidarMovimiento())
            {
                MiMovimientoLocal.Fecha = DtpFecha.Value.Date;
                MiMovimientoLocal.Anotaciones = TxtAnotaciones.Text.Trim();

                MiMovimientoLocal.MiTipo.MovimientoTipoID = Convert.ToInt32(CboxTipo.SelectedValue);

                MiMovimientoLocal.MiUsuario = Globales.ObjetosGlobales.MiUsuarioGlobal;


                TrasladarDetalles();

                if (MiMovimientoLocal.Agregar()) ;
                {
                    MessageBox.Show("EL MOVIMEINTO SE HA AGREGADO CORRECTAMENTE", ":D", MessageBoxButtons.OK);

                    //TODO generar un reporte visual en CR

                }

            }

        }

        private void TrasladarDetalles()
        {

            foreach (DataRow item in DtListaDetalleProductos.Rows)
            {

                //EN CADA ITERACION CREAMOS UN NUEVO OBJETO DE "MOVIIENTODETALLE" QUE LUEGO
                //SERA AGREGADO A LA LISTA DE DETALLES DEL OBJETO LOCAL 

                Logica.Models.MovimientoDetalle NuevoDetalle = new Logica.Models.MovimientoDetalle();

                NuevoDetalle.CantidadMovimiento = Convert.ToDecimal(item["CantidadMovimiento"]);
                NuevoDetalle.Costo = Convert.ToDecimal(item["Costo"]);
                NuevoDetalle.PrecioUnitario = Convert.ToDecimal(item["PrecioUnitario"]);
                NuevoDetalle.SubTotal = Convert.ToDecimal(item["SubTotal"]);
                NuevoDetalle.TotalIVA = Convert.ToDecimal(item["TotalIVA"]);

                //ATRIBUTO COMPUESTO SIMPLE

                NuevoDetalle.MiProducto.ProductoID = Convert.ToInt32(item["ProductoID"]);

                //AGREGAR EL DETALLE NUEVO A LA LISTA DEL OBJETO LOCAL

                MiMovimientoLocal.Detalles.Add(NuevoDetalle);

            }

        }


        private bool ValidarMovimiento()
        {
            bool R = false;
            if (DtpFecha.Value.Date <= DateTime.Now.Date &&
                CboxTipo.SelectedIndex > -1 &&
                DtListaDetalleProductos.Rows.Count > 0)
            {
                R = true;
            }
            else
            {
                if (DtpFecha.Value.Date > DateTime.Now.Date)
                {
                    MessageBox.Show("La fecha del movimiento no puede " +
                        "ser superior a la fecha actual", "Error de Validación",
                        MessageBoxButtons.OK);
                    return false;
                }
                if (CboxTipo.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar un tipo de movimiento",
                        "Error de Validación", MessageBoxButtons.OK);
                    return false;
                }
                if (DtListaDetalleProductos == null || DtListaDetalleProductos.Rows.Count == 0)
                {
                    MessageBox.Show("No se puede procesar un movimiento sin detalles",
                        "Error de Validación", MessageBoxButtons.OK);
                    return false;
                }
            }
            return R;
        }

    }
}
