using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario
    {
        String DNI_U;
        Boolean Rol_U;
        String Contraseña_U;
        Boolean Estado;
        // Constructor
        public Usuario() { 
        }
        // Gets y Sets
        public string getDNI_U()
        {
            return this.DNI_U;
        }
        public void setDNI_U(string variable)
        {
            this.DNI_U = variable;
        }
        public bool getRol_U()
        {
            return this.Rol_U;
        }
        public void setRol_U(bool variable)
        {
            this.Rol_U = variable;
        }
        public string getContraseña_U()
        {
            return this.Contraseña_U;
        }
        public void setContraseña_U(string variable)
        {
            this.Contraseña_U = variable;
        }
        public Boolean getEstado()
        {
            return this.Estado;
        }
        public void setEstado(Boolean variable)
        {
            this.Estado = variable;
        }
    }
}
