using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamRedProject.Enitites;
using TeamRedWebApi.Models.UserModel;

namespace TeamRedWebApi.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
           // CreateMap<CreateUserDto, User>();
            CreateMap<UpdateUser, User>();

        }
    }
}
