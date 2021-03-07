using GrantManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Interfaces
{
  public  interface IReviewBL
    {
        public List<ApplicantGrantDetails> GetApplicantGrantDetails();

        public int UpdateApplicantReviewStatus(ApplicantGrantDetails details);
    }
}
