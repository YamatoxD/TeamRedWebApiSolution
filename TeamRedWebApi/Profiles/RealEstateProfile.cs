using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamRedProject.Enitites;
using TeamRedWebApi.Models.RealEstateModel;

namespace TeamRedWebApi.Profiles
{
    public class RealEstateProfile : Profile
    {
        public RealEstateProfile()
        {
            CreateMap<RealEstate, RealEstateDto>();
            CreateMap<RealEstate, RealEstateDetailsDto>();
            CreateMap<RealEstate, RealEstateDetailsPrivateDto>();
            CreateMap<CreateRealEstateDto, RealEstate>();
        }
    }
}
