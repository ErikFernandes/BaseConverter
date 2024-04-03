namespace BaseConverter.Extensions
{
    public static class BoolExtension
    {
        /// <summary>
        /// Converte um valor <see cref="bool"/> para um valor <see cref="int"/> no tipo Bit.
        /// </summary>
        /// <param name="value">Valor a ser convertido.</param>
        /// <returns>1 se o valor for <see langword="true"/>, 0 se o valor for <see langword="false"/>.</returns>
        public static int ToInt(this bool value) =>
            value ? 1 : 0;
    }
}
