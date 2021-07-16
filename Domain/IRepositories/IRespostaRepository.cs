using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IRespostaRepository : IBaseRepository<Resposta>
    {
        Task Alterar(long id, Resposta resposta);
    }
}
