using Microservicio_Autentication.Domain.Command.BaseRepository;
using Microservicio_Autentication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Autentication.Domain.Queries
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        void AddUsuarioRol(UsuarioRol usuarioRol);
    }
}
