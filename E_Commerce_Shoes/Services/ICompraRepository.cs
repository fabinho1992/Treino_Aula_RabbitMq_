using E_Commerce_Shoes.Models;

namespace E_Commerce_Shoes.Services
{
    public interface ICompraRepository
    {
        Task Create(Compra compra);
        Task<List<Compra>> GetAll();
        Task Delete(int id);
    }
}
