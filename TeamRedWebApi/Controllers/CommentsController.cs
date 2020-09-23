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
using TeamRedWebApi.Models.CommentModel;

namespace TeamRedWebApi.Controllers
{
    [Authorize]
    [Route("api/Comments")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IRealEstateRepo commentRepo;
        private readonly IMapper _mapper;

        public CommentsController(IRealEstateRepo commentRepo, IMapper mapper)
        {
            this.commentRepo = commentRepo;
            _mapper = mapper;
        }

        [HttpGet()]
        [HttpHead]
        [Route("api/Comments/{realEstateId}")]
        public ActionResult<IEnumerable<CommentDto>> GetComments(int realEstateId,
                            [FromQuery] string skip = "", [FromQuery] string take = "10")
        {
            var commentsFromRepo = commentRepo.GetComments(realEstateId, skip, take);
            return Ok(_mapper.Map<IEnumerable<CommentDto>>(commentsFromRepo));
        }

        [HttpGet("{userName}", Name = "GetComments")]
        [Route("api/Comments/ByUser/{userName}")]
        public ActionResult<IEnumerable<CommentDto>> GetComments(string userName,
                            [FromQuery] string skip = "", [FromQuery] string take = "10")
        {
            var commentsFromRepo = commentRepo.GetCommentsFromUser(userName, skip, take);

            return Ok(_mapper.Map<IEnumerable<CommentDto>>(commentsFromRepo));
        }

        [HttpPost]
        public ActionResult<CommentDto> CreateComment(CreateCommentDto comment)
        {
            var commentEntity = _mapper.Map<Comment>(comment);
            commentRepo.AddComment(User.Identity.Name,commentEntity);
            commentRepo.Save();

            var commentToReturn = _mapper.Map<CommentDto>(commentEntity);
            return CreatedAtRoute("GetComments",
                new { userName = commentToReturn.UserName }, commentToReturn);
        }
    }
}
