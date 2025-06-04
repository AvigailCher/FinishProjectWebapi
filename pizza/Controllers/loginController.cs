using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using models;
using ServiceCL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pizza.Login;
using Login.identity;
using FileService;
using FileService.Interfaces;
namespace pizza.Controllers

{
    [Route("[controller]")]
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult<String> Login([FromBody] string name ,int password)
        {
            
            var dt = DateTime.Now;
           identityService identity=new identityService();
            if (!identity.isExist(name,password))
            {
                return Unauthorized();
            }

            var claims = new List<Claim>
     {
         new Claim("role", "Admin"),
         new Claim("name","john"),
         new Claim("brithdatae","")
     };

            var token = PizzaTokenService.GetToken(claims);

            return new OkObjectResult(PizzaTokenService.WriteToken(token));
        }

        [HttpPost]
        [Route("[action]")]
        [Authorize(Policy = "Admin")]
        public IActionResult GenerateBadge( Worker worker)
        {

            var claims = new List<Claim>
      {
          new Claim("role", "Agent"),
        //   new Claim("ClearanceLevel", Agent.ClearanceLevel.ToString()),
      };

            var token = PizzaTokenService.GetToken(claims);

            return new OkObjectResult(PizzaTokenService.WriteToken(token));
        }
    }
}