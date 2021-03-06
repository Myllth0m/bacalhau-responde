using BacalhauResponde.Extentions;
using Microsoft.AspNetCore.Identity;

namespace BacalhauResponde.Models
{
    public class Usuario : IdentityUser
    {
        protected Usuario() { }
        public Usuario(
            string nome,
            string email,
            string ocupacao) : base(userName: nome.BuscarPrimeiroNome())
        {
            Nome = nome;
            Email = email;
            Ocupacao = ocupacao;
        }

        public string Nome { get; private set; }
        public string Ocupacao { get; private set; }
    }
}
