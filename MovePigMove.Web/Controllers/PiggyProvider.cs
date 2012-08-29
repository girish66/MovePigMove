using System;
using System.Collections.Generic;
using System.Web.Security;
using MovePigMove.Core.Storage;
using WebMatrix.WebData;


namespace MovePigMove.Web.Controllers
{
    public class PiggyProvider : ExtendedMembershipProvider
    {
        //private IUserProfileRepository _repo;

        //public PiggyProvider(IUserProfileRepository repo)
        //{
        //    _repo = repo;
        //}

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException("Create User");
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException("ChangePasswordQuestionAndAnswer");
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException("GetPassword");
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException("ChangePassword");
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException("ResetPassword");
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException("UpdateUser");
        }

        public override bool ValidateUser(string username, string password)
        {

            throw new NotImplementedException("ValidateUser");
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException("UnlockUser");
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException("GetUser(obj, bool)");
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            throw new NotImplementedException("GetUser(string, bool)");
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException("GetUserNameByEmail");
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException("DeleteUser");
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException("MembershipUserCollection");
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException("GetNumberOfUsersOnline");
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException("MembershipUserCollection");
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException("MembershipUserCollection");
        }

        public override bool EnablePasswordRetrieval
        {
            get { throw new NotImplementedException("EnablePasswordRetrieval"); }
        }

        public override bool EnablePasswordReset
        {
            get { throw new NotImplementedException("EnablePasswordReset"); }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { throw new NotImplementedException("RequiresQuestionAndAnswer"); }
        }

        public override string ApplicationName { get; set; }

        public override int MaxInvalidPasswordAttempts
        {
            get { throw new NotImplementedException("MaxInvalidPasswordAttempts"); }
        }

        public override int PasswordAttemptWindow
        {
            get { throw new NotImplementedException("PasswordAttemptWindow"); }
        }

        public override bool RequiresUniqueEmail
        {
            get { throw new NotImplementedException("RequiresUniqueEmail"); }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException("MembershipPasswordFormat"); }
        }

        public override int MinRequiredPasswordLength
        {
            get { throw new NotImplementedException("MinRequiredPasswordLength"); }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new NotImplementedException("MinRequiredNonAlphanumericCharacters"); }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException("PasswordStrengthRegularExpression"); }
        }

        public override ICollection<OAuthAccountData> GetAccountsForUser(string userName)
        {
            throw new NotImplementedException("GetAccountsForUser");
        }

        public override string CreateUserAndAccount(string userName, string password, bool requireConfirmation, IDictionary<string, object> values)
        {
            throw new NotImplementedException("CreateUserAndAccount");
        }

        public override string CreateAccount(string userName, string password, bool requireConfirmationToken)
        {
            throw new NotImplementedException("CreateAccount");
        }

        public override bool ConfirmAccount(string userName, string accountConfirmationToken)
        {
            throw new NotImplementedException("ConfirmAccount");
        }

        public override bool ConfirmAccount(string accountConfirmationToken)
        {
            throw new NotImplementedException("ConfirmAccount");
        }

        public override bool DeleteAccount(string userName)
        {
            throw new NotImplementedException("DeleteAccount");
        }

        public override string GeneratePasswordResetToken(string userName, int tokenExpirationInMinutesFromNow)
        {
            throw new NotImplementedException("GeneratePasswordResetToken");
        }

        public override int GetUserIdFromPasswordResetToken(string token)
        {
            throw new NotImplementedException("GetUserIdFromPasswordResetToken");
        }

        public override bool IsConfirmed(string userName)
        {
            throw new NotImplementedException("IsConfirmed");
        }

        public override bool ResetPasswordWithToken(string token, string newPassword)
        {
            throw new NotImplementedException("ResetPasswordWithToken");
        }

        public override int GetPasswordFailuresSinceLastSuccess(string userName)
        {
            throw new NotImplementedException("GetPasswordFailuresSinceLastSuccess");
        }

        public override DateTime GetCreateDate(string userName)
        {
            throw new NotImplementedException("GetCreateDate");
        }

        public override DateTime GetPasswordChangedDate(string userName)
        {
            throw new NotImplementedException("GetPasswordChangedDate");
        }

        public override DateTime GetLastPasswordFailureDate(string userName)
        {
            throw new NotImplementedException("GetLastPasswordFailureDate");
        }
    }
}