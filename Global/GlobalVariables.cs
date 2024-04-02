﻿using BaseConverter.Enums;
using System.Text;

namespace BaseConverter.Global
{
    public static class GlobalVariables
    {
        public static string PathConversao { get; set; } = "C:/Conversão/";


        public static string PathFileProdutos { get; set; } = "C:/Conversão/ScriptConversão - Produtos.sql";
        public static string PathFileClientes { get; set; } = "C:/Conversão/ScriptConversão - Clientes.sql";
        public static string PathFileFornecedores { get; set; } = "C:/Conversão/ScriptConversão - Fornecedores.sql";


        public static int CurrentIdProdutos { get; set; } = 1;
        public static int CurrentIdProdutosQtd { get; set; } = 1;
        public static int CurrentIdClientes { get; set; } = 1;


        public static StringBuilder StringOutput { get; set; } = new StringBuilder();


        public static TypeConversion SelectedType { get; set; }


        public static Dictionary<ColumnsSupportedProd, int?> SelectedColumnsProd { get; set; } =
            Enum.GetValues(typeof(ColumnsSupportedProd)).Cast<ColumnsSupportedProd>().
                Select(x => new KeyValuePair<ColumnsSupportedProd, int?>(x, null)).ToDictionary(x => x.Key, x => x.Value);

        public static Dictionary<ColumnsSupportedCli, int?> SelectedColumnsCli { get; set; } =
            Enum.GetValues(typeof(ColumnsSupportedCli)).Cast<ColumnsSupportedCli>().
                Select(x => new KeyValuePair<ColumnsSupportedCli, int?>(x, null)).ToDictionary(x => x.Key, x => x.Value);

    }
}