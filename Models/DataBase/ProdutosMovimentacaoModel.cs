namespace BaseConverter.Models
{
    public class ProdutosMovimentacaoModel
    {
        public int IdProd { get; set; }
        public int IdCadFilial { get; set; } = 1;
        public string Logado { get; set; } = "Base-Converter";
        public string Vendedor { get; set; } = string.Empty;
        public DateTime Data => DateTime.Now;
        public string Documento { get; set; } = string.Empty;
        public string Historico { get; set; } = "Adicionado pelo sistema de conversão";
        public decimal Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal Estoque => Quantidade;
        public string? TelaUtilizada => null;
        public string TipoCustoMedio { get; set; } = string.Empty;

    }
}
