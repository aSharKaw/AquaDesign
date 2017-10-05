using UnityEngine;

/// <summary>
/// 水草ビルボードスクリプト
/// </summary>
public class BillBord : MonoBehaviour
{
    /// <summary>
    /// Inspectorからカメラを指定するｔめの関数。
    /// </summary>
    [SerializeField]
    private Camera _targetCamera;

    /// <summary>
    /// Inspectorからカメラの指定がなけれあメインカメラを対象とする。
    /// </summary>
    private void Start ( )
    {
        if (this._targetCamera != null) return;
            _targetCamera = Camera.main;
    }

    /// <summary>
    /// 手動でカメラの方向を向かせてビルボード化。
    /// </summary>
    private void FixedUpdate ( )
    {
        //X軸は維持したままカメラの方を向く
        Vector3 target = this._targetCamera.transform.position;
        target.y = this.transform.position.y;
        this.transform.LookAt( target );
    }
}
