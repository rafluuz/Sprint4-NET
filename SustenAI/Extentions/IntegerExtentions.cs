namespace SustenAI.Extentions
{
    public static class IntegerExtentions
    {
        public static string ToCurrency(this int value)
        {
            return value.ToString("C");
        }
    }
}
