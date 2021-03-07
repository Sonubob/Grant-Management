using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.Models;
using GrantManagement.Models;

namespace Business.FactoryLayer
{
    public class ApplicantFactory : IApplicantFactory
    {
        public async  Task<ApplicantDetails> GetApplicantResponseObject(ApplicantDetail applicant, List<EducationalDetail> educationalDetails)
        {
            var result = new ApplicantDetails();
            await Task.Run(() =>
            {
                
                result.EducationalDetails = new List<EducationalDetail>();
                result.Address = applicant.Address;
                result.ApplicantId = applicant.ApplicantId;
                result.City = applicant.City;
                result.Country = applicant.Country;
                result.Dob = applicant.Dob;
                result.Email = applicant.Email;
                result.FirstName = applicant.FirstName;
                result.GrantId = applicant.GrantId;
                result.LastName = applicant.LastName;
                result.Mobile = applicant.Mobile;
                result.Phone = applicant.Phone;
                result.PhyDisabled = applicant.PhyDisabled;
                result.PostCode = applicant.PostCode;
                result.State = applicant.State;
                result.UserId = applicant.UserId;
                result.EducationalDetails = educationalDetails;
            });
            
            return result;
        }

        public async Task<ApplicantDropdownList> GetDropdownModel(List<CountryLookup> countryobjt, List<StateLookup> stateobjt, List<GrantProgram> grantLookup)
        {
            var applicantobjt = new ApplicantDropdownList();
            var countryObjt = new List<DropdownType>();
            var stateObjt = new List<DropdownType>();
            var grantObjt = new List<DropdownType>();
            await Task.Run(() =>
            {
                countryobjt.ForEach(x => countryObjt.Add(new DropdownType() { Id = x.CountryId, Name = x.CountryName }));
                stateobjt.ForEach(x => stateObjt.Add(new DropdownType() { ValueId = x.CountryId, Id = x.StateId, Name = x.StateName }));
                grantLookup.Where(x => x.Status == true).Select(x => x).ToList().ForEach(x => grantObjt.Add(new DropdownType() { Id = x.GrantId, Name = x.ProgramName }));
                applicantobjt.CountryDropdown = countryObjt;
                applicantobjt.StateDropdown = stateObjt;
                applicantobjt.GrantDropdown = grantObjt;
            });
            return applicantobjt;
        }




        public async Task<ApplicantDetail> GetApplicantDetailObject (ApplicantDetails data)
        {
            var result = new ApplicantDetail();
            //   D d = Activator.CreateInstance<D>();
            var sType = data.GetType();

            var dType = typeof(ApplicantDetail);
            await Task.Run(() =>
            {

                foreach (PropertyInfo sP in sType.GetProperties())
                {
                    foreach (PropertyInfo dP in dType.GetProperties())
                    {

                        if (dP.Name == sP.Name)
                        {
                            dP.SetValue(result, sP.GetValue(data));
                        }

                    }

                }
            });

            return result;
        }
    }
}
