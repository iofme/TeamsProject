
using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.DTOs;
using API.Entidades;
using API.Extensions;
using API.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController(DataContext context, IUsuarioRepository usuarioRepository, ITokenServices tokenServices) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<ActionResult<UsuarioDTO>> CreateUser(RegisterDTO registerDTO)
        {

            using var hmac = new HMACSHA512();

            var user = new Usuario
            {
                Username = registerDTO.Username,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDTO.Password)),
                PasswoedSalt = hmac.Key,
                Foto = registerDTO.Foto,
                Funcao = registerDTO.Funcao,
                DateBirth = registerDTO.DateBirth,
            };

            context.Usuarios.Add(user);
            await usuarioRepository.SaveAllAsync();

            return new UsuarioDTO
            {
                Username = user.Username,
                Foto = user.Foto,
                DateBirth = user.DateBirth,
                Funcao = user.Funcao,
                Token = tokenServices.CreateToken(user)
            };
        }
        [HttpPost("login")]
        public async Task<ActionResult<UsuarioDTO>> Login(LoginDto loginDto)
        {
            var user = await context.Usuarios.FirstOrDefaultAsync(u => u.Username == loginDto.Username);

            if (user == null) return Unauthorized("Usuario invalido");

            using var hmac = new HMACSHA512(user.PasswoedSalt);

            var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for(int i = 0; i < computeHash.Length; i++)
            {
                if(computeHash[i] != user.PasswordHash[i]) return Unauthorized("Senha invalida");
            }

            return new UsuarioDTO{
                Username = user.Username,
                Foto = user.Foto,
                DateBirth = user.DateBirth,
                Funcao = user.Funcao,
                Token = tokenServices.CreateToken(user)
            };
        }
    }


}