using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICreate : MonoBehaviour {

    //[SerializeField]
    private GameObject _fishUI;
    private BiologicalManager _manager;

    void Awake()
    {
        _fishUI = Resources.Load("Prefub/FishUI") as GameObject;
    }

    //UIの作成
    void Create(string id, string fish_name, Vector2 position)
    {
        //必要オブジェクトの参照と生成
        GameObject canvas = GameObject.Find("Canvas");
        GameObject fishUI;
        fishUI = Instantiate(_fishUI, position, Quaternion.identity, canvas.transform);

        //UI内のテキストの変更
        fishUI.transform.FindChild("FishName").GetComponent<Text>().text = fish_name.ToString();

        //UI画像の参照
        Sprite sprite = Resources.Load("Image/Fish/" + id, typeof(Sprite)) as Sprite;
        Image fishImage = fishUI.transform.FindChild("FishImage").GetComponent<Image>();
        fishImage.sprite = sprite;

        //OnClickイベントの作成
        BiologicalManager _manager = GetComponent<BiologicalManager>();
        Button createButton = fishUI.transform.FindChild("CreateButton").GetComponent<Button>();
        createButton.onClick.AddListener(() => _manager.FishCreate(id));
        Button deleteButton = fishUI.transform.FindChild("DeleteButton").GetComponent<Button>();
        deleteButton.onClick.AddListener(_manager.NeonTetraDelete);
    }

    void Start () {
        Create("NeonTetra", "ネオンテトラ", new Vector2(730, 350));
        Create("TigerOscar", "タイガーオスカー", new Vector2(730, 230));
    }
    
}
