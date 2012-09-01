using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Web.Security;
using DotNetOpenAuth.AspNet.Clients;
using MovePigMove.Core.Storage;
using WebMatrix.WebData;


namespace MovePigMove.Web.Controllers
{
    public class LocalUser
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PasswordQuestion { get; set; }
        public string PasswordAnswer { get; set; }
        public bool IsApproved { get; set; }
        public object ProviderUserKey { get; set; }
    }

    public class PasswordUtiltity
    {
        public static string OneWayHash(string password)
        {
            return password;
        }

        public static bool PasswordMatch(string password, string hashedPassword)
        {
            return OneWayHash(password).Equals(password);
        }
    }

    public interface ILocalUserDao
    {
        LocalUser LoadByUserName(string userName);
        void UpdateAccount(LocalUser account);
        LocalUser FindByEmailAddress(string email);
        IList<LocalUser> AllUsers();
        void Insert(LocalUser account);
    }

    public class LocalUserDao : ILocalUserDao
    {
        public LocalUser LoadByUserName(string userName)
        {
            return new LocalUser
                {
                    Email = "joe.lowrance@gmail.com",
                    IsApproved = true,
                    Password = "foo",
                    PasswordAnswer = "dog",
                    PasswordQuestion = "best pet?",
                    ProviderUserKey = "google",
                    UserName = "joe"
                };
        }

        public void UpdateAccount(LocalUser account)
        {
            return;
        }

        public LocalUser FindByEmailAddress(string email)
        {
            return LoadByUserName(email);
        }

        public IList<LocalUser> AllUsers()
        {
            return new List<LocalUser>{LoadByUserName("")};
        }

        public void Insert(LocalUser account)
        {
            return;
        }
    }

  


    public class PiggyProvider : ExtendedMembershipProvider
    {
        //private IUserProfileRepository _repo;

        //public PiggyProvider(IUserProfileRepository repo)
        //{
        //    _repo = repo;
        //}

        private readonly ILocalUserDao _userDao  = new LocalUserDao();

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            var account = new LocalUser
                {
                    Email = email,
                    IsApproved = true,
                    Password = PasswordUtiltity.OneWayHash(password),
                    PasswordAnswer = passwordAnswer,
                    PasswordQuestion = passwordQuestion,
                    ProviderUserKey = providerUserKey,
                    UserName = username,
                };

            //repo.add


            status = MembershipCreateStatus.Success;

            return GetUser(username, userIsOnline: true);
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            var account = _userDao.LoadByUserName(username);

            if (account == null) return false;
            
            if (PasswordUtiltity.PasswordMatch(password, account.Password))
            {
                account.PasswordQuestion = newPasswordQuestion;
                account.PasswordAnswer = newPasswordAnswer;
                _userDao.UpdateAccount(account);
                return true;
            }

            return false;
        }

        public override string GetPassword(string username, string answer)
        {
            throw new ApplicationException("I don't know your password.  We hash shit around here.");
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            var account = _userDao.LoadByUserName(username);
            if (account == null) return false;

            if (PasswordUtiltity.PasswordMatch(oldPassword, account.Password))
            {
                account.Password = PasswordUtiltity.OneWayHash(newPassword);
                _userDao.UpdateAccount(account);
            }

            return false;
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new FileLoadException("We don't know your password.  Shit gets hashed around here.");
        }

        public override void UpdateUser(MembershipUser user)
        {
            //todo
        }

        public override bool ValidateUser(string username, string password)
        {
            var account = _userDao.LoadByUserName(username);

            if (account == null) return false;
            
            return PasswordUtiltity.PasswordMatch(password, account.Password);
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException("UnlockUser");
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            return GetUser(providerUserKey.ToString(), userIsOnline);
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            var account = _userDao.LoadByUserName(username);

            if (account != null)
            {
                return new MembershipUser(
                    "providername",
                    account.UserName,
                    account.ProviderUserKey,
                    account.Email,
                    account.PasswordQuestion, "",
                    isApproved: true,
                    isLockedOut: false, 
                    creationDate: DateTime.Now, 
                    lastLoginDate: DateTime.Now,
                    lastActivityDate: DateTime.Now, 
                    lastPasswordChangedDate: DateTime.Now,
                    lastLockoutDate: DateTime.MinValue);
            }

            return null;
        }

        public override string GetUserNameByEmail(string email)
        {
            var account = _userDao.FindByEmailAddress(email);
            return (account ?? new LocalUser()).UserName;
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException("DeleteUser");
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            var foo = _userDao.AllUsers();
            totalRecords = foo.Count;
            
            var result = new MembershipUserCollection();

            foo.ToList().ForEach(x =>
                {
                    var user = GetUser(x.UserName, true);
                    if (user != null)
                    {
                        result.Add(user);
                    }
                });

            return result;
        }

        public override int GetNumberOfUsersOnline()
        {
            return 100000;
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException("FindUsersByName");
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException("FindUsersByEmail");
        }

        public override bool EnablePasswordRetrieval
        {
            get { return false; }
        }

        public override bool EnablePasswordReset
        {
            get { return false; }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { return true; }
        }

        public override string ApplicationName { get; set; }

        public override int MaxInvalidPasswordAttempts
        {
            get { return 3; }
        }

        public override int PasswordAttemptWindow
        {
            get { return 5; }
        }

        public override bool RequiresUniqueEmail
        {
            get { return true; }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { return MembershipPasswordFormat.Hashed; }
        }

        public override int MinRequiredPasswordLength
        {
            get { return 6; }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { return 0; }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { return string.Empty; }
        }

        public override ICollection<OAuthAccountData> GetAccountsForUser(string userName)
        {
            return new Collection<OAuthAccountData>();
        }

        public override string CreateUserAndAccount(string userName, string password, bool requireConfirmation, IDictionary<string, object> values)
        {
            var account = new LocalUser {UserName = userName, Password = PasswordUtiltity.OneWayHash(password)};
            _userDao.Insert(account);
            return userName;
        }

        public override string CreateAccount(string userName, string password, bool requireConfirmationToken)
        {
            var account = new LocalUser { UserName = userName, Password = PasswordUtiltity.OneWayHash(password) };
            _userDao.Insert(account);
            return userName;
        }

        public override bool ConfirmAccount(string userName, string accountConfirmationToken)
        {
            return true;
        }

        public override bool ConfirmAccount(string accountConfirmationToken)
        {
            return true;
        }

        public override bool DeleteAccount(string userName)
        {
            return false;
        }

        public override string GeneratePasswordResetToken(string userName, int tokenExpirationInMinutesFromNow)
        {
            return "absc";
        }

        public override int GetUserIdFromPasswordResetToken(string token)
        {
            return 100;
        }

        public override bool IsConfirmed(string userName)
        {
            return true;
        }

        public override bool ResetPasswordWithToken(string token, string newPassword)
        {
            return true;
        }

        public override int GetPasswordFailuresSinceLastSuccess(string userName)
        {
            return 0;
        }

        public override DateTime GetCreateDate(string userName)
        {
            return DateTime.Now;
        }

        public override DateTime GetPasswordChangedDate(string userName)
        {
            return DateTime.Now;
        }

        public override DateTime GetLastPasswordFailureDate(string userName)
        {
            return DateTime.Now;
        }

        public override int GetUserIdFromOAuth(string provider, string providerUserId)
        {
            //this would be a select frmo statement from the userdao
            return -1;
        }

        public override string GetUserNameFromId(int userId)
        {
            return "joelowrance@gmail.com";
        }
    }
}