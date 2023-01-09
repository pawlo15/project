using Project.Infrastructure.Accessories;

namespace Project.Infrastructure.Exceptions
{
    public class NoActiveAccountException : Exception
    {
        public ErrorCode ErrorCode;
        public NoActiveAccountException(ErrorCode errorCode) : base(Errors.GetValue(errorCode)) 
        {
            ErrorCode = errorCode;
        }
    }
}
