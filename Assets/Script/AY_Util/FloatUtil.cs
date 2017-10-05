using UnityEngine;

/// <summary>
/// Utility library.
/// <authority> ATSUSHI YAMASHITA. </authority>
/// </summary>
namespace AY_Util
{
    /// <summary>
    /// Float utilities library.
    /// </summary>
    public class FloatUtil
    {
        /// <summary>
        /// 絶対値上の四捨五入に、負の値であればマイナスをかけて戻す。
        /// </summary>
        /// <param name="num">四捨五入する値。</param>
        /// <returns>変換された整数。</returns>
        public static int Round ( float num )
        {
            float abs = Mathf.Abs( num + 0.5f );
            int type = num < 0 ? -1 : 1;
            return type * Mathf.FloorToInt( abs );
        }
    }
}
