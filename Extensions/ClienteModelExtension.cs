using BaseConverter.Enums;
using BaseConverter.Models;
using System.Reflection;

namespace BaseConverter.Extensions
{
    /// <summary>
    /// Assigns a value to a property of a <see cref="ClienteModel"/> that corresponds to
    /// the <paramref name="column"/> of the database.
    /// </summary>
    /// <param name="model">Model to be modified.</param>
    /// <param name="column">Column to be changed.</param>
    /// <param name="value">New value.</param>
    public static class ClienteModelExtension
    {
        public static void SetValueColumn(this ClienteModel model, ColumnsSupportedCli column, object value)
        {
            foreach (PropertyInfo property in model.GetType().GetProperties())
            { if (property.Name == column.ToString()) { property.SetValue(model, value); } }
        }
    }
}
