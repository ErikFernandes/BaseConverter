using System.Globalization;

namespace BaseConverter.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Remove todos os valores específicos em <paramref name="values"/> da string <paramref name="input"/>.
        /// </summary>
        /// <param name="input">Valor a ser modificado.</param>
        /// <param name="values">Array contendo os valores a serem removidos.</param>
        /// <returns><paramref name="input"/> com os valores removidos.</returns>
        public static string RemoveAll(this string input, string[] values) =>
            values.Aggregate(input, (current, value) => current.Replace(value, string.Empty));

        /// <summary>
        /// Remove aspas simples (') da string <paramref name="input"/>.
        /// </summary>
        /// <param name="input">Valor a ser modificado.</param>
        /// <returns><paramref name="input"/> sem aspas.</returns>
        public static string RemoveMarks(this string input) =>
            input.Replace("'", string.Empty);

        /// <summary>
        /// Corta a string <paramref name="input"/> para o tamanho <paramref name="maxLength"/>.
        /// </summary>
        /// <param name="input">Valor a ser cortado.</param>
        /// <param name="maxLength">Tamanho máximo da string.</param>
        /// <returns><paramref name="input"/> cortado para o tamanho máximo <paramref name="maxLength"/>.</returns>
        public static string CutIfTooLong(this string input, int maxLength) =>
            input.Length > maxLength ? input[..maxLength] : input;

        /// <summary>
        /// Verifica se a string <paramref name="input"/> esta contida em <paramref name="values"/>.
        /// </summary>
        /// <param name="input">Valor a ser verificado.</param>
        /// <param name="values">Array contendo os valores a serem verificados.</param>
        /// <returns>True se a string <paramref name="input"/> estiver contida em <paramref name="values"/>.</returns>
        public static bool In(this string input, params string[] values) =>
            values.Contains(input);

        /// <summary>
        /// Converte um valor <see cref="string"/> para um valor <see cref="decimal"/>.
        /// </summary>
        /// <param name="input">Valor a ser convertido.</param>
        /// <returns><paramref name="input"/> convertido para <see cref="decimal"/> ou <see langword="null"/> se o valor não puder ser convertido.</returns>
        public static decimal? ToDecimal(this string input)
        {
            if (Convert.ToDecimal("3.3") == ((decimal)3.3))
            { return decimal.TryParse(input.Replace(",", "."), out decimal result) ? result : null; }
            else
            { return decimal.TryParse(input.Replace(".", ","), out decimal result) ? result : null; }
        }

        /// <summary>
        /// Converte um valor <see cref="string"/> para um valor <see cref="DateTime"/>.
        /// </summary>
        /// <param name="input">Valor a ser convertido.</param>
        /// <returns><paramref name="input"/> convertido para <see cref="DateTime"/> ou <see langword="null"/> se o valor não puder ser convertido.</returns>
        public static DateTime? ToDateTime(this string input)
        {
            return DateTime.TryParseExact(input, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result) ?
                result : null;
        }

        /// <summary>
        /// Converte um valor <see cref="string"/> para um valor <see cref="bool"/>.
        /// </summary>
        /// <param name="input">Valor a ser convertido.</param>
        /// <returns><paramref name="input"/> convertido para <see cref="bool"/> ou <see langword="null"/> se o valor não puder ser convertido.</returns>
        public static bool? TryBoolParse(this string input)
        {
            string formValue = input.ToLower();

            if (bool.TryParse(input, out bool result)) return result;

            if (formValue.In(["sim", "nao", "não"])) return formValue == "sim";

            if (formValue.In(["true", "false"])) return formValue == "true";

            if (formValue.In(["1", "0"])) return formValue == "1";

            return null;
        }

        #region Format

        /// <summary>
        /// Formata um número de telefone para um padrão sem nenhum caractere especial.
        /// </summary>
        /// <param name="input">Valor a ser formatado.</param>
        /// <returns><paramref name="input"/> formatado para o padrão sem nenhum caractere especial.</returns>
        public static string ToPhone(this string input)
        {
            string varRet = input.RemoveAll(["(", ")", "-", " "]);
            if (!long.TryParse(varRet, out long phoneLong)) return string.Empty;
            varRet = phoneLong.ToString();
            return varRet.Length == 10 ? varRet.Insert(2, "9") : varRet;
        }

        /// <summary>
        /// Formata um número de celular para um padrão sem nenhum caractere especial.
        /// </summary>
        /// <param name="input">Valor a ser formatado.</param>
        /// <returns><paramref name="input"/> formatado para o padrão sem nenhum caractere especial.</returns>
        public static string ToCell(this string input)
        {
            string varRet = input.RemoveAll(["(", ")", "-", " "]);
            if (!long.TryParse(varRet, out long phoneLong)) return string.Empty;
            return phoneLong.ToString();
        }

        #endregion




    }
}
