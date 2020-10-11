using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservicio_Autentication.Domain.DTO;
using Microservicio_Autentication.Domain.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Microservicio_Autentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioService _service;

        public UsuarioController(IUsuarioService service)
        {
            this._service = service;
        }

        [HttpPost]

        public IActionResult Usuario(UsuarioRegistroDTO usuario)
        {
            try
            {
                return new JsonResult(this._service.Registro(usuario)) { StatusCode = 201};
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("usuario")]

        public IActionResult Usuario(UsuarioLoginDTO usuario)
        {
            try
            {
                return new JsonResult(this._service.Login(usuario)) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



    }
}