/// <summary>
/// 生体タイプ
/// </summary>
public enum BioType
{
    FISH, LEAF, ACCESSARY, TERRAIN
};

/// <summary>
/// 生体データ
/// </summary>
public class BioData
{
    /// <summary>
    /// 生体の英語名
    /// </summary>
    private string _nameEn;

    /// <summary>
    /// 生体の日本語名
    /// </summary>
    private string _nameJp;

    /// <summary>
    /// このデータの生体型
    /// </summary>
    private BioType _type;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    public BioData ( ) { }

    /// <summary>
    /// 英語名を設定する関数
    /// </summary>
    /// <param name="name">設定する文字列</param>
    /// <returns>自分のインスタンスを返す</returns>
    public BioData SetNameEn ( string name ) { _nameEn = name; return this; }

    public string GetNameEn ( ) { return _nameEn; }

    /// <summary>
    /// 日本語名を設定する関数
    /// </summary>
    /// <param name="name">設定する文字列</param>
    /// <returns>自分のインスタンスを返す</returns>
    public BioData SetNameJp ( string name ) { _nameJp = name; return this; }
    public string GetNameJp ( ) { return _nameJp; }

    /// <summary>
    /// 生体型を設定する関数
    /// </summary>
    /// <param name="type">設定するs生体型</param>
    /// <returns>自分のインスタンスを返す</returns>
    public BioData SetType ( BioType type ) { _type = type; return this; }
    public BioType GetBioType ( ) { return _type; }
}
