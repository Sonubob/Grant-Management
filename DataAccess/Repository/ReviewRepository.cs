using DataAccess.Interfaces;
using GrantManagement.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        public ReviewRepository GetInstance()
        {
            return new ReviewRepository();
        }

     
        public List<ApplicantGrantDetails> GetApplicantGrantDetails()
        {
            using (var context = new GrantDBContext())
            {
                List<ApplicantGrantDetails> result = (from apd in context.ApplicantDetails
                              join gp in context.GrantPrograms
                              on apd.GrantId equals gp.GrantId
                              join c in context.CountryLookups
                              on apd.Country equals c.CountryId
                             
                              where gp.Status == true
                              select new ApplicantGrantDetails
                              {
                                  ApplicantId = apd.ApplicantId,
                                  ProgramCode = gp.ProgramCode,
                                  FullName = apd.FirstName+" "+apd.LastName,
                                  Country = c.CountryName,
                                  ApplicationStatus = apd.ApplicationStatus,
                                  ReviewStatus = apd.ReviewStatus==true?1:0
                              }).ToList();

                //var result = context.ApplicantDetails.Select(x => x).ToList();
                return result;
            }
        }

    
        public ApplicantDetail GetApplicantDetailsById(int applicantID)
        {
            using (var context = new GrantDBContext())
            {
                var result = context.ApplicantDetails.Select(x => x).Where(x => x.ApplicantId == applicantID).FirstOrDefault();
                return result;
            }
        }

        public int UpdateApplicantDetail(ApplicantDetail detail)
        {
            using (var context = new GrantDBContext())
            {
                context.ApplicantDetails.Update(detail);
                 var result = context.SaveChanges();
                return result;
            }
        }
    }
}
