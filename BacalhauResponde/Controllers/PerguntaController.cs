using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BacalhauResponde.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BacalhauResponde.Controllers
{
    public class PerguntaController : Controller
    {
        private readonly BacalhauRespondeContexto contexto;
        public PerguntaController(BacalhauRespondeContexto contexto)
        {
            this.contexto = contexto;
        }

        public async Task<IActionResult> ListarTodasAsPerguntas()
        {
            var listaDePerguntas = await contexto.Perguntas.AsNoTracking()
                                                           .ToListAsync();

            return View(listaDePerguntas);
        }

        public async Task<IActionResult> ListarPerguntasPorTitulo(string titulo)
        {
            var listaDePerguntasPorTitulo = await contexto.Perguntas.AsNoTracking()
                                                                    .Where(p => p.Titulo.ToLower().Contains(titulo.ToLower()))
                                                                    .ToListAsync();

            return View(listaDePerguntasPorTitulo);
        }

        public async Task<IActionResult> BuscarPerguntaComRespostas(long id)
        {
            var perguntaComRespostas = await contexto.Perguntas.AsNoTracking()
                                                               .Include(p => p.Respostas)
                                                               .FirstOrDefaultAsync(p => p.Id.Equals(id));

            return View(perguntaComRespostas);
        }

        public async Task<IActionResult> AtualizarPergunta(long id)
        {
            var pergunta = await contexto.Perguntas.FirstOrDefaultAsync(p => p.Id.Equals(id));

            return View(pergunta);
        }
    }
}
