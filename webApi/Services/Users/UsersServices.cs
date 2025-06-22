
using AutoMapper;
using Newtonsoft.Json;
using RestSharp;
using System.Linq;
using webApi.Infrastructure;
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
            try
            {
                var users = appDbContext.usersSample.FirstOrDefault(c => c.Id == userDTO.Id);
                if (users != null)
                    return new ResultDto { IsSuccess = false, Message = "the selected user exist" };
                var convertedUsers = autoMapper.Map<Model.Users>(userDTO);
                appDbContext.usersSample.Add(convertedUsers);
                appDbContext.SaveChanges();
                return new ResultDto() { IsSuccess = true, Message = "the user successfully added to the database" };
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message);  
            }         
        }

        public ResultDto DeleteUsers(int id)
        {
            try
            {
                var userExist = appDbContext.usersSample.FirstOrDefault(u => u.Id == id);
                if (userExist == null)
                   return new ResultDto { IsSuccess = false, Message = "the selected user is not exist" };
                appDbContext.usersSample.Remove(userExist);
                appDbContext.SaveChanges();
                return new ResultDto { IsSuccess = true, Message = "the user successfully Deleted" };
            }
            catch (Exception exp)
            {
              throw new Exception(exp.Message);             
            }
                     
        }

        public List<UsersDTO> GetAllUsers()
        {            
            var allusers = appDbContext.usersSample.ToList();
            if (allusers == null || allusers.Count == 0)
                return new List<UsersDTO>(){};
            var convertedUsers = autoMapper.Map<List<UsersDTO>>(allusers);
            return convertedUsers;                    
        }

        public UsersDTO GetUser(int id)
        {
            try
            {
                var users = appDbContext.usersSample.FirstOrDefault(c => c.Id == id);
                if (users == null)
                    return new UsersDTO() { };
                var convertedUsers = autoMapper.Map<UsersDTO>(users);
                return convertedUsers;
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message);
            }         
        }

        public ResultDto UpdateUsers(int id, UsersUpdateDTO usersUpdate)
        {
            try
            {
                var userExist = appDbContext.usersSample.FirstOrDefault(u => u.Id == id);
                if (userExist == null)
                    return new ResultDto { IsSuccess = false, Message = "the selected user is not exist" };
                else
                {
                    userExist.IsAdmin = usersUpdate.IsAdmin;
                    userExist.Password = usersUpdate.Password;
                    userExist.Role = usersUpdate.Role;
                    userExist.UserName = usersUpdate.UserName;
                    appDbContext.SaveChanges();
                }
                return new ResultDto { IsSuccess = true, Message = "the user successfully Updated" };
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message); 
            }
       
        }

        public bool checkUserExist(int id)
        {
            return appDbContext.usersSample.Any(u=>u.Id == id);
        }

        public ExternalUserDTO GetUserExternal()
        {
            var options = new RestClientOptions("https://jsonplaceholder.typicode.com")
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("/todos/1", Method.Get);
            RestResponse response =  client.Execute(request);
            Console.WriteLine(response.Content);
            var convertedData = JsonConvert.DeserializeObject<ExternalUserDTO>(response.Content);
            return convertedData;
        }

     
    }
}
