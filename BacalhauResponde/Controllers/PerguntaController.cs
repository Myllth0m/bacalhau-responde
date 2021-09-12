using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BacalhauResponde.Context;
using BacalhauResponde.Models;
using BacalhauResponde.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BacalhauResponde.Controllers
{
    [Authorize]
    public class PerguntaController : BaseController
    {
        private readonly BacalhauRespondeContexto contexto;
        public PerguntaController(BacalhauRespondeContexto contexto) => this.contexto = contexto;

        [HttpPost]
        public async Task<IActionResult> Cadastrar(CriarPerguntaViewModel perguntaViewModel)
        {
            if (ModelState.IsValid)
            {
                var novaPergunta = new Pergunta(
                    id: perguntaViewModel.Id,
                    usuarioId: User.FindFirstValue(ClaimTypes.NameIdentifier),
                    titulo: perguntaViewModel.Titulo,
                    descricao: perguntaViewModel.Descricao,
                    foto: string.Empty
                    );

                await contexto.AddAsync(novaPergunta);
                await contexto.SaveChangesAsync();

                NotificarSucesso("Sua pergunta foi adicionada com sucesso!");
            }
            else
                NotificarErro("Não foi possível adicionar sua pergunta!");

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> BuscarPerguntaComRespostas(long perguntaId)
        {
            var perguntaComListDeRespostas = await contexto.Perguntas.AsNoTracking()
                                                               .Include(p => p.Usuario)
                                                               .Include(p => p.Respostas)
                                                                   .ThenInclude(p => p.Usuario)
                                                               .FirstOrDefaultAsync(p => p.Id.Equals(perguntaId));

            var listaDeRespostasDaPergunta = new List<RespostaViewModel>();

            foreach (var resposta in perguntaComListDeRespostas.Respostas)
            {
                listaDeRespostasDaPergunta.Add(new RespostaViewModel
                {
                    DataDeCricaoDaResposta = resposta.DataDeCriacao,
                    UsuarioDaResposta = resposta.Usuario.Nome,
                    OcupacaoDoUsuario = resposta.Usuario.Ocupacao,
                    RespostaId = resposta.Id,
                    Descricao = resposta.Descricao
                });
            }

            var perguntaComRespostas = new PerguntaComRespostasViewModel
            {
                UsuarioDaPergunta = perguntaComListDeRespostas.Usuario.Nome,
                OcupacaoDoUsuario = perguntaComListDeRespostas.Usuario.Ocupacao,
                DataDeCricaoDaPergunta = perguntaComListDeRespostas.DataDeCriacao,
                PerguntaId = perguntaComListDeRespostas.Id,
                Titulo = perguntaComListDeRespostas.Titulo,
                Descricao = perguntaComListDeRespostas.Descricao,

                Respostas = listaDeRespostasDaPergunta
            };

            ViewBag.RespostaViewModel = new CriarRespostaViewModel() { PerguntaId = perguntaId };

            return View("PerguntaComRespostas", perguntaComRespostas);
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

        public async Task<IActionResult> AtualizarPergunta(long id)
        {
            var pergunta = await contexto.Perguntas.FirstOrDefaultAsync(p => p.Id.Equals(id));

            return View(pergunta);
        }
    }
}
