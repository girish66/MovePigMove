namespace MovePigMove.Core.CommandHandlers
{
    public abstract class AbstractUserProfileCommand
    {
        public string ProviderUserId { get; set; }
        public string ProviderName { get; set; }
        public string UserName { get; set; }


        protected AbstractUserProfileCommand(string providerName, string providerUserId, string userName)
        {
            ProviderUserId = providerUserId;
            ProviderName = providerName;
            UserName = userName;
        }
    }
}