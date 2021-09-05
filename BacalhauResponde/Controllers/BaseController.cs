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

        public object NotificarErro(string mensagem = "")
        {
            if (string.IsNullOrEmpty(mensagem))
                TempData["erro"] = "Algo deu errado! Tente novamente. Se o problema persistir, contate a administração";
            else
                TempData["erro"] = mensagem;

            return TempData["erro"];
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
    }
}
