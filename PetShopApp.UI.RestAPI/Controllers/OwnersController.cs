using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.ApplicationService;
using PetShop.Core.Entity;

namespace PetShopApp.UI.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        private IOwnerService _ownerService;

        public OwnersController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        // GET api/owners
        [HttpGet]
        public ActionResult<IEnumerable<Owner>> Get([FromQuery] Filter filter)
        {
            try
            {
                return Ok(_ownerService.GetFilteredOwners(filter));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //GET api/owner/id
        [HttpGet("{id}")]
        public ActionResult<Owner> Get(int id)
        {
            try
            {
                return Ok(_ownerService.FindOwnerByIdWithPets(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //Post api/owners
        [HttpPost]
        public ActionResult<Owner> Post([FromBody]Owner owner)
        {
            try
            {
                return Ok(_ownerService.AddOwner(owner));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //DELETE api/owners
        [HttpDelete ("{id}")]
        public ActionResult<Owner> Delete(int id)
        {
            try
            {
                return Ok(_ownerService.RemoveOwner(id > 0 ? new Owner() { Id = id } : null));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //PUT api/owners
        [HttpPut("{id}")]
        public ActionResult<Owner> Put(int id, [FromBody] Owner ownerToUpdate)
        {
            try
            {
                if (id < 1 || id != ownerToUpdate.Id)
                {
                    return BadRequest("Parameter Id and customer ID must be the same");
                }
                return Ok(_ownerService.UpdateOwner(ownerToUpdate));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}