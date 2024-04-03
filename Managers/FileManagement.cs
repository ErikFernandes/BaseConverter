using BaseConverter.Global;

namespace BaseConverter.Managers
{
    public static class FileManagement
    {
        /// <summary>
        /// Lê todas as linhas do arquivo localizado em <paramref name="path"/>. <br/>
        /// Caso ocorra um erro <see cref="IOException"/> o programa ficará em loop de tentativas a cada 2 segundos. <br/>
        /// Caso ocorra qualquer outro tipo de erro, o programa irá mostrar o erro para o usuário e retornar um array vazio.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
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
