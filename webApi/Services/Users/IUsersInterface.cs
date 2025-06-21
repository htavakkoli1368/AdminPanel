using webApi.Services.Users.Responses;

namespace webApi.Services.Users
{
    public interface IUsersInterface
    {
        List<UsersDTO> GetAllUsers();

        ResultDto AddNewUsers(UsersDTO userDTO);
        UsersDTO GetUser(int id);
        ResultDto DeleteUsers(int id);
        ResultDto UpdateUsers(int id);

    }
}
