
using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
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
        private readonly IMemoryCache memoryCache;

        public UsersServices(AppDbContext appContext ,IMapper autoMapper,IMemoryCache memoryCache)
        {
            this.appDbContext = appContext;
            this.autoMapper = autoMapper;
            this.memoryCache = memoryCache;
        }

        public ResultDto AddNewUsers(UsersDTO userDTO)
        {
            try
            {
                var users = appDbContext.usersSample.FirstOrDefault(c => c.Id == userDTO.Id);
                if (users != null)
                    return new ResultDto { IsSuccess = false, Message = "the selected user exist" };
                var convertedUsers = autoMapper.Map<Model.UsersModel>(userDTO);
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
        public List<UsersDTO> GetAllUsersByCache()
        {
            const string cacheKey = "userList";
            bool fromCache = true;
            // Try to get data from cache
            if (!memoryCache.TryGetValue(cacheKey, out List<UsersModel> users))
            {
                // Not in cache, so fetch from repository
                users =  appDbContext.usersSample.ToList();

                // Store in cache, set expiration time (e.g., 5 minutes)
                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(5))
                    .SetSlidingExpiration(TimeSpan.FromMinutes(2));

                memoryCache.Set(cacheKey, users, cacheOptions);
                fromCache = false;
            }
            if (users is null)
                return new List<UsersDTO>();
           var convertedUsers = autoMapper.Map<List<UsersDTO>>(users);
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
            var convertedData = JsonConvert.DeserializeObject<ExternalUserDTO>(response.Content);
            return convertedData;
        }

     
    }
}
