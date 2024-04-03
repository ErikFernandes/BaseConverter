using System.Globalization;

namespace BaseConverter.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Removes all specific values in <paramref name="values"/> from the string <paramref name="input"/>.
        /// </summary>
        /// <param name="input">Value to be modified.</param>
        /// <param name="values">Array containing the values to be removed.</param>
        /// <returns><paramref name="input"/> with the specified values removed.</returns>
        public static string RemoveAll(this string input, string[] values) =>
            values.Aggregate(input, (current, value) => current.Replace(value, string.Empty));

        /// <summary>
        /// Removes single quotes (') from the string <paramref name="input"/>.
        /// </summary>
        /// <param name="input">Value to be modified.</param>
        /// <returns><paramref name="input"/> without single quotes.</returns>
        public static string RemoveMarks(this string input) =>
            input.Replace("'", string.Empty);

        /// <summary>
        /// Truncates the string <paramref name="input"/> to the length <paramref name="maxLength"/>.
        /// </summary>
        /// <param name="input">Value to be truncated.</param>
        /// <param name="maxLength">Maximum length of the string.</param>
        /// <returns><paramref name="input"/> truncated to the maximum length <paramref name="maxLength"/>.</returns>
        public static string CutIfTooLong(this string input, int maxLength) =>
            input.Length > maxLength ? input[..maxLength] : input;

        /// <summary>
        /// Checks if the string <paramref name="input"/> is contained in <paramref name="values"/>.
        /// </summary>
        /// <param name="input">Value to be checked.</param>
        /// <param name="values">Array containing the values to be checked.</param>
        /// <returns>True if the string <paramref name="input"/> is contained in <paramref name="values"/>.</returns>
        public static bool In(this string input, params string[] values) =>
            values.Contains(input);
       
        /// <summary>
        /// Converts a <see cref="string"/> value to a <see cref="decimal"/> value.
        /// </summary>
        /// <param name="input">Value to be converted.</param>
        /// <returns><paramref name="input"/> converted to <see cref="decimal"/> or <see langword="null"/> if the value cannot be converted.</returns>
        public static decimal? ToDecimal(this string input)
        {
            if (Convert.ToDecimal("3.3") == ((decimal)3.3))
            { return decimal.TryParse(input.Replace(",", "."), out decimal result) ? result : null; }
            else
            { return decimal.TryParse(input.Replace(".", ","), out decimal result) ? result : null; }
        }

        /// <summary>
        /// Converts a <see cref="string"/> value to a <see cref="DateTime"/> value.
        /// </summary>
        /// <param name="input">Value to be converted.</param>
        /// <returns><paramref name="input"/> converted to <see cref="DateTime"/> or <see langword="null"/> if the value cannot be converted.</returns>
        public static DateTime? ToDateTime(this string input)
        {
            return DateTime.TryParseExact(input, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result) ?
                result : null;
        }

        /// <summary>
        /// Converts a <see cref="string"/> value to a <see cref="bool"/> value.
        /// </summary>
        /// <param name="input">Value to be converted.</param>
        /// <returns><paramref name="input"/> converted to <see cref="bool"/> or <see langword="null"/> if the value cannot be converted.</returns>
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
        /// Formats a phone number to a standard pattern without any special characters.
        /// </summary>
        /// <param name="input">Value to be formatted.</param>
        /// <returns><paramref name="input"/> formatted to the standard pattern without any special characters.</returns>
        public static string ToPhone(this string input)
        {
            string varRet = input.RemoveAll(["(", ")", "-", " "]);
            if (!long.TryParse(varRet, out long phoneLong)) return string.Empty;
            varRet = phoneLong.ToString();
            return varRet.Length == 10 ? varRet.Insert(2, "9") : varRet;
        }

        /// <summary>
        /// Formats a cellphone number to a standard pattern without any special characters.
        /// </summary>
        /// <param name="input">Value to be formatted.</param>
        /// <returns><paramref name="input"/> formatted to the standard pattern without any special characters.</returns>
        public static string ToCell(this string input)
        {
            string varRet = input.RemoveAll(["(", ")", "-", " "]);
            if (!long.TryParse(varRet, out long phoneLong)) return string.Empty;
            return phoneLong.ToString();
        }

        #endregion




    }
}
