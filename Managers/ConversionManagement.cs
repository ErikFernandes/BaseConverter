using BaseConverter.Enums;
using BaseConverter.Extensions;
using BaseConverter.Global;

namespace BaseConverter.Managers
{
    public static class ConversionManagement
    {
        private static bool LetterIsNotValid(string l) =>
            l != string.Empty && (l.Length > 1 || !Enum.IsDefined(typeof(ColumnsIndex), l));


        public static void LoadColumnsProdutos()
        {
            foreach (ColumnsSupportedProd column in GlobalVariables.SelectedColumnsProd.Keys)
            {
                Console.Write($"{column,-22} : ");

                string valueEnter = Console.ReadLine()?.ToUpper() ?? string.Empty;

                if (LetterIsNotValid(valueEnter))
                {
                    while (true)
                    {
                        Console.WriteLine("Opção inválida! Tente novamente: ");
                        valueEnter = Console.ReadLine()?.ToUpper() ?? string.Empty;
                        if (!LetterIsNotValid(valueEnter)) { break; }
                    }
                }

                if (valueEnter != string.Empty)
                { GlobalVariables.SelectedColumnsProd[column] = (int)Enum.Parse<ColumnsIndex>(valueEnter); }
            }
        }

        public static void LoadColumnsClientes()
        {
            foreach (ColumnsSupportedCli column in GlobalVariables.SelectedColumnsCli.Keys)
            {
                Console.Write($"{column,-22} : ");

                string valueEnter = Console.ReadLine()?.ToUpper() ?? string.Empty;

                if (LetterIsNotValid(valueEnter))
                {
                    while (true)
                    {
                        Console.WriteLine("Opção inválida! Tente novamente: ");
                        valueEnter = Console.ReadLine()?.ToUpper() ?? string.Empty;
                        if (!LetterIsNotValid(valueEnter)) { break; }
                    }
                }

                if (valueEnter != string.Empty)
                { GlobalVariables.SelectedColumnsCli[column] = (int)Enum.Parse<ColumnsIndex>(valueEnter); }
            }
        }
        

        public static void BuildLineProdutos(string line)
        {
            foreach (ColumnsSupportedProd column in GlobalVariables.SelectedColumnsProd.Keys)
            {
                if (GlobalVariables.SelectedColumnsProd[column]!.IsNull()) { continue; }


            }
        }
    }
}
