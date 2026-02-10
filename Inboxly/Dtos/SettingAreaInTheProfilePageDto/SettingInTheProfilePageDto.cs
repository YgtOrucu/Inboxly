namespace Inboxly.Dtos.SettingAreaInTheProfilePageDto
{
    public class SettingInTheProfilePageDto
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? PhoneNumber { get; set; }
        public string? About { get; set; }
        public string? Address { get; set; }
        public string? Location { get; set; }
        public string? AvatarImage { get; set; }
        public IFormFile? ImageFile { get; set; }

    }
}
