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
    public class PetsController : ControllerBase
    {
        private IPetService _petService;

        public PetsController(IPetService petService)
        {
            _petService = petService;

        }

        // GET api/pets
        [HttpGet]
        public ActionResult<IEnumerable<Pet>> Get()
        {
            return _petService.GetPets();
        }

        //POST api/pets
        [HttpPost]
        public void Post([FromBody] string name, string type, DateTime birthDate, DateTime soldDate, string color, Owner prevOwner, double price)
        {
            _petService.AddPet(name, type, birthDate, soldDate, color, prevOwner, price);
        }
    }
}