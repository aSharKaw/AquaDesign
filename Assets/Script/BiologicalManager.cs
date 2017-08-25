using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiologicalManager : MonoBehaviour {

    //テスト
    //[System.NonSerialized]
    private string _fish_name;

    private int _fish_count;

    private GameObject _water;

    //AssetBundle assetBundle;

	void Start ()
    {
        GameObject water_pot = GameObject.Find("WaterPot");
        _water = water_pot.transform.FindChild("Water").gameObject;
        //assetBundle = AssetBundle.LoadFromFile("Assets/AssetBundles/resources");
    }

    public void ObjectCreate(string Type, string fish_name)
    {
        _fish_count++;
        Vector3 instant_pos = new Vector3(Random.Range(_water.transform.localScale.x / -2.0f, _water.transform.localScale.x / 2.0f), Random.Range(_water.transform.localScale.y / -2.0f, _water.transform.localScale.y / 2.0f), 0);

        //GameObject _fish = assetBundle.LoadAsset<GameObject>(fish_name);
        GameObject Object = Resources.Load("Prefub/" + Type + "/" + fish_name) as GameObject;
        Object = Instantiate(Object, instant_pos, Quaternion.Euler(new Vector3(0, 90, 0)));
        Object.name = fish_name + _fish_count;     
    }

    public void ObjectDelete(string fish_name)
    {
        if(_fish_count > 0)
        {
            int temp_count = _fish_count;
            GameObject Object = GameObject.Find(fish_name + temp_count);
            while (Object == null)
            {
                temp_count--;
                Object = GameObject.Find(fish_name + temp_count);
                if (temp_count < 0)
                {
                    break;
                }
            }
            //fish_count--;
            Destroy(Object);
        }
    }

    void Update ()
    {
        
	}
}
