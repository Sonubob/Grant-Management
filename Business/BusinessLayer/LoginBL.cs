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
    public class LoginBL : ILoginBL
    {
        private readonly ILoginRegisterFactory _factoryObjt;
        private  ILoginRegisterRepository _repoObjt;
        private  IApplicantBL _applicantobjt;
        
        public LoginBL(ILoginRegisterFactory factoryObjt, ILoginRegisterRepository objt, IApplicantBL applicantobjt)
        {
            _factoryObjt = factoryObjt;
            _repoObjt = objt;
            _applicantobjt = applicantobjt;
        }

       
        public async  Task<ApplicantDetails> Login(UserDetails user)
        {
             //_repoObjt = _factoryObjt.GetInstanceofDBObject();
            string userName = user.Email;
            string password = user.Password;
            var result = _repoObjt.ValidateUser(userName, password);
           
            if(result == "User Valid")
            {
                var userDetails = _repoObjt.GetUserInfo(userName);
                if(userDetails.UserType == "Student")
                {
                    return await _applicantobjt.GetApplicantFullDetails(userName);
                }
                else
                {
                    var admin = new ApplicantDetails();
                    admin.UserId = userDetails.UserId;
                    admin.ApplicantId = 0;
                    admin.EducationalDetails = new List<EducationalDetail>();
                   return admin;
                }
              
               
            }
            return new ApplicantDetails();
        }

     


        //public List<ApplicantGrantDetails> GetApplicantGrantDetails()
        //{

        //}

       

     

     

    }
}
