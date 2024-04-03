namespace BaseConverter.Extensions
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Verifica se o objeto é nulo.
        /// </summary>
        /// <param name="obj">Objeto a ser verificado.</param>
        /// <returns>True se o objeto for nulo.</returns>
        public static bool IsNull(this object obj) =>
            obj is null;

        /// <summary>
        /// Verifica se o objeto não é nulo.
        /// </summary>
        /// <param name="obj">Objeto a ser verificado.</param>
        /// <returns>True se o objeto não for nulo.</returns>
        public static bool IsNotNull(this object obj) =>
            obj is not null;
    }
}
