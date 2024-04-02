namespace BaseConverter.Extensions
{
    public static class DecimalExtension
    {
        public static string ToFormatWithDot(this decimal value) => value.ToString().Replace(",", ".");
    }
}
