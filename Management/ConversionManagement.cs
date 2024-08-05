using BaseConverter.Enums;
using BaseConverter.Extensions;
using BaseConverter.Global;
using BaseConverter.Models;
using System.Reflection;
using System.Text;

namespace BaseConverter.Management
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
        /// Creates an INSERT statement for the table <paramref name="tableName"/> with the values of <paramref name="model"/>.
        /// </summary>
        /// <param name="tableName">Table name.</param>
        /// <param name="model">Model filled with column values.</param>
        /// <returns>String containing the INSERT for the table.</returns>
        private static string BuildSqlInsertStatement(string tableName, object model)
        {
            List<string> values = [];
            StringBuilder sb = new();

            sb.Append($"INSERT INTO {tableName} VALUES(");
            foreach (PropertyInfo property in model.GetType().GetProperties())
            { values.Add(FormatManagement.FormatByStringSql(property.GetValue(model))); }
            sb.Append(string.Join(", ", values) + "); \n");
            values.Clear();

            return sb.ToString();
        }

        /// <summary>
        /// Creates an UPDATE statement for the table <paramref name="tableName"/> with the values of <paramref name="model"/>.
        /// </summary>
        /// <param name="tableName">Table name.</param>
        /// <param name="model">Model filled with column values.</param>
        /// <returns>String containing the UPDATE for the table.</returns>
        private static string BuildSqlUpdateStatement(string tableName, object model)
        {
            List<string> values = [];
            StringBuilder sb = new();

            sb.Append($"UPDATE {tableName} SET ");
            foreach (PropertyInfo property in model.GetType().GetProperties())
            { values.Add($"{property.Name} = {FormatManagement.FormatByStringSql(property.GetValue(model))}"); }
            sb.Append(string.Join(", ", values) + "; \n");

            return sb.ToString();

        }



        /// <summary>
        /// Creates an INSERT statement for the tables <see cref="ProdutoModel"/> and <see cref="ProdutosQtdModel"/>.
        /// </summary>
        /// <param name="produto">Model filled with column values.</param>
        /// <param name="produtoQtd">Model filled with column values.</param>
        /// <returns>String containing the INSERT for both tables.</returns>
        private static string CreateCommandLineProdutos(ProdutoModel produto, ProdutosQtdModel produtoQtd) =>
            BuildSqlInsertStatement("Produtos", produto) + BuildSqlInsertStatement("ProdutosQtd", produtoQtd);

        /// <summary>
        /// Creates an INSERT statement for the table <see cref="ClienteModel"/>.
        /// </summary>
        /// <param name="cliente">Model filled with column values.</param>
        /// <returns>String containing the INSERT for the table.</returns>
        private static string CreateCommandLineClientes(ClienteModel cliente) =>
            BuildSqlInsertStatement("CadCli", cliente);

        /// <summary>
        /// Creates an INSERT statement for the table <see cref="FornecedorModel"/>.
        /// </summary>
        /// <param name="fornecedor">Model filled with column values.</param>
        /// <returns>String containing the INSERT for the table.</returns>
        private static string CreateCommandLineFornecedores(FornecedorModel fornecedor) =>
            BuildSqlInsertStatement("CadFor", fornecedor);

        /// <summary>
        /// Creates an INSERT statement for the tables <see cref="DepartamentoModel"/> and <see cref="CategoriasModel"/>.
        /// </summary>
        /// <param name="depModel">Model filled with column values.</param>
        /// <param name="catModel">Model filled with column values.</param>
        /// <returns>String containing the INSERT for both tables.</returns>
        private static string CreateCommandLineDepartamentos(DepartamentoModel depModel, CategoriasModel catModel)
            => BuildSqlInsertStatement("DicDepartamentos", depModel) + BuildSqlInsertStatement("DicCategorias", catModel);

        /// <summary>
        /// Creates an INSERT statement for the table <see cref="UnidadeModel"/>
        /// </summary>
        /// <param name="unModel">Model filled with column values.</param>
        /// <returns>String containing the INSERT for the table.</returns>
        private static string CreateCommandLineUnidades(UnidadeModel unModel) =>
            BuildSqlInsertStatement("DicUnidades", unModel);

        /// <summary>
        /// Creates an INSERT statement for the table <see cref="MarcaModel"/>
        /// </summary>
        /// <param name="marcaModel">Model filled with column values.</param>
        /// <returns>String containing the INSERT for the table.</returns>
        private static string CreateCommandLineMarcas(MarcaModel marcaModel) =>
            BuildSqlInsertStatement("DicMarcas", marcaModel);

        /// <summary>
        /// Creates an UPDATE statement for the table <see cref="CodigosModel"/>
        /// </summary>
        /// <param name="codModel">Model filled with column values.</param>
        /// <returns>String containing the UPDATE for the table.</returns>
        public static string CreateCommandLineCodigos(CodigosModel codModel) =>
            BuildSqlUpdateStatement("Codigos", codModel);



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
        /// Receives user input through the <see cref="Console"/> and updates the <see cref="GlobalVariables.SelectedColumnsForn"/> <br/>
        /// with the columns selected by the user.
        /// </summary>
        public static void LoadColumnsFornecedores()
        {
            foreach (ColumnsSupportedForn column in GlobalVariables.SelectedColumnsForn.Keys)
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
                { GlobalVariables.SelectedColumnsForn[column] = (int)Enum.Parse<ColumnsIndex>(valueEnter); }
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
            produtoQtd.IdProd = GlobalVariables.CurrentIdProdutos;
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

            if (GlobalVariables.CodBarrasKnown.Contains(produto.CodBarras))
            { throw new Exception("Cod. de barras duplicado: " + produto.CodBarras); }

            GlobalVariables.CodBarrasKnown.Add(produto.CodBarras);
            GlobalVariables.AllDepartamentos.AddIfNotExists(produto.Departamento);
            GlobalVariables.AllUnidades.AddIfNotExists(produto.Unidade);
            GlobalVariables.AllMarcas.AddIfNotExists(produto.Marca);
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

        /// <summary>
        /// Builds and adds an INSERT statement for suppliers from a CSV (<paramref name="line"/>) row <br/>
        /// with the desired values.
        /// </summary>
        /// <param name="line">CSV row (;) with values.</param>
        public static void BuildLineFornecedores(string line)
        {

            string[] lineValues = line.Split(";");

            // If the used table has auto-increment, the ID does not need to be added in the 
            // database models.
            FornecedorModel fornecedor = new()
            { IdCadFor = GlobalVariables.CurrentIdCadFor };

            foreach (ColumnsSupportedForn column in GlobalVariables.SelectedColumnsForn.Keys)
            {
                if (GlobalVariables.SelectedColumnsForn[column]!.IsNull()) { continue; }

                fornecedor.SetValueColumn(column, FormatManagement.
                    FormatValueForColumnForn(column, lineValues[GlobalVariables.SelectedColumnsForn[column]!.Value]));
            }

            GlobalVariables.StringOutput.AppendLine(CreateCommandLineFornecedores(fornecedor));
        }

        /// <summary>
        /// Create essential dependent objects for the <see cref="ProdutoModel"/>.
        /// </summary>
        public static void ShutWithDependentsProdutos()
        {
            GlobalVariables.StringOutput.AppendLine();

            #region Departamentos/Categorias

            foreach (string dep in GlobalVariables.AllDepartamentos)
            {
                DepartamentoModel depModel = new()
                {
                    IdDepartamento = GlobalVariables.CurrentIdDepartamentos,
                    Departamento = dep
                };

                CategoriasModel catModel = new()
                {
                    IdCategorias = GlobalVariables.CurrentIdCategorias,
                    Departamento = dep
                };

                GlobalVariables.StringOutput.Append(CreateCommandLineDepartamentos(depModel, catModel));

                GlobalVariables.CurrentIdDepartamentos++;
                GlobalVariables.CurrentIdCategorias++;
            }

            #endregion

            #region Unidades

            foreach (string un in GlobalVariables.AllUnidades)
            {
                UnidadeModel unModel = new()
                {
                    IdUnidade = GlobalVariables.CurrentIdUnidades,
                    Unidade = un
                };

                GlobalVariables.StringOutput.Append(CreateCommandLineUnidades(unModel));

                GlobalVariables.CurrentIdUnidades++;
            }

            #endregion

            #region DicMarcas

            foreach (string marca in GlobalVariables.AllMarcas)
            {
                MarcaModel marcasModel = new()
                {
                    IdMarca = GlobalVariables.CurrentIdMarcas,
                    Marca = marca
                };

                GlobalVariables.StringOutput.Append(CreateCommandLineMarcas(marcasModel));

                GlobalVariables.CurrentIdMarcas++;
            }

            #endregion

        }
    }
}
