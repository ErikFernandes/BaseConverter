namespace BaseConverter.Extensions
{
    public static class DecimalExtension
    {
        /// <summary>
        /// Converts a <see cref="decimal"/> value to a <see cref="string"/> value by replacing "," with ".".
        /// </summary>
        /// <param name="value">Value to be converted.</param>
        /// <returns><paramref name="value"/> converted to a <see cref="string"/> with "," replaced by ".".</returns>
        public static string ToFormatWithDot(this decimal value) => value.ToString().Replace(",", ".");
    }
}
