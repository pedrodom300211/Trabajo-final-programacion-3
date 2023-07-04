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
    public class DaoComposicionFamiliar
    {
        private AccesoDatos ds = new AccesoDatos();
        private DaoPaciente Dp = new DaoPaciente();

        public Boolean existeComposicionFamiliar(ComposicionFamiliar composicionFamiliar) // busca por DNI composicion familiar
        {
            String consulta = "SELECT * FROM ComposicionFamiliar WHERE DNIPac_CF='" + composicionFamiliar.getDNIPAC_CF().getDNIPac_Pa() + "'";
            return ds.existe(consulta);
        }

        public DataTable getTablaComposicionFamiliar()
        {
            DataTable tabla = ds.ObtenerTabla("ComposicionFamiliar", "SELECT * FROM ComposicionFamiliar");
            return tabla;
        }

        public DataTable getTablaComposicionFamiliarPorDNI(ComposicionFamiliar composicionFamiliar)
        {
            DataTable tabla = ds.ObtenerTabla("ComposicionFamiliar", "SELECT * FROM ComposicionFamiliar  WHERE DNIPac_CF= " + composicionFamiliar.getDNIPAC_CF().getDNIPac_Pa());/*inner join Paciente on ComposicionFamiliar.DNIPac_CF=Paciente.DNIPac_Pa*/
            return tabla;
        }
        public int agregarFamiliar(ComposicionFamiliar ComFamiliar)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosFamiliarAgregar(ref comando, ComFamiliar);
            return ds.EjecutarProcedimientoAlmacenado(comando, "SP_AgregarFamiliar");
        }
        
        private void ArmarParametrosFamiliarAgregar(ref SqlCommand Comando, ComposicionFamiliar comFamiliar)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@DNIPAC_CF", SqlDbType.VarChar);
            SqlParametros.Value = comFamiliar.getDNIPAC_CF().getDNIPac_Pa();
            SqlParametros = Comando.Parameters.Add("@DNIFAM_CF", SqlDbType.VarChar);
            SqlParametros.Value = comFamiliar.getDNIFAM_CF();
            SqlParametros = Comando.Parameters.Add("@NombreFamiliar_CF", SqlDbType.VarChar);
            SqlParametros.Value = comFamiliar.getNombreFamiliar_CF();
            SqlParametros = Comando.Parameters.Add("@EdadFamiliar_CF", SqlDbType.VarChar);
            SqlParametros.Value = comFamiliar.getEdadFamiliar_CF();
            SqlParametros = Comando.Parameters.Add("@OcupacionFaimiliar_CF", SqlDbType.VarChar);
            SqlParametros.Value = comFamiliar.getOcupacionFamiliar_CF();
            SqlParametros = Comando.Parameters.Add("@ConviveFamiliar_CF", SqlDbType.Bit);
            SqlParametros.Value = comFamiliar.getConviveFamiliar_CF();
            SqlParametros = Comando.Parameters.Add("@TelefonoFamiliar_CF", SqlDbType.VarChar);
            SqlParametros.Value = comFamiliar.getTelefonoFamiliar_CF();
            SqlParametros = Comando.Parameters.Add("@ParentescoFamiliar_CF", SqlDbType.VarChar);
            SqlParametros.Value = comFamiliar.getParentescoFamiliar_CF();
            
        }

        private void ArmarParametrosFamiliarModificar(ref SqlCommand Comando, ComposicionFamiliar comFamiliar)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@DNIPAC_CF", SqlDbType.VarChar);
            SqlParametros.Value = comFamiliar.getDNIPAC_CF().getDNIPac_Pa();
            SqlParametros = Comando.Parameters.Add("@DNIFAM_CF", SqlDbType.VarChar);
            SqlParametros.Value = comFamiliar.getDNIFAM_CF();
            SqlParametros = Comando.Parameters.Add("@NombreFamiliar_CF", SqlDbType.VarChar);
            SqlParametros.Value = comFamiliar.getNombreFamiliar_CF();
            SqlParametros = Comando.Parameters.Add("@EdadFamiliar_CF", SqlDbType.VarChar);
            SqlParametros.Value = comFamiliar.getEdadFamiliar_CF();
            SqlParametros = Comando.Parameters.Add("@OcupacionFamiliar_CF", SqlDbType.VarChar);
            SqlParametros.Value = comFamiliar.getOcupacionFamiliar_CF();
            SqlParametros = Comando.Parameters.Add("@ConviveFamiliar_CF", SqlDbType.Bit);
            SqlParametros.Value = comFamiliar.getConviveFamiliar_CF();
            SqlParametros = Comando.Parameters.Add("@TelefonoFamiliar_CF", SqlDbType.VarChar);
            SqlParametros.Value = comFamiliar.getTelefonoFamiliar_CF();
            SqlParametros = Comando.Parameters.Add("@ParentescoFamiliar_CF", SqlDbType.VarChar);
            SqlParametros.Value = comFamiliar.getParentescoFamiliar_CF();

        }

        private DataTable obtenerTabla(String nombre, String consultaSql)
        {
            DataSet ds = new DataSet();
            AccesoDatos datos = new AccesoDatos();
            SqlDataAdapter adp = datos.obtenerAdaptador(consultaSql);
            adp.Fill(ds, nombre);
            return ds.Tables[nombre];
        }

        public DataTable obtenerComposicionFamiliar()
        {
            String nombreTabla = "ComposicionFamiliar";
            String consultaSQL = "SELECT * FROM ComposicionFamiliar";
            return obtenerTabla(nombreTabla, consultaSQL);
        }

        public DataTable obtenerComposicionFamiliarConWhere( String DniPac)
        {
            String nombreTabla = "ComposicionFamiliar";
            String consultaSQL = "SELECT * FROM ComposicionFamiliar WHERE DNIPac_CF = " + DniPac;

            return obtenerTabla(nombreTabla, consultaSQL);
        }

        public bool actualizarComposicionFamiliar(ComposicionFamiliar composicionFamiliar)
        {
            String sp = "SP_ModificarComposicionFamiliar";
            SqlCommand comando = new SqlCommand();
            ArmarParametrosFamiliarModificar(ref comando, composicionFamiliar);
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
