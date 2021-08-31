using System.Linq;
using Microsoft.AspNetCore.Http;

namespace BacalhauResponde.Historias.Usuario
{
    public class ServicoDeUsuario : IServicoDeUsuario
    {
        private readonly IHttpContextAccessor gerenciadorDeAcesso;
        public ServicoDeUsuario(IHttpContextAccessor gerenciadorDeAcesso) => this.gerenciadorDeAcesso = gerenciadorDeAcesso;

        public string ObterId()
        {
            var id = gerenciadorDeAcesso.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("Id"));

            return id != null ? id.Value : string.Empty;
        }

        public string ObterPerfil()
        {
            var perfil = gerenciadorDeAcesso.HttpContext.User.Claims.Where(x => x.Type.Equals("Perfil")).ToList();

            return perfil.Any() ? perfil.FirstOrDefault().Value : string.Empty;
        }

        public string ObterEmail()
        {
            var email = gerenciadorDeAcesso.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("Email"));

            return email != null ? email.Value : string.Empty;
        }

        public string ObterNome()
        {
            var nome = gerenciadorDeAcesso.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("Nome"));

            return nome != null ? nome.Value : string.Empty;
        }
    }
}
