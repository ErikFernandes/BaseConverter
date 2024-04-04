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

            #region Option selection

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

            #region File name

            Console.WriteLine($"Digite o nome do arquivo CSV dentro da pasta {GlobalVariables.PathConversao} para a conversão: ");

            while (true)
            {
                string fileName = Console.ReadLine() ?? string.Empty;
                string pathFile = Path.Combine(GlobalVariables.PathConversao, fileName + ".csv");

                if (File.Exists(pathFile)) { GlobalVariables.PathConversao = pathFile; break; }
                else { Console.WriteLine("Arquivo inexistente, tente novamente: "); }
            }

            #endregion

            #region Column association

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

            #region Load file

            string[] lines = FileManagement.GetLines(GlobalVariables.PathConversao);

            foreach (string line in lines)
            {
                switch (GlobalVariables.SelectedType)
                {
                    case TypeConversion.Clientes:
                        ConversionManagement.BuildLineClientes(line);
                        GlobalVariables.CurrentIdClientes++;
                        break;

                    case TypeConversion.Produtos:
                        ConversionManagement.BuildLineProdutos(line);
                        GlobalVariables.CurrentIdProdutos++;
                        GlobalVariables.CurrentIdProdutosQtd++;
                        break;
                }
            }

            if (GlobalVariables.SelectedType == TypeConversion.Produtos) { ConversionManagement.ShutWithDependentsProdutos(); }

            #endregion

            #region Write file

            switch (GlobalVariables.SelectedType)
            {
                case TypeConversion.Clientes:
                    FileManagement.WriteFileClientes(GlobalVariables.StringOutput.ToString());
                    break;

                case TypeConversion.Produtos:
                    FileManagement.WriteFileProdutos(GlobalVariables.StringOutput.ToString());
                    break;
            }

            #endregion

        }
    }
}
