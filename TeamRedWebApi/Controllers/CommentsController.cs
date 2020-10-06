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
#pragma warning disable CS1591
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
        /// <summary>
        /// Gets all the comments from a Realestate
        /// </summary>
        /// <param name="realEstateId">The id of the realestate that you want to take the comments from</param>
        /// <param name="skip">The amount of comments you want to skip</param>
        /// <param name="take">The amount of comments you want to take</param>
        /// <returns>Returns Content, the username, and when the comment was created</returns>

        [HttpGet("{realEstateId}")]
        public ActionResult<IEnumerable<CommentDto>> GetComments(int realEstateId,
                            [FromQuery] int skip = 0, [FromQuery] int take = 10)
        {
            var commentsFromRepo = commentRepo.GetCommentsFromRealEstate(realEstateId, skip, take);
            return Ok(_mapper.Map<IEnumerable<CommentDto>>(commentsFromRepo));
        }

        /// <summary>
        /// Get Comments by the Username
        /// </summary>
        /// <param name="userName">The username of the user that has made the comments</param>
        /// <param name="skip">The amount of comments you want to skip</param>
        /// <param name="take">The amount of comments you want to take</param>
        /// <returns>Returns the Content, username and when the comment was created</returns>
        [HttpGet("ByUser/{userName}", Name = "GetComments")]
        public ActionResult<IEnumerable<CommentDto>> GetComments(string userName,
                            [FromQuery] int skip = 0, [FromQuery] int take = 10)
        {
            var commentsFromRepo = commentRepo.GetCommentsFromUser(userName, skip, take);
            return Ok(_mapper.Map<IEnumerable<CommentDto>>(commentsFromRepo));
        }

        /// <summary>
        /// Create a comment
        /// </summary>
        /// <param name="comment">The comment that should be crated</param>
        /// <returns>Returns the content, username and when the comment was created</returns>
        [HttpPost]
        public ActionResult<CommentDto> CreateComment(CreateCommentDto comment)
        {
            var commentEntity = _mapper.Map<Comment>(comment);

            commentRepo.AddComment(User.Identity.Name, commentEntity);
            commentRepo.Save();

            var commentToReturn = _mapper.Map<CommentDto>(commentEntity);
            return CreatedAtRoute("GetComments",
                new { realEstateId = comment.RealEstateId, userName = commentToReturn.UserName }, commentToReturn);
        }
    }
}
