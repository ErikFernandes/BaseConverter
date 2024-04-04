namespace BaseConverter.Models
{
    public class CategoriasModel
    {
        public int IdCategorias { get; set; } = 1;
        public string Categoria { get; set; } = "Geral";
        public string Departamento { get; set; } = "Geral";
        public DateTime DataControl { get; set; } = DateTime.Now;
    }
}
