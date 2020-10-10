using Microservicio_Autentication.Application.Services.Base;
using Microservicio_Autentication.Domain.Queries;
using Microservicio_Autentication.Domain.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Autentication.Application.Services
{
    public class UsuarioService : GenericService, IUsuarioService
    {
        public UsuarioService(IUsuarioRepository repository) : base(repository)
        {

        }

    }
}
