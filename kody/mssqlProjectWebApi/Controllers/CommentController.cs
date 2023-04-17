using Microsoft.AspNetCore.Mvc;
using mssqlProject.Services.IServices;
using mssqlProject.Models;
using mssqlProject.Services;

namespace mssqlProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : Controller
    {
        private readonly ICommentService _CommentService;
        private readonly IPlaceService _PlaceService;

        public CommentController(ICommentService commentService, IPlaceService placeService)
        {
            _CommentService = commentService;
            _PlaceService = placeService;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<RepositoryResponse<Comment>>> Get()
        {
            var response = await _CommentService.GetCommentsAsync();
            return Ok(response.Data);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RepositoryResponse<Comment>>> Get(int id)
        {
            var response = await _CommentService.GetCommentAsync(u => u.Id == id);
            if (response.Success)
            {
                return Ok(response.Data);
            }
            else
            {
                return BadRequest(response.Data);
            }
        }

        [HttpPost]
        public async Task<ActionResult<RepositoryResponse<Comment>>> Post([FromBody] CommentDTO comment)
        {
            var place = await _PlaceService.GetPlaceAsync(u => u.Id == comment.PlaceId);
            if (place.Data == null)
            {
                return new RepositoryResponse<Comment> { Success = false, Message = "Place don't exist" };
            }

            Comment newComment = new Comment
            {
                PlaceId = comment.PlaceId,
                Content = comment.Content,
                Author = comment.Author
            };

            var response = await _CommentService.CreateComment(newComment);
            return Ok(response.Data);
        }

        // PUT api/<ValuesController>/
        [HttpPut("{id}")]
        public async Task<ActionResult<RepositoryResponse<Comment>>> Put([FromBody] Comment comment)
        {
            var response = await _CommentService.UpdateComment(comment);
            return Ok(response.Data);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RepositoryResponse<bool>>> Delete(int id)
        {
            var response = await _CommentService.DeleteComment(new Models.Comment() { Id = id });
            if (response.Success)
            {
                return Ok(response.Data);
            }
            else
            {
                return BadRequest(response.Data);
            }
        }

    }
}
