using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer
{
   public class ClienteBO
    {
        public int ID_CLIENTE { get; set; }
        public string NOMBRES { get; set; }
        public string APELLIDOS { get; set; }
        public string RUT { get; set; }
        public int CELULAR { get; set; }
        public string CORREO { get; set; }
        public string DIRECCION { get; set; }
        public string CLAVE { get; set; }
    }
}
