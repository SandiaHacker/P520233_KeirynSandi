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

            CargarListaUsuarios(CbVerActivos.Checked);

            ActivarBotonAgregar();

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

        private void CargarListaUsuarios(bool VerActivos, string FiltroBusqueda = "") 
        {
            Logica.Models.Usuario miusuario = new Logica.Models.Usuario();

            DataTable lista = new DataTable();

            if (CbVerActivos.Checked)
            {
                //SI SE QUIEREN VER LOS USUARIOS ACTIVOS
                lista = miusuario.ListarActivos(FiltroBusqueda);

                DgListaUsuario.DataSource = lista;

            }
            else
            {
                //USUSARIOS INACTIVOS
                lista = miusuario.ListarInactivos(FiltroBusqueda);
                DgListaUsuario.DataSource = lista;


            }


           
        }

        private bool ValidarDatosRequeridos(bool OmitirContrasennia = false)
        {

            bool R = false;


            //VALIDAR QUE SE HAYAN DIGITADO VALORES EN LOS CAMPOS OBLIGATORIOS
            if (!string.IsNullOrEmpty(TxtUsuarioCedula.Text.Trim()) &&
                !string.IsNullOrEmpty(TxtUsuarioNombre.Text.Trim()) &&
                !string.IsNullOrEmpty(TxtUsuarioCorreo.Text.Trim()) &&

                CboxUsuarioTipoRol.SelectedIndex > -1
                )
            {

                if (OmitirContrasennia)
                {

                    //SI SE OMITE LA CONTRASEÑA ENTONCES SE PASA A TRUE

                    R = true;
                }
                else
                {
                    //SI NO SE OMITE LA CONTRASEÑA DEBEMOS VALIDAR TAMBIEN ESE CAMPO

                    if (!string.IsNullOrEmpty(TxtUsuarioContrasenia.Text.Trim()))
                    {
                        R = true;
                    }
                    else
                    {
                        //CONTRASEÑA
                        if (string.IsNullOrEmpty(TxtUsuarioContrasenia.Text.Trim()))
                        {
                            MessageBox.Show("Debe Digitar la Contraseña", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                }

                R = true;
            }
            else
            {
                //INDICAR AL USUARIO QUE VALIDACION ESTA FALTANDO

                //CÉDULA
                if (string.IsNullOrEmpty(TxtUsuarioCedula.Text.Trim()))
                {
                    MessageBox.Show("Debe Digitar la Cédula", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            CargarListaUsuarios(CbVerActivos.Checked);

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

        private void DgListaUsuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DgListaUsuario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LimpiarForm();

            //ColUsuarioID

            //COMO NECESITO COLSULTAR POR EL ID EL USUARIO, SE DEBE EXTRAER EL VALOR DE LA COLUMNA
            //CORRESPONDIENTE DEL dgv, en este caso "ColUsuarioID"

            DataGridViewRow MiDgvFila = DgListaUsuario.SelectedRows[0];
            int IDUsuario = Convert.ToInt32(MiDgvFila.Cells["ColUsuarioID"].Value);

            MiUsuarioLocal = new Logica.Models.Usuario();
            MiUsuarioLocal = MiUsuarioLocal.ConsultarPorID(IDUsuario);

            if (MiUsuarioLocal != null && MiUsuarioLocal.UsuarioID > 0)
            {
                //UNA VEZ QUE SEA HA ASEGURADO QUE EXISTE EL USUSARIO Y QUE TIENE DATOS SE "DIBUJAN" ESOS
                //DATOS EN LOS CONTROLES CORRESPONDIENTES DEL FORMULARIO

                TxtUsuarioCodigo.Text = MiUsuarioLocal.UsuarioID.ToString();
                TxtUsuarioCedula.Text = MiUsuarioLocal.Cedula;
                TxtUsuarioNombre.Text = MiUsuarioLocal.Nombre;
                TxtUsuarioCorreo.Text = MiUsuarioLocal.Correo;
                TxtUsuarioTelefono.Text = MiUsuarioLocal.Telefono;
                TxtUsuarioDireccion.Text = MiUsuarioLocal?.Direccion;

                //EN ESTE CASO NO QUIERO QUE SE MUESTRE LA CONTRASEÑA YA QUE ESTA ENCRIPTADA Y NO SE
                //REQUIERE ACTUALIZARLA Y SE DEJA EN BLANCO EL AMPO EN TXT

                CboxUsuarioTipoRol.SelectedValue = MiUsuarioLocal.MiUsuarioRol.UsuarioRolID;
                CbUsuarioActivo.Checked = MiUsuarioLocal.Activo;

                ActivarBotonesModificarYEliminar();

            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarForm();
            ActivarBotonAgregar();
        }

        private void ActivarBotonAgregar()
        {
            BtnAgregar.Enabled = true;
            BtnModificarUsuario.Enabled = false;
            BtnEliminar.Enabled = false;
        }

        private void ActivarBotonesModificarYEliminar()
        {
            BtnAgregar.Enabled = false;
            BtnModificarUsuario.Enabled = true;
            BtnEliminar.Enabled = true;
        }

        private void DgListaUsuario_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //ESTO LIMPIA LA SELECCION DE LA FILA AUTOMATICA QUE ES EL COMPORTAMIENTO ESTANDAR DEL CONTROL

            DgListaUsuario.ClearSelection();
        }

        private void BtnModificarUsuario_Click(object sender, EventArgs e)
        {
            //AL IGUAL QUE CON EL AGREGAR, SE DEBEN VALIDAR LOS DATOS REQUERIDOS PERO,
            //EL CAMPO DE LA CONTRASEÑA DEBE SER OPCIONAL EN ESTE CASO

            if (ValidarDatosRequeridos(true))
            {
                //TRANSFERIMOS AL OBJETO LOCAL LOS POSIBLES CAMBIOS QUE SE HAYAN HECHO EN LOS DATOS DEL USUARIO

                MiUsuarioLocal.Nombre = TxtUsuarioNombre.Text.Trim();
                MiUsuarioLocal.Cedula = TxtUsuarioCedula.Text.Trim();
                MiUsuarioLocal.Correo = TxtUsuarioCorreo.Text.Trim();
                MiUsuarioLocal.Telefono = TxtUsuarioTelefono.Text.Trim();
                MiUsuarioLocal.MiUsuarioRol.UsuarioRolID = Convert.ToInt32(CboxUsuarioTipoRol.SelectedValue);
                MiUsuarioLocal.Direccion = TxtUsuarioDireccion.Text.Trim();

                //DEPENDE DE SI SE DIGITO O NO UNA CONTRASEÑA, HABRAN DOS DISTINTOS UPDATE EN LOS SPs

                MiUsuarioLocal.Contrasennia = TxtUsuarioContrasenia.Text.Trim();

                //EN EL DIAGRAMA EXPANDIDO DE CASOS DE USO PA EL TEMA USUSARIOS SE INDICA
                // QUE PARA MODIFICAR O ELIMINAR PRIMERO SE DEBE CONSULTAR POR EL ID

                if (MiUsuarioLocal.ConsultarPorID())
                {

                    DialogResult Resp = MessageBox.Show("¿DESEA MODIFICAR EL USUSARIO?", "???", MessageBoxButtons.YesNo);

                    if (Resp == DialogResult.Yes)
                    {
                        if (MiUsuarioLocal.Actualizar())
                        {
                            MessageBox.Show("USUARIO MODIFICADO CORRECTAMENTE!", "*:)", MessageBoxButtons.OK);

                            LimpiarForm();
                            CargarListaUsuarios(CbVerActivos.Checked);
                            ActivarBotonAgregar();
                        }
                    }

                    //PROCEDEMOS A MODIFICAR EL REGISTRO DEL USUARIO




                }



            }



        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (CbVerActivos.Checked)
            {
                //SE PROCEDE A ELIMINAR
                if (MiUsuarioLocal.UsuarioID > 0)
                {
                    string msg = string.Format("¿Estás seguro de eliminar el usuario{0}.?", MiUsuarioLocal.Nombre);

                    DialogResult respuesta = MessageBox.Show(msg, "Confirmación requerida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (respuesta == DialogResult.Yes && MiUsuarioLocal.Eliminar())
                    {
                        MessageBox.Show("El Usuarios ha sido ELIMINADO", "!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LimpiarForm();
                        CargarListaUsuarios(CbVerActivos.Checked);
                        ActivarBotonAgregar();

                    }

                }

            }
            else
            {
                //SE PROCEDE A ACTIVAR

                if (MiUsuarioLocal.UsuarioID > 0)
                {
                    string msg = string.Format("¿Estás seguro de activar el usuario{0}.?", MiUsuarioLocal.Nombre);

                    DialogResult respuesta = MessageBox.Show(msg, "Confirmación requerida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (respuesta == DialogResult.Yes && MiUsuarioLocal.Activar())
                    {
                        MessageBox.Show("El Usuarios ha sido ACTIVADO", "!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LimpiarForm();
                        CargarListaUsuarios(CbVerActivos.Checked);
                        ActivarBotonAgregar();

                    }


                }
            }

        }

        private void TxtUsuarioCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Tools.Validaciones.CaracteresNumeros(e);
        }

        private void TxtUsuarioNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Tools.Validaciones.CaracteresTexto(e);
        }

        private void TxtUsuarioCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Tools.Validaciones.CaracteresTexto(e, false, true);
        }

        private void TxtUsuarioTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Tools.Validaciones.CaracteresNumeros(e);
        }

        private void TxtUsuarioContrasenia_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Tools.Validaciones.CaracteresTexto(e);
        }

        private void TxtUsuarioDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Tools.Validaciones.CaracteresTexto(e);
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CbVerActivos_CheckedChanged(object sender, EventArgs e)
        {
            CargarListaUsuarios(CbVerActivos.Checked);

            if (CbVerActivos.Checked)
            {
                BtnEliminar.Text = "ELIMINAR";
            }
            else
            {
                BtnEliminar.Text = "ACTIVAR";
            }


        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(TxtBuscar.Text.Trim()) && TxtBuscar.Text.Count() >= 3)
            {
                CargarListaUsuarios(CbVerActivos.Checked, TxtBuscar.Text.Trim());
            }
            else
            {
                CargarListaUsuarios(CbVerActivos.Checked);
            }
        }
    }
}
