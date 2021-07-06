using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IRespostaRepository
    {
        Task Criar(Resposta resposta);

        Task Alterar(int id, Resposta resposta);

        Task Excluir(int id);

        Task<Resposta> BuscarPorId(int id);
    }
}
