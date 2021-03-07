using Business.FactoryLayer;
using Business.Interfaces;
using Business.Models;
using DataAccess.Interfaces;
using GrantManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.BusinessLayer
{
    public class ApplicantBL: IApplicantBL
    {
        private readonly IApplicantFactory _factoryObjt;
        private IApplicantRepository _repoObjt;

        public ApplicantBL(IApplicantFactory factoryObjt, IApplicantRepository objt)
        {
            _factoryObjt = factoryObjt;
            _repoObjt = objt;
        }

        public async Task<ApplicantDropdownList> GetApplicantDropdownList()
        {
            //_repoObjt = _factoryObjt.GetInstanceofDBObject();

            var countryLookups = _repoObjt.GetCountryLookups();
            var stateLookups = _repoObjt.GetStateLookups();
            var grantLookup = _repoObjt.GetGrantDetails();
            var result = await _factoryObjt.GetDropdownModel(countryLookups, stateLookups, grantLookup);
            return result;

        }

        public async Task<ApplicantDetails> UpdateApplicantDetails(ApplicantDetails data)
        {
            //_repoObjt = _factoryObjt.GetInstanceofDBObject();

            var applicantData = await _factoryObjt.GetApplicantDetailObject(data);
            var result = _repoObjt.UpdateApplicantDetails(applicantData);
            var educationDetails = data.EducationalDetails;
            var detailsDB = await GetApplicantFullDetails(applicantData.Email);
            foreach (var detail in educationDetails)
            {
                if (detail.EducationalDetailId == 0)
                {
                    _repoObjt.AddEducationDetail(detail);
                }
                else
                {
                    _repoObjt.UpdateEducationDetail(detail);
                }
            }
            foreach (var entry in detailsDB.EducationalDetails)
            {
                if (!(educationDetails.Exists(x => x.EducationalDetailId == entry.EducationalDetailId)))
                {
                    _repoObjt.DeleteEducationDetail(entry);
                }
            }
            if (result == "Done")
            {
                var returnData = await GetApplicantFullDetails(applicantData.Email);
                return returnData;
            }
            else
            {
                return new ApplicantDetails();
            }

        }

        public async Task<ApplicantDetails> GetApplicantFullDetails(string userName)
        {
            var applicantDetails = _repoObjt.GetApplicantDetailByName(userName);
            var educationalDetails = _repoObjt.GetEducationalDetailsByApplicant(applicantDetails.ApplicantId);
            if (applicantDetails != null)
            {
                ApplicantDetails responseDto = await _factoryObjt.GetApplicantResponseObject(applicantDetails, educationalDetails);

                return responseDto;
            }
            else
            {
                return new ApplicantDetails();
            }
        }

    }
}
