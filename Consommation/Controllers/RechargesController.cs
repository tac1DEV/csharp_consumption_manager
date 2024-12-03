using Consommation.Domain.Business;
using Consommation.Domain.Interfaces.Business;
using Consommation.Domain.Models.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Consommation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RechargesController : ControllerBase
    {
        private static IRechargeBusiness _rechargeBusiness;

        public RechargesController(IRechargeBusiness rechargeBusiness)
        {
            _rechargeBusiness = rechargeBusiness;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var Result = _rechargeBusiness.GetAllRecharges();

            return Ok(Result);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var Result = _rechargeBusiness.GetRechargeById(id);

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
        public ActionResult Post(AddRechargeRequest request)
        {
            if (ModelState.IsValid)
            {
                return Ok(_rechargeBusiness.CreateRecharge(request));
            }
            else { return BadRequest(); }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id) 
        {
            var Result = _rechargeBusiness.DeleteRecharge(id);

            if(Result == false)
            {
                return NotFound();
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPut]
        public ActionResult Put(int id, AddRechargeRequest request)
        {
            var Result = _rechargeBusiness.GetRechargeById(id);
            
            if (Result == null)
            {
                return NotFound();
            }
            else
            {
                if(ModelState.IsValid)
                {
                    return Ok(_rechargeBusiness.UpdateRecharge(id, request));
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
        }
    }
}
