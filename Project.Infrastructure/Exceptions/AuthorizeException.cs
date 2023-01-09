using Project.Infrastructure.Accessories;

namespace Project.Infrastructure.Exceptions
{
    public class AuthorizeException : Exception
    {
        public ErrorCode ErrorCode;
        public AuthorizeException(ErrorCode errorCode) : base(Errors.GetValue(errorCode)) 
        {
            ErrorCode = errorCode;
        }
    }
}
