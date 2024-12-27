using E_Commerce_Shoes.Models;

namespace E_Commerce_Shoes.Services
{
    public interface IUsuarioRepository
    {
        Task Create(Usuario usuario);
        Task<List<Usuario>> GetAll();
        Task Delete(int id);
    }
}
