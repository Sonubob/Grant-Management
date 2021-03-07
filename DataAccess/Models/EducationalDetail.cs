using System;
using System.Collections.Generic;



namespace GrantManagement.Models
{
    public partial class EducationalDetail
    {
        public int EducationalDetailId { get; set; }
        public int? ApplicantId { get; set; }
        public string CourseName { get; set; }
        public int? Country { get; set; }
        public string Institution { get; set; }
        public int? CompletionYear { get; set; }
    }
}
