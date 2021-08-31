using System.Collections.Generic;
using System.Diagnostics;
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
    public class HomeController : BaseController
    {
        private readonly BacalhauRespondeContexto contexto;
        public HomeController(BacalhauRespondeContexto contexto)
        {
            this.contexto = contexto;
        }

        public async Task<IActionResult> Index()
        {
            var listaDePerguntas = await contexto.Perguntas
                                          .AsNoTracking()
                                          .Include(x => x.Usuario)
                                          .ToListAsync();

            var dashBoardViewModel = new List<DashBoardViewModel>();

            foreach (var pergunta in listaDePerguntas)
            {
                dashBoardViewModel.Add(new DashBoardViewModel
                {
                    UsuarioDaPergunta = pergunta.Usuario.UserName,
                    DataDeAtualizacao = pergunta.DataDeAtualizacao,
                    PerguntaId = pergunta.Id,
                    Titulo = pergunta.Titulo,
                    Descricao = pergunta.Descricao,
                });
            }

            ViewBag.PerguntaViewModel = new PerguntaViewModel();

            return View(dashBoardViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
