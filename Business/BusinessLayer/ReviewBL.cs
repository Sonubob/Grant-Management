using Business.Interfaces;
using DataAccess.Interfaces;
using GrantManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.BusinessLayer
{
    public class ReviewBL: IReviewBL
    {
        private readonly IReviewFactory _factoryObjt;
        private IReviewRepository _objt;

        public ReviewBL(IReviewFactory factoryObjt, IReviewRepository objt)
        {
            _factoryObjt = factoryObjt;
            _objt = objt;
        }
        public List<ApplicantGrantDetails> GetApplicantGrantDetails()
        {
            //_objt = _factoryObjt.GetInstanceofDBObject();
            return _objt.GetApplicantGrantDetails();

        }


        public int UpdateApplicantReviewStatus(ApplicantGrantDetails details)
        {
            var applicantDetails = _objt.GetApplicantDetailsById(details.ApplicantId);

            if (details.ReviewStatus == 1)
            {
                applicantDetails.ReviewStatus = true;
                applicantDetails.ApplicationStatus = "Approved";
            }
            else
            {
                applicantDetails.ReviewStatus = false;
                applicantDetails.ApplicationStatus = "Rejected";
            }
            return _objt.UpdateApplicantDetail(applicantDetails);
        }

    }
}
