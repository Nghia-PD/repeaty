/*
base(message) mean usinng message param from exception since 
my exception innheritage Exception class
*/
public static class CustomExceptions
{
    public class BadRequestBodyException : Exception
    {
        public BadRequestBodyException(string message) : base(message) { }
    }

    public class ConflictException : Exception
    {
        public string Code { get; }

        public ConflictException(string code, string message) : base(message)
        {
            Code = code;
        }
    }
}