using Domain.Entities;
using Infra.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IPerguntaRepository : IBaseRepository<Pergunta>
    {
        Task Alterar(int id, Pergunta pergunta);
        Task<Pergunta> BuscarComRespostas(int id);

        Task<IList<Pergunta>> ListarPorTitulo(string titulo);

        Task<IList<Pergunta>> ListarTodas();
    }
}
