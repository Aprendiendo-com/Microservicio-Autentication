using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Autentication.Domain.Entities
{
    public class UsuarioRol
    {
        public int UsuarioRolId { get; set; }
        public int UsuarioId { get; set; }
        public int RolId { get; set; }

        public Usuario Usuarios { get; set; }
        public Rol Roles { get; set; }

    }
}
