using AY_Util;
using System.Collections;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class UICreate : MonoBehaviour
{
    /// <summary>
    /// ページ要素の総数
    /// </summary>
    private readonly int _PAGE_ELEMENT = 8;

    /// <summary>
    /// キャンバス要素
    /// </summary>
    private GameObject _canvas;

    /// <summary>
    /// ドロップダウンUI
    /// </summary>
    private Dropdown _dropdown;

    /// <summary>
    /// UI単位のプレファブ
    /// </summary>
    private GameObject _fishUI;

    /// <summary>
    /// 生成用UIチップのルートの位置
    /// </summary>
    [SerializeField]
    private Vector3 _UiHeadPos = new Vector3( -308, -259, 0 );

    /// <summary>
    /// 生成用UIチップのルートの大きさ
    /// </summary>
    [SerializeField]
    private Vector3 _UiHeadScale = new Vector3( 0.8f, 0.8f, 1 );


    /// <summary>
    /// ボタンなどのUIを作成する。
    /// </summary>
    /// <param name="arr"></param>
    public void CreateUI ( ArrayList arr )
    {
        Debug.LogFormat( "{0} : {1}", this.GetType().Name, new System.Diagnostics.StackFrame().GetMethod().Name );
        GameObject FishUIHead = new GameObject( "FishUI" );
        FishUIHead.transform.parent = _canvas.transform;


        Debug.LogFormat( "Count {0}", arr.Count );

        for (int i = 0; i < _PAGE_ELEMENT && i < arr.Count ; i++)
        {
            BioData data = ( BioData )arr[i];
            Debug.LogFormat( "Count {0}, data name : {1}", arr.Count, data.GetNameEn() );

            if (data.GetNameEn().Length < 1) continue;
            CreateUITip( FishUIHead, i, data );
        }


        FishUIHead.transform.localPosition = _UiHeadPos;
        FishUIHead.transform.localScale = _UiHeadScale;

    }

    /// <summary>
    /// 指定されたページに表示されるUI要素をフィルタリングして返す。
    /// </summary>
    /// <param name="page">表示する予定のページインデックス</param>
    /// <returns>表示される要素の配列</returns>
    public void GetPageElement ( int page )
    {
        DeleteUI();
        ArrayList arr = BioDataManager.Instance().GetArray();
        int pageStart = page * _PAGE_ELEMENT;
        ArrayList pageData = ArrayListUtil<BioData>.Slice( arr, pageStart, pageStart + _PAGE_ELEMENT );


        CreateUI( pageData );
    }

    /// <summary>
    /// シーン起動時にメンバー関数の初期化を行う。
    /// </summary>
    private void Awake ( )
    {
        _fishUI = Resources.Load( "Prefub/FishUI" ) as GameObject;
        _canvas = GameObject.Find( "Canvas" );
        _dropdown = _canvas.transform.FindChild( "Dropdown" ).gameObject.GetComponent<Dropdown>();
    }

    /// <summary>
    /// OnClickイベントの作成
    /// </summary>
    /// <param name="fishUI">UI単位をまとめるオブジェクト。</param>
    /// <param name="data">作成する魚のデータ</param>
    private void ClickEvent ( GameObject fishUI, BioData data )
    {
        BiologicalManager _manager = GetComponent<BiologicalManager>();
        FishManager fish = _manager.GetFishManager();
        Button createButton = GetButtonComponent( fishUI, "CreateButton" );
        createButton.onClick.AddListener( ( ) =>
        {
            fish.FishCreate( data.GetBioType(), data.GetNameEn() );
        } );

        Button deleteButton = GetButtonComponent( fishUI, "DeleteButton" );
        if (BioType.FISH == data.GetBioType())
        {
            deleteButton.onClick.AddListener( ( ) => fish.ObjectDelete( data.GetNameEn() ) );
            return;
        }
        // 魚以外はDeleteButtonは使わないので削除
        Destroy( deleteButton.gameObject );
    }

    /// <summary>
    /// UIオブジェクトの生成
    /// </summary>
    /// <param name="FishUIHead">生成されたオブジェクトの親要素</param>
    /// <param name="i">生成位置を調整するインデックス</param>
    /// <param name="data">生成するオブジェクトのデータが入ったインスタンス</param>
    private void CreateUITip ( GameObject FishUIHead, int i, BioData data )
    {
        Debug.LogFormat( "uihead name :{0}, data en name :{1}", FishUIHead.name, data.GetNameEn() );
        GameObject fishUI;
        int posx = 820 + ( ( i % 2 ) * 95 );
        int posy = 370 - ( ( i / 2 ) * 95 );
        Vector2 position = new Vector2( posx, posy );

        fishUI = Instantiate( _fishUI, position, Quaternion.identity );
        fishUI.transform.parent = FishUIHead.transform;
        fishUI.name = data.GetNameJp();

        PictureRef( fishUI, data );
        ClickEvent( fishUI, data );
    }

    /// <summary>
    /// FishUIがすでに生成済みであれば削除する。
    /// </summary>
    private void DeleteUI ( )
    {
        GameObject alreadyUI = GameObject.Find( "FishUI" ).gameObject;
        if (alreadyUI == null) return;
        Destroy( alreadyUI );
    }

    /// <summary>
    /// 指定したオブジェクトから、子要素にある、指定した名前のボタンコンポネントを取得して返す。
    /// </summary>
    /// <param name="obj">ボタンを子にもつオブジェクト</param>
    /// <param name="name">取得するボタンオブジェクトの名前</param>
    /// <returns>指定された名前のボタンコンポネント</returns>
    private Button GetButtonComponent ( GameObject obj, string name )
    {
        Button btn = obj.transform.FindChild( name ).GetComponent<Button>();
        Assert.IsNotNull( btn );
        return btn;
    }

    /// <summary>
    /// 参照するUI画像をリソースから読み込んで表示
    /// </summary>
    /// <param name="fishUI">画像を設定するゲームオブジェクトの親オブジェクト</param>
    /// <param name="data">設定するデータ</param>
    private void PictureRef ( GameObject fishUI, BioData data )
    {
        string type = StringUtil.ToTitle( data.GetBioType().ToString() );
        Image image = fishUI.transform.FindChild( "View" ).GetComponent<Image>();
        string resourceString = "Image/" + type + "/" + data.GetNameEn();
        Sprite View = Resources.Load( resourceString, typeof( Sprite ) ) as Sprite;
        image.sprite = View;
    }

    /// <summary>
    /// ドロップダウンUIの項目名を設定する。
    /// </summary>
    private void SetDropDown ( )
    {
        // 後でBioTypeから生成するようにする。
        string[] ids = { "生体1", "生体2", "生体3", "水草1", "水草2", "小物", "地形" };
        ArrayUtil<string>.ForEach( ids, id =>
        {
            Dropdown.OptionData data = new Dropdown.OptionData
            {
                text = id
            };
            _dropdown.options.Add( data );
        } );
        _dropdown.RefreshShownValue();
    }

    /// <summary>
    /// ドロップダウンを初期化する
    /// </summary>
    private void Start ( )
    {
        SetDropDown();
    }
}
