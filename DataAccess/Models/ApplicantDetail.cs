using System;
using System.Collections.Generic;


namespace GrantManagement.Models
{
    public partial class ApplicantDetail
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
        public string ApplicationStatus { get; set; } 
        public bool ReviewStatus { get; set; }
        public UserInfo UserInfo { get; set; }

        public GrantProgram GrantProgram { get; set; }
    }
}
