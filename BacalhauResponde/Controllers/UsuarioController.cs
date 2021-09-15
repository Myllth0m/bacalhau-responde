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
        public UsuarioController(UserManager<Usuario> gerenciadorDeUsuario) => this.gerenciadorDeUsuario = gerenciadorDeUsuario;

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
                    email: usuarioViewModel.Email.ToLower(),
                    ocupacao: usuarioViewModel.Ocupacao);

                var resultadoDaCriacaoDeUsuario = await gerenciadorDeUsuario.CreateAsync(novoUsuario, usuarioViewModel.Senha);

                if (resultadoDaCriacaoDeUsuario.Succeeded)
                {
                    NotificarSucesso("cadastro criado com sucesso");
                    
                    return RedirectToAction("Entrar", "Autenticacao");
                }
            }

            NotificarErro("Não foi possível concluir seu cadastro!");
            
            return View(usuarioViewModel);
        }
    }
}
