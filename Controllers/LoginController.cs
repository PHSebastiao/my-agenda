using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyAgenda.Models;
using MyAgenda.Data;
using MyAgenda.Services;

namespace MyAgenda.Controllers
{
    [Route("api/Login")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly MyAgendaContext _context;

        public LoginController(MyAgendaContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody]Conta model)
        {
            // Recupera o usuário
            var user = await _context.Conta.SingleOrDefaultAsync(conta => conta.Email == model.Email);

            // Verifica se o usuário existe
            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });
            if (user.Senha != model.Senha)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            // Gera o Token
            var token = TokenService.GenerateToken(user);

            // Retorna o token
            return Ok(new { token });
        }
        [HttpGet]
        [Authorize]
        public bool LoggedIn() => true;
    }
}
