using BaseConverter.Enums;
using BaseConverter.Global;
using BaseConverter.Managers;

namespace BaseConverter
{
    internal class Program
    {
        static void Main()
        {

            Console.WriteLine("Bem vindo ao Conversor de Banco!\n");
            Console.WriteLine("Selecione uma opção de conversão:");

            #region Seleção de opções

            string options = Enum.GetValues(typeof(TypeConversion)).Cast<TypeConversion>().
                Select(x => (int)x + " - " + x.ToString() + "\n").Aggregate((x, y) => x + y);

            Console.WriteLine(options);

            if (!int.TryParse(Console.ReadLine(), out int selectOption) || !Enum.IsDefined(typeof(TypeConversion), selectOption))
            {
                Console.WriteLine("Opção inválida!");
                Thread.Sleep(2000);
                Console.Clear();
                Main();
            }

            GlobalVariables.SelectedType = (TypeConversion)selectOption;

            #endregion

            #region Nome do arquivo

            Console.WriteLine($"Digite o nome do arquivo CSV dentro da pasta {GlobalVariables.PathConversao} para a conversão: ");

            while (true)
            {
                string fileName = Console.ReadLine() ?? string.Empty;
                string pathFile = Path.Combine(GlobalVariables.PathConversao, fileName + ".csv");

                if (File.Exists(pathFile)) { GlobalVariables.PathConversao = pathFile; break; }
                else { Console.WriteLine("Arquivo inexistente, tente novamente: "); }
            }

            #endregion

            #region Associação das colunas

            Console.WriteLine("Associe as colunas com a letra correspondete no arquivo: ");

            switch (GlobalVariables.SelectedType)
            {
                case TypeConversion.Clientes:
                    ConversionManagement.LoadColumnsClientes();
                    break;

                case TypeConversion.Produtos:
                    ConversionManagement.LoadColumnsProdutos();
                    break;
            }


            #endregion

            #region Carregar o arquivo

            string[] lines = File.ReadAllLines(GlobalVariables.PathConversao);

            foreach (string line in lines)
            {
                string[] values = line.Split(';');
            }

            #endregion

        }
    }
}
