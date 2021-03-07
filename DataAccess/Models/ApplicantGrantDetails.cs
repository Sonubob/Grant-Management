using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrantManagement.Models
{
    public class ApplicantGrantDetails
    {
        public int ApplicantId { get; set; }
      //  public int? GrantId { get; set; }
        public string FullName { get; set; }

        public string ProgramCode { get; set; }
        public string Country { get; set; }
        public string ApplicationStatus { get; set; }
        public int ReviewStatus { get; set; }



    }
}
