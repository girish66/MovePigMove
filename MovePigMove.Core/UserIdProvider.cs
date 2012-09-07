namespace MovePigMove.Core
{
    public class UserIdProvider
    {
        public string UserId()
        {
            return System.Threading.Thread.CurrentPrincipal.Identity.Name;
        }
    }
}