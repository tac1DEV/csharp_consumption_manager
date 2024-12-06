using Consommation.Domain.Interfaces.Business;
using Consommation.Domain.Models.Requests;
using Microsoft.AspNetCore.Mvc;


namespace Consommation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentairesController : ControllerBase
    {
        private static ICommentaireBusiness _commentaireBusiness;

        public CommentairesController(ICommentaireBusiness commentaireBusiness)
        {
            _commentaireBusiness = commentaireBusiness;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var Result = _commentaireBusiness.GetAllCommentaires();

            return Ok(Result);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var Result = _commentaireBusiness.GetCommentaireById(id);

            if (Result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Result);
            }
        }

        [HttpPost]
        public ActionResult Post(AddCommentaireRequest request)
        {
            if (ModelState.IsValid)
            {
                return Ok(_commentaireBusiness.CreateCommentaire(request));
            }
            else { return BadRequest(); }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var Result = _commentaireBusiness.DeleteCommentaire(id);

            if (Result == false)
            {
                return NotFound();
            }
            else
            {
                return NoContent();
            }
        }
        
        [HttpPut("{id}")]
        public ActionResult Put(int id, AddCommentaireRequest request)
        {
            var Result = _commentaireBusiness.GetCommentaireById(id);

            if (Result == null)
            {
                return NotFound();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    return Ok(_commentaireBusiness.UpdateCommentaire(id, request));
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
        }
    }
}
