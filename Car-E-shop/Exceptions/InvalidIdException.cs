namespace Car_E_shop.Exceptions
{
    public class InvalidIdException: Exception
    {
        public InvalidIdException() : base()
        {
        }
        public InvalidIdException(string message) : base(message)
        {
        }
        public InvalidIdException(string message, Exception e) : base(message, e)
        {
        }
    }
}
