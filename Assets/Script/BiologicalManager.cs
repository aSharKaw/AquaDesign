using UnityEngine;
using UnityEngine.Assertions;

/// <summary>
/// 水槽全体の管理をします。
/// </summary>
public class BiologicalManager
{
    /// <summary>
    ///このBiologicalManagerが複数作られた時に、
    ///エラーを表示するために使います。
    /// </summary>
    static private int _instantiated = 0;

    /// <summary>
    /// 魚の管理を行っているインスタンスです。
    /// </summary>
    private FishManager _fishManager;

    /// <summary>
    /// 水のインスタンスを保持しています。
    /// </summary>
    private GameObject _water;

    /// <summary>
    /// 魚を管理しているマネージャーを取得します。
    /// </summary>
    /// <returns></returns>
    public FishManager GetFishManager ( )
    {
        return _fishManager;
    }

    /// <summary>
    /// シーン開始時に呼び出され、
    /// 水インスタンスの取得と、魚の管理クラスを初期化しています。
    /// </summary>
    private void Start ( )
    {
        Assert.IsTrue( _instantiated == 0, "複数のマネージャが作成されています。" );
        GameObject water_pot = GameObject.Find( "WaterPot" );
        Assert.IsTrue( water_pot != null, "水槽オブジェクトがみつかりません。" );
        _water = water_pot.transform.FindChild( "Water" ).gameObject;
        _fishManager = new FishManager( _water );
    }
}
