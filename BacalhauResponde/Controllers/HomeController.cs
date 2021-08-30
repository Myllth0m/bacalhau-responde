using System.Diagnostics;
using System.Threading.Tasks;
using BacalhauResponde.Context;
using BacalhauResponde.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BacalhauResponde.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly BacalhauRespondeContexto contexto;
        public HomeController(BacalhauRespondeContexto contexto)
        {
            this.contexto = contexto;
        }

        public async Task<IActionResult> Index()
        {
            var perguntas = await contexto.Perguntas
                                          .AsNoTracking()
                                          .ToListAsync();

            return View(perguntas);
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
