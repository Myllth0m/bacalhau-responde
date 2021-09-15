using System.Security.Claims;
using System.Threading.Tasks;
using BacalhauResponde.Context;
using BacalhauResponde.Models;
using BacalhauResponde.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BacalhauResponde.Controllers
{
    public class RespostaController : BaseController
    {
        private readonly BacalhauRespondeContexto contexto;
        public RespostaController(BacalhauRespondeContexto contexto) => this.contexto = contexto;

        public async Task<IActionResult> AdicionarResposta(CriarRespostaViewModel respostaViewModel)
        {
            if (ModelState.IsValid)
            {
                var novaResposta = new Resposta(
                    id: respostaViewModel.Id,
                    perguntaId: respostaViewModel.PerguntaId,
                    usuarioId: User.FindFirstValue(ClaimTypes.NameIdentifier),
                    descricao: respostaViewModel.Descricao,
                    foto: string.Empty);

                await contexto.AddAsync(novaResposta);
                await contexto.SaveChangesAsync();

                NotificarSucesso("Sua resposta foi adicionada com sucesso!");
            }
            else
                NotificarErro("Não foi possível adicionar sua resposta!");

            return RedirectToAction("BuscarPerguntaComRespostas", "Pergunta", new { respostaViewModel.PerguntaId });
        }
    }
}
