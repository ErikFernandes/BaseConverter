namespace BaseConverter.Extensions
{
    public static class BoolExtension
    {
        /// <summary>
        /// Converts a <see cref="bool"/> value to an <see cref="int"/> value in Bit type.
        /// </summary>
        /// <param name="value">Value to be converted.</param>
        /// <returns>1 if the value is <see langword="true"/>, 0 if the value is <see langword="false"/>.</returns>
        public static int ToInt(this bool value) =>
            value ? 1 : 0;
    }
}
