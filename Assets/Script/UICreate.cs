using AY_Util;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UICreate : MonoBehaviour
{
    private readonly int _PAGE_SUBJECT = 8;
    private GameObject _canvas;

    [SerializeField]
    private Dropdown _dropdown;

    private GameObject _fishUI;

    private BiologicalManager _manager;

    private enum TYPE
    {
        Fish,
        Leaf,
        Accessory,
        Terrain
    };

    public void CreateUI ( ArrayList arr )
    {
        GameObject FishUIHead = new GameObject( "FishUI" );
        FishUIHead.transform.parent = _canvas.transform;

        for (int i = 0; i < _PAGE_SUBJECT; i++)
        {
            BioData data = ( BioData )arr[i];
            CreateUITip( i, data, FishUIHead );
        }
    }

    public ArrayList GetPageElement ( int page )
    {
        DeleteUI();
        ArrayList arr = BioDataManager.Instance().GetArray();
        int pageStart = page * _PAGE_SUBJECT;
        ArrayList pageData = ArrayListUtil<BioData>.Slice( arr, pageStart, pageStart + _PAGE_SUBJECT );
        return pageData;
    }

    private void Awake ( )
    {
        _fishUI = Resources.Load( "Prefub/FishUI" ) as GameObject;
        _canvas = GameObject.Find( "Canvas" );
        _dropdown = _canvas.transform.FindChild( "Dropdown" ).gameObject.GetComponent<Dropdown>();
    }

    private void ClickEvent ( BioData data, GameObject fishUI )
    {
        //OnClickイベントの作成
        BiologicalManager _manager = GetComponent<BiologicalManager>();
        Button createButton = fishUI.transform.FindChild( "CreateButton" ).GetComponent<Button>();
        FishManager fish = _manager.GetFishManager();
        createButton.onClick.AddListener( ( ) =>
        fish.FishCreate( data.GetBioType().ToString(), data.GetNameJp() ) );

        if (BioType.FISH == data.GetBioType())
        {
            //OnClickイベントの作成
            Button deleteButton = fishUI.transform.FindChild( "DeleteButton" ).GetComponent<Button>();
            deleteButton.onClick.AddListener( ( ) => fish.ObjectDelete( data.GetNameJp() ) );
            return;
        }
        //DeleteButtonは使わないので削除
        GameObject dalete = fishUI.transform.FindChild( "DeleteButton" ).gameObject;
        Destroy( dalete );
    }

    private void CreateUITip ( int i, BioData data, GameObject FishUIHead )
    {
        //必要オブジェクトの参照と生成
        GameObject fishUI;
        int posx = 820 + ( ( i % 2 ) * 95 );
        int posy = 370 - ( ( i / 2 ) * 95 );
        Vector2 position = new Vector2( posx, posy );

        fishUI = Instantiate( _fishUI, position, Quaternion.identity, FishUIHead.transform );
        fishUI.name = data.GetNameJp();

        PictureRef( fishUI, data );
        ClickEvent( data, fishUI );
    }

    private void DeleteUI ( )
    {
        //生成済みのものがあれば削除
        GameObject alreadyUI = GameObject.Find( "FishUI" ).gameObject;
        if (alreadyUI == null) return;
        Destroy( alreadyUI );
    }

    private void PictureRef ( GameObject fishUI, BioData data )
    {
        //UI画像の参照
        Image ViewImage = fishUI.transform.FindChild( "View" ).GetComponent<Image>();
        string resourceString = "Image/" + data.GetBioType() + "/" + data.GetNameJp();
        Sprite View = Resources.Load( resourceString, typeof( Sprite ) ) as Sprite;
        ViewImage.sprite = View;
    }

    /// <summary>
    /// ドロップダウンUIの項目名を設定する。
    /// </summary>
    private void SetDropDown ( )
    {
        // 後でBioTypeから生成するようにする。
        string[] ids ={"生体1","生体2","生体3","水草1","水草2","小物","地形"};
        foreach (string id in ids)
        {
            Dropdown.OptionData data = new Dropdown.OptionData
            {
                text = id
            };
            _dropdown.options.Add( data );
        }
        _dropdown.RefreshShownValue();
    }

    private void Start ( )
    {
        SetDropDown();
    }
}
