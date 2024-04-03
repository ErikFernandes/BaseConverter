namespace BaseConverter.Extensions
{
    public static class DecimalExtension
    {
        /// <summary>
        /// Converte um valor <see cref="decimal"/> para um valor <see cref="string"/> substituindo "," por ".".
        /// </summary>
        /// <param name="value">Valor a ser convertido.</param>
        /// <returns><paramref name="value"/> convertido para <see cref="string"/> com "," substituido por ".".</returns>
        public static string ToFormatWithDot(this decimal value) => value.ToString().Replace(",", ".");
    }
}
