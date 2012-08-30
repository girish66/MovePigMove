namespace MovePigMove.Core.CommandHandlers
{
    public class ChangeUserNameCommand : AbstractUserProfileCommand
    {
        public ChangeUserNameCommand(string providerName, string providerUserId, string userName)
            : base(providerName, providerUserId, userName)
        { 
        }
    }
}