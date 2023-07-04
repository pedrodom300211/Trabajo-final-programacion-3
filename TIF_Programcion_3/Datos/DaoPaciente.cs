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
    public class DaoPaciente
    {
        private AccesoDatos ds = new AccesoDatos();

        public Paciente getPaciente(Paciente paciente)
        {

            DataTable tabla = ds.ObtenerTabla("Paciente", "Select * from Paciente inner join SituacionLaboral on Paciente.CodSitLab_SL_Pa = SituacionLaboral.CodSitLab_SL inner join Acercamiento on Paciente.CodAcerc_A_Pa = Acercamiento.CodAcerc_A where DNIPac_Pa = '"+ paciente.getDNIPac_Pa() + "'");
            ///setear el obj de sit lab
            SituacionLaboral SitLab = new SituacionLaboral();
            SitLab.setCodSitLab_SL(tabla.Rows[0][12].ToString());
            SitLab.setDescripcion_SL(tabla.Rows[0][13].ToString());
            ///Set objeto Acercamiento
            Acercamiento Acer = new Acercamiento();
            Acer.setCodAcerc_A(tabla.Rows[0][14].ToString());
            Acer.setDescripcion_A(tabla.Rows[0][15].ToString());

            ///set paciente
            paciente.setDNIPac_Pa(tabla.Rows[0][0].ToString());
            paciente.setNombreApellido_PA(tabla.Rows[0][1].ToString());
            paciente.setEdad_PA(tabla.Rows[0][2].ToString());
            paciente.setNomAcompaniante_Pa(tabla.Rows[0][3].ToString());
            paciente.setParentezco_Pa(tabla.Rows[0][4].ToString());
            paciente.setFechaEntrevista_Pa(Convert.ToDateTime(tabla.Rows[0][5].ToString()));
            paciente.setCUD_Pa(Convert.ToBoolean(tabla.Rows[0][6].ToString()));
            paciente.setVencimientoCUD_Pa(Convert.ToDateTime(tabla.Rows[0][7].ToString()));
            paciente.setMotivoConsulta_Pa(tabla.Rows[0][8].ToString());
            paciente.setEstado(Convert.ToBoolean(tabla.Rows[0][9].ToString()));
            paciente.setCodSitLab_SL_Pa(SitLab);
            paciente.setCodAcerc_A_Pa(Acer);
            return paciente;
        }
        public Boolean existePaciente(Paciente paciente) // busca paciente por DNI
        {
            String consulta = "SELECT * FROM Paciente WHERE DNIPac_Pa='" + paciente.getDNIPac_Pa() + "'";
            return ds.existe(consulta);
        }
        
        public Boolean existePaciente(String DNIpaciente) // busca paciente por DNI
        {
            String consulta = "SELECT * FROM Paciente WHERE DNIPac_Pa='" + DNIpaciente + "'and Estado ='1'";
            return ds.existe(consulta);
        }

        public DataTable getTablaPaciente()
        {
            DataTable tabla = ds.ObtenerTabla("Paciente", "SELECT DNIPac_Pa ,NombreApellido_PA , Edad_PA , NomAcompaniante_Pa,Parentezco_Pa, FechaEntrevista_Pa , CUD_Pa  , VencimientoCUD_Pa, MotivoConsulta_Pa,Descripcion_SL,Descripcion_A FROM Paciente " +
                                                "inner join SituacionLaboral on Paciente.CodSitLab_SL_Pa = SituacionLaboral.CodSitLab_SL " +
                                                "inner join Acercamiento on Paciente.CodAcerc_A_Pa = Acercamiento.CodAcerc_A WHERE ESTADO = 1"); // MODIFICADO Y FUNCIONANDO
            return tabla;
        }

       
        public DataTable getTablaPacientePorDNI(Paciente paciente)
        {
            DataTable tabla = ds.ObtenerTabla("Paciente", "SELECT DNIPac_Pa ,NombreApellido_PA , Edad_PA , NomAcompaniante_Pa,Parentezco_Pa, FechaEntrevista_Pa , CUD_Pa  , VencimientoCUD_Pa, MotivoConsulta_Pa,Descripcion_SL,Descripcion_A FROM Paciente " +
                                                "inner join SituacionLaboral on Paciente.CodSitLab_SL_Pa = SituacionLaboral.CodSitLab_SL " +
                                                "inner join Acercamiento on Paciente.CodAcerc_A_Pa = Acercamiento.CodAcerc_A WHERE DNIPac_Pa=" + paciente.getDNIPac_Pa());
            return tabla;
        }
        public DataTable getTablaPacientePorDNILaborAcercamiento(Paciente paciente)
        {
            DataTable tabla = ds.ObtenerTabla("Paciente", "SELECT DNIPac_Pa ,NombreApellido_PA , Edad_PA , NomAcompaniante_Pa,Parentezco_Pa, FechaEntrevista_Pa , CUD_Pa  , VencimientoCUD_Pa, MotivoConsulta_Pa,Descripcion_SL,Descripcion_A FROM Paciente " +
                                                "INNER JOIN SituacionLaboral on Paciente.CodSitLab_SL_Pa = SituacionLaboral.CodSitLab_SL " +
                                                "INNER JOIN Acercamiento on Paciente.CodAcerc_A_Pa = Acercamiento.CodAcerc_A WHERE Estado = 1 AND DNIPac_Pa=" + paciente.getDNIPac_Pa());
            return tabla;
        }

        public int agregarPaciente(Paciente paciente)
        {
            
            SqlCommand comando = new SqlCommand();
            ArmarParametrosPacienteAgregar(ref comando, paciente);
            return ds.EjecutarProcedimientoAlmacenado(comando, "SP_AgregarPaciente");
        }

        public int BajaLogicaPaciente(Paciente paciente)
        {
            SqlCommand comando = new SqlCommand();

            ArmarParametrosPacienteBajaLogica(ref comando, paciente);
            return ds.EjecutarProcedimientoAlmacenado(comando, "SP_BajaLogicaPaciente");
        }

        private void ArmarParametrosPacienteAgregar(ref SqlCommand Comando, Paciente paciente)
        {
            SqlParameter SqlParametros = new SqlParameter();
         
            SqlParametros = Comando.Parameters.Add("@DNIPac_Pa", SqlDbType.VarChar);
            SqlParametros.Value = paciente.getDNIPac_Pa();
            SqlParametros = Comando.Parameters.Add("@NombreApellido_PA", SqlDbType.VarChar);
            SqlParametros.Value = paciente.getNombreApellido_PA();
            SqlParametros = Comando.Parameters.Add("@Edad_PA", SqlDbType.VarChar);
            SqlParametros.Value = paciente.getEdad_PA();
            SqlParametros = Comando.Parameters.Add("@NomAcompaniante_Pa", SqlDbType.VarChar);
            SqlParametros.Value = paciente.getNomAcompaniante_Pa();
            SqlParametros = Comando.Parameters.Add("@Parentezco_Pa", SqlDbType.VarChar);
            SqlParametros.Value = paciente.getParentezco_Pa();
            SqlParametros = Comando.Parameters.Add("@FechaEntrevista_Pa", SqlDbType.VarChar);
            SqlParametros.Value = paciente.getFechaEntrevista_Pa();
            SqlParametros = Comando.Parameters.Add("@CUD_Pa", SqlDbType.Bit);
            SqlParametros.Value = paciente.getCUD_Pa();
            SqlParametros = Comando.Parameters.Add("@VencimientoCUD_Pa", SqlDbType.VarChar);
            SqlParametros.Value = paciente.getVencimientoCUD_Pa();
            SqlParametros = Comando.Parameters.Add("@MotivoConsulta_Pa", SqlDbType.VarChar);
            SqlParametros.Value = paciente.getMotivoConsulta_Pa();
            SqlParametros = Comando.Parameters.Add("@CodSitLab_SL_Pa", SqlDbType.VarChar);
            SqlParametros.Value = paciente.getCodSitLab_SL_Pa().getCodSitLab_SL();
            SqlParametros = Comando.Parameters.Add("@CodAcerc_A_Pa", SqlDbType.VarChar);
            SqlParametros.Value = paciente.getCodAcerc_A_Pa().getCodAcerc_A();
        }
        ///Puede ser q se tenga q borrar
        private void ArmarParametrosPacienteModificar(ref SqlCommand Comando, Paciente paciente)
        {
            SqlParameter SqlParametros = new SqlParameter();

            SqlParametros = Comando.Parameters.Add("@DNIPac_Pa", SqlDbType.VarChar);
            SqlParametros.Value = paciente.getDNIPac_Pa();
            SqlParametros = Comando.Parameters.Add("@NombreApellido_PA", SqlDbType.VarChar);
            SqlParametros.Value = paciente.getNombreApellido_PA();
            SqlParametros = Comando.Parameters.Add("@Edad_PA", SqlDbType.VarChar);
            SqlParametros.Value = paciente.getEdad_PA();
            SqlParametros = Comando.Parameters.Add("@NomAcompaniante_Pa", SqlDbType.VarChar);
            SqlParametros.Value = paciente.getNomAcompaniante_Pa();
            SqlParametros = Comando.Parameters.Add("@Parentezco_Pa", SqlDbType.VarChar);
            SqlParametros.Value = paciente.getParentezco_Pa();
            SqlParametros = Comando.Parameters.Add("@FechaEntrevista_Pa", SqlDbType.DateTime);
            SqlParametros.Value = paciente.getFechaEntrevista_Pa();
            SqlParametros = Comando.Parameters.Add("@CUD_Pa", SqlDbType.Bit);
            SqlParametros.Value = paciente.getCUD_Pa();
            SqlParametros = Comando.Parameters.Add("@VencimientoCUD_Pa", SqlDbType.DateTime);
            SqlParametros.Value = paciente.getVencimientoCUD_Pa();
            SqlParametros = Comando.Parameters.Add("@MotivoConsulta_Pa", SqlDbType.VarChar);
            SqlParametros.Value = paciente.getMotivoConsulta_Pa();
            SqlParametros = Comando.Parameters.Add("@CodSitLab_SL_Pa", SqlDbType.VarChar);
            SqlParametros.Value = paciente.getCodSitLab_SL_Pa().getCodSitLab_SL();
            SqlParametros = Comando.Parameters.Add("@CodAcerc_A_Pa", SqlDbType.VarChar);
            SqlParametros.Value = paciente.getCodAcerc_A_Pa().getCodAcerc_A();
        }

        private void ArmarParametrosPacienteModificar2(ref SqlCommand Comando, Paciente paciente)
        {
            SqlParameter SqlParametros = new SqlParameter();

            SqlParametros = Comando.Parameters.Add("@DNIPac_Pa", SqlDbType.VarChar);
            SqlParametros.Value = paciente.getDNIPac_Pa();
            SqlParametros = Comando.Parameters.Add("@NombreApellido_PA", SqlDbType.VarChar);
            SqlParametros.Value = paciente.getNombreApellido_PA();
            SqlParametros = Comando.Parameters.Add("@Edad_PA", SqlDbType.VarChar);
            SqlParametros.Value = paciente.getEdad_PA();
            SqlParametros = Comando.Parameters.Add("@NomAcompaniante_Pa", SqlDbType.VarChar);
            SqlParametros.Value = paciente.getNomAcompaniante_Pa();
            SqlParametros = Comando.Parameters.Add("@Parentezco_Pa", SqlDbType.VarChar);
            SqlParametros.Value = paciente.getParentezco_Pa();
            SqlParametros = Comando.Parameters.Add("@FechaEntrevista_Pa", SqlDbType.DateTime);
            SqlParametros.Value = paciente.getFechaEntrevista_Pa();
            SqlParametros = Comando.Parameters.Add("@CUD_Pa", SqlDbType.Bit);
            SqlParametros.Value = paciente.getCUD_Pa();
            SqlParametros = Comando.Parameters.Add("@VencimientoCUD_Pa", SqlDbType.DateTime);
            SqlParametros.Value = paciente.getVencimientoCUD_Pa();          
            SqlParametros = Comando.Parameters.Add("@MotivoConsulta_Pa", SqlDbType.VarChar);
            SqlParametros.Value = paciente.getMotivoConsulta_Pa();
            SqlParametros = Comando.Parameters.Add("@CodSitLab_SL_Pa", SqlDbType.VarChar);
            SqlParametros.Value = paciente.getCodSitLab_SL_Pa().getCodSitLab_SL();
            SqlParametros = Comando.Parameters.Add("@CodAcerc_A_Pa", SqlDbType.VarChar);
            SqlParametros.Value = paciente.getCodAcerc_A_Pa().getCodAcerc_A();
        }
       
        private void ArmarParametrosPacienteBajaLogica(ref SqlCommand Comando, Paciente paciente)
        {
            SqlParameter SqlParametros = new SqlParameter();

            SqlParametros = Comando.Parameters.Add("@DNIPac_Pa", SqlDbType.Int);
            SqlParametros.Value = paciente.getDNIPac_Pa();
        }

        private DataTable obtenerTabla(String nombre, String consultaSql)
        {
            DataSet ds = new DataSet();
            AccesoDatos datos = new AccesoDatos();
            SqlDataAdapter adp = datos.obtenerAdaptador(consultaSql);
            adp.Fill(ds, nombre);
            return ds.Tables[nombre];
        }

        public DataTable obtenerPacientes()
        {
            String nombreTabla = "Paciente";
            String consultaSQL = "SELECT * FROM Paciente";
            return obtenerTabla(nombreTabla, consultaSQL);
        }

        public DataTable obtenerPacientesEspecificos(String Dni)
        {
            String nombreTabla = "Paciente";
            String consultaSQL = "SELECT DNIPac_Pa ,NombreApellido_PA , Edad_PA , NomAcompaniante_Pa,Parentezco_Pa, FechaEntrevista_Pa , CUD_Pa  , VencimientoCUD_Pa, MotivoConsulta_Pa,Descripcion_SL,Descripcion_A FROM Paciente " +
                                                "inner join SituacionLaboral on Paciente.CodSitLab_SL_Pa = SituacionLaboral.CodSitLab_SL " +
                                                "inner join Acercamiento on Paciente.CodAcerc_A_Pa = Acercamiento.CodAcerc_A WHERE DNIPac_Pa= " + Dni; 

            return obtenerTabla(nombreTabla, consultaSQL);
        }

        public bool actualizarPacientes(Paciente paciente)
        {
            String sp = "SP_ModificarPaciente";
            SqlCommand comando = new SqlCommand();
            ArmarParametrosPacienteModificar2(ref comando, paciente);
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
        public DataTable obtenerPacientesEspecificosConFiltro(String Dni, String simbolo)
        {
            String nombreTabla = "Paciente";
            String consultaSQL = "SELECT DNIPac_Pa ,NombreApellido_PA , Edad_PA , NomAcompaniante_Pa,Parentezco_Pa, FechaEntrevista_Pa , CUD_Pa  , VencimientoCUD_Pa, MotivoConsulta_Pa,Descripcion_SL,Descripcion_A FROM Paciente " +
                                                "inner join SituacionLaboral on Paciente.CodSitLab_SL_Pa = SituacionLaboral.CodSitLab_SL " +
                                                "inner join Acercamiento on Paciente.CodAcerc_A_Pa = Acercamiento.CodAcerc_A WHERE DNIPac_Pa"+ simbolo+ Dni;

            return obtenerTabla(nombreTabla, consultaSQL);
        }
        
    }
}
