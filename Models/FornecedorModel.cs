namespace BaseConverter.Models
{
    public class FornecedorModel
    {
        public int IdCadFilial { get; set; } = 1;
        public string Nome { get; set; } = "SEM NOME";
        public string Ende { get; set; } = "";
        public string Numero { get; set; } = "";
        public string Complemento { get; set; } = "";
        public string Bairro { get; set; } = "";
        public string Uf { get; set; } = "";
        public string Cidade { get; set; } = "";
        public string Cep { get; set; } = "";
        public string Nacionalidade { get; set; } = "";
        public string CpfCnpj { get; set; } = "";
        public string TipoDocumento { get; set; } = "";
        public string InscEst { get; set; } = "";
        public string Email { get; set; } = "";
        public string Tel { get; set; } = "";
        public string Celular { get; set; } = "";
        public string Fax { get; set; } = "";
        public string Contato { get; set; } = "";
        public string Obs { get; set; } = "";
        public bool Bloqueado { get; set; } = false;
        public DateTime DataControl { get; set; } = DateTime.Now;
        public string CodigoMunicipio { get; set; } = "";
    }
}
