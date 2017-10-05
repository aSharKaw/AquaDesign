using UnityEngine;

/// <summary>
/// Utility library.
/// <authority> ATSUSHI YAMASHITA. </authority>
/// </summary>
namespace AY_Util
{
    /// <summary>
    /// Random utilities library.
    /// </summary>
    public class RandUtil
    {
        public delegate float Type ( );

        /// <summary>
        /// 絶対値を基準とした-1から1の範囲を含む正規化乱数。
        /// </summary>
        /// <returns>乱数</returns>
        public static float AbsNormal ( )
        {
            return Random.Range( -1.0f, 1.0f );
        }

        /// <summary>
        /// 0から１までの範囲を含む正規化乱数。
        /// </summary>
        /// <returns>乱数</returns>
        public static float Normal ( )
        {
            return Random.Range( 0.0f, 1.0f );
        }

        /// <summary>
        /// 生成した正規化乱数に範囲を適用する。
        /// </summary>
        /// <param name="func">正規化乱数の生成関数</param>
        /// <param name="size">乱数の大きさ</param>
        /// <returns>指定された大きさの乱数</returns>
        public static float Range ( Type func, float size )
        {
            return func() * size;
        }
    }
}
