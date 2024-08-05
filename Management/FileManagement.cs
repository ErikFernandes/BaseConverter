using BaseConverter.Global;

namespace BaseConverter.Management
{
    public static class FileManagement
    {
        /// <summary>
        /// Writes <paramref name="content"/> to the file located at <paramref name="path"/>.
        /// </summary>
        /// <param name="path">Path to the file.</param>
        /// <param name="content">Content to be written.</param>
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
                return File.ReadAllLines(path);
            }
            catch (Exception ex)
            {
                if (ex is IOException && ex.Message.Contains("because it is being used by another process."))
                {
                    Console.WriteLine("Provavelmente o arquivo está sendo usado em outro programa. Por favor, feche-o.");
                    Thread.Sleep(2000);
                    return GetLines(path);
                }

                Console.WriteLine("The following error occurred: " + ex.Message);
                return [];
            }
        }

        /// <summary>
        /// Writes <paramref name="content"/> to the file located at <see cref="GlobalVariables.PathFileClientes"/>.
        /// </summary>
        /// <param name="content">Content to be written.</param>
        public static void WriteFileClientes(string content) => 
            WriteFile(GlobalVariables.PathFileClientes, content);

        /// <summary>
        /// Writes <paramref name="content"/> to the file located at <see cref="GlobalVariables.PathFileProdutos"/>.
        /// </summary>
        /// <param name="content">Content to be written.</param>
        public static void WriteFileProdutos(string content) =>
            WriteFile(GlobalVariables.PathFileProdutos, content);

        /// <summary>
        /// Writes <paramref name="content"/> to the file located at <see cref="GlobalVariables.PathFileFornecedores"/>.
        /// </summary>
        /// <param name="content">Content to be written.</param>
        public static void WriteFileFornecedores(string content) =>
            WriteFile(GlobalVariables.PathFileFornecedores, content);
    }
}
