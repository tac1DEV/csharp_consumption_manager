using Consommation.Domain.Interfaces.Business;
using Consommation.Domain.Models.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Consommation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoituresController : ControllerBase
    {
        private static IVoitureBusiness _voitureBusiness;

        public VoituresController(IVoitureBusiness voitureBusiness)
        {
            _voitureBusiness = voitureBusiness;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var Result = _voitureBusiness.GetAllVoitures();

            return Ok(Result);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var Result = _voitureBusiness.GetVoitureById(id);

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
        public ActionResult Post(AddVoitureRequest request)
        {
            if (ModelState.IsValid)
            {
                return Ok(_voitureBusiness.CreateVoiture(request));
            }
            else { return BadRequest(); }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var Result = _voitureBusiness.DeleteVoiture(id);

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
        public ActionResult Put(int id, AddVoitureRequest request)
        {
            var Result = _voitureBusiness.GetVoitureById(id);

            if (Result == null)
            {
                return NotFound();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    return Ok(_voitureBusiness.UpdateVoiture(id, request));
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
        }
    }
}
