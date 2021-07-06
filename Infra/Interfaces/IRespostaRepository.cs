using Domain.Entities;
using Infra.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IRespostaRepository : IBaseRepository<Resposta>
    {
        Task Alterar(int id, Resposta resposta);
        Task<IEnumerable<Resposta>> ListarTodos();
    }
}
