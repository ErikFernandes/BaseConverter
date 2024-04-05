using BaseConverter.Global;

namespace BaseConverter.Models
{
    public class CodigosModel
    {
        public int IdProd { get; set; } = GlobalVariables.CurrentIdProdutos;
        public int IdProdQtd { get; set; } = GlobalVariables.CurrentIdProdutosQtd;
        public int IdDepartamento { get; set; } = GlobalVariables.CurrentIdDepartamentos;
        public int IdCategoria { get; set; } = GlobalVariables.CurrentIdCategorias;
        public int IdMarca { get; set; } = GlobalVariables.CurrentIdMarcas;
        public int IdUnidade { get; set; } = GlobalVariables.CurrentIdUnidades;

    }
}
