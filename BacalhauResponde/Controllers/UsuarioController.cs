using System.Collections.Generic;
using System.Threading.Tasks;
using BacalhauResponde.Models;
using BacalhauResponde.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BacalhauResponde.Controllers
{
    public class UsuarioController : BaseController
    {
        private readonly UserManager<Usuario> gerenciadorDeUsuario;
        public UsuarioController(UserManager<Usuario> gerenciadorDeUsuario)
        {
            this.gerenciadorDeUsuario = gerenciadorDeUsuario;
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(UsuarioViewModel usuarioViewModel)
        {
            if (ModelState.IsValid)
            {
                var novoUsuario = new Usuario(
                    nome: usuarioViewModel.Nome,
                    email: usuarioViewModel.Email.ToLower()
                );

                var resultadoDaCriacaoDeUsuario = await gerenciadorDeUsuario.CreateAsync(novoUsuario, usuarioViewModel.Senha);

                if (resultadoDaCriacaoDeUsuario.Succeeded)
                {
                    NotificarSucesso();
                    return RedirectToAction("Entrar", "Autenticacao");
                }
            }

            NotificarErros(new List<string>() { "Não foi possível cadastrar um novo usuário" });
            return View(usuarioViewModel);
        }
    }
}
