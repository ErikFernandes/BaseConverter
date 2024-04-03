using BaseConverter.Enums;
using BaseConverter.Models;
using System.Reflection;

namespace BaseConverter.Extensions
{
    /// <summary>
    /// Atribui um valor a uma propriedade de um <see cref="ClienteModel"/> que corresponde a
    /// <paramref name="column"/> do banco.
    /// </summary>
    /// <param name="model">Modelo a ser alterado.</param>
    /// <param name="column">Coluna que deseja alterar.</param>
    /// <param name="value">Novo valor.</param>
    public static class ClienteModelExtension
    {
        public static void SetValueColumn(this ClienteModel model, ColumnsSupportedCli column, object value)
        {
            foreach (PropertyInfo property in model.GetType().GetProperties())
            { if (property.Name == column.ToString()) { property.SetValue(model, value); } }
        }
    }
}
