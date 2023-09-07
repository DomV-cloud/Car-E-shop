namespace Car_E_shop.Exceptions
{
    public class ObjectIsNullException : Exception
    {
        public ObjectIsNullException() : base()
        {
        }
        public ObjectIsNullException(string message) : base(message)
        {
        }
        public ObjectIsNullException(string message, Exception e) : base(message, e)
        {
        }
    }
}
