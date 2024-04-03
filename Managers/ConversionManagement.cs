using BaseConverter.Enums;
using BaseConverter.Extensions;
using BaseConverter.Global;
using BaseConverter.Models;
using System.Reflection;
using System.Text;

namespace BaseConverter.Managers
{
    public static class ConversionManagement
    {
        /// <summary>
        /// Checks if the input <paramref name="l"/> is valid and of type <see cref="ColumnsIndex"/>.
        /// </summary>
        /// <param name="l">String to be checked.</param>
        /// <returns>True if <paramref name="l"/> is valid.</returns>
        private static bool LetterIsNotValid(string l) =>
            l != string.Empty && (l.Length > 1 || !Enum.IsDefined(typeof(ColumnsIndex), l));

        /// <summary>
        /// Creates an INSERT statement for the tables <see cref="Produtos"/> and <see cref="ProdutosQtd"/>.
        /// </summary>
        /// <param name="produto">Model filled with column values.</param>
        /// <param name="produtoQtd">Model filled with column values.</param>
        /// <returns>String containing the INSERT for both tables.</returns>
        private static string CreateCommandLineProdutos(ProdutoModel produto, ProdutosQtdModel produtoQtd)
        {
            List<string> values = [];
            StringBuilder sb = new();

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

        /// <summary>
        /// Creates an INSERT statement for the table <see cref="CadCli"/>.
        /// </summary>
        /// <param name="cliente">Model filled with column values.</param>
        /// <returns>String containing the INSERT for the table.</returns>
        private static string CreateCommandLineClientes(ClienteModel cliente)
        {
            List<string> values = [];
            StringBuilder sb = new();

            #region CadCli

            sb.Append("INSERT INTO CadCli VALUES(");
            foreach (PropertyInfo property in cliente.GetType().GetProperties())
            { values.Add(FormatManagement.FormatByStringSql(property.GetValue(cliente))); }
            sb.Append(string.Join(", ", values) + "); \n");

            #endregion

            return sb.ToString();
        }


        /// <summary>
        /// Receives user input through the <see cref="Console"/> and updates the <see cref="GlobalVariables.SelectedColumnsProd"/> <br/>
        /// with the columns selected by the user.
        /// </summary>
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

        /// <summary>
        /// Receives user input through the <see cref="Console"/> and updates the <see cref="GlobalVariables.SelectedColumnsCli"/> <br/>
        /// with the columns selected by the user.
        /// </summary>
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

        /// <summary>
        /// Builds and adds an INSERT statement for products from a CSV (<paramref name="line"/>) row <br/>
        /// with the desired values.
        /// </summary>
        /// <param name="line">CSV row (;) with values.</param>
        public static void BuildLineProdutos(string line)
        {

            string[] lineValues = line.Split(";");

            ProdutoModel produto = new();
            ProdutosQtdModel produtoQtd = new();

            // If the used table has auto-increment, the ID does not need to be added in the 
            // database models.
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

        /// <summary>
        /// Builds and adds an INSERT statement for clients from a CSV (<paramref name="line"/>) row <br/>
        /// with the desired values.
        /// </summary>
        /// <param name="line">CSV row (;) with values.</param>
        public static void BuildLineClientes(string line)
        {

            string[] lineValues = line.Split(";");

            // If the used table has auto-increment, the ID does not need to be added in the 
            // database models.
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
