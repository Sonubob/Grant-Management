using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.Models;
using GrantManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace GrantManagement2.Controllers
{
    [ApiController]
    [EnableCors("MyPolicy")]
    [Route("[controller]")]
    public class ApiController : Controller
    {
        private readonly ILoginBL _loginRegisterbl;
        private readonly IConfiguration _config;
      
        private readonly ILogger<ApiController> _logger;

        public ApiController(ILogger<ApiController> logger, ILoginBL loginRegistrationbl, IConfiguration config)
        {
            _logger = logger;
            _loginRegisterbl = loginRegistrationbl;
            _config = config;
        }


        [HttpPost]
        [Route("ValidateUser")]
        [AllowAnonymous]
        public async Task<JsonResult> ValidateUser(UserDetails data)
        {
           
                if (ModelState.IsValid)
                {
                _logger.LogInformation("Starting the user validation");
                    var result = await _loginRegisterbl.Login(data);
                    if (result != null && result.UserId > 0)
                    {
                    _logger.LogInformation("User Successfully logged in");
                    return Json(result);
                    }
                    else
                    {
                    _logger.LogInformation("User validation failed");
                    return Json("Error found");
                    }
                }
                return Json("Error found");
            
   
           
               
                
            
        }

      
        [Route("GenerateTokenForUser")]
      
        public ObjectResult GetAuthToken()
        {
            _logger.LogInformation("Creating JWT Token");
            var result = BuildJWTToken();
            

                  return Ok(new { result });
           

        }


        private string BuildJWTToken()
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtToken:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var issuer = _config["JwtToken:Issuer"];
            var audience = _config["JwtToken:Audience"];
            var jwtValidity = DateTime.Now.AddMinutes(Convert.ToDouble(_config["JwtToken:TokenExpiry"]));

            var token = new JwtSecurityToken(issuer,
              audience,
              expires: jwtValidity,
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }
}
