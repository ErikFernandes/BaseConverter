using BaseConverter.Enums;
using BaseConverter.Management;

namespace BaseConverter.Models
{
    public class FornecedorModel
    {
        public int IdCadFor { get; set; } = 1;
        public int IdCadFilial { get; set; } = 1;
        public string Nome { get; set; } = "SEM NOME";
        public string Ende { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public string Complemento { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        public string Uf { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string Cep { get; set; } = string.Empty;
        public string Nacionalidade { get; set; } = string.Empty;
        public string CpfCnpj { get; set; } = string.Empty;
        public string TipoDocumento => CpfCnpj.Length == 11 ? "CPF" : CpfCnpj.Length == 14 ? "CNPJ" : string.Empty;
        public string InscEst { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Tel { get; set; } = string.Empty;
        public string Celular { get; set; } = string.Empty;
        public string Fax { get; set; } = string.Empty;
        public string Contato { get; set; } = string.Empty;
        public string Obs { get; set; } = string.Empty;
        public bool Bloqueado { get; set; } = false;
        public DateTime DataControl { get; set; } = DateTime.Now;
        public string CodigoMunicipio => IBGEManagement.GetCidadeByNome(Enum.Parse<EstadosEnum>(Uf), Cidade)?.CodMunicipio.ToString() ?? string.Empty;
    }

}
