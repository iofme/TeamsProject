using API.Entidades;

namespace API.Interface
{
    public interface IUsuarioRepository
    {
        Task<Usuario> GetUsuarioById(int id);
        Task<Usuario> GetUsuarioByUsername(string username);
        Task<IEnumerable<Usuario>> GetUsuarios();
        Task<bool> SaveAllAsync();
        void update(Usuario usuario);
    }
}