namespace BaseConverter.Models
{
    public class DepartamentoModel
    {
        public int IdDepartamento { get; set; } = 1;
        public string Departamento { get; set; } = "Geral";
        public DateTime DataControl { get; set; } = DateTime.Now;
    }
}
