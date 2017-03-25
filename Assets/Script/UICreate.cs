using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICreate : MonoBehaviour {

    //[SerializeField]
    private GameObject _fishUI;
    private BiologicalManager _manager;
    private GameObject _canvas;
    [SerializeField]
    private Dropdown _dropdown;

    private string[] ID =
    {
        "生体",
        "水草",
        "小物"
    };

    private string[] TYPE =
    {
        "Fish",
        "Leaf",
        "Accessory"
    };

    private string[] FISH_NAME =
    {
        "NeonTetra",//ネオンテトラ
        "TigerOscar",//タイガーオスカー
        "HoneyDwarfGourami",//ハニードワーフグラミー
        "GoldenGourami",//ゴールデングラミー
        "Polypterus",//ポリプテルス
        "Otocinclus",//オトシンクルス

        "Amazonicus",//アマゾンソード
        "Anubias",//アヌビスナナ
        "Cabomba",//カボンバ
        "MicroSorum",//ミクロソリウム

        "Wood1",//木1
        "Wood2",//木2
        "Moss_HighHill",//苔石(高)
        "Moss_HighHalfHill",//苔石(高・半)
        "Moss_HighQuarterHill",//苔石(高・半々)
        "Moss_LowHill",//苔石(低)
        "Moss_LowHalfHill",//苔石(低・半)
        "Moss_LowQuarterHill"//苔石(低・半々)
    };

    void Awake()
    {
        _fishUI = Resources.Load("Prefub/FishUI") as GameObject;
        _canvas = GameObject.Find("Canvas");
        _dropdown = _canvas.transform.FindChild("Dropdown").gameObject.GetComponent<Dropdown>();
    }

    //UIの作成
    void CreateUI(int id_number, int number, string Type)
    {
        GameObject FishUIHead = new GameObject("FishUI");
        FishUIHead.transform.parent = _canvas.transform;

        for (int i = 0; i < number;i++)
        {
            //必要オブジェクトの参照と生成
            GameObject fishUI;
            Vector2 position = new Vector2(820 + ((i % 2) * 95), 370 - ((i / 2) * 95));

            fishUI = Instantiate(_fishUI, position, Quaternion.identity, FishUIHead.transform);
            fishUI.name = "fishUI";
            //ボタンイベントのみ想定の次の要素が参照されるバグ対応のため
            int id_check_number = id_number + i;

            //UI画像の参照
            Image ViewImage = fishUI.transform.FindChild("View").GetComponent<Image>();
            Sprite View = Resources.Load("Image/" + Type + "/" + FISH_NAME[id_check_number], typeof(Sprite)) as Sprite;
            ViewImage.sprite = View;

            if (Type == "Fish")
            {
                //OnClickイベントの作成
                BiologicalManager _manager = GetComponent<BiologicalManager>();
                Button createButton = fishUI.transform.FindChild("CreateButton").GetComponent<Button>();
                createButton.onClick.AddListener(() => _manager.ObjectCreate(Type, FISH_NAME[id_check_number]));
                Button deleteButton = fishUI.transform.FindChild("DeleteButton").GetComponent<Button>();
                deleteButton.onClick.AddListener(() => _manager.ObjectDelete(FISH_NAME[id_check_number]));
            }
            else if(Type == "Leaf" || Type == "Accessory")
            {
                //OnClickイベントの作成
                BiologicalManager _manager = GetComponent<BiologicalManager>();
                Button createButton = fishUI.transform.FindChild("CreateButton").GetComponent<Button>();
                createButton.onClick.AddListener(() => _manager.ObjectCreate(Type, FISH_NAME[id_check_number]));
                //DeleteButtonは使わないので削除
                GameObject deleteButton = fishUI.transform.FindChild("DeleteButton").gameObject;
                Destroy(deleteButton);
            }
        }
    }

    void DeleteUI()
    {
        //生成済みのものがあれば削除
        GameObject alreadyUI = GameObject.Find("FishUI").gameObject;
        if (alreadyUI != null)
        {
            Destroy(alreadyUI);
        }
    }

    void SetDropDown()
    {
        for(int i = 0;i < ID.Length; i++)
        {
            _dropdown.options.Add(new Dropdown.OptionData { text = ID[i] });
        }
        _dropdown.RefreshShownValue();
    }

    public void SetUI(int value)
    {
        DeleteUI();
        switch(value)
        {
            case 0:
                CreateUI(0, 6, TYPE[0]);
                break;
            case 1:
                CreateUI(6, 4, TYPE[1]);
                break;
            case 2:
                CreateUI(10, 8, TYPE[2]);
                break;
        }
    }

    private void Start()
    {
        SetDropDown();
    }
}
