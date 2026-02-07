namespace Inboxly.Dtos.LoginDtos
{
    public class SignInDto
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool RememberMe { get; set; }
        public int ConfirmCode { get; set; }
    }
}
