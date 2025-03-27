using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.DTOs;
using API.Entidades;
using API.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController(DataContext context, IUsuarioRepository usuarioRepository) : ControllerBase
    {
        

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsers()
        {
            var users = await usuarioRepository.GetUsuarios();

            return Ok(users);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Usuario>> GetUser(int id)
        {
            var user = await usuarioRepository.GetUsuarioById(id);

            return Ok(user);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Usuario>> DeleteUser(int id)
        {
            var user = await usuarioRepository.GetUsuarioById(id);
            if (user == null)
            {
                return BadRequest("Erro ao deletar o usuário");
            }

            context.Usuarios.Remove(user);
            await usuarioRepository.SaveAllAsync();
            return Ok("");
        }
    }
}