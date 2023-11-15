using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Logica.Tools;

namespace Logica.Models
{
    public class Usuario
    {

        //ctor automatico
        public Usuario()
        {
            MiUsuarioRol = new UsuarioRol();

        }

        public int UsuarioID { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Contrasennia { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public bool Activo { get; set; }
        public UsuarioRol MiUsuarioRol { get; set; }


        //Funciones, metodos

        public bool Agregar()
        {
            bool R = false;

            Conexion MiCnn = new Conexion();

            //AHORA AGREGAMOS TODOS LOS PARAMETROS QUE SOLICITA EL SP DE AGREGARA

            MiCnn.ListaDeParametros.Add(new SqlParameter("@Cedula", this.Cedula));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Nombre", this.Nombre));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Correo", this.Correo));
            //TODO ENCRIPTAR
            Tools.Crypto MiEncriptador = new Tools.Crypto();
            string ContrasenniaEncriptada = MiEncriptador.EncriptarEnUnSentido(this.Contrasennia);
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Contrasennia", ContrasenniaEncriptada));

            MiCnn.ListaDeParametros.Add(new SqlParameter("@Telefono", this.Telefono));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Direccion", this.Direccion));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@UsuarioRollID", this.MiUsuarioRol.UsuarioRolID));

            int resultado = MiCnn.EjecutarDML("SPUsuariosAgregar");

            if (resultado > 0) R = true;


