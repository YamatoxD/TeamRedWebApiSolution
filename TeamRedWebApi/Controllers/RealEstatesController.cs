using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamRedProject.Enitites;
using TeamRedProject.Services;
using TeamRedWebApi.Models.RealEstateModel;

namespace TeamRedWebApi.Controllers
{
    [Route("api/RealEstates")]
    [ApiController]
    public class RealEstatesController : ControllerBase
    {
        private readonly IRealEstateRepo realEstateRepo;
        private readonly IMapper _mapper;

        public RealEstatesController(IRealEstateRepo realEstateRepo, IMapper mapper)
        {
            this.realEstateRepo = realEstateRepo;
            _mapper = mapper;
        }


        [HttpGet()]
        public ActionResult<IEnumerable<RealEstateDto>> GetRealEstates([FromQuery] int skip = 0, [FromQuery] int take = 10)
        {
            var realEstateFromRepo = realEstateRepo.GetRealEstates(skip, take);
            return Ok(_mapper.Map<IEnumerable<RealEstateDto>>(realEstateFromRepo));
        }

        [HttpGet("{realEstateId}", Name = "GetRealEstates")]
        public IActionResult GetRealEstates(int realEstateId)
        {
            var realEstateFromRepo = realEstateRepo.GetRealEstate(realEstateId);

            if (realEstateFromRepo == null) return NotFound();

            if (User.Identity.IsAuthenticated) return Ok(_mapper.Map<RealEstateDetailsPrivateDto>(realEstateFromRepo));

            return Ok(_mapper.Map<RealEstateDetailsDto>(realEstateFromRepo));
        }

        [Authorize]
        [HttpPost]
        public ActionResult<RealEstateDto> CreateRealEstate(CreateRealEstateDto realEstate)
        {
            var user = realEstateRepo.GetUser(User.Identity.Name);

            var realEstateEntity = _mapper.Map<RealEstate>(realEstate);
            realEstateRepo.AddRealEstate(user.Id, realEstateEntity);
            realEstateRepo.Save();

            var realEstateToReturn = _mapper.Map<RealEstateDto>(realEstateEntity);
            return CreatedAtRoute("GetRealEstates",
                new { realEstateId = realEstateToReturn.Id }, realEstateToReturn);
        }
    }
}
