using UnityEngine;

/// <summary>
/// このクラスはまだ機能していないようにみえます。
/// </summary>
public class ObjectDrag : MonoBehaviour
{
    /// <summary>
    /// カメラインスタンスをInspectorから指定するための変数。
    /// </summary>
    [SerializeField]
    private Camera _camera;

    /// <summary>
    /// Rayを飛ばすときのマスク
    /// </summary>
    [SerializeField]
    private LayerMask _mask;

    /// <summary>
    /// レイが命中しなかった場合の定数。
    /// </summary>
    private readonly Vector3 DROP_OUT = new Vector3( 0, 0, -100 );

    /// <summary>
    /// Rayの当たった地点を返す
    /// </summary>
    /// <returns></returns>
    private Vector3 GetRayHitPoint ( )
    {
        RaycastHit hit;
        Ray ray = _camera.ScreenPointToRay( Input.mousePosition );

        bool isHit = Physics.Raycast( ray, out hit, 1.0f, _mask );
        if (isHit == false) return DROP_OUT;
        return hit.point;
    }

    /// <summary>
    /// マウスのボタンをあげたときの処理。
    /// </summary>
    private void OnMouseUp ( )
    {
        bool isDropOut = gameObject.transform.position == DROP_OUT;
        if (isDropOut == false) return;
        Destroy( gameObject );
    }

    /// <summary>
    /// /カメラが指定されていなければ、メインカメラを取得する。
    /// </summary>
    private void Start ( )
    {
        if (this._camera != null) return;
        _camera = Camera.main;
    }
}
