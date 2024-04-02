using BaseConverter.Enums;
using BaseConverter.Extensions;

namespace BaseConverter.Managers
{
    public static class FormatManagement
    {
        public static object FormatValueForColumnProd(ColumnsSupportedProd column, string value)
        {
            return column switch
            {
                ColumnsSupportedProd.Referencia => value.RemoveMarks().CutIfTooLong(13),
                ColumnsSupportedProd.CodBarras => value.RemoveMarks().CutIfTooLong(14),
                ColumnsSupportedProd.Descricao => value.RemoveMarks().CutIfTooLong(120),
                ColumnsSupportedProd.Departamento => value.RemoveMarks().CutIfTooLong(15),
                ColumnsSupportedProd.Categoria => value.RemoveMarks().CutIfTooLong(15),
                ColumnsSupportedProd.Unidade => value.RemoveMarks().CutIfTooLong(3),
                ColumnsSupportedProd.Marca => value.RemoveMarks().CutIfTooLong(15),
                ColumnsSupportedProd.ValorCustoMedio => value.ToDecimal() ?? throw new Exception("Invalid value for column: " + column.ToString()),
                ColumnsSupportedProd.PrecoVendaVarejo => value.ToDecimal() ?? throw new Exception("Invalid value for column: " + column.ToString()),
                ColumnsSupportedProd.PrecoVendaAtacado => value.ToDecimal() ?? throw new Exception("Invalid value for column: " + column.ToString()),
                ColumnsSupportedProd.PrecoVendaPromocional => value.ToDecimal() ?? throw new Exception("Invalid value for column: " + column.ToString()),
                ColumnsSupportedProd.Ncm => value.RemoveMarks().CutIfTooLong(8),
                ColumnsSupportedProd.CSOSN => value.RemoveMarks().CutIfTooLong(3),
                ColumnsSupportedProd.CEST => value.RemoveMarks().CutIfTooLong(7),
                ColumnsSupportedProd.ProdCfopSai => value.RemoveMarks().CutIfTooLong(4),
                ColumnsSupportedProd.Quantidade => value.ToDecimal() ?? throw new Exception("Invalid value for column: " + column.ToString()),
                ColumnsSupportedProd.Ativo => value.TryBoolParse()?.ToInt() ?? throw new Exception("Invalid value for column: " + column.ToString()),
                _ => throw new Exception("Column not implemented in FormatValueForColumnProd()"),
            };
        }

        public static object FormatValueForColumnCli(ColumnsSupportedCli column, string value)
        {
            return column switch
            {
                ColumnsSupportedCli.Nome => value.RemoveMarks().CutIfTooLong(60),
                ColumnsSupportedCli.NomeFantasia => value.RemoveMarks().CutIfTooLong(50),
                ColumnsSupportedCli.Ende => value.RemoveMarks().CutIfTooLong(60),
                ColumnsSupportedCli.Numero => value.RemoveMarks().CutIfTooLong(10),
                ColumnsSupportedCli.Complemento => value.RemoveMarks().CutIfTooLong(20),
                ColumnsSupportedCli.Bairro => value.RemoveMarks().CutIfTooLong(60),
                ColumnsSupportedCli.Cep => value.RemoveMarks().CutIfTooLong(8),
                ColumnsSupportedCli.Celular => value.ToCell().CutIfTooLong(11),
                ColumnsSupportedCli.Celular2 => value.ToCell().CutIfTooLong(11),
                ColumnsSupportedCli.Tel => value.ToPhone().CutIfTooLong(10),
                ColumnsSupportedCli.Uf => value.RemoveMarks().CutIfTooLong(2),
                ColumnsSupportedCli.Cidade => value.RemoveMarks().CutIfTooLong(32),
                ColumnsSupportedCli.CodMunicipio => value.RemoveMarks().CutIfTooLong(7),
                ColumnsSupportedCli.CpfCnpj => value.RemoveMarks().CutIfTooLong(14),
                ColumnsSupportedCli.InscEst => value.RemoveMarks().CutIfTooLong(14),
                ColumnsSupportedCli.DataControl => value.ToDateTime()!.IsNotNull() ? value.ToDateTime()?.ToString("yyyy/MM/dd")! :
                                        throw new Exception("Invalid value for column: " + column.ToString()), 
                _ => throw new Exception("Column not implemented in FormatValueForColumnCli()"),
            };
        }

        public static string FormatByStringSql(object? value)
        {
            if (value == null) { return "NULL"; }
            if (value is string) { return $"'{value}'"; }
            if (value is int ) { return $"{value}"; }
            if (value is decimal ) { return $"{decimal.Parse(value.ToString()!).ToFormatWithDot()}"; }
            if (value is bool) { return $"{bool.Parse(value.ToString()!).ToInt()}"; }
            if (value is DateTime) { return $"'{value.ToString()!.ToDateTime()?.ToString("yyyy-MM-dd HH:mm:ss")}'"; }

            else { throw new Exception("Type not implemented in FormatByStringSql()"); }
        }
    }
}
