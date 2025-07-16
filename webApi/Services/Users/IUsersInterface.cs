using webApi.Model;
using webApi.Services.Users.Responses;

namespace webApi.Services.Users
{
    public interface IUsersInterface
    {
        //Done
        List<UsersDTO> GetAllUsers();
        List<UsersDTO> GetAllUsersByCache();
        //Done
        ResultDto AddNewUsers(UsersDTO userDTO);
        //Done
        UsersDTO GetUser(int id);
        ExternalUserDTO GetUserExternal();
        ResultDto DeleteUsers(int id);
        //Done
        ResultDto UpdateUsers(int id,UsersUpdateDTO usersUpdate);
        //Done
        bool checkUserExist(int id);

    }
}
