using System.Collections.Generic;
using System.Threading.Tasks;
using BacalhauResponde.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BacalhauResponde.Controllers
{
    public class UsuarioController : BaseController
    {
        private readonly UserManager<IdentityUser> gerenciadorDeUsuario;
        public UsuarioController(UserManager<IdentityUser> gerenciadorDeUsuario)
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
                var novoUsuario = new IdentityUser
                {
                    UserName = usuarioViewModel.Nome.ToLower(),
                    Email = usuarioViewModel.Email.ToLower()
                };

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
