using BaseConverter.Global;

namespace BaseConverter.Management
{
    public static class FileManagement
    {
        private static void WriteFile(string path, string content)
        {
            using FileStream fileStream = new(path, FileMode.Create);
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(content);

            fileStream.Write(bytes, 0, bytes.Length);
        }

        /// <summary>
        /// Reads all lines from the file located at <paramref name="path"/>. <br/>
        /// If an <see cref="IOException"/> occurs, the program will enter a retry loop every 2 seconds. <br/>
        /// If any other type of error occurs, the program will display the error to the user and return an empty array.
        /// </summary>
        /// <param name="path">Path to the file.</param>
        /// <returns>Lines of the file if no unexpected error occurs.</returns>
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
                Console.WriteLine("The following error occurred: " + ex.Message);
                return [];
            }
        }

        public static void WriteFileClientes(string content) => 
            WriteFile(GlobalVariables.PathFileClientes, content);

        public static void WriteFileProdutos(string content) =>
            WriteFile(GlobalVariables.PathFileProdutos, content);
    }
}
