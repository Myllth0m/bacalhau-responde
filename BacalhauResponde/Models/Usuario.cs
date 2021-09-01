using Microsoft.AspNetCore.Identity;

namespace BacalhauResponde.Models
{
    public class Usuario : IdentityUser
    {
        protected Usuario() { }
        public Usuario(
            string nome,
            string email) : base(userName: nome.Replace(" ", string.Empty))
        {
            Nome = nome;
            Email = email;
        }

        public string Nome { get; private set; }
    }
}
