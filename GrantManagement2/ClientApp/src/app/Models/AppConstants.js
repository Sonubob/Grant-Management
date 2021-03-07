"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.AppConstants = void 0;
var AppConstants = /** @class */ (function () {
    function AppConstants() {
    }
    AppConstants.baseUrl = window.location.origin + '/';
    AppConstants.applicant = "Applicant/";
    AppConstants.api = "Api/";
    AppConstants.review = "Review/";
    AppConstants.grant = "Grant/";
    AppConstants.register = "Register/";
    AppConstants.uservalidationmethod = "ValidateUser";
    AppConstants.registeruser = 'RegisterUser';
    AppConstants.getdropdowns = 'GetDropdowns';
    AppConstants.applicantsavemethod = 'SaveApplicantDetails';
    AppConstants.getapplicantdetailsmethod = 'GetApplicantGrantDetails';
    AppConstants.savereviewdetailsmethod = 'SaveReviewDetails';
    AppConstants.getGrantDetailsMethod = 'GetGrantDetails';
    AppConstants.saveGrantDetailsmethod = 'SaveGrantDetails';
    AppConstants.UnAuthorizedAccess = 'UnAuthorizedAccess';
    AppConstants.passwordpattern = '^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{8,}$';
    AppConstants.SaveMessage = "Data Saved";
    AppConstants.DataNotSavedMessage = 'Data not saved : Please check the data entered in the checked rows';
    AppConstants.AdminHeader = 'Welcome to Admin Screen';
    AppConstants.ApplicantHeader = 'Welcome to Applicant Screen';
    return AppConstants;
}());
exports.AppConstants = AppConstants;
//# sourceMappingURL=AppConstants.js.map