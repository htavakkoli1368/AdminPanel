namespace webApi.Services.Users
{
    public interface IUsersInterface
    {
        List<UsersDTO> GetAllUsers();

        void AddNewUsers(UsersDTO userDTO);
        UsersDTO GetUser(int id);
        string DeleteUsers(int id);
        string UpdateUsers(int id);

    }
}
