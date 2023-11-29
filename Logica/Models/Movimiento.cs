using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace Logica.Models
{
    public class Movimiento
    {
        public Movimiento() 
        {
          MiTipo = new  MovimientoTipo();
          MiUsuario = new Usuario();

          Detalles = new List<MovimientoDetalle>();  
        }

        public int MovimientoID { get; set; }
        public DateTime Fecha { get; set; }
        public int NumeroMovimiento { get; set; }
        public string Anotaciones { get; set; }

        public bool Agregar()
        {
            bool R = false;

            //PRIMERO HACEMOS UN INSERT EN EL ENCABEZADO Y RECOLECTAMOS EL ID QUE SE GENERA
            //ESTO ES INDISPENSABLE YA QUE SE NECESITA COMO FK EN LA TABLA DE DETALLE.

            Conexion MyCnn = new Conexion();

            MyCnn.ListaDeParametros.Add(new SqlParameter("@Fecha", this.Fecha));
            MyCnn.ListaDeParametros.Add(new SqlParameter("@Anotaciones", this.Anotaciones));
            MyCnn.ListaDeParametros.Add(new SqlParameter("@TipoMovimiento", this.MiTipo.MovimientoTipoID));
            MyCnn.ListaDeParametros.Add(new SqlParameter("@UsuarioID ", this.MiUsuario.UsuarioID));

            Object RetornoSPAgregar = MyCnn.EjecutarSELECTEscalar("SPMovimientosAgregarEncabezados");

            int IDMovimientoRecienCreado;

            if (RetornoSPAgregar != null)
            {
                //ESPECIALIZADO
                IDMovimientoRecienCreado = Convert.ToInt32(RetornoSPAgregar.ToString());

                foreach (MovimientoDetalle item in this.Detalles)
                {
                    //POR CADA ITERACION EN LA LISTA DE DETALLES HACEMOS UN INSERT EN LA 
                    //TABLA DE DETALLES

                    Conexion MyCnnDetalle = new Conexion();

                    MyCnnDetalle.ListaDeParametros.Add(new SqlParameter("@IDMovimiento", IDMovimientoRecienCreado));
                    MyCnnDetalle.ListaDeParametros.Add(new SqlParameter("@IDProducto", item.MiProducto.ProductoID));
                    MyCnnDetalle.ListaDeParametros.Add(new SqlParameter("@Cantidad ", item.CantidadMovimiento));
                    MyCnnDetalle.ListaDeParametros.Add(new SqlParameter("@Costo", item.Costo));
                    MyCnnDetalle.ListaDeParametros.Add(new SqlParameter("@SubTotal", item.SubTotal));
                    MyCnnDetalle.ListaDeParametros.Add(new SqlParameter("@TotalIVA", item.TotalIVA));
                    MyCnnDetalle.ListaDeParametros.Add(new SqlParameter("@PrecioUnitario",item.PrecioUnitario));

                    MyCnnDetalle.EjecutarDML("SPMovimientosAgregarDetalle");


                }
                R = true;
            }

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

        public DataTable Listar()
        {
            DataTable R = new DataTable();

            return R;
        }

        //COMPOSICIONES 

        public MovimientoTipo MiTipo { get; set; }
        public Usuario MiUsuario { get; set; }

        //En el caso del detalle, si analizamos el  diagrama de clases 
        //Vemos que al llegar a la clase de detalles termina en "muchos"
        //1..* Eso significa que el atributo tiene multiplicidad 
        //o sea que se puede repetir N veces 

       public List<MovimientoDetalle> Detalles { get; set; }

        public DataTable AsignarEsquemaDelDetalle()
        {
            DataTable R = new DataTable();

            Conexion MyCnn = new Conexion();

            //QUEREMOS CARGAR EL ESQUEMA DEL DATATBLE, NO LOS DATOS
            R = MyCnn.EjecutarSELECT("SPMovimientoCargarDetalle", true);


            //PARA EVITAR EL IDENTIFY (1,1) QUE ESTÁ ORIGINALMENTE EN LA TABLA
            //ME GENERA NUMEROS UNICOS QUE IMPIDAN REPETIR REGISTROS
            R.PrimaryKey = null;


            return R;
        }




































    }
}
