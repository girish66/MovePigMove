namespace MovePigMove.Core.Documents
{
    public class UserProfileDocument
    {
        public int Id { get; set; }
        public string ProviderName { get; set; }
        public string ProviderUserId { get; set; }
        public string UserName { get; set; }


        //public string UserName { get; set; }
        //public string Password { get; set; }
        //public string Email { get; set; }
        //public string PasswordQuestion { get; set; }
        //public string PasswordAnswer { get; set; }
        //public bool IsApproved { get; set; }
        //public object ProviderUserKey { get; set; }
    }

    
}