using DataAccess.Interfaces;
using GrantManagement.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class RegisterRepository : IRegisterRepository
    {
        public RegisterRepository GetInstance()
        {
            return new RegisterRepository();
        }

      
        public UserInfo AddUser(UserInfo user)
        {
            var id = 0;
            using (var context = new GrantDBContext())
            {
                context.UserInfos.Add(user);
                var result = context.SaveChanges();

                if (result != 0)
                {
                     
                    return user;
                }
            }

            return new UserInfo();
        }

        public string AddApplicantDetails(ApplicantDetail details)
        {
            using (var context = new GrantDBContext())
            {
                context.ApplicantDetails.Add(details);
                var result = context.SaveChanges();
                if (result != 0)
                {
                    return "Done";
                }
            }

            return "Error Occured";
        
        }

        public string ValidateUser(string userName, string password)
        {
            using (var context = new GrantDBContext())
            {

                var result = context.UserInfos.Any(c => c.UserName == userName && c.Password == password);
                if (result)
                {
                    return "User Valid";
                }
                return "User Invalid";
            }

        }

    }
}
