using DataAccess.Interfaces;
using GrantManagement.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ApplicantRepository : IApplicantRepository
    {
        public ApplicantRepository GetInstance()
        {
            return new ApplicantRepository();
        }

      

        public ApplicantDetail GetApplicantDetailByName(string userName)
        {
            using (var context = new GrantDBContext())
            {
                var result = context.ApplicantDetails.Select(x => x).Where(c => c.Email == userName).FirstOrDefault();
                return result;
            }
                
        }

       

        public List<GrantProgram> GetGrantDetails()
        {
            using (var context = new GrantDBContext())
            {
                var result = context.GrantPrograms.Select(x => x).ToList();
                return result;
            }
        }

     

        public List<CountryLookup> GetCountryLookups()
        {
            using (var context = new GrantDBContext())
            {
               var result = context.CountryLookups.Select(x => x).ToList();
                return result;
            }
        }

        public List<StateLookup> GetStateLookups()
        {
            using (var context = new GrantDBContext())
            {
                var result = context.StateLookups.Select(x => x).ToList();
                return result;
            }
        }

        public string UpdateApplicantDetails(ApplicantDetail details)
        {
            using (var context = new GrantDBContext())
            {
                context.ApplicantDetails.Update(details);
                var result = context.SaveChanges();
                if (result != 0)
                {
                    return "Done";
                }
            }

            return "Error Occured";

        }


     

        public List<EducationalDetail> GetEducationalDetailsByApplicant(int applicantID)
        {
            using (var context = new GrantDBContext())
            {
                var result = context.EducationalDetails.Where(x => x.ApplicantId == applicantID).Select(x => x).ToList();
                return result;
            }
        }

        public int AddEducationDetail(EducationalDetail data)
        {
            using (var context = new GrantDBContext())
            {
                var result = context.EducationalDetails.Add(data);
              var index =  context.SaveChanges();
                return index;
            }
        }

        public int UpdateEducationDetail(EducationalDetail data)
        {
            using (var context = new GrantDBContext())
            {
                var result = context.EducationalDetails.Update(data);
                var index = context.SaveChanges();
                return index;
            }
        }

        public int DeleteEducationDetail(EducationalDetail data)
        {
            using (var context = new GrantDBContext())
            {
                var result = context.EducationalDetails.Remove(data);
                var index = context.SaveChanges();
                return index;
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
