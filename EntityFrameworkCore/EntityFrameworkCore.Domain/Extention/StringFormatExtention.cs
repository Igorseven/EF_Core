namespace EFCore.Domain.Extention
{
    public static class StringFormatExtention
    {
        public static string ToFormatMessage(this string message, params object[] args)
        {
            return string.Format(message, args);
        }
    }
}
