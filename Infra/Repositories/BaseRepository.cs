using Domain.Entities;
using Infra.DataContext;
using Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class BaseRepository<TEntidade> : IBaseRepository<TEntidade> where TEntidade : EntidadeBase
    {
        private readonly Context _context;
        public BaseRepository(Context context) => _context = context;

        public virtual async Task<TEntidade> Criar(TEntidade entidade)
        {
            _context.Add(entidade);
            await _context.SaveChangesAsync();

            return entidade;
        }

        public virtual async Task Excluir(long id)
        {
            var obj = await BuscarPorId(id);
            
            if(obj != null)
                _context.Remove(obj);

            await _context.SaveChangesAsync();
        }

        public virtual async Task<TEntidade> BuscarPorId(long id)
        {
            return await _context.Set<TEntidade>().AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(id));
        }
    }
}
