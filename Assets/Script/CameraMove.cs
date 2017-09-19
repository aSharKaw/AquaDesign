using UnityEngine;

/// <summary>
/// カメラ移動用スクリプト
/// </summary>
public class CameraMove : MonoBehaviour
{
    /// <summary>
    /// 移動速度
    /// </summary>
    private float _moveSpeed;

    /// <summary>
    /// カメラのデフォルトポジション
    /// </summary>
    private Vector3 DEFAULT_POS = new Vector3( 0, 0, 0.7f );

    /// <summary>
    /// カメラに対する移動処理の内容を一時的に保持する。
    /// newコストを避けるためにメンバー関数として保持。
    /// </summary>
    private Vector2 _delta = new Vector2();

    /// <summary>
    /// カメラの変化量を計算するために使う。
    /// newコストを避けるためにメンバー関数として保持。
    /// </summary>
    private Vector2 _move = new Vector2();

    /// <summary>
    /// ボタン入力による処理を_deltaで受け止めるための窓口。
    /// </summary>
    /// <param name="x">X上の移動量。</param>
    public void MoveX(int x)
    {
        _delta.x += x;
    }

    /// <summary>
    /// ボタン入力による処理を_deltaで受け止めるための窓口。
    /// </summary>
    /// <param name="y">Y上の移動量</param>
    public void MoveY ( int y )
    {
        _delta.y += y;
    }

    /// <summary>
    /// ボタン入力でカメラ位置を初期位置へ戻すための窓口。
    /// </summary>
    public void ResetButton ( )
    {
        gameObject.transform.position = DEFAULT_POS;
        gameObject.transform.LookAt( Vector3.zero );
    }

    /// <summary>
    ///
    /// </summary>
    private void Update ( )
    {
        float size = _moveSpeed * Time.deltaTime;
        _move.Set( _delta.x * size, _delta.y * size );
        gameObject.transform.Translate(_move);
        gameObject.transform.LookAt( Vector3.zero );
        _move.Set( 0, 0 );
    }
}
