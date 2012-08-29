using System;

namespace MovePigMove.Web.Controllers
{
    public class MembershipException : Exception
    {
        public MembershipException() : base("Membership functionality is not implemented in this web site.")
        {

        }
    }
}