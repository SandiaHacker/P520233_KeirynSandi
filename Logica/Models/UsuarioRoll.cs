﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class UsuarioRol
    {
        //1-Propiedades de la clase

        public int UsuarioRolID { get; set; }
        public string Rol { get; set; }

        //2-Digitan las funciones

        public DataTable Listar()
        {
            DataTable R = new DataTable();

            Conexion MiCnn = new Conexion();

            R = MiCnn.EjecutarSELECT("SPUsuariosRolListar");

            return R;
        }
    }
}