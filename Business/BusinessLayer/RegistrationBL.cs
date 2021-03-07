using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.Models;
using DataAccess.Interfaces;

namespace Business.BusinessLayer
{
    public class RegistrationBL:IRegistrationBL
    {
        private readonly ILoginRegisterFactory _factoryObjt;
        private IRegisterRepository _objt;

        public RegistrationBL(ILoginRegisterFactory factoryObjt, IRegisterRepository objt)
        {
            _factoryObjt = factoryObjt;
            _objt = objt;
        }

        public int RegisterUser(RegisterUser user)
        {
            //_objt = _factoryObjt.GetInstanceofDBObject();
            if (_objt.ValidateUser(user.EmailID, user.Password) == "User Valid")
            {
                return (int)Status.UserExists;
            }
            else
            {
                var reqDto = _factoryObjt.GetUserInfoObject(user);


                var result = _objt.AddUser(reqDto);
                if (result.UserId > 0)
                {
                    var applicantreqDto = _factoryObjt.GetApplicantDetailsObject(user, result);
                    var resultData = _objt.AddApplicantDetails(applicantreqDto);
                    if (resultData == "Done")
                    {
                        return (int)Status.Success;
                    }
                    else
                    {
                        return (int)Status.Failure;
                    }

                }
                else
                {
                    return (int)Status.Failure;
                }
            }


        }
    }
}
