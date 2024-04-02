using BaseConverter.Enums;

namespace BaseConverter.Models
{
    public class CidadeModel
    {
        public EstadosEnum UF { get; set; }
        public string CodMunicipio { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
    }
}
