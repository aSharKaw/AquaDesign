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
    /// 初期化されたシングルトンインスタンス
    /// </summary>
    private static BiologicalManager _self = new BiologicalManager();

    /// <summary>
    /// 魚の管理を行っているインスタンスです。
    /// </summary>
    private FishManager _fishManager;

    /// <summary>
    /// 水のインスタンスを保持しています。
    /// </summary>
    private GameObject _water;

    /// 水インスタンスの取得と、魚の管理クラスを初期化しています。
    private BiologicalManager ( )
    {
        GameObject water_pot = GameObject.Find( "WaterPot" );
        Assert.IsNotNull( water_pot );
        _water = water_pot.transform.FindChild( "Water" ).gameObject;
        _fishManager = new FishManager( _water );
    }

    /// <summary>
    /// 魚を管理しているマネージャーを取得します。
    /// </summary>
    /// <returns>管理しているFishManagerを返す。</returns>
    public FishManager GetFishManager ( )
    {
        GameObject water_pot = GameObject.Find("WaterPot");
        _water = water_pot.transform.FindChild("Water").gameObject;
        //assetBundle = AssetBundle.LoadFromFile("Assets/AssetBundles/resources");
    }

    /// <summary>
    /// シングルトンのインスタンスを返す。
    /// </summary>
    /// <returns>シングルトンのインスタンス。</returns>
    private static BiologicalManager Instance ( ) { return _self; }
}
