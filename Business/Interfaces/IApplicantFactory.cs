using Business.Models;
using GrantManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IApplicantFactory
    {
        public Task< ApplicantDetails> GetApplicantResponseObject(ApplicantDetail applicant, List<EducationalDetail> educationalDetails);
        public Task<ApplicantDropdownList> GetDropdownModel(List<CountryLookup> countryobjt, List<StateLookup> stateobjt, List<GrantProgram> grantLookup);

        public Task<ApplicantDetail> GetApplicantDetailObject(ApplicantDetails data);
    }
}
