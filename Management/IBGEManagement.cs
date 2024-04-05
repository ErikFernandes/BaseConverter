using BaseConverter.Enums;
using BaseConverter.Extensions;
using BaseConverter.Models;

namespace BaseConverter.Management
{
    public static class IBGEManagement
    {
        /// <summary>
        /// Path to the CSV file containing all IBGE cities.
        /// </summary>
        private static string PathCsvMunicipios { get; set; } = $"{Environment.CurrentDirectory}\\Data\\Municipios.csv";

        /// <summary>
        /// List of all IBGE cities.
        /// </summary>
        private static List<CidadeModel> AllCidades { get; set; } = GetAllCidades();

        /// <summary>
        /// Gets all IBGE cities.
        /// </summary>
        /// <returns> List of all <see cref="CidadeModel"/></returns>
        private static List<CidadeModel> GetAllCidades()
        {
            List<CidadeModel> outputCidades = [];
            string[] lines = FileManagement.GetLines(PathCsvMunicipios);

            if (lines.Length == 0) return outputCidades;

            foreach (string line in lines[1..])
            {
                string[] lineValues = line.Split(";");

                outputCidades.Add(new CidadeModel()
                {
                    UF = Enum.Parse<EstadosEnum>(lineValues[0]),
                    CodMunicipio = lineValues[1],
                    Nome = lineValues[2]
                });
            }

            return outputCidades;
        }


        /// <summary>
        /// Get a <see cref="CidadeModel"/> by its <paramref name="codMunicipio"/>.
        /// </summary>
        /// <param name="codMunicipio">Code of the city.</param>
        /// <returns></returns>
        public static CidadeModel? GetCidadeByCodMunicipio(string codMunicipio) =>
            AllCidades.FirstOrDefault(c => c.CodMunicipio == codMunicipio);

        /// <summary>
        /// Get a <see cref="CidadeModel"/> by its <paramref name="uf"/> and <paramref name="nome"/>.
        /// </summary>
        /// <param name="uf">UF of the city.</param>
        /// <param name="nome">Name of the city.</param>
        /// <returns></returns>
        public static CidadeModel? GetCidadeByNome(EstadosEnum uf, string nome) =>
            AllCidades.FirstOrDefault(c => c.UF == uf &&
                c.Nome.RemoveAccents().Equals(nome.RemoveAccents(), StringComparison.CurrentCultureIgnoreCase));
    }
}
