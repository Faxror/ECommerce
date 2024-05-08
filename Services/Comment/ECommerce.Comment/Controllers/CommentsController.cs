using ECommerce.Comment.Context;
using ECommerce.Comment.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Comment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class CommentsController : ControllerBase
    {
        private readonly CommentContext _Context;

        public CommentsController(CommentContext context)
        {
            _Context = context;
        }

        [HttpGet]
        public IActionResult GetAllComment() 
        {
            var valuse = _Context.userComments.ToList();
            return Ok(valuse);
        }

        [HttpGet("{id}")]
        public IActionResult GetAllCommentById(int id)
        {
            var valuse = _Context.userComments.Find(id);
            return Ok(valuse);
        }


        [HttpGet("CommentListByProductId")]
        public IActionResult CommentListByProductId(string id)
        {
            var valusee = _Context.userComments.Where(x => x.ProductId == id).ToList();
            return Ok(valusee);
        }

        [HttpPost]
        public IActionResult CreateComment(UserComment userComment) 
        {
            _Context.userComments.Add(userComment);
            _Context.SaveChanges();
            return Ok("Yorum başarılı şekilde eklendi");
        }


        [HttpDelete]
        public IActionResult DeleteComment(int id)
        {
            var value = _Context.userComments.Find(id);
            if (value != null)
            {
                _Context.userComments.Remove(value);
                _Context.SaveChanges();
                return Ok("Yorum başarılı şekilde silindi");
            }
            return BadRequest();
        }
        [HttpPut]
        public IActionResult UpdateComment(UserComment userComment)
        {
            _Context.userComments.Update(userComment);
            _Context.SaveChanges();
            return Ok("Yorum başarılı şekilde güncellendi");
        }
    }
}
