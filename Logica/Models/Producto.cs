using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace Logica.Models
{
    public class Producto
    {

        public int ProductoID { get; set; }
        public string CodigoBarras { get; set; }
        public string NombreProducto { get; set; }  
        public decimal Costo { get; set; }
        public decimal Utilidad { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TasaImpuesto { get; set; }
        public decimal PrecioUnitrio { get; set; }
        public decimal CantidadStock { get; set; }
        public bool Activo { get; set; }

        ProductoCategoria MiCategoria { get; set; }

        public Producto() 
        { 
          MiCategoria = new ProductoCategoria();
        }

        //FUNCIONES
        public bool Agregar()
        {
            bool R = false;

            return R;
        }
        public bool Actualizar()
        {
            bool R = false;

            return R;
        }
        public bool Eliminar()
        {
            bool R = false;

            return R;
        }
        public bool ConsultarPorID()
        {
            bool R = false;

            return R;
        }

        public bool ConsultarPorCodigoDeBarras(string CodigoBarras)
        {
            bool R = false;

            return R;
        }

        public DataTable Listar(bool VerActivos = true )
        {
            DataTable R = new DataTable();

            return R;
        }

        public DataTable ListarEnMovimientoDetalleProducto(bool VerActivos = true, string Filtro = "")
        {
            DataTable R = new DataTable();

            Conexion MyCnnn = new Conexion();

            MyCnnn.ListaDeParametros.Add(new SqlParameter("@VerActivos", VerActivos));
            MyCnnn.ListaDeParametros.Add(new SqlParameter("@Filtro", Filtro));

            R = MyCnnn.EjecutarSELECT("SPProductosListar");

            return R;
        }







    }
}
