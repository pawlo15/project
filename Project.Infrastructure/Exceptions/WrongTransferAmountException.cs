using Project.Infrastructure.Accessories;

namespace Project.Infrastructure.Exceptions
{
    public class WrongTransferAmountException : Exception
    {
        public ErrorCode ErrorCode;
        public WrongTransferAmountException(ErrorCode errorCode) : base(Errors.GetValue(errorCode)) 
        {
            ErrorCode = errorCode;
        }
    }
}
