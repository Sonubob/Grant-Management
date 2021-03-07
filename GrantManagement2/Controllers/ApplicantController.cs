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
    public class ApplicantController : ControllerBase
    {

        private readonly IApplicantBL _applicantbl;
        private readonly IConfiguration _config;
        //private static readonly string[] Summaries = new[]
        //{
        //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //};

        private readonly ILogger<ApplicantController> _logger;

        public ApplicantController(ILogger<ApplicantController> logger, IApplicantBL applicantbl, IConfiguration config)
        {
            _logger = logger;
            _applicantbl = applicantbl;
            _config = config;
        }


        [Route("GetDropdowns")]

        public async Task<ObjectResult> GetApplicantDropdownList()
        {

            var result = await _applicantbl.GetApplicantDropdownList();
            return Ok(result);


        }

        [HttpPost]

        [Route("SaveApplicantDetails")]
        public async Task<ObjectResult> UpdateApplicantDetails(ApplicantDetails data)
        {

            var result = await _applicantbl.UpdateApplicantDetails(data);
            return Ok(result);


        }
    }
}
