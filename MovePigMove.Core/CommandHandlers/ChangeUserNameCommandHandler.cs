using System.Linq;
using MovePigMove.Core.Storage;

namespace MovePigMove.Core.CommandHandlers
{
    public class ChangeUserNameCommandHandler : ICommandHandler<ChangeUserNameCommand>
    {
        private IUserProfileRepository _repo;

        public ChangeUserNameCommandHandler(IUserProfileRepository repo)
        {
            _repo = repo;
        }

        public void Handle(ChangeUserNameCommand command)
        {
            var doc = _repo.Where(new FindUserByProviderAndProviderIdQuery(command.ProviderName, command.ProviderUserId)).Single();
            doc.ChangeUserName(command.UserName);
        }
    }
}