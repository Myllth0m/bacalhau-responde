using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IPerguntaRepository : IBaseRepository<Pergunta>
    {
        Task Alterar(long id, Pergunta pergunta);

        Task<Pergunta> BuscarComRespostas(long id);

        Task<IList<Pergunta>> ListarPorTitulo(string titulo);

        Task<IList<Pergunta>> ListarTodas();
    }
}
