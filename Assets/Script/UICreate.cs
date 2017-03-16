using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICreate : MonoBehaviour {

    //[SerializeField]
    private GameObject _fishUI;
    private BiologicalManager _manager;

    private string[] ID =
    {
        "NeonTetra",//ネオンテトラ
        "TigerOscar",//タイガーオスカー
        "Amazonicus",//アマゾンソード
        "Anubias",//アヌビスナナ
        "Cabomba",//カボンバ
        "MicroSorum",//ミクロソリウム
        "HighHill",//苔石(高)
        "LowHill"//苔石(低)
    };

    //enum ID
    //{
    //    NeonTetra = 0,
    //    TigerOscar,
    //    Amazonicus,
    //    Anubias,
    //    Cabomba,
    //    MicroSorum,
    //    HighHill,
    //    LowHill

    //}

    void Awake()
    {
        _fishUI = Resources.Load("Prefub/FishUI") as GameObject;
    }

    //UIの作成
    void CreateUI(string id)
    {
        //必要オブジェクトの参照と生成
        GameObject canvas = GameObject.Find("Canvas");
        GameObject fishUI;
        Vector2 position = new Vector2(868, 380);

        fishUI = Instantiate(_fishUI, position, Quaternion.identity, canvas.transform);
        fishUI.name = "FishUI";

        //UI画像の参照
        Sprite spritePlus = Resources.Load("Image/UI/" + id + "Plus", typeof(Sprite)) as Sprite;
        Sprite spriteMinus = Resources.Load("Image/UI/" + id + "Minus", typeof(Sprite)) as Sprite;
        Image createButtonImage = fishUI.transform.FindChild("CreateButton").GetComponent<Image>();
        Image deleteButtonImage = fishUI.transform.FindChild("DeleteButton").GetComponent<Image>();
        createButtonImage.sprite = spritePlus;
        deleteButtonImage.sprite = spriteMinus;

        //OnClickイベントの作成
        BiologicalManager _manager = GetComponent<BiologicalManager>();
        Button createButton = fishUI.transform.FindChild("CreateButton").GetComponent<Button>();
        createButton.onClick.AddListener(() => _manager.FishCreate(id));
        Button deleteButton = fishUI.transform.FindChild("DeleteButton").GetComponent<Button>();
        deleteButton.onClick.AddListener(() => _manager.FishDelete(id));
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

    void TempCreateUI(string id)
    {
        //必要オブジェクトの参照と生成
        GameObject canvas = GameObject.Find("Canvas");
        GameObject LeafUI;
        Vector2 position = new Vector2(868, 380);

        LeafUI = Instantiate(_fishUI, position, Quaternion.identity, canvas.transform);
        LeafUI.name = "FishUI";

        //UI画像の参照
        Sprite spritePlus = Resources.Load("Image/Leaf/" + id, typeof(Sprite)) as Sprite;
        Image createButtonImage = LeafUI.transform.FindChild("CreateButton").GetComponent<Image>();
        createButtonImage.sprite = spritePlus;
        
        //OnClickイベントの作成
        BiologicalManager _manager = GetComponent<BiologicalManager>();
        Button createButton = LeafUI.transform.FindChild("CreateButton").GetComponent<Button>();
        createButton.onClick.AddListener(() => _manager.FishCreate(id));
     }

    public void SetUI(int value)
    {
        DeleteUI();
        if(value <= 1)
        {
            CreateUI(ID[value]);
        }
        else
        {
            TempCreateUI(ID[value]);
        }
    }
}
