namespace BaseConverter.Extensions
{
    public static class ListExtension
    {
        /// <summary>
        /// Adits the <paramref name="value"/> to the list if it is not already in it.
        /// </summary>
        /// <param name="list">List to be modified.</param>
        /// <param name="value">Value to be added.</param>
        public static void AddIfNotExists<T>(this List<T> list, T value)
        { if (!list.Contains(value)) { list.Add(value); } }
        
    }
}
