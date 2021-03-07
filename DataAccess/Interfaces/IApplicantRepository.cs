using DataAccess.Repository;
using GrantManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IApplicantRepository
    {
        public ApplicantRepository GetInstance();

       

        public List<GrantProgram> GetGrantDetails();


        public List<StateLookup> GetStateLookups();
        public List<CountryLookup> GetCountryLookups();
        public string UpdateApplicantDetails(ApplicantDetail details);

        public ApplicantDetail GetApplicantDetailByName(string userName);

        public List<EducationalDetail> GetEducationalDetailsByApplicant(int applicantID);

        public int AddEducationDetail(EducationalDetail data);

   

        public int UpdateEducationDetail(EducationalDetail data);

 

        public int DeleteEducationDetail(EducationalDetail data);


        public int UpdateApplicantDetail(ApplicantDetail detail);
    }
}
