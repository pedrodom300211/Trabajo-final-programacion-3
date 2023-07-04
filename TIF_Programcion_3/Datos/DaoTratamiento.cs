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
    public class DaoTratamiento
    {
        private AccesoDatos ds = new AccesoDatos();
        public Tratamientos getTratamiento(Tratamientos tratamiento)
        {
            DataTable tabla = ds.ObtenerTabla("Tratamiento", "SELECT * FROM Tratamiento inner join Paciente on Tratamiento.DNIPac_Tr=Paciente.DNIPac_Pa WHERE NumTram_Tr= " + tratamiento.getNumTram_Tr());
            ///seteamos obj paciente
            Paciente pac = new Paciente();
            pac.setDNIPac_Pa(tabla.Rows[0][8].ToString());
            tratamiento.setNumTram_Tr(Convert.ToInt32(tabla.Rows[0][0].ToString()));
            tratamiento.setDNIPac_Tr(pac);
            tratamiento.setDroga_Tr(tabla.Rows[0][2].ToString());
            tratamiento.setMarca_Tr(tabla.Rows[0][3].ToString());
            tratamiento.setPsicoterapia_Tr(Convert.ToBoolean(tabla.Rows[0][4].ToString()));
            tratamiento.setRehabilitacion_Tr(Convert.ToBoolean(tabla.Rows[0][5].ToString()));
            tratamiento.setTO_Tr(Convert.ToBoolean(tabla.Rows[0][6].ToString()));
            tratamiento.setOtras_Tr(Convert.ToBoolean(tabla.Rows[0][7].ToString()));
            return tratamiento;
        }
        public Boolean existetratamiento(Tratamientos tratamiento) // busca tratamiento por DNI
        {
            String consulta = "SELECT * FROM Tratamiento WHERE DNIPac_Tr='" + tratamiento.getDNIPac_Tr().getDNIPac_Pa() + "'";
            return ds.existe(consulta);
        }
        public Boolean existeTratamientoPorId(Tratamientos tratamiento)
        {
            String consulta = "SELECT * FROM Tratamiento WHERE NumTram_Tr='" + tratamiento.getNumTram_Tr() + "'";
            return ds.existe(consulta);
        }
        public DataTable getTablaTratamiento()
        {
            DataTable tabla = ds.ObtenerTabla("Tratamiento", "SELECT * FROM Tratamiento");
            return tabla;
        }
        public DataTable getTablaTratamientoPorDNI(Tratamientos tratamiento)
        {
            DataTable tabla = ds.ObtenerTabla("Tratamiento", "SELECT * FROM Tratamiento WHERE DNIPac_Tr=" + tratamiento.getDNIPac_Tr().getDNIPac_Pa());
            return tabla;
        }

        public DataTable obtenerTratamientosEspecificosConFiltro(String droga, String dni)
        {
            String nombreTabla = "ObservacionesGenerales";
            String consultaSQL = "SELECT * FROM Tratamiento WHERE Droga_Tr LIKE '" + droga + "%' AND DNIPac_Tr = '" + dni + "'"; 
            return obtenerTabla(nombreTabla, consultaSQL);
        }
        public int agregarTratamiento(Tratamientos tratamientos)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosTratamientoAgregar(ref comando, tratamientos);
            return ds.EjecutarProcedimientoAlmacenado(comando, "SP_AgregarTratamiento");
        }
        private void ArmarParametrosTratamientoAgregar(ref SqlCommand Comando, Tratamientos tratamientos)
        {
            SqlParameter SqlParametros = new SqlParameter();

            SqlParametros = Comando.Parameters.Add("@DNIPac_Tr", SqlDbType.VarChar);
            SqlParametros.Value = tratamientos.getDNIPac_Tr().getDNIPac_Pa();
            SqlParametros = Comando.Parameters.Add("@Droga_Tr", SqlDbType.VarChar);
            SqlParametros.Value = tratamientos.getDroga_Tr();
            SqlParametros = Comando.Parameters.Add("@Marca_Tr", SqlDbType.VarChar);
            SqlParametros.Value = tratamientos.getMarca_Tr();
            SqlParametros = Comando.Parameters.Add("@Psicoterapia_Tr", SqlDbType.Bit);
            SqlParametros.Value = tratamientos.getPsicoterapia_Tr();
            SqlParametros = Comando.Parameters.Add("@Rehabilitacion_Tr", SqlDbType.Bit);
            SqlParametros.Value = tratamientos.getRehabilitacion_Tr();
            SqlParametros = Comando.Parameters.Add("@TO_Tr", SqlDbType.Bit);
            SqlParametros.Value = tratamientos.getTO_Tr();
            SqlParametros = Comando.Parameters.Add("@Otras_Tr", SqlDbType.Bit);
            SqlParametros.Value = tratamientos.getOtras_Tr();
        }

        private void ArmarParametrosTratamientoModificar(ref SqlCommand Comando, Tratamientos tratamientos)
        {
            SqlParameter SqlParametros = new SqlParameter();

            SqlParametros = Comando.Parameters.Add("@NumTram_Tr", SqlDbType.Int);
            SqlParametros.Value = tratamientos.getNumTram_Tr();
            SqlParametros = Comando.Parameters.Add("@DNIPac_Tr", SqlDbType.VarChar);
            SqlParametros.Value = tratamientos.getDNIPac_Tr().getDNIPac_Pa();
            SqlParametros = Comando.Parameters.Add("@Droga_Tr", SqlDbType.VarChar);
            SqlParametros.Value = tratamientos.getDroga_Tr();
            SqlParametros = Comando.Parameters.Add("@Marca_Tr", SqlDbType.VarChar);
            SqlParametros.Value = tratamientos.getMarca_Tr();
            SqlParametros = Comando.Parameters.Add("@Psicoterapia_Tr", SqlDbType.Bit);
            SqlParametros.Value = tratamientos.getPsicoterapia_Tr();
            SqlParametros = Comando.Parameters.Add("@Rehabilitacion_Tr", SqlDbType.Bit);
            SqlParametros.Value = tratamientos.getRehabilitacion_Tr();
            SqlParametros = Comando.Parameters.Add("@TO_Tr", SqlDbType.Bit);
            SqlParametros.Value = tratamientos.getTO_Tr();
            SqlParametros = Comando.Parameters.Add("@Otras_Tr", SqlDbType.Bit);
            SqlParametros.Value = tratamientos.getOtras_Tr();
        }

        private DataTable obtenerTabla(String nombre, String consultaSql)
        {
            DataSet ds = new DataSet();
            AccesoDatos datos = new AccesoDatos();
            SqlDataAdapter adp = datos.obtenerAdaptador(consultaSql);
            adp.Fill(ds, nombre);
            return ds.Tables[nombre];
        }

        public DataTable obtenerTratamientos()
        {
            String nombreTabla = "Tratamiento";
            String consultaSQL = "SELECT * FROM Tratamiento";
            return obtenerTabla(nombreTabla, consultaSQL);
        }

        public DataTable obtenerTratamientosEspecificos(String dni)
        {
            String nombreTabla = "Tratamiento";
            String consultaSQL = "SELECT * FROM Tratamiento WHERE DNIPac_Tr = " + dni;

            return obtenerTabla(nombreTabla, consultaSQL);
        }

        public bool actualizarTratamiento(Tratamientos tratamientos)
        {
            String sp = "SP_ModificarTratamiento";
            SqlCommand comando = new SqlCommand();
            ArmarParametrosTratamientoModificar(ref comando, tratamientos);
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
