

using Domain.Entities;
using Infra.DataContext;
using Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Base
    {
        private readonly Context _context;

        public BaseRepository(Context context)
        {
            _context = context;
        }

        public virtual async Task<T> Criar(T obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();

            return obj;
        }


        public virtual async Task Excluir(int id)
        {
            var obj = await BuscarPorId(id);
            if(obj != null)
                _context.Remove(obj);
                await _context.SaveChangesAsync();
        }

        public virtual async Task<T> BuscarPorId(int id)
        {
            return await _context.Set<T>()
                           .AsNoTracking()
                           .FirstOrDefaultAsync(x => x.Id.Equals(id));
        }
    }
}
