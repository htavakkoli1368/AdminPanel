
using AutoMapper;
using System.Linq;
using webApi.Infrastructure;
using webApi.Mapper;
using webApi.Model;


namespace webApi.Services.Users
{
    public class UsersServices : IUsersInterface
    {
        public readonly AppDbContext appDbContext;
       // public readonly IMapper autoMapper;
        public UsersServices(AppDbContext appContext )
        {
            this.appDbContext = appContext;
            //this.autoMapper = autoMapper;
        }

        public void AddNewUsers(UsersDTO userDTO)
        {
            var users = appDbContext.usersSample.FirstOrDefault(c => c.Id == userDTO.Id);
            if (users != null)
                throw new Exception("the user you want to add exist");
            var convertedUsers = new Model.Users() { IsAdmin = userDTO.IsAdmin, Passwoed = userDTO.Passwoed, Role = userDTO.Role, UserName = userDTO.UserName };
            appDbContext.usersSample.Add(convertedUsers);
            appDbContext.SaveChanges();          
        }

        public string DeleteUsers(int id)
        {
            throw new NotImplementedException();
        }

        public List<Model.Users> GetAllUsers()
        {
             var allusers = appDbContext.usersSample.ToList();
            if (allusers == null)
                throw new Exception("there is no users in database");
            return allusers;
        }

        public UsersDTO GetUser(int id)
        {
            var users = appDbContext.usersSample.FirstOrDefault(c=>c.Id == id);
            if (users == null)
                throw new Exception("the user not found");
            var convertedUsers =  new UsersDTO() { Id=users.Id,IsAdmin=users.IsAdmin,Passwoed=users.Passwoed,Role=users.Role,UserName=users.UserName};
            return convertedUsers;
        }

        public string UpdateUsers(int id)
        {
            throw new NotImplementedException();
        }
    }
}
