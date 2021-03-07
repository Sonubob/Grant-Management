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
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;


namespace GrantManagement.Controllers
{
    [Route("[controller]")]
    [Authorize]
    [ApiController]
    public class GrantController : ControllerBase
    {
        private readonly IGrantBL _grantbl;
        private readonly IConfiguration _config;
      

        private readonly ILogger<GrantController> _logger;

        public GrantController(ILogger<GrantController> logger, IGrantBL grantbl, IConfiguration config)
        {
            _logger = logger;
            _grantbl = grantbl;
            _config = config;
        }



        [Route("GetGrantDetails")]
     
        public ObjectResult GetGrantDetails()
        {
            _logger.LogInformation("entered get grant details..");
                var result = _grantbl.GetGrantPrograms();
                return Ok(result);
         

        }

        [Route("SaveGrantDetails")]
   
        public ObjectResult AddUpdateGrantDetails(List<GrantProgram> data)
        {
            _logger.LogInformation("Beginning save grant details..");
            var result = _grantbl.AddUpdateGrantDetails(data);
                return Ok(result);
            
          

        }

    }
}
