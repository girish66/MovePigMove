using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web.Security;
using Microsoft.Web.WebPages.OAuth;
using MovePigMove.Core.CommandHandlers;
using MovePigMove.Core.Storage;

namespace MovePigMove.Web.Controllers
{
    public class AuthenticationService
    {
        private IUserProfileRepository _profileRepository;
        private ICommandInvoker _invoker;

        public AuthenticationService(IUserProfileRepository profileRepository, ICommandInvoker invoker)
        {
            _profileRepository = profileRepository;
            _invoker = invoker;
        }

        public bool Login(string providerName, string provderUserId, bool createPersistentCookie = false)
        {
            var account = LoadAccountBasedOnExternalCredentials(providerName, provderUserId);

            if (account != null)
            {
                FormsAuthentication.SetAuthCookie(account.UserName, createPersistentCookie);
                FormsAuthentication.RedirectFromLoginPage(account.UserName, createPersistentCookie);
                return true;
            }

            return false;
        }

        public void CreateOrUpdateAccount(string providerName, string providerUserId, string userName)
        {
            var account = LoadAccountBasedOnExternalCredentials(providerName, providerUserId);

            if (account == null)
            {
                CreateAccount(providerName, providerUserId, userName);
            }
            else
            {
                ChangeAccountUserName(providerName, providerUserId, userName);
            }
        }

        private void ChangeAccountUserName(string providerName, string providerUserId, string userName)
        {
            var command = new ChangeUserNameCommand(providerName, providerUserId, userName);
            _invoker.Execute(command);
            
        }

        public void CreateAccount(string providerName, string providerUserId, string userName)
        {
            var command = new CreateAbstractUserProfileCommand(providerName, providerUserId, userName);
            _invoker.Execute(command);
        }

        private Core.Entities.UserProfile LoadAccountBasedOnExternalCredentials(string providerName, string providerUserId)
        {
            return
                _profileRepository.Where(new FindUserByProviderAndProviderIdQuery(providerName, providerUserId)).
                    SingleOrDefault();
        }

        public bool UserNameExists(string userName)
        {
            return _profileRepository.Where(new FindUserByUserNameQuery(userName)).FirstOrDefault() != null;
        }


        public ICollection<OAuthAccount> GetAccountsFromUserName(string userName)
        {
            var accounts = _profileRepository.Where(new FindUserByUserNameQuery(userName));
            var list = new Collection<OAuthAccount>();

            foreach (var profile in accounts)
            {
                list.Add(new OAuthAccount(profile.ProviderName, profile.ProviderUserId));
            }

            return list;
        }

        public string GetUserName(string providerId, string providerUserId)
        {
            var item = _profileRepository.Where(new FindUserByProviderAndProviderIdQuery(providerId, providerUserId));
            return item.FirstOrDefault().UserName;
        }

        public void DeleteAccount(string provider, string providerUserId)
        {
            var command = new DeleteAccountCommand(provider, providerUserId, string.Empty);
            _invoker.Execute(command);
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}