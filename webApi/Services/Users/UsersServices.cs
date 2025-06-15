
using AutoMapper;
using webApi.Infrastructure;
using webApi.Mapper;

namespace webApi.Services.Users
{
    public class UsersServices : UsersInterface
    {
        public readonly AppDbContext appDbContext;
        public readonly IMapper AutoMapper;
        public UsersServices(AppDbContext appContext, IMapper autoMapper)
        {
            this.appDbContext = appContext;
            AutoMapper = autoMapper;
        }

        public void AddNewUsers(UsersDTO userDTO)
        {
            throw new NotImplementedException();
        }

        public string DeleteUsers(int id)
        {
            throw new NotImplementedException();
        }

        public List<UsersDTO> GetAllUsers()
        {
            
        }

        public UsersDTO GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public string UpdateUsers(int id)
        {
            throw new NotImplementedException();
        }
    }
}
