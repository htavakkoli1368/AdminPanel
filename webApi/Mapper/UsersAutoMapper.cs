using AutoMapper;
using webApi.Model;
using webApi.Services.Users;

namespace webApi.Mapper
{
    public class UsersAutoMapper : Profile
    {
        protected UsersAutoMapper()
        {
            CreateMap<Users,UsersDTO>().ReverseMap();
        }
    }
}
