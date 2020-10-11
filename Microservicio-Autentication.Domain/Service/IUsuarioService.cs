using Microservicio_Autentication.Domain.Command.BaseService;
using Microservicio_Autentication.Domain.DTO;
using Microservicio_Autentication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Autentication.Domain.Service
{
    public interface IUsuarioService: IService<Usuario>
    {
        RegistroExitosoDTO Registro(UsuarioRegistroDTO usuario);
        string Login(UsuarioLoginDTO usuario);
        string GetHash(string contra);
    }
}
