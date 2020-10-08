using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamRedWebApi.Enitites;
using TeamRedWebApi.Models.ImageModel;

namespace TeamRedWebApi.Models.Profiles
{
#pragma warning disable CS1591
    public class ImageProfile : Profile
    {
        public ImageProfile()
        {
            CreateMap<Image, ImageDto>();
        }
    }
}
