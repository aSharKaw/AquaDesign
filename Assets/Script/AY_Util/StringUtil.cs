/// <summary>
/// Utility library.
/// <authority> ATSUSHI YAMASHITA. </authority>
/// </summary>
namespace AY_Util
{
    using System.Globalization;

    /// <summary>
    /// String utilities library.
    /// </summary>
    public static class StringUtil
    {
        /// <summary>
        /// Convert to title case.
        /// </summary>
        /// <param name="str">Convert string.</param>
        /// <returns>Converted string.</returns>
        public static string ToTitle ( this string str )
        {
            TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
            return ti.ToTitleCase( str );
        }
    }
}
