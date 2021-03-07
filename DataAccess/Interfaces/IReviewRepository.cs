using DataAccess.Repository;
using GrantManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IReviewRepository
    {
        public ReviewRepository GetInstance();

    

        public List<ApplicantGrantDetails> GetApplicantGrantDetails();


        public ApplicantDetail GetApplicantDetailsById(int applicantID);

        public int UpdateApplicantDetail(ApplicantDetail detail);
    }
}
