using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamRedProject.Enitites;
using TeamRedWebApi.Models.CommentModel;

namespace TeamRedWebApi.Profiles
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, CommentDto>().ForMember(
                    dest => dest.UserName,
                    opt => opt.MapFrom(src => $"{src.Creator.UserName}"));
            CreateMap<CreateCommentDto, Comment>();
        }
    }
}
