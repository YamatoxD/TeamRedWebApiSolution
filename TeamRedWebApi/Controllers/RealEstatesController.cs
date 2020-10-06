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
#pragma warning disable CS1591
    [Route("api/RealEstates")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class RealEstatesController : ControllerBase
    {
        private readonly IRealEstateRepo realEstateRepo;
        private readonly IMapper _mapper;

        public RealEstatesController(IRealEstateRepo realEstateRepo, IMapper mapper)
        {
            this.realEstateRepo = realEstateRepo;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all realestates and skip/take diff.
        /// </summary>
        /// <param name="skip">The number of realestates you want to skip, make empty to skip none</param>
        /// <param name="take">The number of realestates you want to take, make empty to take all</param>
        /// <returns>Returns all the Realestates for the conditions inputed</returns>
        /// /// <response code="200">Gets the Requested Realestate</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [HttpGet()]
        public ActionResult<IEnumerable<RealEstateDto>> GetRealEstates([FromQuery] int skip = 0, [FromQuery] int take = 10)
        {
            var realEstateFromRepo = realEstateRepo.GetRealEstates(skip, take);
            return Ok(_mapper.Map<IEnumerable<RealEstateDto>>(realEstateFromRepo));
        }

        /// <summary>
        /// Get an Realestate by the id
        /// </summary>
        /// <param name="realEstateId">The is of the realestate you want to get</param>
        /// <returns>returns realestate with id, Title, Rentingprice, purchaseprice, canberented and can be purchased </returns>
        /// <response code="200">Gets the Requested Realestate</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [HttpGet("{realEstateId}", Name = "GetRealEstates")]
        public IActionResult GetRealEstates(int realEstateId)
        {
            var realEstateFromRepo = realEstateRepo.GetRealEstate(realEstateId);

            if (realEstateFromRepo == null) return NotFound();

            if (User.Identity.IsAuthenticated) return Ok(_mapper.Map<RealEstateDetailsPrivateDto>(realEstateFromRepo));

            return Ok(_mapper.Map<RealEstateDetailsDto>(realEstateFromRepo));
        }

        /// <summary>
        /// Create a realestate.
        /// </summary>
        /// <param name="realEstate">The realestate that should be created</param>
        /// <returns>Returns a Realestate with, Title, Address, Description, RentingPrice, PurchasePrice, CanBeRented, CanBePurchased, Contact, ConstructionYear and Type</returns>
        /// <response code="201">Returns the Created Realestate</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
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
