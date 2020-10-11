using Microservicio_Autentication.Application.Services.Base;
using Microservicio_Autentication.Domain.DTO;
using Microservicio_Autentication.Domain.Entities;
using Microservicio_Autentication.Domain.Queries;
using Microservicio_Autentication.Domain.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Microservicio_Autentication.Application.Services
{
    public class UsuarioService : GenericService<Usuario>, IUsuarioService
    {
        private readonly IConfiguration _configuration;

        public UsuarioService(IUsuarioRepository repository, IConfiguration configuration) : base(repository)
        {
            this._configuration = configuration;
        }


        public RegistroExitosoDTO Registro(UsuarioRegistroDTO usuario)
        {
            if (usuario == null)
            {
                 throw new Exception("Ha ocurrudo un error");
            }

            if (usuario.Nombre == "" || usuario.Apellido == "" || usuario.Email == "" || usuario.Contraseña == "")
            {
                throw new Exception("Por favor ingrese caracteres validos");
            }

            var usuarioDb = new Usuario()
            {
                Apellido = usuario.Apellido,
                Nombre = usuario.Nombre,
                Contraseña = GetHash(usuario.Contraseña),
                Email = usuario.Email,
            };

            this.Repository.Add(usuarioDb);

            var usuarioRol = new  UsuarioRol()
            {
                UsuarioId = usuarioDb.UsuarioId,
                RolId = usuario.RolId
            };

            ((IUsuarioRepository)Repository).AddUsuarioRol(usuarioRol);

            return new RegistroExitosoDTO { Estado = "Registro Exitoso" };
        }


        public string Login(UsuarioLoginDTO usuario)
        {
            //validamos que el usuario ingresado existe en la db

            var usuariodb = this.GetBy( x => x.Apellido == usuario.Apellido && x.Nombre == usuario.Nombre, new string[] { "UsuarioRolNavigator.Roles" })
                .FirstOrDefault();

            if (usuariodb == null)
            {
                throw new Exception("El usuario ingresado no existe. Por favor registrese.");
            }

            var verificarContraseña = GetHash(usuario.Contraseña);

            if (usuariodb.Contraseña != verificarContraseña)
            {
                throw new Exception("La contraseña ingresada no es valida");
            }

            var rol = usuariodb.UsuarioRolNavigator.Select(x => x.Roles.TipoRol).FirstOrDefault();

            // se crea el header //
            var _symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._configuration.GetSection("Authentication:SecretKey").Value));
            var _signingCredentials = new SigningCredentials( _symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(_signingCredentials);

            // se crea los claim
            var claims = new[] {
                new Claim("Nombre", usuario.Nombre),
                new Claim("Apellido", usuario.Apellido),
                new Claim("Rol", rol)
            };

            // creacion del payload del token
            var payload = new JwtPayload(
                    issuer: "",
                    audience: "",
                    claims: claims,
                    notBefore: DateTime.UtcNow,
                    // vence en un dia.
                    expires: DateTime.UtcNow.AddDays(1)
                );

            // con los claims y payload se crea el token
            var token = new JwtSecurityToken( header, payload);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }



        public string GetHash(string contra)
        {
            var sha256 = SHA256.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();

            StringBuilder cadena = new StringBuilder();
            byte[] stream = sha256.ComputeHash(encoding.GetBytes(contra));

            for (int i = 0; i < stream.Length; i++)
            {
                cadena.AppendFormat("{0:x2}", stream[i]);
            }

            return cadena.ToString();
        }
    }
}
