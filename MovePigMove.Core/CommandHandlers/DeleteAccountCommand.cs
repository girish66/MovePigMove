namespace MovePigMove.Core.CommandHandlers
{
    public class DeleteAccountCommand : AbstractUserProfileCommand
    {
        public DeleteAccountCommand(string providerName, string providerUserId, string userName)
            : base(providerName, providerUserId, userName)
        {
        }
    }
}