using Microsoft.AspNetCore.Identity;

namespace Inboxly.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? AvatarImage { get; set; }
        public int ConfirmCode { get; set; }
    }
}
