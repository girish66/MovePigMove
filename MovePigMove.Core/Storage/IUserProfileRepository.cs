using MovePigMove.Core.Documents;
using MovePigMove.Core.Entities;
using Raven.Client;

namespace MovePigMove.Core.Storage
{
    public interface IUserProfileRepository : IRepository<UserProfile, UserProfileDocument>
    {
    }

    public class UserProfileRepository : BaseRepository<UserProfile, UserProfileDocument>,  IUserProfileRepository
    {
        public UserProfileRepository(IDocumentSession documentSession) : base(documentSession)
        {
        }

        protected override UserProfile CreateFromDataModel(UserProfileDocument dataModel)
        {
            return new UserProfile(dataModel);
        }

    }
}