using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.DomainService;
using PetShop.Core.Entity;
using PetShop.Core.Helper;
using PetShop.Core.Model;

namespace PetShopApp.UI.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokensController : ControllerBase
    {
        private IUserRepository repository;
        private IAuthenticationHelper authenticationHelper;

        public TokensController(IUserRepository repos, IAuthenticationHelper authService)
        {
            repository = repos;
            authenticationHelper = authService;
        }


        [HttpPost]
        public IActionResult Login([FromBody] LoginModel model)
        {
            var user = repository.GetAllUsers().FirstOrDefault(u => u.UserName == model.Username);

            // check if username exists
            if (user == null)
                return Unauthorized();

            // check if password is correct
            if (!authenticationHelper.VerifyPasswordHash(model.Password, user.PasswordHash, user.PasswordSalt))
                return Unauthorized();

            // Authentication successful
            return Ok(new
            {
                username = user.UserName,
                token = authenticationHelper.GenerateToken(user)
            });
        }

    }
}