namespace BaseConverter.Enums
{
    public enum TypeConversion
    {
        Produtos = 1,
        Clientes = 2,
        Fornecedores = 3
    }

    public enum ColumnsSupportedProd
    {
        Referencia,
        CodBarras,
        Descricao,
        Departamento,
        Categoria,
        Unidade,
        Marca,
        ValorCustoMedio,
        PrecoVendaVarejo,
        PrecoVendaAtacado,
        PrecoVendaPromocional,
        Ncm,
        CSOSN,
        CEST,
        ProdCfopSai,
        Quantidade,
        Ativo
    }

    public enum ColumnsSupportedCli
    {
        Nome,
        NomeFantasia,
        Ende,
        Numero,
        Complemento,
        Bairro,
        Cep,
        Celular,
        Celular2,
        Tel,
        Uf,
        Cidade,
        CodMunicipio,
        CpfCnpj,
        InscEst,
        DataControl
    }
}
