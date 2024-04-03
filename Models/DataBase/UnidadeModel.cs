namespace BaseConverter.Models
{
    public class UnidadeModel
    {
        public int IdUnidade { get; set; } = 1;
        public string Unidade { get; set; } = "UN";
        public DateTime DataControl { get; set; } = DateTime.Now;
        public bool M1 { get; set; } = false;
        public bool M2 { get; set; } = false;
        public bool UnidMassa { get; set; } = false;
    }
}
