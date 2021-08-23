using Microsoft.AspNetCore.Identity;

namespace BacalhauResponde.Models
{
    public class Usuario : IdentityUser
    {
        public Usuario(
            string nome,
            string email)
        {
            Name = nome;
            Email = email;
        }

        public string Name { get; private set; }
    }
}
