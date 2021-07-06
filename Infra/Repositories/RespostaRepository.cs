using Domain.Entities;
using Domain.IRepositories;
using Infra.DataContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class RespostaRepository : BaseRepository<Resposta>, IRespostaRepository
    {
        private readonly Context _context;
        public RespostaRepository(Context context) : base(context) => _context = context;


        public async Task Alterar(int id, Resposta resposta)
        {
            var dadosDaResposta = await BuscarPorId(id);

            dadosDaResposta.AtualizarDados(resposta.Descricao, resposta.Foto);

            _context.Update(dadosDaResposta);
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
    }
}
