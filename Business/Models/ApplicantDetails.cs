using GrantManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Models
{
    public class ApplicantDetails
    {
        public int ApplicantId { get; set; }
        public int? GrantId { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime? Dob { get; set; }
        public int? Country { get; set; }
        public int? State { get; set; }
        public bool? PhyDisabled { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public decimal? Mobile { get; set; }
        public decimal? Phone { get; set; }

        public List<EducationalDetail> EducationalDetails { get; set; }
    }
}
