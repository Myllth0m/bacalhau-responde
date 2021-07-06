using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IRespostaRepository : IBaseRepository<Resposta>
    {
        Task Alterar(int id, Resposta resposta);

    }
}
