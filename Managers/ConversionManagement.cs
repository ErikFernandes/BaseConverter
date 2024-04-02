using System.Text;
using System.Reflection;
using BaseConverter.Enums;
using BaseConverter.Global;
using BaseConverter.Models;
using BaseConverter.Extensions;

namespace BaseConverter.Managers
{
    public static class ConversionManagement
    {
        private static bool LetterIsNotValid(string l) =>
            l != string.Empty && (l.Length > 1 || !Enum.IsDefined(typeof(ColumnsIndex), l));

        private static string CreateCommandLineProdutos(ProdutoModel produto, ProdutosQtdModel produtoQtd)
        {
            List<string> values = [];
            StringBuilder sb = new ();

            #region Produtos

            sb.Append("INSERT INTO Produtos VALUES(");
            foreach (PropertyInfo property in produto.GetType().GetProperties())
            { values.Add(FormatManagement.FormatByStringSql(property.GetValue(produto))); }
            sb.Append(string.Join(", ", values) + "); \n");
            values.Clear();

            #endregion

            #region ProdutosQtd

            sb.Append("INSERT INTO ProdutosQtd VALUES(");
            foreach (PropertyInfo property in produtoQtd.GetType().GetProperties())
            { values.Add(FormatManagement.FormatByStringSql(property.GetValue(produtoQtd))); }
            sb.Append(string.Join(", ", values) + ");");

            #endregion
            
            return sb.ToString();
        }

        private static string CreateCommandLineClientes(ClienteModel cliente)
        {
            List<string> values = [];
            StringBuilder sb = new();

            sb.Append("INSERT INTO CadCli VALUES(");
            foreach (PropertyInfo property in cliente.GetType().GetProperties())
            { values.Add(FormatManagement.FormatByStringSql(property.GetValue(cliente))); }
            sb.Append(string.Join(", ", values) + "); \n");

            return sb.ToString();
        }


        public static void LoadColumnsProdutos()
        {
            foreach (ColumnsSupportedProd column in GlobalVariables.SelectedColumnsProd.Keys)
            {
                Console.Write($"{column,-22} : ");

                string valueEnter = Console.ReadLine()?.ToUpper() ?? string.Empty;

                if (LetterIsNotValid(valueEnter))
                {
                    while (true)
                    {
                        Console.WriteLine("Opção inválida! Tente novamente: ");
                        valueEnter = Console.ReadLine()?.ToUpper() ?? string.Empty;
                        if (!LetterIsNotValid(valueEnter)) { break; }
                    }
                }

                if (valueEnter != string.Empty)
                { GlobalVariables.SelectedColumnsProd[column] = (int)Enum.Parse<ColumnsIndex>(valueEnter); }
            }
        }

        public static void LoadColumnsClientes()
        {
            foreach (ColumnsSupportedCli column in GlobalVariables.SelectedColumnsCli.Keys)
            {
                Console.Write($"{column,-22} : ");

                string valueEnter = Console.ReadLine()?.ToUpper() ?? string.Empty;

                if (LetterIsNotValid(valueEnter))
                {
                    while (true)
                    {
                        Console.WriteLine("Opção inválida! Tente novamente: ");
                        valueEnter = Console.ReadLine()?.ToUpper() ?? string.Empty;
                        if (!LetterIsNotValid(valueEnter)) { break; }
                    }
                }

                if (valueEnter != string.Empty)
                { GlobalVariables.SelectedColumnsCli[column] = (int)Enum.Parse<ColumnsIndex>(valueEnter); }
            }
        }
        

        public static void BuildLineProdutos(string line)
        {

            string[] lineValues = line.Split(";");

            ProdutoModel produto = new();
            ProdutosQtdModel produtoQtd = new();

            produto.IdProd = GlobalVariables.CurrentIdProdutos;
            produtoQtd.IdProdQtd = GlobalVariables.CurrentIdProdutosQtd;

            foreach (ColumnsSupportedProd column in GlobalVariables.SelectedColumnsProd.Keys)
            {
                if (GlobalVariables.SelectedColumnsProd[column]!.IsNull()) { continue; }

                if (column == ColumnsSupportedProd.Quantidade) 
                { 
                    produtoQtd.Quantidade = lineValues[GlobalVariables.SelectedColumnsProd[column]!.Value].ToDecimal() ?? 0;
                    continue; 
                }

                produto.SetValueColumn(column, FormatManagement.
                    FormatValueForColumnProd(column, lineValues[GlobalVariables.SelectedColumnsProd[column]!.Value]));
            }

            GlobalVariables.StringOutput.AppendLine(CreateCommandLineProdutos(produto, produtoQtd));
        }

        public static void BuildLineClientes(string line)
        {

            string[] lineValues = line.Split(";");

            ClienteModel cliente = new()
            { IdCadCli = GlobalVariables.CurrentIdClientes };

            foreach (ColumnsSupportedCli column in GlobalVariables.SelectedColumnsCli.Keys)
            {
                if (GlobalVariables.SelectedColumnsCli[column]!.IsNull()) { continue; }

                cliente.SetValueColumn(column, FormatManagement.
                    FormatValueForColumnCli(column, lineValues[GlobalVariables.SelectedColumnsCli[column]!.Value]));
            }

            GlobalVariables.StringOutput.AppendLine(CreateCommandLineClientes(cliente));
        }
    }
}
