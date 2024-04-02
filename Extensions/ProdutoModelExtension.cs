using BaseConverter.Enums;
using BaseConverter.Models;
using System.Reflection;

namespace BaseConverter.Extensions
{
    public static class ProdutoModelExtension
    {
        public static void SetValueColumn(this ProdutoModel model, ColumnsSupportedProd column, object value)
        {
            foreach (PropertyInfo property in model.GetType().GetProperties())
            { if (property.Name == column.ToString()) { property.SetValue(model, value); break; } }
        }
    }
}
