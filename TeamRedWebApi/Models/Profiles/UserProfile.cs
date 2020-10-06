using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamRedProject.Enitites;
using TeamRedWebApi.Models.UserModel;

namespace TeamRedWebApi.Profiles
{
#pragma warning disable CS1591
    public class UserProfile : Profile
    {

        public UserProfile()
        {
            CreateMap<User, UserDto>().ForMember(
                    dest => dest.RealEstates,
                    opt => opt.MapFrom(src => src.RealEstates.Count())).ForMember(
                    dest => dest.Comments,
                    opt => opt.MapFrom(src => src.Comments.Count()));

            CreateMap<UserDto, User>();

            CreateMap<CreateUserDto, User>();

            CreateMap<UpdateUser, User>();
        }
    }
#pragma warning restore CS1591
}
