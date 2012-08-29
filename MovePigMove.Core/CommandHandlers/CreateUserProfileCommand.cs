using MovePigMove.Core.Documents;
using MovePigMove.Core.Entities;
using MovePigMove.Core.Storage;

namespace MovePigMove.Core.CommandHandlers
{
    public class CreateUserProfileCommandHandler : ICommandHandler<CreateUserProfileCommand>
    {
        private Storage.IUserProfileRepository _repo;

        public CreateUserProfileCommandHandler(IUserProfileRepository repo)
        {
            _repo = repo;
        }

        public void Handle(CreateUserProfileCommand command)
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

    public class CreateUserProfileCommand
    {
        public string ProviderUserId { get; set; }
        public string ProviderName { get; set; }
        public string UserName { get; set; }


        public CreateUserProfileCommand(string providerUserId, string providerName, string userName)
        {
            ProviderUserId = providerUserId;
            ProviderName = providerName;
            UserName = userName;
        }
    }
}