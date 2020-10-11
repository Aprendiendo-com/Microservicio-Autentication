using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Autentication.Domain.DTO
{
    public class UsuarioLoginDTO
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Contraseña { get; set; }
    }
}
