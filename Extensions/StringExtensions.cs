using System.Globalization;

namespace BaseConverter.Extensions
{
    public static class StringExtensions
    {
        public static string RemoveAll(this string input, string[] values) =>
            values.Aggregate(input, (current, value) => current.Replace(value, string.Empty));

        public static string RemoveMarks(this string input) =>
            input.Replace("'", string.Empty);

        public static string CutIfTooLong(this string input, int maxLength) =>
            input.Length > maxLength ? input[..maxLength] : input;
        
        public static bool In(this string input, params string[] values) => 
            values.Contains(input);

        public static decimal? ToDecimal(this string input)
        {
            if (Convert.ToDecimal("3.3") == ((decimal)3.3))
            { return Convert.ToDecimal(input.Replace(",", ".")); }
            else
            { return Convert.ToDecimal(input.Replace(".", ",")); }
        }

        public static DateTime? ToDateTime(this string input)
        {
            return DateTime.TryParseExact(input, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result) ?
                result : null;
        }

        public static bool? TryBoolParse(this string txt)
        {
            string formValue = txt.ToLower();

            if (bool.TryParse(txt, out bool result)) return result;

            if (formValue.In(["sim", "nao", "não"])) return formValue == "sim";

            if (formValue.In(["true", "false"])) return formValue == "true";

            if (formValue.In(["1", "0"])) return formValue == "1";
        
            return null;
        }

        #region Format

        public static string ToPhone(this string txt)
        {
            string varRet = txt.RemoveAll(["(", ")", "-", " "] );
            if (!long.TryParse(varRet, out long phoneLong)) return string.Empty;
            varRet = phoneLong.ToString();
            return varRet.Length == 10 ? varRet.Insert(2, "9") : varRet;
        }

        public static string ToCell(this string txt)
        {
            string varRet = txt.RemoveAll(["(", ")", "-", " "]);
            if (!long.TryParse(varRet, out long phoneLong)) return string.Empty;
            return phoneLong.ToString();
        }

        #endregion




    }
}
