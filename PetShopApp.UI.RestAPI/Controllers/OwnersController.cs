using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.ApplicationService;
using PetShop.Core.DomainService.Filter;
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
        [Authorize]
        [HttpGet]
        public ActionResult<FilteredList<Owner>> Get([FromQuery] Filter filter)
        {
            try
            {
                if (filter.CurrentPage == 0 && filter.ItemsPrPage == 0)
                {
                    var list = _ownerService.GetFilteredOwners(null);
                    var newList = new List<Owner>();
                    foreach (var owner in list.List)
                    {
                        newList.Add(new Owner()
                        {
                            FirstName = owner.FirstName,
                            LastName = owner.LastName
                        });
                    }

                    var newFilteredList = new FilteredList<Owner>();
                    newFilteredList.List = newList;
                    newFilteredList.Count = list.Count;
                    return Ok(newFilteredList);
                }

                var advancedFilteredList = _ownerService.GetFilteredOwners(filter);
                var newOwnerList = new List<object>();

                foreach (var owner in advancedFilteredList.List)
                {
                    newOwnerList.Add(new
                    {
                        owner.FirstName,
                        owner.LastName
                    });
                }

                return Ok(new FilteredList<object>
                {
                    Count = advancedFilteredList.Count,
                    List = newOwnerList
                });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        //GET api/owner/id
        [Authorize(Roles = "Administrator")]
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
        [Authorize(Roles = "Administrator")]
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
        [Authorize(Roles = "Administrator")]
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
        [Authorize(Roles = "Administrator")]
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