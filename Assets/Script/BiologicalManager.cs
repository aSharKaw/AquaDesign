using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiologicalManager : MonoBehaviour {

    //テスト
    //[System.NonSerialized]
    private string _fish_name;

    private int _fish_count;

    private int _neonTetra_count;
    //private int _tigerOscar_count;

    //AssetBundle assetBundle;

	void Start ()
    {
        //assetBundle = AssetBundle.LoadFromFile("Assets/AssetBundles/resources");
        _neonTetra_count = 0;
        //_tigerOscar_count = 0;
    }

    public void FishCreate(string fish_name)
    {
        //GameObject _fish = assetBundle.LoadAsset<GameObject>(fish_name);
        GameObject _fish = Resources.Load("Prefub/" + fish_name) as GameObject;
        _fish = Instantiate(_fish);
        _fish.name = fish_name + _fish_count;
        _fish_count++;
    }

    public void NeonTetraDelete()
    {
        _neonTetra_count--;
        GameObject _fish = GameObject.Find("NeonTetra" + _neonTetra_count);
        Destroy(_fish);
    }

    void Update ()
    {
        
	}
}
