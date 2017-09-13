using System.Collections;

/// <summary>
/// 生体情報のマネジメントを行う
/// </summary>
public class BioDataManager
{
    /// <summary>
    /// シングルトンのインスタンス
    /// </summary>
    static private BioDataManager _self = new BioDataManager();

    /// <summary>
    /// BioDataManagerのリスト
    /// </summary>
    private ArrayList _arr = new ArrayList();

    /// <summary>
    /// アクセサリーの名前の英語名
    /// </summary>
    private string[] ACCESSARY_NAME_EN =
    {
        "Wood1",//木1
        "Wood2",//木2
        "Wood3",//木3
        "Oukoseki",//黄虎石
        "Mokaseki",//木化石
        "Sansuiseki",//山水石
    };

    /// <summary>
    /// アクセサリーの名前の日本語名
    /// </summary>
    private string[] ACCESSARY_NAME_JP =
    {
        "木1",
        "木2",
        "木3",
        "黄虎石",
        "木化石",
        "山水石",
    };

    /// <summary>
    /// 魚の英語名
    /// </summary>
    private string[] FISH_NAME_EN =
    {
        "NeonTetra",//ネオンテトラ
        "CardinalTetra",//カージナルテトラ
        "EmperorTetra",//エンペラーテトラ
        "TigerOscar",//タイガーオスカー
        "HoneyDwarfGourami",//ハニードワーフグラミー
        "GoldenGourami",//ゴールデングラミー
        "Polypterus",//ポリプテルス
        "Otocinclus",//オトシンクルス

        "SailfinCatfish",//セルフィンプレコ
        "CorydorasJulii",//コリドラスジュリー
        "CorydorasPanda",//コリドラスパンダ
        "TigerPleco",//タイガープレコ
        "JapaneseShrimp",//ヤマトヌマエビ
        "RedBeeShrimp",//レッドビーシュリンプ
        "BlackTetra",//ブラックテトラ
        "RedPlaty",//レッドプラティ

        "AfricanLampeye",//アフリカンランプアイ
        "YellowSunsetPlaty",//イエローサンセットプラティ
    };

    /// <summary>
    /// 魚の日本語名
    /// </summary>
    private string[] FISH_NAME_JP =
    {
        "ネオンテトラ",
        "カージナルテトラ",
        "エンペラーテトラ",
        "タイガーオスカー",
        "ハニードワーフグラミー",
        "ゴールデングラミー",
        "ポリプテルス",
        "オトシンクルス",

        "セルフィンプレコ",
        "コリドラスジュリー",
        "コリドラスパンダ",
        "タイガープレコ",
        "ヤマトヌマエビ",
        "レッドビーシュリンプ",
        "ブラックテトラ",
        "レッドプラティ",

        "アフリカンランプアイ",
        "イエローサンセットプラティ",
    };

    /// <summary>
    /// 植物の名前の英語名
    /// </summary>
    private string[] LEAF_NAME_EN =
    {
        "Amazonicus",//アマゾンソード
        "Anubias",//アヌビスナナ
        "Cabomba",//カボンバ
        "MicroSorum",//ミクロソリウム
        "LudwigiaPerennis",//レッドルブラ
        "AmmaniaGracilis",//アマニアグラキリス
        "Nesaea",//ネサエア
        "ScrewVallisneria",//スクリューバリスネリア
        "WaterBacopa",//ウォーターバコパ
        "Rotala",//ロタラ
    };

    /// <summary>
    /// 植物の名前の日本語名
    /// </summary>
    private string[] LEAF_NAME_JP =
    {
        "アマゾンソード",
        "アヌビスナナ",
        "カボンバ",
        "ミクロソリウム",
        "レッドルブラ",
        "アマニアグラキリス",
        "ネサエア",
        "スクリューバリスネリア",
        "ウォーターバコパ",
        "ロタラ",
    };

    /// <summary>
    /// 地形オブジェクトの英語名
    /// </summary>
    private string[] TERRAIN_NAME_EN =
    {
        "Moss_HighHill",//苔石(高)
        "Moss_HighHalfHill",//苔石(高・半)
        "Moss_HighQuarterHill",//苔石(高・半々)
        "Moss_LowHill",//苔石(低)
        "Moss_LowHalfHill",//苔石(低・半)
        "Moss_LowQuarterHill"//苔石(低・半々)
    };

    /// <summary>
    /// 地形オブジェクトの日本語名
    /// </summary>
    private string[] TERRAIN_NAME_JP =
    {
        "苔石(高)",
        "苔石(高・半)",
        "苔石(高・半々)",
        "苔石(低)",
        "苔石(低・半)",
        "苔石(低・半々)"
    };

    /// <summary>
    /// シングルトンのために封印
    /// </summary>
    private BioDataManager ( )
    {
        ArrayInit( _arr, BioType.FISH, FISH_NAME_EN, FISH_NAME_JP );
        ArrayInit( _arr, BioType.LEAF, LEAF_NAME_EN, LEAF_NAME_JP );
        ArrayInit( _arr, BioType.ACCESSARY, ACCESSARY_NAME_EN, ACCESSARY_NAME_JP );
        ArrayInit( _arr, BioType.TERRAIN, TERRAIN_NAME_EN, TERRAIN_NAME_JP );
    }

    /// <summary>
    /// シングルトンの取得
    /// </summary>
    /// <returns>シングルトンのインスタンス</returns>
    static public BioDataManager Instance ( ) { return _self; }

    /// <summary>
    /// 配列のインスタンスを返す
    /// </summary>
    /// <returns>配列のインスタンス</returns>
    public ArrayList GetArray ( )
    {
        return _arr;
    }

    /// <summary>
    /// 配列の値を初期化する
    /// </summary>
    /// <param name="fish">データを追加したい配列</param>
    /// <param name="type">設定する生体型</param>
    /// <param name="en">設定する英語名</param>
    /// <param name="jp">設定する日本語名</param>
    private void ArrayInit ( ArrayList fish, BioType type, string[] en, string[] jp )
    {
        for (int i = 0; i < en.Length; i++)
        {
            BioData data = new BioData()
                .SetType( type )
                .SetNameEn( en[i] )
                .SetNameJp( jp[i] );
            fish.Add( data );
        }

        // 空要素でページの空欄を埋めています
        for (int i = 0; i < 8 - en.Length % 8; i++)
        {
            BioData data = new BioData()
                .SetType( type )
                .SetNameEn( "" )
                .SetNameJp( "" );
            fish.Add( data );
        }
    }
}
