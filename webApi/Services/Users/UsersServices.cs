
using AutoMapper;
using System.Linq;
using webApi.Infrastructure;
using webApi.Mapper;
using webApi.Model;
using webApi.Services.Users.Responses;


namespace webApi.Services.Users
{
    public class UsersServices : IUsersInterface
    {
        public readonly AppDbContext appDbContext;
        public readonly IMapper autoMapper;
        public UsersServices(AppDbContext appContext ,IMapper autoMapper)
        {
            this.appDbContext = appContext;
            this.autoMapper = autoMapper;
        }

        public ResultDto AddNewUsers(UsersDTO userDTO)
        {
            var users = appDbContext.usersSample.FirstOrDefault(c => c.Id == userDTO.Id);
            if (users != null)
                throw new Exception("the user you want to add exist");
            var convertedUsers = autoMapper.Map<Model.Users>(userDTO);
            appDbContext.usersSample.Add(convertedUsers);
            appDbContext.SaveChanges();              
            return new ResultDto() { IsSuccess = true ,Message="the user successfully added to the database"};
        }

        public ResultDto DeleteUsers(int id)
        {

            return new ResultDto { IsSuccess = true, Message = "the user successfully updated" };
        }

        public List<UsersDTO> GetAllUsers()
        {
             var allusers = appDbContext.usersSample.ToList();
            if (allusers == null)
                throw new Exception("there is no users in database");
            var convertedUsers = autoMapper.Map<List<UsersDTO>>(allusers);
            return convertedUsers;
        }

        public UsersDTO GetUser(int id)
        {
            var users = appDbContext.usersSample.FirstOrDefault(c=>c.Id == id);
            if (users == null)
                throw new Exception("the user not found");
            var convertedUsers =  new UsersDTO() { Id=users.Id,IsAdmin=users.IsAdmin,Passwoed=users.Passwoed,Role=users.Role,UserName=users.UserName};
            return convertedUsers;
        }

        public ResultDto UpdateUsers(int id)
        {
            return new ResultDto { IsSuccess = true, Message = "the user successfully updated" };
        }
    }
}
