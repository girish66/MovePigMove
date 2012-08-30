using System.Linq;
using MovePigMove.Core.Storage;

namespace MovePigMove.Core.CommandHandlers
{
    public class DeleteAccountCommandHandler : ICommandHandler<DeleteAccountCommand>
    {
        private IUserProfileRepository _repo;

        public DeleteAccountCommandHandler(IUserProfileRepository repo)
        {
            _repo = repo;
        }

        public void Handle(DeleteAccountCommand command)
        {
            var account = _repo.Where(new FindUserByProviderAndProviderIdQuery(command.ProviderName, command.ProviderUserId)).Single();
            _repo.Remove(account);
        }
    }
}