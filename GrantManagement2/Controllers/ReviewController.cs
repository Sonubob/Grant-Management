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
    [ApiController]
    [Authorize]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewBL _loginRegisterbl;
        private readonly IConfiguration _config;
        //private static readonly string[] Summaries = new[]
        //{
        //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //};

        private readonly ILogger<ReviewController> _logger;

        public ReviewController(ILogger<ReviewController> logger, IReviewBL loginRegistrationbl, IConfiguration config)
        {
            _logger = logger;
            _loginRegisterbl = loginRegistrationbl;
            _config = config;
        }



        [Route("GetApplicantGrantDetails")]
    
        public ObjectResult GetApplicantGrantDetails()
        {
            _logger.LogInformation("Fetching Applicant Grant details..");
            
                var result = _loginRegisterbl.GetApplicantGrantDetails();
                return Ok(result);
            
           
               
            

        }

        [HttpPost]
       
        [Route("SaveReviewDetails")]
        public ObjectResult SaveReviewDetails(ApplicantGrantDetails data)
        {
           
                var result = _loginRegisterbl.UpdateApplicantReviewStatus(data);
                return Ok(result);
            
           

        }
    }
}
