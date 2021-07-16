using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IBaseRepository<TEntidade> where TEntidade : EntidadeBase
    {
        Task<TEntidade> Criar(TEntidade obj);

        Task Excluir(long id);

        Task<TEntidade> BuscarPorId(long id);
    }
}
