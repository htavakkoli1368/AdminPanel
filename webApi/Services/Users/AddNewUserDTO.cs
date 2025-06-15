namespace webApi.Services.Users
{
    public class AddNewUserDTO
    {
        public string UserName { get; set; }

        public string Passwoed { get; set; }

        public string Role { get; set; }
        public bool IsAdmin { get; set; }
    }
}
