using BaseConverter.Enums;
using BaseConverter.Models;
using System.Reflection;

namespace BaseConverter.Extensions
{
    public static class ProdutoModelExtension
    {
        /// <summary>
        /// Assigns a value to a property of a <see cref="ProdutoModel"/> that corresponds to
        /// the <paramref name="column"/> of the database.
        /// </summary>
        /// <param name="model">Model to be modified.</param>
        /// <param name="column">Column to be changed.</param>
        /// <param name="value">New value.</param>
        public static void SetValueColumn(this ProdutoModel model, ColumnsSupportedProd column, object value)
        {
            foreach (PropertyInfo property in model.GetType().GetProperties())
            { if (property.Name == column.ToString()) { property.SetValue(model, value); break; } }
        }
    }
}
