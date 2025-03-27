using API.Entidades;
using API.Interface;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class UsuarioRepository(DataContext context) : IUsuarioRepository
    {
        public Task<Usuario> GetUsuarioById(int id)
        {
            return context.Usuarios.FirstOrDefaultAsync(u => u.Id == id)!;
        }

        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            return await context.Usuarios.ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }

        public void update(Usuario usuario)
        {
            context.Entry(usuario).State = EntityState.Modified;
        }
    }
}