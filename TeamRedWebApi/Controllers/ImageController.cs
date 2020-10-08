using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamRedProject.Services;
using TeamRedWebApi.Models.ImageModel;

namespace TeamRedWebApi.Controllers
{
#pragma warning disable CS1591
    [Route("images")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IRealEstateRepo userRepo;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ImageController(IRealEstateRepo userRepo, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            this.userRepo = userRepo;
            this._mapper = mapper;
            this._webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("{realestatId}")]
        public ActionResult<IEnumerable<ImageDto>> GetImagesFromRealEstate([FromRoute] int realestatId)
        {
            if (!ModelState.IsValid) return BadRequest();
            var imageEntity = userRepo.GetImageFromRealEstate(realestatId);
            if (imageEntity == null) return NotFound();

            return Ok(_mapper.Map<IEnumerable<ImageDto>>(imageEntity));
        }
        [HttpGet]
        public IActionResult GetImage([FromQuery] int imageid)
        {
            if (!ModelState.IsValid) return BadRequest();
            var imageEntity = userRepo.GetImage(imageid);
            if (imageEntity == null) return NotFound();

            return Ok(_mapper.Map<ImageDto>(imageEntity));
        }

        [Authorize]
        [HttpPost]
        public IActionResult Post([FromForm] int realestateId, [FromForm] string title, [FromForm] IFormCollection formdata)
        {
            var realestate = userRepo.GetRealEstateFromUser(User.Identity.Name, realestateId);
            if (realestate == null) return BadRequest();

            string realestateImagesPath = CreatePath(realestateId);
            CreateDirectory(realestateImagesPath);

            SaveFile(realestateId, formdata, realestateImagesPath, title);

            return Ok();
        }

        private void SaveFile(int realestateId, IFormCollection formdata, string realestatePath, string title)
        {
            int i = 0;
            foreach (var file in formdata.Files)
            {
                if (file.Length > 0)
                {
                    var extension = Path.GetExtension(file.FileName);
                    var filename = DateTime.Now.ToString("yymmssff");
                    var path = Path.Combine(realestatePath, filename) + extension;

                    userRepo.AddImage(realestateId, path, title);
                    userRepo.Save();

                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                        fileStream.Flush();
                    }
                    i++;
                }
            }
        }

        private string CreatePath(int realestateId)
        {
            return Path.Combine(_webHostEnvironment.WebRootPath
                                               + $"{Path.DirectorySeparatorChar}Uploads" +
                                                 $"{Path.DirectorySeparatorChar}RealEstateImages" +
                                                 $"{Path.DirectorySeparatorChar}RealEstateId" + realestateId.ToString());
        }

        private static void CreateDirectory(string realestatePath)
        {
            if (!Directory.Exists(realestatePath))
            {
                Directory.CreateDirectory(realestatePath);
            }
        }
    }
}
