using E_Commerce_Shoes.Models;
using E_Commerce_Shoes.Services;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Shoes.Infraestrutura.Repositories
{
    public class CompraRepository : ICompraRepository
    {
        private readonly ContextDb _context;

        public CompraRepository(ContextDb context)
        {
            _context = context;
        }

        public async Task Create(Compra compra)
        {
            await _context.Compras.AddAsync(compra);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var obj = await _context.Compras.SingleOrDefaultAsync(a => a.Id == id);
            _context.Compras.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Compra>> GetAll()
        {
            return await _context.Compras.Include(x => x.Usuario).ToListAsync();
        }
    }
}
