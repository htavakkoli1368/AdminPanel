using AutoMapper;
using webApi.Model;
using webApi.Services.Users;

namespace webApi.Mapper
{
    public class UsersAutoMapper : Profile
    {
        public UsersAutoMapper()
        {
            CreateMap<Users,UsersDTO>().ReverseMap();
          //  CreateMap<UsersDTO,Users>();
        }
    }
}
