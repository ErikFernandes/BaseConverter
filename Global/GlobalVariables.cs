﻿using BaseConverter.Enums;
using BaseConverter.Models;
using System.Text;

namespace BaseConverter.Global
{
    public static class GlobalVariables
    {
        /// <summary>
        /// Path of the .csv file used in the conversion.
        /// </summary>
        public static string PathConversao { get; set; } = "C:\\Conversão\\";


        /// <summary>
        /// Path of the output files.
        /// </summary>
        #region Caminhos dos arquivos de saída

        public static string PathFileProdutos { get; set; } = "C:\\Conversão\\ScriptConversão - Produtos.sql";
        public static string PathFileClientes { get; set; } = "C:\\Conversão\\ScriptConversão - Clientes.sql";
        public static string PathFileFornecedores { get; set; } = "C:\\Conversão\\ScriptConversão - Fornecedores.sql";

        #endregion


        /// <summary> 
        /// Properties used to generate IDs for tables that do not have auto-increment.
        /// </summary>
        #region Ids

        public static int CurrentIdProdutos { get; set; } = 1;
        public static int CurrentIdProdutosQtd { get; set; } = 1;
        public static int CurrentIdClientes { get; set; } = 2;
        public static int CurrentIdDepartamentos { get; set; } = 1;
        public static int CurrentIdCategorias { get; set; } = 1;
        public static int CurrentIdUnidades { get; set; } = 1;
        public static int CurrentIdMarcas { get; set; } = 1;
        public static int CurrentIdCadFor { get; set; } = 1;

        #endregion


        /// <summary>
        /// Properties used to check if code repeats.
        /// </summary>
        #region Códigos conhecidos

        public static List<string> CodBarrasKnown { get; set; } = [];

        #endregion


        /// <summary>
        /// List of records composing the product registry and need to be inserted into other tables.
        /// </summary>
        #region Dependents

        public static List<DepartamentoModel> AllDepartamentos { get; set; } = [];
        public static List<CategoriasModel> AllCategorias { get; set; } = [];
        public static List<string> AllUnidades { get; set; } = [];
        public static List<string> AllMarcas { get; set; } = [];

        #endregion

        /// <summary>
        /// <see cref="StringBuilder"/> to store output data for printing in the file.
        /// </summary>
        public static StringBuilder StringOutput { get; set; } = new StringBuilder();


        /// <summary>
        /// Type of conversion selected by the user.
        /// </summary>
        public static TypeConversion SelectedType { get; set; }


        /// <summary>
        /// Columns of the .csv file of products selected by the user.
        /// </summary>
        public static Dictionary<ColumnsSupportedProd, int?> SelectedColumnsProd { get; set; } =
            Enum.GetValues(typeof(ColumnsSupportedProd)).Cast<ColumnsSupportedProd>().
                Select(x => new KeyValuePair<ColumnsSupportedProd, int?>(x, null)).ToDictionary(x => x.Key, x => x.Value);

        /// <summary>
        /// Columns of the .csv file of clients selected by the user.
        /// </summary>
        public static Dictionary<ColumnsSupportedCli, int?> SelectedColumnsCli { get; set; } =
            Enum.GetValues(typeof(ColumnsSupportedCli)).Cast<ColumnsSupportedCli>().
                Select(x => new KeyValuePair<ColumnsSupportedCli, int?>(x, null)).ToDictionary(x => x.Key, x => x.Value);

        /// <summary>
        /// Columns of the .csv file of suppliers selected by the user.
        /// </summary>
        public static Dictionary<ColumnsSupportedForn, int?> SelectedColumnsForn { get; set; } =
            Enum.GetValues(typeof(ColumnsSupportedForn)).Cast<ColumnsSupportedForn>().
                Select(x => new KeyValuePair<ColumnsSupportedForn, int?>(x, null)).ToDictionary(x => x.Key, x => x.Value);

    }
}