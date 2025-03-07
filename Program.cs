using BaseConverter.Enums;
using BaseConverter.Global;
using BaseConverter.Management;
using BaseConverter.Models;

namespace BaseConverter
{
    internal class Program
    {
        static void Main()
        {

            Console.WriteLine("Bem vindo ao Conversor de Banco!\n");

            #region Check TempBkp

            bool useTempBkp = false;

            if (TempBkpManagement.ExistsBkpFile())
            {
                while (true)
                {
                    Console.WriteLine("Deseja usar as opções salvas? (Y/N): ");
                    string option = Console.ReadLine() ?? string.Empty;

                    if (option.Equals("Y", StringComparison.CurrentCultureIgnoreCase)) { useTempBkp = true; break; }
                    else if (option.Equals("N", StringComparison.CurrentCultureIgnoreCase)) { useTempBkp = false; break; }
                    else
                    {
                        Console.WriteLine("Opção inválida");
                        continue;
                    }
                }
            }

            if (useTempBkp)
            {
                TempBkpManagement.LoadBkpFile();
                goto skipUserInfo;
            }
            else
            {
                TempBkpManagement.DeleteBkpFile();
            }

            #endregion

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

                case TypeConversion.Fornecedores:
                    ConversionManagement.LoadColumnsFornecedores();
                    break;
            }


            #endregion

            #region Save TempBkp

            bool saveFile;

            while (true)
            {
                Console.WriteLine("Deseja salvar essas opções para as próximas vezes? (Y/N): ");
                string option = Console.ReadLine() ?? string.Empty;

                if (option.Equals("Y", StringComparison.CurrentCultureIgnoreCase)) { saveFile = true; break; }
                else if (option.Equals("N", StringComparison.CurrentCultureIgnoreCase)) { saveFile = false; break; }
                else
                {
                    Console.WriteLine("Opção inválida");
                    continue;
                }
            }

            if (saveFile)
                TempBkpManagement.CreateBkpFile();

            #endregion

            // Here the file is loaded
            skipUserInfo:

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

                    case TypeConversion.Fornecedores:
                        ConversionManagement.BuildLineFornecedores(line);
                        GlobalVariables.CurrentIdCadFor++;
                        break;
                }
            }

            if (GlobalVariables.SelectedType == TypeConversion.Produtos) { ConversionManagement.ShutWithDependentsProdutos(); }

            GlobalVariables.StringOutput.Append(ConversionManagement.CreateCommandLineCodigos(new CodigosModel()));

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

                case TypeConversion.Fornecedores:
                    FileManagement.WriteFileFornecedores(GlobalVariables.StringOutput.ToString());
                    break;
            }

            #endregion

        }
    }
}
