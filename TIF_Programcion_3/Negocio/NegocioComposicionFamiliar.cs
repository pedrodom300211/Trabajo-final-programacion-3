using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;
using System.Data;

namespace Negocio
{
    public class NegocioComposicionFamiliar
    {   private DaoPaciente dp = new DaoPaciente();
        public DataTable getTabla()
        {
            DaoComposicionFamiliar dao = new DaoComposicionFamiliar();
            return dao.getTablaComposicionFamiliar();
        }

        public DataTable getTablaDNI(string dni)
        {
            DaoComposicionFamiliar dao = new DaoComposicionFamiliar();
            ComposicionFamiliar composicionFamiliar = new ComposicionFamiliar();
            Paciente pac = new Paciente();
            pac.setDNIPac_Pa(dni);
            composicionFamiliar.setDNIPAC_CF(pac);
            return dao.getTablaComposicionFamiliarPorDNI(composicionFamiliar);
        }
        public bool agregarFamiliar(ComposicionFamiliar comFamiliar/*String nombre*/)
        {
            int cantFilas = 0;

            DaoComposicionFamiliar dao = new DaoComposicionFamiliar();
           
            cantFilas = dao.agregarFamiliar(comFamiliar);
            if (cantFilas == 1)
                return true;
            else
                return false;
        }

        public bool ModificarComposicionFamiliar(ComposicionFamiliar composicionFamiliar)
        {
            DaoComposicionFamiliar dao = new DaoComposicionFamiliar();

            bool op = dao.actualizarComposicionFamiliar(composicionFamiliar);
            if (op == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable obtenerTabla()
        {
            DaoComposicionFamiliar composicionFamiliar = new DaoComposicionFamiliar();
            return composicionFamiliar.obtenerComposicionFamiliar();
        }

        public DataTable obtenerTablaEspecifica( String dnipac)
        {
            DaoComposicionFamiliar composicionFamiliar = new DaoComposicionFamiliar();
            return composicionFamiliar.obtenerComposicionFamiliarConWhere (dnipac);
        }

        public bool ValidarExistePaciente(string dni)
        {
            
            DaoPaciente paciente = new DaoPaciente();
            if (paciente.existePaciente(dni))
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
