using E_Commerce_Shoes.Models;
using E_Commerce_Shoes.Services;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Shoes.Infraestrutura.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ContextDb _context;

        public UsuarioRepository(ContextDb context)
        {
            _context = context;
        }

        public async Task Create(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var obj = await _context.Usuarios.SingleOrDefaultAsync(a => a.Id == id);
            _context.Usuarios.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Usuario>> GetAll()
        {
            return await _context.Usuarios.Include(x => x.Compras).ToListAsync();
        }
    }
}
