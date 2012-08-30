using MovePigMove.Core.Documents;
using MovePigMove.Core.Entities;
using MovePigMove.Core.Storage;

namespace MovePigMove.Core.CommandHandlers
{
    public class CreateUserProfileCommandHandler : ICommandHandler<CreateAbstractUserProfileCommand>
    {
        private Storage.IUserProfileRepository _repo;

        public CreateUserProfileCommandHandler(IUserProfileRepository repo)
        {
            _repo = repo;
        }

        public void Handle(CreateAbstractUserProfileCommand command)
        {
            var doc = new UserProfileDocument
                {
                    ProviderName = command.ProviderName,
                    ProviderUserId = command.ProviderUserId,
                    UserName = command.UserName
                };

            var entity = new UserProfile(doc);
            _repo.Add(entity);
        }
    }
}