using Domain.Entities;
using Domain.IRepositories;
using Infra.DataContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class RespostaRepository : IRespostaRepository
    {
        private readonly Context _context;
        public RespostaRepository(Context context) => _context = context;

        public async Task Criar(Resposta resposta)
        {
            _context.Respostas.Add(resposta);
            await _context.SaveChangesAsync();
        }

        public async Task Alterar(int id, Resposta resposta)
        {
            var dadosDaResposta = await BuscarPorId(id);

            dadosDaResposta.AtualizarDados(resposta.Descricao, resposta.Foto);

            _context.Update(resposta);
            await _context.SaveChangesAsync();
        }

        public async Task Excluir(int id)
        {
            var resposta = await BuscarPorId(id);

            _context.Respostas.Remove(resposta);
            await _context.SaveChangesAsync();
        }

        public async Task<Resposta> BuscarPorId(int id)
        {
            return await _context.Respostas.FirstOrDefaultAsync(r => r.Id.Equals(id));
        }

        public async Task<IEnumerable<Resposta>> ListarTodos()
        {
            return await _context.Respostas.AsNoTracking().ToListAsync();
        }
    }
}
