using System.Collections;
using UnityEngine.Assertions;

/// <summary>
/// Utility library.
/// <authority> ATSUSHI YAMASHITA. </authority>
/// </summary>
namespace AY_Util
{
    /// <summary>
    /// ArrayList型を扱うための汎用的な操作の型。
    /// </summary>
    /// <typeparam name="T">操作対象とするArrayListの型</typeparam>
    public class ArrayListUtil<T>
    {
        public delegate T MinFunc ( T t1, T t2 );

        public delegate T Func ( T e );

        public delegate bool MatchFunc ( T e );

        /// <summary>
        /// Map 関数。指定した操作を全ての要素に大して行う。
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="f"></param>
        /// <returns></returns>
        static public ArrayList Map ( ArrayList arr, Func f)
        {
            ArrayList ret = new ArrayList();
            for(int i = 0; i < arr.Count; i++)
            {
                T r = f( ( T )arr[i] );
                ret.Add( r );
            }
            return ret;
        }

        /// <summary>
        /// Filter 関数。条件関数が真のものだけ要素として返す。
        /// </summary>
        /// <param name="arr">操作対象</param>
        /// <param name="f">判定に使う条件関数。</param>
        /// <returns></returns>
        static public ArrayList Filter ( ArrayList arr, MatchFunc f )
        {
            ArrayList ret = new ArrayList();
            for (int i = 0; i < arr.Count; i++)
            {
                bool use = f( ( T )arr[i] );
                if(use) ret.Add( arr[i] );
            }
            return ret;
        }

        /// <summary>
        /// ArrayListを渡すと、指定した地点から指定した長さの要素を持った、
        /// 新しいArrayListを生成して返す。
        /// </summary>
        /// <param name="arr">操作対象。</param>
        /// <param name="start">要素の初期地点</param>
        /// <param name="length">要素の長さ</param>
        /// <returns></returns>
        static public ArrayList Slice (ArrayList arr, int start, int length)
        {
            Assert.IsTrue( arr.Count > start );
            Assert.IsTrue( arr.Count <= start + length);
            ArrayList ret = new ArrayList();
            for (int i = 0; i < arr.Count && i < length; i++)
                ret.Add( ( T )arr[i + start] );
            return ret;
        }

        /// <summary>
        /// 指定された要素で、指定された長さだけ配列を埋める。
        /// </summary>
        /// <param name="arr">操作対象。</param>
        /// <param name="data">埋めるデータ。</param>
        /// <param name="length">埋める長さ。</param>
        /// <returns></returns>
        static public ArrayList Fill (ArrayList arr, T data, int length)
        {
            ArrayList ret = new ArrayList();
            for (int i = 0; i < arr.Count; i++) ret.Add( arr[i] );
            for (int i = 0; i < length; i++) ret.Add( data );
            return ret;
        }
    }
}




