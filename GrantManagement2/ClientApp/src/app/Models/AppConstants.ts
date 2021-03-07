export class AppConstants {
  static baseUrl = window.location.origin + '/';
  static applicant = "Applicant/";
  static api = "Api/";
  static review = "Review/";
  static grant = "Grant/";
  static register = "Register/";
  static uservalidationmethod = "ValidateUser";
  static registeruser = 'RegisterUser';
  static getdropdowns = 'GetDropdowns';
  static applicantsavemethod = 'SaveApplicantDetails';
  static getapplicantdetailsmethod = 'GetApplicantGrantDetails';
  static savereviewdetailsmethod = 'SaveReviewDetails';
  static getGrantDetailsMethod = 'GetGrantDetails';
  static saveGrantDetailsmethod = 'SaveGrantDetails';
  static UnAuthorizedAccess = 'UnAuthorizedAccess';
  static passwordpattern = '^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{8,}$';
  static SaveMessage = "Data Saved";
  static DataNotSavedMessage = 'Data not saved : Please check the data entered in the checked rows';
  static AdminHeader = 'Welcome to Admin Screen';
  static ApplicantHeader = 'Welcome to Applicant Screen';
}
