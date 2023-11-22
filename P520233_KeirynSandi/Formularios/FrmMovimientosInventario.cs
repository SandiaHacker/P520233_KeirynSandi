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
            Logica.Models.UsuarioRol MiRol = new Logica.Models.UsuarioRol();

            DataTable dt = new DataTable();

            dt = MiRol.Listar();

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
                //TODO AGREGAR LA NUEVA LINEA DE DETALLE
            }

        }
    }
}
