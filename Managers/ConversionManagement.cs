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
        /// Verifica se a entrada <paramref name="l"/> é válida e do tipo <see cref="ColumnsIndex"/>.
        /// </summary>
        /// <param name="l">String a ser verificada.</param>
        /// <returns>True se <paramref name="l"/> é válida.</returns>
        private static bool LetterIsNotValid(string l) =>
            l != string.Empty && (l.Length > 1 || !Enum.IsDefined(typeof(ColumnsIndex), l));

        /// <summary>
        /// Cria uma linha de INSERT na tabela <see cref="Produtos"/> e <see cref="ProdutosQtd"/>
        /// </summary>
        /// <param name="produto">Modelo preenchido com os valores das colunas.</param>
        /// <param name="produtoQtd">Modelo preenchido com os valores das colunas.</param>
        /// <returns>String contendo o INSERT nas duas tabelas.</returns>
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
        /// Cria uma linha de INSERT na tabela <see cref="CadCli"/>
        /// </summary>
        /// <param name="cliente">Modelo preenchido com os valores das colunas.</param>
        /// <returns>String contendo o INSERT na tabela.</returns>
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
        /// Recebe o input do usuário pelo <see cref="Console"/> e atualiza a <see cref="GlobalVariables.SelectedColumnsProd"/> <br/>
        /// com as colunas selecionadas pelo usuário.
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
        /// Recebe o input do usuário pelo <see cref="Console"/> e atualiza a <see cref="GlobalVariables.SelectedColumnsCli"/> <br/>
        /// com as colunas selecionadas pelo usuário.
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
        /// Monta e adiciona uma linha de INSERT de produtos a partir de uma linha (<paramref name="line"/>) csv <br/>
        /// com os valores desejados.
        /// </summary>
        /// <param name="line">Linha csv(;) com os valores.</param>
        public static void BuildLineProdutos(string line)
        {

            string[] lineValues = line.Split(";");

            ProdutoModel produto = new();
            ProdutosQtdModel produtoQtd = new();

            // Se a tabela usada tiver autoincremento, o ID não precisa ser adicionado nos 
            // modelos do banco de dados.
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
        /// Monta e adiciona uma linha de INSERT de clientes a partir de uma linha (<paramref name="line"/>) csv <br/>
        /// com os valores desejados.
        /// </summary>
        /// <param name="line">Linha csv(;) com os valores.</param>
        public static void BuildLineClientes(string line)
        {

            string[] lineValues = line.Split(";");

            // Se a tabela usada tiver autoincremento, o ID não precisa ser adicionado nos 
            // modelos do banco de dados.
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
