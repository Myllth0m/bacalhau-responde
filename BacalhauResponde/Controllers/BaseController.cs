using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BacalhauResponde.Controllers
{
    public class BaseController : Controller
    {
        public object NotificarSucesso(string mensagem = "")
        {
            if (string.IsNullOrEmpty(mensagem))
                TempData["sucesso"] = "Ação realizada com sucesso!";
            else
                TempData["sucesso"] = mensagem;

            return TempData["sucesso"];
        }

        public object NotificarErros(IEnumerable<string> erros)
        {
            if (erros.Any())
                TempData["erros"] = JsonSerializer.Serialize(erros);
            else
                TempData["erros"] = "Algo deu errado! Tente novamente. Se o problema persistir, contate a administração";

            return TempData["erros"];
        }

        public object NotificarAtencao(string mensagem = "")
        {
            TempData["atencao"] = mensagem;

            return TempData["atencao"];
        }

        public object NotificarInformacao(string mensagem = "")
        {
            TempData["informacao"] = mensagem;

            return TempData["informacao"];
        }

        public void NotificarErrosDaModelState()
        {
            var erros = new List<string>();

            ModelState.Values.ToList().ForEach(x => x.Errors.ToList().ForEach(x => erros.Add(x.ErrorMessage)));

            NotificarErros(erros);
        }

        public void Notificar(Dictionary<string, string> erros)
        {
            if (!erros.Any())
                NotificarSucesso();
            else
                NotificarErros(erros.Values);
        }
    }
}
