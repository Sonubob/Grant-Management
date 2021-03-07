using AutoMapper;
using Business.Interfaces;
using Business.Models;
using DataAccess.Interfaces;
using DataAccess.Repository;
using GrantManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Business.FactoryLayer
{
    public class LoginRegisterFactory : ILoginRegisterFactory
    {
        private readonly ILoginRegisterRepository _repository;
        public LoginRegisterFactory(ILoginRegisterRepository repository)
        {
            _repository = repository;
        }
        public ILoginRegisterRepository GetInstanceofDBObject()
        {
            return _repository;
        }

        public UserInfo GetUserInfoObject(RegisterUser user)
        {
            var userdetails = new UserInfo();
            userdetails.FirstName = user.FirstName;
            userdetails.LastName = user.LastName;
            userdetails.Password = user.Password;
            userdetails.UserType = "Student";
            userdetails.UserName = user.EmailID;
            userdetails.CreateDate = DateTime.Now;

            return userdetails;

        }

        public ApplicantDetail GetApplicantDetailsObject(RegisterUser user, UserInfo userID)
        {

            var userDetails = new ApplicantDetail();
         //   userDetails.UserInfo = new UserInfo();
            userDetails.FirstName = user.FirstName;
            userDetails.LastName = user.LastName;
            userDetails.Email = user.EmailID;
            userDetails.UserId =  userID.UserId;
            userDetails.ReviewStatus = false;
            userDetails.ApplicationStatus = "";
            return userDetails;

        }
        
    }
}
