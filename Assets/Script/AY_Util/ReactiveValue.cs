using System.Collections.Generic;

/// <summary>
/// Utility library.
/// <authority> ATSUSHI YAMASHITA. </authority>
/// </summary>
namespace AY_Util
{
    /// <summary>
    /// 値の更新時にアクションを呼び出す。
    /// </summary>
    /// <typeparam name="T">監視する対象の値</typeparam>
    [System.Serializable]
    public class ReactiveValue<T>
    {
        /// <summary>
        /// 変更時に呼び出される関数のリスト
        /// </summary>
        [UnityEngine.SerializeField]
        private List<Action> _actions = new List<Action>();

        /// <summary>
        /// 変更を確認するためのイコール判定関数
        /// </summary>
        private EqualFunc _equals = null;

        /// <summary>
        /// 監視対象の値
        /// </summary>
        [UnityEngine.SerializeField]
        private T _value;

        /// <summary>
        /// 初期値を設定して作成する。
        /// </summary>
        /// <param name="initValue">初期値</param>
        public ReactiveValue ( T initValue )
        {
            _value = initValue;
        }

        /// <summary>
        /// アクション関数を定義するデリゲート型
        /// </summary>
        /// <param name="oldValue">更新前の値</param>
        /// <param name="newValue">更新後の値</param>
        public delegate void Action ( T oldValue, T newValue );

        /// <summary>
        /// この型で指定された二つの値が等しいかを判定する。
        /// </summary>
        /// <param name="a">値１</param>
        /// <param name="b">値２</param>
        /// <returns>等しい場合は真</returns>
        public delegate bool EqualFunc ( T a, T b );

        /// <summary>
        /// 監視している内部の値を取得する。
        /// </summary>
        /// <returns>内部の値</returns>
        public T Get ( )
        {
            return _value;
        }

        /// <summary>
        /// 同値判定関数の設定
        /// </summary>
        /// <param name="efunc">設定する同値判定関数</param>
        /// <returns>メソッドチェーン用に自身のインスタンス</returns>
        public ReactiveValue<T> SetEquals ( EqualFunc efunc )
        {
            _equals = efunc;
            return this;
        }

        /// <summary>
        /// アクション関数を追加する処理。
        /// </summary>
        /// <param name="aFunc">追加するアクションの関数</param>
        /// <returns>メソッドチェーン用に自身のインスタンス</returns>
        public ReactiveValue<T> Subscribe ( T instance, Action aFunc )
        {
            _actions.Add( aFunc );
            return this;
        }

        /// <summary>
        /// 値の代入を行う処理。変化が発生すれば登録されたアクションをつかって通知する。
        /// </summary>
        /// <param name="newValue">代入したい値。</param>
        public void Overwrite ( T newValue )
        {
            if (_equals == null) throw new System.Exception( "Unset equals function" );
            if (_equals( _value, newValue )) return;
            _actions.ForEach( ( Action a ) => { a( _value, newValue ); } );
            _value = newValue;
        }
    }
}