            return R;
        }
        public bool Actualizar()
        {
            bool R = false;

            Conexion MiCnn = new Conexion();

            //AHORA AGREGAMOS TODOS LOS PARAMETROS QUE SOLICITA EL SP DE AGREGARA

            MiCnn.ListaDeParametros.Add(new SqlParameter("@Cedula", this.Cedula));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Nombre", this.Nombre));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Correo", this.Correo));

            Tools.Crypto MiEncriptador = new Tools.Crypto();
            string ContrasenniaEncriptada = MiEncriptador.EncriptarEnUnSentido(this.Contrasennia);
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Contrasennia", ContrasenniaEncriptada));
     
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Telefono", this.Telefono));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Direccion", this.Direccion));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@UsuarioRollID", this.MiUsuarioRol.UsuarioRolID));

            MiCnn.ListaDeParametros.Add(new SqlParameter("@ID", this.UsuarioID));

            int resultado = MiCnn.EjecutarDML("SPUsuariosActualizar");

            if (resultado > 0) R = true;


            return R;
        }
        public bool Eliminar()
        {
            bool R = false;

            Conexion MyCnn = new Conexion();

            MyCnn.ListaDeParametros.Add(new SqlParameter("@ID", this.UsuarioID));

            int resultado = MyCnn.EjecutarDML("SPUsuariosEliminar");

            if (resultado > 0) R = true;


            return R;
        }

        public bool Activar()
        {
            bool R = false;

            Conexion MyCnn = new Conexion();

            MyCnn.ListaDeParametros.Add(new SqlParameter("@ID", this.UsuarioID));

            int resultado = MyCnn.EjecutarDML("SPUsuariosActivar");

            if (resultado > 0) R = true;


            return R;
        }


        public bool ConsultarPorID()
        {
            bool R = false;

            Conexion MyCnn = new Conexion();

            MyCnn.ListaDeParametros.Add(new SqlParameter("@ID",this.UsuarioID));

            DataTable DatosUsuario = new DataTable();

            DatosUsuario = MyCnn.EjecutarSELECT("SPUsuariosConsultarPorID");

            if (DatosUsuario != null && DatosUsuario.Rows.Count > 0)
            {
                //EL USUSARIO EXISTE

                R = true;
            }


            return R;
        }

        public Usuario ConsultarPorID(int IdUsuario)
        {
            Usuario R = new Usuario();

            //ESTA FUNCION RETORNA UN OBJETO DE TIPO USUARIO CON DATOS EN LOS ATRIBUTOS.
            //ES UNA VARIEDAD DE ConsultarPorID QUE ME PEREMITE MANIPULAR EL OBJETO Y NO
            //SOLO SABER SI EL USUARIO EXISTE O NO A TRAVES DE UN BOOL

            Conexion MyCnn = new Conexion();

            MyCnn.ListaDeParametros.Add(new SqlParameter("@ID", IdUsuario));

            DataTable DatosUsuario = new DataTable();

            DatosUsuario = MyCnn.EjecutarSELECT("SPUsuariosConsultarPorID");

            if (DatosUsuario != null && DatosUsuario.Rows.Count > 0)
            {
                //COMO TENEMOS QUE LLENAR UN OBJETO COMPUESTOS (POR EL ROL DE USUARIO)
                //DEBEMOS ECTRAER LOS DATOS DE LA CONSULTA Y LLENAR LOS ATRIBUTOS
                //CORRESPONDIENTES DEL OBJETO DE TIPO "Usuario R"


                //ACÁ CAPTURAMOS LOS DATOS DE LA FILA 0 DEL RESULTADO
                DataRow MiFila = DatosUsuario.Rows[0];

                R.UsuarioID = Convert.ToInt32(MiFila["UsuarioID"]);
                R.Nombre = Convert.ToString(MiFila["Nombre"]);
                R.Cedula = Convert.ToString(MiFila["Cedula"]);
                R.Correo = Convert.ToString(MiFila["Correo"]);
                R.Telefono = Convert.ToString(MiFila["Telefono"]);
                R.Contrasennia = Convert.ToString(MiFila["Contrasennia"]);
                R.Direccion = Convert.ToString(MiFila["Direccion"]);
                R.MiUsuarioRol.UsuarioRolID = Convert.ToInt32(MiFila["UsuarioRolID"]);
                R.MiUsuarioRol.Rol = Convert.ToString(MiFila["Rol"]);
                R.Activo = Convert.ToBoolean(MiFila["Activo"]);

            }

            return R;
        }

        public bool ConsultarPorCedula(string pCedula)
        {
            bool R = false;

            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("@Cedula",pCedula));

            DataTable dt = new DataTable();

            dt = MiCnn.EjecutarSELECT("SPUsuariosConsultarPorCedula");

            if (dt != null && dt.Rows.Count > 0) R = true;

            return R;
        }
        public bool ConsultarPorCorreo(string pCorreo)
        {
            bool R = false; 

            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("@Correo", pCorreo));

            DataTable dt = new DataTable();

            dt = MiCnn.EjecutarSELECT("SPUsuariosConsultarPorCorreo");

            if (dt != null && dt.Rows.Count > 0) R = true;

            return R;
        }
        public DataTable ListarActivos(string pFiltro = "")
        {
            DataTable R = new DataTable();

            //HAY QUE HACER INSTANCIA DE LA CLASE CONEXION

                Conexion MiCnn = new Conexion();
            //COMO EL SP PARA LISTAR QUIERE UN PARAMETRO, HAY QUE AGREGARLO A LA LISTA
            MiCnn.ListaDeParametros.Add(new SqlParameter("@VerActivos", true));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Filtro", pFiltro));

            R = MiCnn.EjecutarSELECT("SPUsuariosListar");

            return R;
        }
        public DataTable ListarInactivos(string pFiltro = "")
        {
            DataTable R = new DataTable();
            //HAY QUE HACER INSTANCIA DE LA CLASE CONEXION

            Conexion MiCnn = new Conexion();
            //COMO EL SP PARA LISTAR QUIERE UN PARAMETRO, HAY QUE AGREGARLO A LA LISTA
            MiCnn.ListaDeParametros.Add(new SqlParameter("@VerActivos", false));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Filtro", pFiltro));

            R = MiCnn.EjecutarSELECT("SPUsuariosListar");
             
            return R;
            
        }

        public int ValidarIngreso(string pUsuario, string pContrasennia)
        {
            int R = 0;

            Conexion MyCnn = new Conexion();

            Crypto MyEncriptador = new Crypto();

            string PasswordEncriptado = MyEncriptador.EncriptarEnUnSentido(pContrasennia);

            MyCnn.ListaDeParametros.Add(new SqlParameter("@Usuario", pUsuario));
            MyCnn.ListaDeParametros.Add(new SqlParameter("@Contrasennia", PasswordEncriptado));

            DataTable resultado = MyCnn.EjecutarSELECT("SPUsuariosValidarIngreso");

            if (resultado != null && resultado.Rows.Count > 0)
            {
                DataRow MiFila = resultado.Rows[0];

                R = Convert.ToInt32(MiFila["UsuarioID"]);

            }

            return R;
        }



      }
    }
