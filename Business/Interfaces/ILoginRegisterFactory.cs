using Business.Models;
using DataAccess.Interfaces;
using DataAccess.Repository;
using GrantManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface ILoginRegisterFactory
    {
        public ILoginRegisterRepository GetInstanceofDBObject();

        public UserInfo GetUserInfoObject(RegisterUser user);

        public ApplicantDetail GetApplicantDetailsObject(RegisterUser user, UserInfo userID);


     
       
    }
}
