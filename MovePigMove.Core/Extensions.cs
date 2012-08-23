namespace MovePigMove.Core
{
    public static class Extensions
    {
        public static string ToFormat(this string @this, params object[] args)
        {
            return string.Format(@this, args);
        }
    }
}