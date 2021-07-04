using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IPerguntaRepository
    {
        Task Criar(Pergunta pergunta);

        Task Alterar(int id, Pergunta pergunta);
        
        Task Excluir(int id);

        Task<Pergunta> BuscarPorId(int id);

        Task<IList<Pergunta>> ListarPorTitulo(string titulo);

        Task<IList<Pergunta>> ListarTodas();
    }
}
