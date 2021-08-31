using System.Linq;
using System.Threading.Tasks;
using BacalhauResponde.Context;
using BacalhauResponde.Historias.Usuario;
using BacalhauResponde.Models;
using BacalhauResponde.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BacalhauResponde.Controllers
{
    [Authorize]
    public class PerguntaController : BaseController
    {
        private readonly BacalhauRespondeContexto contexto;
        private readonly IServicoDeUsuario servicoDeUsuario;
        public PerguntaController(
            BacalhauRespondeContexto contexto,
            IServicoDeUsuario servicoDeUsuario)
        {
            this.contexto = contexto;
            this.servicoDeUsuario = servicoDeUsuario;
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(PerguntaViewModel perguntaViewModel)
        {
            var novaPergunta = new Pergunta(
                id: perguntaViewModel.Id,
                usuarioId: servicoDeUsuario.ObterId(),
                titulo: perguntaViewModel.Titulo,
                descricao: perguntaViewModel.Descricao,
                foto: string.Empty
                );

            await contexto.AddAsync(novaPergunta);
            await contexto.SaveChangesAsync();

            return View(perguntaViewModel);
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
