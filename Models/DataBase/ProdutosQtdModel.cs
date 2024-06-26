﻿namespace BaseConverter.Models
{
    public class ProdutosQtdModel
    {
        public int IdProdQtd { get; set; } = 1;
        public int IdCadFilial { get; set; } = 1;
        public int IdProd { get; set; } = 1;
        public decimal Quantidade { get; set; } = 0.00m;
        public decimal EstoqueMaximo { get; set; } = 0.00m;
        public decimal EstoqueMinimo { get; set; } = 0.00m;
        public string Prateleira { get; set; } = string.Empty;
        public bool Ativo { get; set; } = true;
    }
}
