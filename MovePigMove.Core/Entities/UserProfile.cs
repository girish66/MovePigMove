using MovePigMove.Core.Documents;

namespace MovePigMove.Core.Entities
{
    public class UserProfile : IDomainEntity<UserProfileDocument>
    {
        private UserProfileDocument _inner;

        public int Id { get { return _inner.Id; } }
        public string UserName { get { return _inner.UserName; } }
        public string ProviderName { get { return _inner.ProviderName; } }
        public string ProviderUserId { get { return _inner.ProviderUserId; } }

        public UserProfile(UserProfileDocument profileDocument)
        {
            _inner = profileDocument;
        }

        public UserProfileDocument GetInnerModel()
        {
            return _inner;
        }

        

        public void ChangeUserName(string userName)
        {
            _inner.UserName = userName;
        }
    }
}