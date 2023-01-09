namespace Project.Infrastructure.Accessories
{
    public enum ErrorCode
    {
        ERR000,
        ERR001,
        ERR002,
        ERR003,
        ERR004
    }
    public class Errors
    {
        public static Dictionary<ErrorCode, string> ErrorDescription = new Dictionary<ErrorCode, string>()
        {
            {ErrorCode.ERR000, "Wystąpił nieoczekiwany błąd." },
            {ErrorCode.ERR001, "Nieprawidłowy login lub hasło." },
            {ErrorCode.ERR002, "Login nie spełnia wymagań." },
            {ErrorCode.ERR003, "Brak wystarczających środków na koncie." },
            {ErrorCode.ERR004, "Konto nie jest aktywne." }
        };

        public static string GetErrorCode(ErrorCode errorCode)
        {
            if (ErrorDescription.ContainsKey(errorCode))
                return errorCode.ToString();
            else
                return string.Empty;
        }

        public static string GetValue(ErrorCode errorCode)
        {
            if (ErrorDescription.ContainsKey(errorCode))
                return ErrorDescription.FirstOrDefault(e => e.Key == errorCode).Value.ToString();
            else
                return string.Empty;
        }
    }
}
