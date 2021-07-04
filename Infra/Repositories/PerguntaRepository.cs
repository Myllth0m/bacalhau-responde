using Domain.Entities;
using Domain.IRepositories;
using Infra.DataContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class PerguntaRepository : IPerguntaRepository
    {
        private readonly Context _context;
        public PerguntaRepository(Context context) => _context = context;

        public async Task Criar(Pergunta pergunta)
        {
            _context.Perguntas.Add(pergunta);
            await _context.SaveChangesAsync();
        }

        public async Task Alterar(int id, Pergunta pergunta)
        {
            var dadosDaPergunta = await BuscarPorId(id);

            dadosDaPergunta.AtualizarDados(pergunta.Titulo, pergunta.Descricao, pergunta.Foto);

            _context.Perguntas.Update(dadosDaPergunta);
            await _context.SaveChangesAsync();
        }
        
        public async Task Excluir(int id)
        {
            var pergunta = await BuscarPorId(id);

            _context.Perguntas.Remove(pergunta);
            await _context.SaveChangesAsync();
        }

        public async Task<Pergunta> BuscarPorId(int id)
        {
            return await _context.Perguntas.FirstOrDefaultAsync(p => p.Id.Equals(id));
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
