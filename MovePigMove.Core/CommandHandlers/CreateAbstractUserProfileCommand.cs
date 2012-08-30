namespace MovePigMove.Core.CommandHandlers
{
    public class CreateAbstractUserProfileCommand : AbstractUserProfileCommand
    {
        public CreateAbstractUserProfileCommand(string providerName, string providerUserId, string userName)
            : base(providerName, providerUserId, userName)
        {
        }
    }
}