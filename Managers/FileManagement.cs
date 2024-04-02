using BaseConverter.Global;

namespace BaseConverter.Managers
{
    public static class FileManagement
    {
        public static string[] GetLines(string path)
        {
            try
            {
                return File.ReadAllLines(GlobalVariables.PathConversao);
            }
            catch (Exception ex) when (ex is IOException)
            {
                Console.WriteLine("Provavelmente o arquivo está sendo usado em outro programa. Por favor, feche-o.");
                Thread.Sleep(2000);
                return GetLines(path);
            }
            catch (Exception ex)
            {
                Console.WriteLine("O seguinte erro ocorreu: " + ex.Message);
                return [];
            }
        }
    }
}
