using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Interfaces
{
   public interface IApplicantBL
    {

        public Task<ApplicantDropdownList> GetApplicantDropdownList();

        public Task<ApplicantDetails> UpdateApplicantDetails(ApplicantDetails data);





        public Task<ApplicantDetails> GetApplicantFullDetails(string userName);
    }
}
