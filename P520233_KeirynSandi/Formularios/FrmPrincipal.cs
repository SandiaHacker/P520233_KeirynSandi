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
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            LblUsuario.Text = Globales.ObjetosGlobales.MiUsuarioGlobal.Nombre + "(" + Globales.ObjetosGlobales.MiUsuarioGlobal.MiUsuarioRol.Rol + ")";

            //AHORA SE DEBE AJUSTAR LOS PERMISOS DE MENÚ PARA QUE SE MUETREN O NO, DEPENDIENDO
            //DEL TIPO DE ROLL

            switch (Globales.ObjetosGlobales.MiUsuarioGlobal.MiUsuarioRol.UsuarioRolID)
            {

                //ADMIN
                case 1:
                    //COMO ADMIN TIENE A TODO, NO ES NECESARIO OCULTAR OPCIONES

                    break;


                //EMPLEADO
                case 2:
                    //OCULTAN LOS MENÚS CORRESPONDIENTES    
                    MnuGestionUsuarios.Enabled = false;
                    MnuGestionProductos.Enabled = false;
                    MnuGestionCategorias.Enabled = false;  
                    break;
                default:
                    break;
            }



        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void movimientosPorTipoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gestiónDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //EN ESTE CASO QUIERO QUE LA VENTANA SE MUESTRE SOLO UNA VEZ 
            // EN LA APP (QUE NO SE ABRA VARIAS VECES). Para esto 
            //HAY QUE REVISAR SI LA VENTANA ESTÁ O NO VISIBLE.

            if (!Globales.ObjetosGlobales.MiFormularioDeGestionDeUsuarios.Visible)
            {
                //HAGO UNA REINSTANCIA DEL OBJETO PARA ASEGURAR QUE INICIAMOS EN LIMPIO
                Globales.ObjetosGlobales.MiFormularioDeGestionDeUsuarios = new FrmUsuariosGestion();

                Globales.ObjetosGlobales.MiFormularioDeGestionDeUsuarios.Show();
            }

        }

        private void FrmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void entradasYSalidasDeInventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Globales.ObjetosGlobales.MiFormularioMovimientos.Visible)
            {
                Globales.ObjetosGlobales.MiFormularioMovimientos = new FrmMovimientosInventario ();
                Globales.ObjetosGlobales.MiFormularioMovimientos.Show();
            }
        }

        private void MnuGestionProductos_Click(object sender, EventArgs e)
        {
            if (!Globales.ObjetosGlobales.MiFormularioDeGestionDeUsuarios.Visible)
            {
                //HAGO UNA REINSTANCIA DEL OBJETO PARA ASEGURAR QUE INICIAMOS EN LIMPIO
                Globales.ObjetosGlobales.MiFormularioDeGestionDeProductos = new FrmGestionProductos();

                Globales.ObjetosGlobales.MiFormularioDeGestionDeProductos.Show();
            }
        }
    }
}
