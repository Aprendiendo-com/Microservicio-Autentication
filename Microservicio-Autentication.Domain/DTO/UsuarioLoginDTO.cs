using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Autentication.Domain.DTO
{
    public class UsuarioLoginDTO
    {
        public string Email { get; set; }
        public string Contraseña { get; set; }
    }
}
