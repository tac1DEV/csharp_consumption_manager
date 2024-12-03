using Consommation.Domain.Interfaces.Business;
using Consommation.Domain.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Consommation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrajetsController : ControllerBase
    {
        private static ITrajetBusiness _trajetBusiness;

        public TrajetsController(ITrajetBusiness trajetBusiness)
        {
            _trajetBusiness = trajetBusiness;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var Result = _trajetBusiness.GetAllTrajets();

            return Ok(Result);
        }
        [HttpGet("{id}")]
        public ActionResult Get(int id) { 
            var Result = _trajetBusiness.GetTrajetById(id);

            if(Result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Result);
            }
        }
        [HttpPost]
        public ActionResult Post(AddTrajetRequest request)
        {
            if (ModelState.IsValid)
            {
                return Ok(_trajetBusiness.CreateTrajet(request));
            }
            else { return BadRequest();}
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var Result = _trajetBusiness.DeleteTrajet(id);

            if(Result == false)
            {
                return NotFound();
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, AddTrajetRequest request)
        {
            var Result = _trajetBusiness.GetTrajetById(id);

            if(Result == null)
            {
                return NotFound();
            }
            else
            {
                if(ModelState.IsValid)
                {
                    return Ok(_trajetBusiness.UpdateTrajet(id, request));
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
        }
    }
}
