using BaseConverter.Enums;
using System.Text;

namespace BaseConverter.Global
{
    public static class GlobalVariables
    {
        /// <summary>
        /// Caminho do arquivo .csv usado na conversão.
        /// </summary>
        public static string PathConversao { get; set; } = "C:/Conversão/";


        /// <summary>
        /// Caminho dos arquivos de saída.
        /// </summary>
        #region Caminhos dos arquivos de saída

        public static string PathFileProdutos { get; set; } = "C:/Conversão/ScriptConversão - Produtos.sql";
        public static string PathFileClientes { get; set; } = "C:/Conversão/ScriptConversão - Clientes.sql";
        public static string PathFileFornecedores { get; set; } = "C:/Conversão/ScriptConversão - Fornecedores.sql";

        #endregion


        /// <summary> 
        /// Propriedades utilizadas para gerar os IDs das tabelas que não possuem autoincremento.
        /// </summary>
        #region Ids

        public static int CurrentIdProdutos { get; set; } = 1;
        public static int CurrentIdProdutosQtd { get; set; } = 1;
        public static int CurrentIdClientes { get; set; } = 1;

        #endregion


        /// <summary>
        /// <see cref="StringBuilder"/> para armazenar os dados de saida para impressão no arquivo.
        /// </summary>
        public static StringBuilder StringOutput { get; set; } = new StringBuilder();


        /// <summary>
        /// Tipo de conversão selecionado pelo usuário.
        /// </summary>
        public static TypeConversion SelectedType { get; set; }


        /// <summary>
        /// Colunas do arquivo .csv de produtos selecionadas pelo usuário.
        /// </summary>
        public static Dictionary<ColumnsSupportedProd, int?> SelectedColumnsProd { get; set; } =
            Enum.GetValues(typeof(ColumnsSupportedProd)).Cast<ColumnsSupportedProd>().
                Select(x => new KeyValuePair<ColumnsSupportedProd, int?>(x, null)).ToDictionary(x => x.Key, x => x.Value);

        /// <summary>
        /// Colunas do arquivo .csv de clientes selecionadas pelo usuário.
        /// </summary>
        public static Dictionary<ColumnsSupportedCli, int?> SelectedColumnsCli { get; set; } =
            Enum.GetValues(typeof(ColumnsSupportedCli)).Cast<ColumnsSupportedCli>().
                Select(x => new KeyValuePair<ColumnsSupportedCli, int?>(x, null)).ToDictionary(x => x.Key, x => x.Value);

    }
}