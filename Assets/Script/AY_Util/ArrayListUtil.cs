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

        static public T Min(ArrayList arr, MinFunc f )
        {
            Assert.IsNotNull( arr );
            T t = (T)arr[0];
            for (int i = 1; i < arr.Count; i++)
                t = f( t, ( T )arr[i] );
            return t;
        }

        static public ArrayList Sort ( ArrayList arr, MinFunc f )
        {
            ArrayList ret = new ArrayList();
            for (int i = 0; i < arr.Count-1; i++)
            {
                T ob1 = ( T )arr[i];
                T ob2 = ( T )arr[i+1];
                int rel = ret.Add( f( ob1, ob2 ) );
                if (rel > 0)
                {
                    T t = ob1;
                    ob1 = ob2;
                    ob2 = t;
                }
            }
            return ret;
        }

        static public ArrayList MapFilter ( ArrayList arr, Func f)
        {
            ArrayList ret = new ArrayList();
            for(int i = 0; i < arr.Count; i++)
            {
                T r = f( ( T )arr[i] );
                if (r == null) continue;
                ret.Add( r );
            }
            return ret;
        }

        static public ArrayList Slice (ArrayList arr, int start, int length)
        {
            ArrayList ret = new ArrayList();
            for (int i = 0; i < arr.Count && i < length; i++)
                ret.Add( ( T )arr[i + start] );
            return ret;
        }
    }
}




