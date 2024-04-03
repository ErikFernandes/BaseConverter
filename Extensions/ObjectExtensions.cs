namespace BaseConverter.Extensions
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Checks if the object is null.
        /// </summary>
        /// <param name="obj">Object to be checked.</param>
        /// <returns>True if the object is null.</returns>
        public static bool IsNull(this object obj) =>
            obj is null;

        /// <summary>
        /// Checks if the object is not null.
        /// </summary>
        /// <param name="obj">Object to be checked.</param>
        /// <returns>True if the object is not null.</returns>
        public static bool IsNotNull(this object obj) =>
            obj is not null;
    }
}
