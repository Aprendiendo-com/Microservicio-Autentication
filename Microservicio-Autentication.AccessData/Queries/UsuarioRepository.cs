using Microservicio_Autentication.AccessData.Commands;
using Microservicio_Autentication.AccessData.Context;
using Microservicio_Autentication.Domain.Entities;
using Microservicio_Autentication.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Autentication.AccessData.Queries
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(GenericContex contexto) : base(contexto)
        {
        }

        public void AddUsuarioRol(UsuarioRol usuarioRol)
        {
            this.Context.Add(usuarioRol);
            this.Context.SaveChanges();
        }
    }
}
