
using AutoMapper;
using System.Linq;
using webApi.Infrastructure;
using webApi.Mapper;
using webApi.Model;


namespace webApi.Services.Users
{
    public class UsersServices : UsersInterface
    {
        public readonly AppDbContext appDbContext;
        public readonly IMapper autoMapper;
        public UsersServices(AppDbContext appContext, IMapper autoMapper)
        {
            this.appDbContext = appContext;
            this.autoMapper = autoMapper;
        }

        public void AddNewUsers(UsersDTO userDTO)
        {
            var users = appDbContext.usersSample.FirstOrDefault(c => c.Id == userDTO.Id);
            if (users != null)
                throw new Exception("the user you want to add exist");
            var convertedUsers = autoMapper.Map<Model.Users>(userDTO);
            appDbContext.usersSample.Add(convertedUsers);
            appDbContext.SaveChanges();          
        }

        public string DeleteUsers(int id)
        {
            throw new NotImplementedException();
        }

        public List<UsersDTO> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public UsersDTO GetUser(int id)
        {
            var users = appDbContext.usersSample.FirstOrDefault(c=>c.Id == id);
            if (users == null)
                throw new Exception("the user not found");
            var convertedUsers = autoMapper.Map<UsersDTO>(users);
            return convertedUsers;
        }

        public string UpdateUsers(int id)
        {
            throw new NotImplementedException();
        }
    }
}
