using System.ComponentModel.DataAnnotations;

namespace Inboxly.Dtos.LoginDtos
{
    public class SignUpDto
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public IFormFile? ImageFile { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }

        [Range(typeof(bool), "true", "true", ErrorMessage = "Gizlilik politikasını kabul etmelisiniz")]
        public bool AcceptPrivacy { get; set; }
    }
}
