using System;
using System.Threading.Tasks;
using BacalhauResponde.Models;
using BacalhauResponde.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BacalhauResponde.Controllers
{
    public class AutenticacaoController : Controller
    {
        private readonly UserManager<Usuario> gerenciadorDeUsuario;
        private readonly SignInManager<Usuario> gerenciadorDeAcesso;
        public AutenticacaoController(
            UserManager<Usuario> gerenciadorDeUsuario,
            SignInManager<Usuario> gerenciadorDeAcesso)
        {
            this.gerenciadorDeUsuario = gerenciadorDeUsuario;
            this.gerenciadorDeAcesso = gerenciadorDeAcesso;
        }

        public IActionResult Entrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Entrar(LoginViewModel loginViewModel)
        {
            var usuario = await gerenciadorDeUsuario.FindByEmailAsync(loginViewModel.Email);

            var resultadoDaTentativaDeLogin = await gerenciadorDeAcesso.PasswordSignInAsync(usuario, loginViewModel.Senha, false, true);

            if (resultadoDaTentativaDeLogin.Succeeded)
                return RedirectToAction(nameof(Index), nameof(HomeController));
            else
            {
                TempData["ERRO"] = "Verifique se o login e a senha estão corretos";
                return View(loginViewModel);
            }
        }

        public async Task<IActionResult> Sair()
        {
            await gerenciadorDeAcesso.SignOutAsync();

            return RedirectToAction(nameof(Entrar));
        }
    }
}
