namespace BaseConverter.Models
{
    public class ProdutoModel
    {
        public int IdProd { get; set; } = 1;
        public int IdCadFilial { get; set; } = 1;
        public string CodBarras { get; set; } = string.Empty;
        public string CodBarrasFor { get; set; } = string.Empty;
        public string Referencia { get; set; } = string.Empty;
        public string Descricao { get; set; } = "SEM DESCRIÇÂO";
        public string Departamento { get; set; } = "Geral";
        public string Categoria { get; set; } = "Geral";
        public string Unidade { get; set; } = "UN";
        public string Marca { get; set; } = "Diversas";
        public string Tamanho { get; set; } = string.Empty;
        public decimal ValorCustoUnitario { get; set; } = 0.00m;
        public decimal pIpi { get; set; } = 0.00m;
        public decimal ValorCustoFinal { get; set; } = 0.00m;
        public decimal? ValorFrete { get; set; } = null;
        public decimal PercentualLucroVarejo => 
            Math.Round((PrecoVendaVarejo - ValorCustoMedio) * 100 / ValorCustoMedio, 2);
        public decimal PrecoVendaVarejo { get; set; } = 0.00m;
        public decimal PercentualLucroAtacado => 
            Math.Round((PrecoVendaAtacado - ValorCustoMedio) * 100 / ValorCustoMedio, 2);
        public decimal PrecoVendaAtacado { get; set; } = 0.00m;
        public decimal Peso { get; set; } = 0.00m;
        public decimal IcmsAliquota { get; set; } = 0.00m;
        public string CST { get; set; } = string.Empty;
        public DateTime DataControl { get; set; } = DateTime.Now;
        public string? Aplicacao { get; set; } = null;
        public string Ncm { get; set; } = string.Empty;
        public decimal pRedBc { get; set; } = 0.00m;
        public decimal pRedBCST { get; set; } = 0.00m;
        public string ModBc { get; set; } = string.Empty;
        public decimal pMVAST { get; set; } = 0.00m;
        public string ModBCST { get; set; } = string.Empty;
        public string CSTPIS { get; set; } = string.Empty;
        public string CSTIPI { get; set; } = string.Empty;
        public decimal pCOFINS { get; set; } = 0.00m;
        public decimal pPIS { get; set; } = 0.00m;
        public decimal vAliqProdPis { get; set; } = 0.00m;
        public decimal vAliqProdCofins { get; set; } = 0.00m;
        public decimal vUnidIPI { get; set; } = 0.00m;
        public decimal? IcmsAliquotaDeReducaoDaBaseDeCalculo { get; set; } = null;
        public decimal? IpiAliquota { get; set; } = null;
        public string CSOSN { get; set; } = "102";
        public string Origem { get; set; } = "0";
        public string CSTCOFINS { get; set; } = string.Empty;
        public decimal ValorCustoMedio { get; set; } = 1.00m;
        public string cEAN { get; set; } = string.Empty;
        public string cEANTrib { get; set; } = string.Empty;
        public decimal CustoIpi { get; set; } = 0.00m;
        public decimal CustoIcms { get; set; } = 0.00m;
        public decimal CustoIcmsSt { get; set; } = 0.00m;
        public decimal CustoFrete { get; set; } = 0.00m;
        public decimal CustoSeguro { get; set; } = 0.00m;
        public decimal CustoOutrasDespesas { get; set; } = 0.00m;
        public decimal? CustoSelecionado { get; set; } = null;
        public decimal Percentual { get; set; } = 0.00m;
        public bool AddUpd { get; set; } = false;
        public string? Producao { get; set; } = null;
        public string FastFoodNomeBotao { get; set; } = string.Empty;
        public string GTIN { get; set; } = string.Empty;
        public bool MatPrima { get; set; } = false;
        public string Anp { get; set; } = string.Empty;
        public int cEnq { get; set; } = 0;
        public string NomeGradeItens { get; set; } = string.Empty;
        public decimal? QtdeMontar { get; set; } = null;
        public string TipoCorte { get; set; } = string.Empty;
        public decimal ValorMedidaConvertido { get; set; } = 0.00m;
        public bool MarcarValorMedidaConvertido { get; set; } = false;
        public string NomeGradeCores { get; set; } = string.Empty;
        public bool AtivoImobilizado { get; set; } = false;
        public string ObsConsulta { get; set; } = string.Empty;
        public string ObsInterna { get; set; } = string.Empty;
        public bool UsarBalancaSga { get; set; } = false;
        public decimal CustoDifIcms { get; set; } = 0.00m;
        public decimal CustoComplST { get; set; } = 0.00m;
        public decimal CustoOutrosImp { get; set; } = 0.00m;
        public decimal CustoValSimples { get; set; } = 0.00m;
        public string CEST { get; set; } = string.Empty;
        public string ProdCfopSai { get; set; } = "5102";
        public string? ProdCfopEnt { get; set; } = null;
        public bool Revenda { get; set; } = true;
        public bool PetVacina { get; set; } = false;
        public bool ArmaFogo { get; set; } = false;
        public bool IsMedicamento { get; set; } = false;
        public string? Med_CodProdAnvisa { get; set; } = null;
        public string? Med_AnvisaMotivoIsencao { get; set; } = null;
        public decimal Med_PrecoMaxConsumidor { get; set; } = -1.00m;
        public string? CodBarrasBalanca { get; set; } = null;
        public int UnidadeBalanca { get; set; } = 0;
        public decimal? CombpGLP { get; set; } = null;
        public decimal? CombpGNn { get; set; } = null;
        public decimal? CombvPart { get; set; } = null;
        public string ExTipi { get; set; } = string.Empty;
        public decimal PrecoVendaPromocional { get; set; } = 0.00m;
        public decimal PercentualLucroPromocional => 
            Math.Round((PrecoVendaPromocional - ValorCustoMedio) * 100 / ValorCustoMedio, 2);


    }
}
