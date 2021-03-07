using System;
using System.Collections.Generic;

#nullable disable

namespace GrantManagement.Models
{
    public partial class GrantProgram
    {
        public int GrantId { get; set; }
        public string ProgramName { get; set; }
        public string ProgramCode { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? Status { get; set; }

        public ICollection<ApplicantDetail> ApplicantDetails { get; set; }

    }
}
