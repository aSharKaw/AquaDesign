using UnityEngine;

/// <summary>
/// 指定された形状の水槽オブジェクトを作成する。
/// このクラスについては、
/// ボタンからの操作でプレファブを指定して渡す方法の方が使いやすいはず。
/// </summary>
public class WaterPotCreate : MonoBehaviour
{

    /// <summary>
    /// 水槽のプレファブを指定しておく
    /// </summary>
    [SerializeField]
    private GameObject _waterpot60;

    /// <summary>
    /// 水槽のプレファブを指定しておく
    /// </summary>
    [SerializeField]
    private GameObject _waterpotcube;

    /// <summary>
    /// 水槽のプレファブを指定しておく
    /// </summary>
    [SerializeField]
    private GameObject _waterpothalfsphere;

    /// <summary>
    /// 水槽のプレファブを指定しておく
    /// </summary>
    [SerializeField]
    private GameObject _waterpotsphere;

    /// <summary>
    /// 今までの水槽を破棄して、新しい水槽を表示する。
    /// </summary>
    private void DeleteOldPot()
    {
        GameObject waterpot = GameObject.Find( "WaterPot" );
        Destroy( waterpot );
    }

    /// <summary>
    /// 水槽をPot60に変更する
    /// </summary>
    public void CreatePot60 ( )
    {
        DeleteOldPot();
        GameObject createPot = Instantiate( _waterpot60 );
        createPot.name = "WaterPot";
    }

    /// <summary>
    /// 水槽をCubeに変更する
    /// </summary>
    public void CreatePotCube ( )
    {
        DeleteOldPot();
        GameObject createPot = Instantiate( _waterpotcube );
        createPot.name = "WaterPot";
    }

    /// <summary>
    /// 水槽を半球体に変更する
    /// </summary>
    public void CreatePotHalfSphere ( )
    {
        DeleteOldPot();
        GameObject createPot = Instantiate( _waterpothalfsphere );
        createPot.name = "WaterPot";
    }

    /// <summary>
    /// 水槽を球体に変更する
    /// </summary>
    public void CreatePotSphere ( )
    {
        DeleteOldPot();
        GameObject createPot = Instantiate( _waterpotsphere );
        createPot.name = "WaterPot";
    }
}
