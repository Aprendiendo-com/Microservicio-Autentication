using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Autentication.Domain.Entities
{
    public class Rol
    {
        public int RolId { get; set; }
        public string TipoRol { get; set; }

        public ICollection<UsuarioRol> UsuarioRolNavigator { get; set; }

    }
}
