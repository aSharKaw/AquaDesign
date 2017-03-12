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
        _fish_count++;
        //GameObject _fish = assetBundle.LoadAsset<GameObject>(fish_name);
        GameObject _fish = Resources.Load("Prefub/" + fish_name) as GameObject;
        _fish = Instantiate(_fish, new Vector3(Random.Range(0, 0), Random.Range(0, 0), 0), Quaternion.Euler(new Vector3(0, 90, 0)));
        _fish.name = fish_name + _fish_count;     
    }

    public void FishDelete(string fish_name)
    {
        if(_fish_count > 0)
        {
            int temp_count = _fish_count;
            GameObject _fish = GameObject.Find(fish_name + _fish_count);
            while (_fish != null)
            {
                temp_count--;
                _fish = GameObject.Find(fish_name + _fish_count);
                if (temp_count < 0)
                {
                    break;
                }
            }
            _fish_count--;
            Destroy(_fish);
        }
    }

    void Update ()
    {
        
	}
}
