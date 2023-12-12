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
    public partial class FrmGestionProductos : Form
    {
        private Logica.Models.Producto MiProductoLocal { get; set; }
        public FrmGestionProductos()
        {

            InitializeComponent();

            MiProductoLocal = new Logica.Models.Producto();
        }

        private void FrmGestionProductos_Load(object sender, EventArgs e)
        {
            MdiParent = Globales.ObjetosGlobales.MiFormularioPrincipal;

            CargarComboRolesProducto();

            CargarListaProductos(CbProductoActivo.Checked);

            ActivarBotonAgregar();
        }

        private void FrmProductosGestion_Load(object sender, EventArgs e)
        {
            MdiParent = Globales.ObjetosGlobales.MiFormularioPrincipal;

            CargarComboRolesProducto();

            CargarListaProductos(CbProductoActivo.Checked);

            ActivarBotonAgregar();
        }

        private void CargarComboRolesProducto()
        {
            Logica.Models.ProductoCategoria MiRol = new Logica.Models.ProductoCategoria();
            DataTable dt = new DataTable();

            dt = MiRol.Listar();

            if (dt != null && dt.Rows.Count > 0)
            {


                //na vez asegurado que el dt tenga valores, los dibujos en el combobox

                CboxUsuarioTipoRol.ValueMember = "id";
                CboxUsuarioTipoRol.DisplayMember = "Descripcion";

                CboxUsuarioTipoRol.DataSource = dt;
                CboxUsuarioTipoRol.SelectedIndex = -1;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        private bool ValidarDatosRequeridos()
        {
            bool R = false;

            if (!string.IsNullOrEmpty(TxtNombreProducto.Text.Trim()) &&
                !string.IsNullOrEmpty(TxtCodigoBarras.Text.Trim()) &&
                !string.IsNullOrEmpty(TxtCosto.Text.Trim()) &&
                !string.IsNullOrEmpty(TxtUtilidad.Text.Trim()) &&
                !string.IsNullOrEmpty(TxtSubTotal.Text.Trim()) &&
                !string.IsNullOrEmpty(TxtIVA.Text.Trim()) &&
                !string.IsNullOrEmpty(TxtPrecioUnitario.Text.Trim()) &&
                !string.IsNullOrEmpty(TxtStock.Text.Trim()) &&

                CboxUsuarioTipoRol.SelectedIndex > -1)
            {
                R = true;
            }
            else
            {
                if (string.IsNullOrEmpty(TxtNombreProducto.Text.Trim()))
                {
                    MessageBox.Show("Debe digitar el nombre del producto", "Error de validación", MessageBoxButtons.OK);
                    return false;
                }

                if (string.IsNullOrEmpty(TxtCodigoBarras.Text.Trim()))
                {
                    MessageBox.Show("Debe digitar el código de barras", "Error de validación", MessageBoxButtons.OK);
                    return false;
                }
                if (string.IsNullOrEmpty(TxtCosto.Text.Trim()))
                {
                    MessageBox.Show("Debe digitar el costo", "Error de validación", MessageBoxButtons.OK);
                    return false;
                }
                if (string.IsNullOrEmpty(TxtUtilidad.Text.Trim()))
                {
                    MessageBox.Show("Debe digitar la utilidad", "Error de validación", MessageBoxButtons.OK);
                    return false;
                }

                if (string.IsNullOrEmpty(TxtSubTotal.Text.Trim()))
                {
                    MessageBox.Show("Debe digitar el Sub.Total", "Error de validación", MessageBoxButtons.OK);
                    return false;
                }
                if (string.IsNullOrEmpty(TxtIVA.Text.Trim()))
                {
                    MessageBox.Show("Debe digitar la Tasa Impuesto", "Error de validación", MessageBoxButtons.OK);
                    return false;
                }
                if (string.IsNullOrEmpty(TxtPrecioUnitario.Text.Trim()))
                {
                    MessageBox.Show("Debe digitar el precio unitario", "Error de validación", MessageBoxButtons.OK);
                    return false;
                }
                if (string.IsNullOrEmpty(TxtStock.Text.Trim()))
                {
                    MessageBox.Show("Debe digitar la cantidad de stock", "Error de validación", MessageBoxButtons.OK);
                    return false;
                }

            }

            return R;
        }


        private void CargarListaProductos(bool VerActivos, string FiltroBusqueda = "")
        {
            Logica.Models.Producto miproducto = new Logica.Models.Producto();

            DataTable lista = new DataTable();

            if (VerActivos)
            {
                //si se quieren ver los usuarios activos
                lista = miproducto.ListarActivos(FiltroBusqueda);
                DgListaUsuario.DataSource = lista;
            }
            else
            {
                //Usuarios inactivos
                lista = miproducto.ListarInactivos(FiltroBusqueda);
                DgListaUsuario.DataSource = lista;
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {

            if (ValidarDatosRequeridos())
            {
                MiProductoLocal.NombreProducto = TxtNombreProducto.Text.Trim();
                MiProductoLocal.CodigoBarras = TxtCodigoBarras.Text.Trim();
                MiProductoLocal.Costo = Convert.ToDecimal(TxtCosto.Text.Trim());
                MiProductoLocal.Utilidad = Convert.ToDecimal(TxtUtilidad.Text.Trim());
                MiProductoLocal.SubTotal = Convert.ToDecimal(TxtSubTotal.Text.Trim());
                MiProductoLocal.TasaImpuesto = Convert.ToDecimal(TxtIVA.Text.Trim());
                MiProductoLocal.PrecioUnitario = Convert.ToDecimal(TxtPrecioUnitario.Text.Trim());
                MiProductoLocal.CantidadStock = Convert.ToDecimal(TxtStock.Text.Trim());


                //CON EL COMBO DE ROL HAY QUE EXTRAER EL VALUEMEMBER SELECCIONADO.

                MiProductoLocal.MiCategoria.ProductoCategoriaID = Convert.ToInt32(CboxUsuarioTipoRol.SelectedValue);


                bool CodigoBarrasOk = MiProductoLocal.ConsultarPorCodigoBarras(MiProductoLocal.CodigoBarras);


                if (CodigoBarrasOk == false && CodigoBarrasOk == false)
                {


                    string Pregunta = string.Format("Está seguro de agregar al Producto {0}??", MiProductoLocal.NombreProducto);
                    DialogResult respuesta = MessageBox.Show(Pregunta, "???", MessageBoxButtons.YesNo);

                    if (respuesta == DialogResult.Yes)
                    {

                        //Procedemos a Agregar el usuario

                        bool ok = MiProductoLocal.Agregar();

                        if (ok)
                        {
                            MessageBox.Show("Producto ingresado correctamente!", ":)", MessageBoxButtons.OK);

                            LimpiarForms();
                            CargarListaProductos(CbProductoActivo.Checked);
                        }
                        else
                        {
                            MessageBox.Show("Producto no se logró agregar!", ":(", MessageBoxButtons.OK);
                        }
                    }
                }


            }


        }
        private void LimpiarForms()
        {
            TxtCodigoBarras.Clear();
            TxtNombreProducto.Clear();
            TxtCosto.Clear();
            TxtUtilidad.Clear();
            TxtSubTotal.Clear();
            TxtIVA.Clear();
            TxtPrecioUnitario.Clear();
            TxtStock.Clear();

            CboxUsuarioTipoRol.SelectedIndex = -1;
            CbProductoActivo.Checked = false;
        }

        private void BtnLimpar_Click(object sender, EventArgs e)
        {
            LimpiarForms();
            ActivarBotonAgregar();
        }

        private void ActivarBotonAgregar()
        {
            BtnAgregar.Enabled = true;
            BtnCerrar.Enabled = false;
            BtnEliminar.Enabled = false;
        }

        private void ActivarBotonesModificarYEliminar()
        {
           
        }

        private void DgListaUsuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {

        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
        }

        private void TxtUsuarioCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Tools.Validaciones.CaracteresNumeros(e);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void CbUsuarioActivo_CheckedChanged(object sender, EventArgs e)
        {
            CargarListaProductos(CbProductoActivo.Checked);

            if (CbProductoActivo.Checked)

            {
                BtnEliminar.Text = "ELIMINAR";

            }
            else
            {
                BtnEliminar.Text = "ACTIVAR";
            }

        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
