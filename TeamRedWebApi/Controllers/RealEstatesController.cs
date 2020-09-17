using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        public ActionResult<IEnumerable<RealEstateDto>> GetRealEstates()
        {
            var realEstateFromRepo = realEstateRepo.GetRealEstates("0", "10");
            return Ok(_mapper.Map<IEnumerable<RealEstateDto>>(realEstateFromRepo));
        }

        /*
        [HttpGet()]
        public ActionResult<IEnumerable<RealEstateDto>> GetRealEstates([FromQuery] string skip = "", [FromQuery] string take = "10")
        {
            var realEstateFromRepo = realEstateRepo.GetRealEstates(skip, take);
            return Ok(_mapper.Map<IEnumerable<RealEstateDto>>(realEstateFromRepo));
        }*/

        [HttpGet("{realEstateId}", Name = "GetRealEstates")]
        public IActionResult GetRealEstates(int realEstateId)
        {
            var realEstateFromRepo = realEstateRepo.GetRealEstate(realEstateId);

            if (realEstateFromRepo == null) return NotFound();

            return Ok(_mapper.Map<RealEstateDto>(realEstateFromRepo));
        }

        [HttpPost]
        public ActionResult<RealEstateDto> CreateRealEstate(CreateRealEstateDto realEstate)
        {
            var realEstateEntity = _mapper.Map<RealEstate>(realEstate);
            realEstateRepo.AddRealEstate(realEstateEntity);
            realEstateRepo.Save();

            var realEstateToReturn = _mapper.Map<RealEstateDto>(realEstateEntity);
            return CreatedAtRoute("GetRealEstates",
                new { realEstateId = realEstateToReturn.Id }, realEstateToReturn);
        }
    }
}
