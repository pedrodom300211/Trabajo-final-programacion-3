using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DaoObservacionGeneral
    {
        private AccesoDatos ds = new AccesoDatos();
        public ObservacionGeneral getObservacionGeneral(ObservacionGeneral observacionGeneral)
        {
            DataTable tabla = ds.ObtenerTabla("ObservacionesGenerales", "SELECT * FROM ObservacionesGenerales inner join Areas on ObservacionesGenerales.CodArea_OG=Areas.CodArea_A inner join Paciente on ObservacionesGenerales.DNIPac_OG = Paciente.DNIPac_Pa WHERE NumObser_OG='" + observacionGeneral.getNumObser_OG() + "'");
            Areas area = new Areas();
            Paciente Pac = new Paciente();
            ///Seteamos paciente
            Pac.setDNIPac_Pa(tabla.Rows[0][6].ToString());
            observacionGeneral.setNumObser_OG(Convert.ToInt32(tabla.Rows[0][0].ToString()));
            observacionGeneral.setDNIPac_OG(Pac);
            observacionGeneral.setDescripcion_OG(tabla.Rows[0][2].ToString());
            ///seteamos obj area
            area.setCodArea_A(tabla.Rows[0][4].ToString());
            area.setDescripcion_A(tabla.Rows[0][5].ToString());
            observacionGeneral.setCodArea_OG(area);
            return observacionGeneral;
        }
        public Boolean existeObservacionGeneral(ObservacionGeneral observacionGeneral) // bsca por DNI paciente foraneo
        {
            String consulta = "SELECT * FROM ObservacionesGenerales WHERE DNIPac_OG='" + observacionGeneral.getDNIPac_OG().getDNIPac_Pa() + "'";
            return ds.existe(consulta);
        }
        public Boolean existeObservacionGeneralPorId(ObservacionGeneral observacionGeneral)
        {
            String consulta = "SELECT * FROM ObservacionesGenerales WHERE NumObser_OG='" + observacionGeneral.getNumObser_OG() + "'";
            return ds.existe(consulta);
        }
        public DataTable getTablaObservacionGeneral()
        {
            DataTable tabla = ds.ObtenerTabla("ObservacionesGenerales", "SELECT * FROM ObservacionesGenerales");
            return tabla;
        }

        public DataTable obtenerObservacionesGeneralesEspecificosConFiltro(String area, String dni)
        {
            String nombreTabla = "ObservacionesGenerales";
            String consultaSQL = "SELECT NumObser_OG, DNIPac_OG, Descripcion_OG, Descripcion_A FROM ObservacionesGenerales " + "INNER JOIN Areas ON CodArea_A = CodArea_OG " + "WHERE Descripcion_A = '" + area + "' AND DNIPac_OG = '" + dni + "'";
            return obtenerTabla(nombreTabla, consultaSQL);
        }
        public DataTable getTablaObservacionGeneralPorDNI2(ObservacionGeneral observacionGeneral)
        {
            DataTable tabla = ds.ObtenerTabla("ObservacionesGenerales", "SELECT NumObser_OG,DNIPac_OG,Descripcion_OG,Descripcion_A FROM ObservacionesGenerales" +
" inner join Areas on ObservacionesGenerales.CodArea_OG = Areas.CodArea_A" +
" WHERE DNIPac_OG ='" + observacionGeneral.getDNIPac_OG().getDNIPac_Pa() + "'");
            return tabla;
        }
        public DataTable getTablaObservacionGeneralPorDNI(ObservacionGeneral observacionGeneral)
        {
            DataTable tabla = ds.ObtenerTabla("ObservacionesGenerales", "SELECT NumObser_OG,DNIPac_OG,Descripcion_OG,Descripcion_A FROM ObservacionesGenerales" +
" inner join Areas on ObservacionesGenerales.CodArea_OG = Areas.CodArea_A" +
" WHERE DNIPac_OG = '" + observacionGeneral.getDNIPac_OG().getDNIPac_Pa() + "'");
            return tabla;
        }

        public int agregarObservacionGeneral(ObservacionGeneral obsGeneral)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosObsGeneralAgregar(ref comando, obsGeneral);
            return ds.EjecutarProcedimientoAlmacenado(comando, "SP_AgregarObservacionGeneral");

        }
        private void ArmarParametrosObsGeneralAgregar(ref SqlCommand Comando, ObservacionGeneral observacionGeneral)
        {
            SqlParameter SqlParametros = new SqlParameter();

            SqlParametros = Comando.Parameters.Add("@DNIPac_OG", SqlDbType.VarChar);
            SqlParametros.Value = observacionGeneral.getDNIPac_OG().getDNIPac_Pa();
            SqlParametros = Comando.Parameters.Add("@Descripcion_OG", SqlDbType.VarChar);
            SqlParametros.Value = observacionGeneral.getDescripcion_OG();
            SqlParametros = Comando.Parameters.Add("@CodArea_OG", SqlDbType.VarChar);
            SqlParametros.Value = observacionGeneral.getCodArea_OG().getCodArea_A();
           
        }

        private void ArmarParametrosObsGeneralModificar(ref SqlCommand Comando, ObservacionGeneral observacionGeneral)
        {
            SqlParameter SqlParametros = new SqlParameter();

            SqlParametros = Comando.Parameters.Add("@NumObser_OG", SqlDbType.Int);
            SqlParametros.Value = observacionGeneral.getNumObser_OG();
            SqlParametros = Comando.Parameters.Add("@DNIPac_OG", SqlDbType.VarChar);
            SqlParametros.Value = observacionGeneral.getDNIPac_OG().getDNIPac_Pa();
            SqlParametros = Comando.Parameters.Add("@Descripcion_OG", SqlDbType.VarChar);
            SqlParametros.Value = observacionGeneral.getDescripcion_OG();
            SqlParametros = Comando.Parameters.Add("@CodArea_OG", SqlDbType.VarChar);
            SqlParametros.Value = observacionGeneral.getCodArea_OG().getCodArea_A();

        }

        public ObservacionGeneral getAreaObservacionGeneralDNI(ObservacionGeneral observacionGeneral)
        {
            Areas Area = new Areas();
            DataTable tabla = ds.ObtenerTabla("ObservacionesGenerales", "SELECT * FROM ObservacionesGenerales WHERE DNIPac_OG='" + observacionGeneral.getDNIPac_OG() + "'");
            Area.setCodArea_A(tabla.Rows[0][3].ToString());
            observacionGeneral.setCodArea_OG(Area);
            return observacionGeneral;
        }

        private DataTable obtenerTabla(String nombre, String consultaSql)
        {
            DataSet ds = new DataSet();
            AccesoDatos datos = new AccesoDatos();
            SqlDataAdapter adp = datos.obtenerAdaptador(consultaSql);
            adp.Fill(ds, nombre);
            return ds.Tables[nombre];
        }

        public DataTable obtenerObservacionesGenerales()
        {
            String nombreTabla = "ObservacionesGenerales";
            String consultaSQL = "SELECT * FROM ObservacionesGenerales";
            return obtenerTabla(nombreTabla, consultaSQL);
        }
        /*
         SELECT NumObser_OG,DNIPac_OG,Descripcion_OG,Descripcion_A FROM ObservacionesGenerales" +
" inner join Areas on ObservacionesGenerales.CodArea_OG = Areas.CodArea_A" +
" WHERE DNIPac_OG =
         
         */
        public DataTable obtenerObservacionesGeneralesConWhere(String Dni)
        {
            String nombreTabla = "ObservacionesGenerales";
            String consultaSQL = "SELECT NumObser_OG,DNIPac_OG,Descripcion_OG,Descripcion_A FROM ObservacionesGenerales" +
" inner join Areas on ObservacionesGenerales.CodArea_OG = Areas.CodArea_A" +
" WHERE DNIPac_OG = '" + Dni+"'";

            return obtenerTabla(nombreTabla, consultaSQL);
        }

        public bool actualizarObservacionesGenerales(ObservacionGeneral observacionGeneral)
        {
            String sp = "SP_ModificarObservacionesGenerales";
            SqlCommand comando = new SqlCommand();
            ArmarParametrosObsGeneralModificar(ref comando, observacionGeneral);
            AccesoDatos ad = new AccesoDatos();
            int filasAfectadas = ad.EjecutarProcedimientoAlmacenado(comando, sp);
            if (filasAfectadas == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
    }
}
