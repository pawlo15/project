using Project.Infrastructure.Accessories;

namespace Project.Infrastructure.Exceptions
{
    public class DomainException : Exception
    {
        public ErrorCode ErrorCode;
        public DomainException(ErrorCode errorCode): base(Errors.GetValue(errorCode)) 
        {
            ErrorCode = errorCode;
        }
    }
}
