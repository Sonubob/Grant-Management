using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace GrantManagement.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class RegisterController : ControllerBase
    {
        private readonly IRegistrationBL _loginRegisterbl;
        private readonly IConfiguration _config;
        //private static readonly string[] Summaries = new[]
        //{
        //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //};

        private readonly ILogger<RegisterController> _logger;

        public RegisterController(ILogger<RegisterController> logger, IRegistrationBL loginRegistrationbl, IConfiguration config)
        {
            _logger = logger;
            _loginRegisterbl = loginRegistrationbl;
            _config = config;
        }



        [HttpPost]
        [Route("RegisterUser")]
        [AllowAnonymous]
        public ObjectResult RegisterUser(RegisterUser data)
        {
            
                if (ModelState.IsValid)
                {
                    var result = _loginRegisterbl.RegisterUser(data);
                    if (result == (int)Status.UserExists)
                    {
                        return Ok(new { result });
                    }
                    else if (result == (int)Status.Success)
                    {
                        return Ok(new { result });
                    }
                    else if (result == (int)Status.Failure)
                    {
                        return Ok(new { result });
                    }
                }
                return Ok(new { result="Failed" }); ;
         

        }
    }
}
