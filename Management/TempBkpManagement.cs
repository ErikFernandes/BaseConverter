using BaseConverter.Enums;
using BaseConverter.Global;
using System.Text.Json;

namespace BaseConverter.Management
{
    public static class TempBkpManagement
    {

        private class StructBkpFile
        {
            public TypeConversion SelectedType { get; set; }
            public string PathConversao { get; set; } = string.Empty;
            public Dictionary<ColumnsSupportedProd, int?> SelectedColumnsProd { get; set; } = [];
            public Dictionary<ColumnsSupportedCli, int?> SelectedColumnsCli { get; set; } = [];
            public Dictionary<ColumnsSupportedForn, int?> SelectedColumnsForn { get; set; } = [];
        }

        private static string PathFile => Path.Combine(Environment.CurrentDirectory, "TempBkp.json");

        public static void CreateBkpFile()
        {

            try
            {
                if (!File.Exists(PathFile))
                    using (File.Create(PathFile)) { }
                

                StructBkpFile jsonBuild = new StructBkpFile
                {
                    SelectedType = GlobalVariables.SelectedType,
                    PathConversao = GlobalVariables.PathConversao,
                    SelectedColumnsProd = GlobalVariables.SelectedColumnsProd,
                    SelectedColumnsCli = GlobalVariables.SelectedColumnsCli,
                    SelectedColumnsForn = GlobalVariables.SelectedColumnsForn
                };

                string content = JsonSerializer.Serialize(jsonBuild);

                File.WriteAllText(PathFile, content);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void LoadBkpFile()
        {

            try
            {
                string content = File.ReadAllText(PathFile);

                StructBkpFile jsonBuild = JsonSerializer.Deserialize<StructBkpFile>(content)!;

                GlobalVariables.SelectedType = jsonBuild.SelectedType;
                GlobalVariables.PathConversao = jsonBuild.PathConversao;
                GlobalVariables.SelectedColumnsProd = jsonBuild.SelectedColumnsProd;
                GlobalVariables.SelectedColumnsCli = jsonBuild.SelectedColumnsCli;
                GlobalVariables.SelectedColumnsForn = jsonBuild.SelectedColumnsForn;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void DeleteBkpFile() => File.Delete(PathFile);

        public static bool ExistsBkpFile() => File.Exists(PathFile);

    }
}
