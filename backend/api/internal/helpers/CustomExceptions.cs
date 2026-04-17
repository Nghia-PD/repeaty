public static class CustomExceptions
{
    public class BadRequestBodyException : Exception
    {
        public BadRequestBodyException(string message) : base(message) { }
    }
}