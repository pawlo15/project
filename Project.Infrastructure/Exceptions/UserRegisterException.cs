using Project.Infrastructure.Accessories;

namespace Project.Infrastructure.Exceptions
{
    public class UserRegisterException : Exception
    {
        public ErrorCode ErrorCode;
        public UserRegisterException(ErrorCode errorCode) : base(Errors.GetValue(errorCode))
        {
            ErrorCode = errorCode;
        }
    }
}
