using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Autentication.Domain.Entities
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }

        public ICollection<UsuarioRol> UsuarioRolNavigator { get; set; }

    }
}
