using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P520233_KeirynSandi.Globales
{
    public static class ObjetosGlobales
    {
        //DEFINIR UN OBJETO GLOBAL PARA EL FORM PRINCIPAL

        public static Form MiFormularioPrincipal = new Formularios.FrmPrincipal();

        public static Formularios.FrmUsuariosGestion MiFormularioDeGestionDeUsuarios = new Formularios.FrmUsuariosGestion();

        //ESTE SERA EL USUARIO VALIDADO EN EL LOGIN, TENDRA UN SCORE GLOBAL 
        //EN TODA LA APP

        public static Logica.Models.Usuario MiUsuarioGlobal = new Logica.Models.Usuario();

        //FORMULARIO DE MOVIMIENTOS DE PRODUCTOS
        public static Formularios.FrmMovimientosInventario
            MiFormularioMovimientos = new Formularios.FrmMovimientosInventario();

        public static Formularios.FrmGestionProductos MiFormularioDeGestionDeProductos = new Formularios.FrmGestionProductos();


    }
}
