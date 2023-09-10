namespace Car_E_shop.ErrorMessages
{
    public static class Message
    {

        public static string InvalidId(int? id)
        {
            return $"The {nameof(id)} is null or negative";
        }

        public static string ObjectIsNull(object obj)
        {
            return $"The {nameof(obj)} is null";
        }
    }
}
