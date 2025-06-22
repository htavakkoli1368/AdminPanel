namespace webApi.Services.Users
{
    public class UsersUpdateDTO
    {         

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }
        public bool IsAdmin { get; set; }
    }
}
