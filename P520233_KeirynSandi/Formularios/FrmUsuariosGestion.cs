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
    public partial class FrmUsuariosGestion : Form
    {
        //OBJETO LOCAL DE TIPO USUARIO

        private Logica.Models.Usuario MiUsuarioLocal { get; set; }
        public FrmUsuariosGestion()
        {
            InitializeComponent();

            MiUsuarioLocal = new Logica.Models.Usuario();
        }

        private void FrmUsuariosGestion_Load(object sender, EventArgs e)
        {

            MdiParent = Globales.ObjetosGlobales.MiFormularioPrincipal;

            CargarComboRolesDeUsuario();

            CargarListaUsuarios();

        }

        private void CargarComboRolesDeUsuario()
        {
            Logica.Models.UsuarioRol MiRol = new Logica.Models.UsuarioRol();

            DataTable dt = new DataTable();

            dt = MiRol.Listar();

            if (dt != null && dt.Rows.Count > 0)
            {
                //UNA VEZ ASEGURADO QUE EL DT TIENE VALORES, LOS "DIBUJO" EN EL COMBOBOX

                CboxUsuarioTipoRol.ValueMember = "id";
                CboxUsuarioTipoRol.DisplayMember = "Descripcion";

                CboxUsuarioTipoRol.DataSource = dt;
                CboxUsuarioTipoRol.SelectedIndex = -1;

            }
        }


        //TODAS LAS FUNCIONALIDADES ESPECIFICAS Y QUE SE PUEDAN REUTILLIZAR DEBEN 
        //SER ENCAPSULADAS

        private void CargarListaUsuarios()
        {
            Logica.Models.Usuario miusuario = new Logica.Models.Usuario();

            DataTable lista = new DataTable();

            lista = miusuario.ListarActivos();

            DgListaUsuario.DataSource = lista;
        }

        private bool ValidarDatosRequeridos()
        {

            bool R = false;


            //VALIDAR QUE SE HAYAN DIGITADO VALORES EN LOS CAMPOS OBLIGATORIOS
            if (!string.IsNullOrEmpty(TxtUsuarioCedula.Text.Trim()) &&
                !string.IsNullOrEmpty(TxtUsuarioNombre.Text.Trim()) &&
                !string.IsNullOrEmpty(TxtUsuarioCorreo.Text.Trim()) &&
                !string.IsNullOrEmpty(TxtUsuarioContrasenia.Text.Trim()) &&
                CboxUsuarioTipoRol.SelectedIndex > -1
                )
            {
                R = true;
            }
            else
            {
                //INDICAR AL USUARIO QUE VALIDACION ESTA FALTANDO

                //CÉDULA
                if (string.IsNullOrEmpty(TxtUsuarioCedula.Text.Trim()))
                {
                    MessageBox.Show("Debe Digitar la Cédula" , "Error de validación" , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                //NOMBRE
                if (string.IsNullOrEmpty(TxtUsuarioNombre.Text.Trim()))
                {
                    MessageBox.Show("Debe Digitar el Nombre", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                //CORREO
                if (string.IsNullOrEmpty(TxtUsuarioCorreo.Text.Trim()))
                {
                    MessageBox.Show("Debe Digitar el Correo", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                //CONTRASEÑA
                if (string.IsNullOrEmpty(TxtUsuarioContrasenia.Text.Trim()))
                {
                    MessageBox.Show("Debe Digitar la Contraseña", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                //ROL DE USUARIO
                if (CboxUsuarioTipoRol.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe Seleccionar un Rol de Usuario", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            }


            return R;

        }


        private void BtnAgregar_Click(object sender, EventArgs e)

        {

            //LO PRIMERO QUE DEBEMOS HACER ES VALIDAR LOS DATOS MÍNIMOS REQUERIDOS
            //ESTO SE HACE PARA EVITAR QUE QUEDEN REGISTOS SIN DATOS S NUEVL DE BASE DE DATOS
            //PERO TAMBIÉN PORQUE SE UN CAMPO DE BASE DE DATOS NO ACEPTA VALORES NULL
            // Y SE LLAMA AL INSERT, DARA UN ERROR.


            //LUEGO DE ESTO Y TOMMANDO EN CUENTA EL DIAGRAMA DE CASOS DE USO EXPANDIDO 
            //DE USUARIO, HAY QUE HACER VALIDAR QUE NO EXISTA UN USUARIO DE LA CEDULA Y/O
            //CORREO QUE SE DIGITATON. (NO SE PUEDEN REPETIR ESTOS DATOS EN DISINTAS
            //FILAS EN LA TABLA USUARIOS).

            //SI  AMBAS VALIDACIONES SON NEGATIVAS ENTONCES SE PROCEDE A AGREGAR() EL USUARIO.


            //...............................................................................//


            //USAREMOS UN OBJETO LOCAL DE TIPO USUARIO, QUE SEÁ AL QUE DAREMOS FORMA PARA LUEGO
            //USAR LAS FUNCIONES COMO AGREGAR, ACTUALIZAR, ELIMINAR, ETC.

            if (ValidarDatosRequeridos())
             {
                MiUsuarioLocal = new Logica.Models.Usuario();

                MiUsuarioLocal.Cedula = TxtUsuarioCedula.Text.Trim(); //Trim elimina los espacios en blanco

                MiUsuarioLocal.Nombre = TxtUsuarioNombre.Text.Trim();

                MiUsuarioLocal.Correo = TxtUsuarioCorreo.Text.Trim();

                MiUsuarioLocal.Telefono = TxtUsuarioTelefono.Text.Trim();

                //CON EL COMBO DE ROL HAY QUE EXTRAER EL VALUEMEMBER SELECCIONADO.

                MiUsuarioLocal.MiUsuarioRol.UsuarioRolID = Convert.ToInt32(CboxUsuarioTipoRol.SelectedValue);

                MiUsuarioLocal.Contrasennia = TxtUsuarioContrasenia.Text.Trim();

                MiUsuarioLocal.Direccion = TxtUsuarioDireccion.Text.Trim();

                bool CedulaOk = MiUsuarioLocal.ConsultarPorCedula(MiUsuarioLocal.Cedula);

                bool CorreOk = MiUsuarioLocal.ConsultarPorCorreo(MiUsuarioLocal.Correo);

                if (CedulaOk == false && CorreOk == false)
                {

                    //SE SOLICITA CONFIRMACION POR PARTE DEL USUARIO

                    string Pregunta = string.Format("¿Está seguro de agregar al usuario {0}?", MiUsuarioLocal.Nombre);

                    DialogResult respuesta = MessageBox.Show(Pregunta, "???", MessageBoxButtons.YesNo);

                    if (respuesta == DialogResult.Yes)
                    {
                        //PROCEDEMOS A AGREGAR EL USUARIO

                        bool ok = MiUsuarioLocal.Agregar();

                        if (ok)
                        {
                            MessageBox.Show("Usuario Ingresado Correctamente", ":D", MessageBoxButtons.OK);


                            LimpiarForm();
                            CargarListaUsuarios();

                        }
                        else
                        {
                            MessageBox.Show("El Usuario no se pudo agregar", "D:", MessageBoxButtons.OK);
                        }

                    }

                }
            }
        }

        private void LimpiarForm()
        {
            TxtUsuarioCodigo.Clear();
            TxtUsuarioCedula.Clear();
            TxtUsuarioNombre.Clear();
            TxtUsuarioCorreo.Clear();   
            TxtUsuarioTelefono.Clear();
            TxtUsuarioContrasenia.Clear();
            TxtUsuarioDireccion.Clear();

            CboxUsuarioTipoRol.SelectedIndex = -1;

            CbUsuarioActivo.Checked = false;
        }


















    }
}
