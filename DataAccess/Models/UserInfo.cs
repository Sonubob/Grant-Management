using System;
using System.Collections.Generic;



namespace GrantManagement.Models
{
    public partial class UserInfo
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
        public DateTime CreateDate { get; set; }

        public ApplicantDetail ApplicantDetail { get; set; }
    }
}
