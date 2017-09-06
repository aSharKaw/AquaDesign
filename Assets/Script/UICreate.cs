using System;
using UnityEngine;
using UnityEngine.UI;
using AY_Util;

public class UICreate : MonoBehaviour
{
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

    private enum ID
    {
        生体1,
        生体2,
        生体3,
        水草1,
        水草2,
        小物,
        地形,
        LENGTH,
    }

    public void SetUI ( int value )
    {
        DeleteUI();

        switch (value)
        {
            case 0://生体
                CreateUI( 0, 8, EnumUtil<TYPE>.GetString( 0 ) );
                break;

            case 1:
                CreateUI( 8, 8, EnumUtil<TYPE>.GetString( 0 ) );
                break;

            case 2:
                CreateUI( 16, 2, EnumUtil<TYPE>.GetString( 0 ) );
                break;

            case 3://水草
                CreateUI( 18, 8, EnumUtil<TYPE>.GetString( 1 ) );
                break;

            case 4:
                CreateUI( 26, 2, EnumUtil<TYPE>.GetString( 1 ) );
                break;

            case 5://小物
                CreateUI( 28, 6, EnumUtil<TYPE>.GetString( 2 ) );
                break;

            case 6://地形
                CreateUI( 34, 6, EnumUtil<TYPE>.GetString( 3 ) );
                break;
        }
    }

    private void Awake ( )
    {
        _fishUI = Resources.Load( "Prefub/FishUI" ) as GameObject;
        _canvas = GameObject.Find( "Canvas" );
        _dropdown = _canvas.transform.FindChild( "Dropdown" ).gameObject.GetComponent<Dropdown>();
    }


    //UIの作成
    private void CreateUI ( int id_number, int number, string Type )
    {
        GameObject FishUIHead = new GameObject( "FishUI" );
        FishUIHead.transform.parent = _canvas.transform;

        for (int i = 0; i < number; i++)
        {
            //必要オブジェクトの参照と生成
            GameObject fishUI;
            int posx = 820 + ( ( i % 2 ) * 95 );
            int posy = 370 - ( ( i / 2 ) * 95 );
            Vector2 position = new Vector2( posx, posy );

            fishUI = Instantiate( _fishUI, position, Quaternion.identity, FishUIHead.transform );
            fishUI.name = FISH_NAME[id_number + i];
            //ボタンイベントのみ想定の次の要素が参照されるバグ対応のため
            int id_check_number = id_number + i;

            //UI画像の参照
            Image ViewImage = fishUI.transform.FindChild( "View" ).GetComponent<Image>();
            Sprite View = Resources.Load( "Image/" + Type + "/" + FISH_NAME[id_check_number], typeof( Sprite ) ) as Sprite;
            ViewImage.sprite = View;

            //OnClickイベントの作成
            BiologicalManager _manager = GetComponent<BiologicalManager>();
            Button createButton = fishUI.transform.FindChild( "CreateButton" ).GetComponent<Button>();
            FishManager fish = _manager.GetFishManager();
            createButton.onClick.AddListener( ( ) => fish.FishCreate( Type, FISH_NAME[id_check_number] ) );

            if (Type == "Fish")
            {
                //OnClickイベントの作成
                Button deleteButton = fishUI.transform.FindChild( "DeleteButton" ).GetComponent<Button>();
                deleteButton.onClick.AddListener( ( ) => fish.ObjectDelete( FISH_NAME[id_check_number] ) );
            }
            else if (Type == "Leaf" || Type == "Accessory" || Type == "Terrain")
            {
                //DeleteButtonは使わないので削除
                GameObject deleteButton = fishUI.transform.FindChild( "DeleteButton" ).gameObject;
                Destroy( deleteButton );
            }
        }
    }

    private void DeleteUI ( )
    {
        //生成済みのものがあれば削除
        GameObject alreadyUI = GameObject.Find( "FishUI" ).gameObject;
        if (alreadyUI == null) return;
        Destroy( alreadyUI );
    }

    /// <summary>
    /// ドロップダウンUIの項目名を設定する。
    /// </summary>
    private void SetDropDown ( )
    {
        foreach (ID id in Enum.GetValues( typeof( ID ) ))
        {
            Dropdown.OptionData data = new Dropdown.OptionData
            {
                text = id.ToString()
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
