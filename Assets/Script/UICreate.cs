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
        "テトラ",
        "オスカー",
        "グラミー",
        "ポリプテルス",
        "オトシンクルス",
        "水草",
        "苔石",
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

        "HighHill",//苔石(高)
        "LowHill"//苔石(低)
    };

    void Awake()
    {
        _fishUI = Resources.Load("Prefub/FishUI") as GameObject;
        _canvas = GameObject.Find("Canvas");
        _dropdown = _canvas.transform.FindChild("Dropdown").gameObject.GetComponent<Dropdown>();
    }

    //UIの作成
    void CreateUI(int id_number, int number, bool CreateDeleteButton)
    {
        GameObject FishUIHead = new GameObject("FishUI");
        FishUIHead.transform.parent = _canvas.transform;

        for (int i = 0; i < number;i++)
        {
            //必要オブジェクトの参照と生成
            GameObject fishUI;
            Vector2 position = new Vector2(868, 380 - (i * 80));

            fishUI = Instantiate(_fishUI, position, Quaternion.identity, FishUIHead.transform);
            fishUI.name = "fishUI";
            //ボタンイベントのみ想定の次の要素が参照されるバグ対応のため
            int id_check_number = id_number + i;

            if (CreateDeleteButton)
            {
                //UI画像の参照
                Sprite spritePlus = Resources.Load("Image/UI/" + FISH_NAME[id_check_number] + "Plus", typeof(Sprite)) as Sprite;
                Sprite spriteMinus = Resources.Load("Image/UI/" + FISH_NAME[id_check_number] + "Minus", typeof(Sprite)) as Sprite;
                Image createButtonImage = fishUI.transform.FindChild("CreateButton").GetComponent<Image>();
                Image deleteButtonImage = fishUI.transform.FindChild("DeleteButton").GetComponent<Image>();
                createButtonImage.sprite = spritePlus;
                deleteButtonImage.sprite = spriteMinus;

                //OnClickイベントの作成
                BiologicalManager _manager = GetComponent<BiologicalManager>();
                Button createButton = fishUI.transform.FindChild("CreateButton").GetComponent<Button>();
                createButton.onClick.AddListener(() => _manager.FishCreate(FISH_NAME[id_check_number]));
                Button deleteButton = fishUI.transform.FindChild("DeleteButton").GetComponent<Button>();
                deleteButton.onClick.AddListener(() => _manager.FishDelete(FISH_NAME[id_check_number]));
            }
            else
            {
                //UI画像の参照
                Sprite spritePlus = Resources.Load("Image/Leaf/" + FISH_NAME[id_check_number], typeof(Sprite)) as Sprite;
                Image createButtonImage = fishUI.transform.FindChild("CreateButton").GetComponent<Image>();
                createButtonImage.sprite = spritePlus;

                //OnClickイベントの作成
                BiologicalManager _manager = GetComponent<BiologicalManager>();
                Button createButton = fishUI.transform.FindChild("CreateButton").GetComponent<Button>();
                createButton.onClick.AddListener(() => _manager.FishCreate(FISH_NAME[id_check_number]));
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
                CreateUI(0, 1, true);
                break;
            case 1:
                CreateUI(1, 1, true);
                break;
            case 2:
                CreateUI(2, 2, true);
                break;
            case 3:
                CreateUI(4, 1, true);
                break;
            case 4:
                CreateUI(5, 1, true);
                break;
            case 5:
                CreateUI(6, 4, false);
                break;
            case 6:
                CreateUI(10, 2, false);
                break;
        }
    }

    private void Start()
    {
        SetDropDown();
    }
}
