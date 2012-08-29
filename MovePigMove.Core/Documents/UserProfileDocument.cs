namespace MovePigMove.Core.Documents
{
    public class UserProfileDocument
    {
        public int Id { get; set; }
        public string ProviderName { get; set; }
        public string ProviderUserId { get; set; }
        public string UserName { get; set; }
    }
}