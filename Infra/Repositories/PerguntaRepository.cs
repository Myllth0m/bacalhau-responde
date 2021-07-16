using Domain.Entities;
using Domain.IRepositories;
using Infra.DataContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class PerguntaRepository : BaseRepository<Pergunta>, IPerguntaRepository
    {
        private readonly Context _context;
        public PerguntaRepository(Context context) : base(context) => _context = context;


        public async Task Alterar(long id, Pergunta pergunta)
        {
            var dadosDaPergunta = await BuscarPorId(id);

            dadosDaPergunta.AtualizarDados(pergunta.Titulo, pergunta.Descricao, pergunta.Foto);

            _context.Perguntas.Update(dadosDaPergunta);
            await _context.SaveChangesAsync();
        }

        public async Task<Pergunta> BuscarComRespostas(long id)
        {
            return await _context.Perguntas.AsNoTracking().Include(p => p.Respostas).FirstOrDefaultAsync(p => p.Id.Equals(id));
        }

        public async Task<IList<Pergunta>> ListarPorTitulo(string titulo)
        {
            return await _context.Perguntas.AsNoTracking().Where(p => p.Titulo.ToLower().Contains(titulo.ToLower())).ToListAsync();
        }

        public async Task<IList<Pergunta>> ListarTodas()
        {
            return await _context.Perguntas.AsNoTracking().ToListAsync();
        }
    }
}
