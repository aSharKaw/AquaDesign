using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiologicalManager : MonoBehaviour {

    //外部ファイル読み込むまでの代理参照
    [SerializeField]
    private GameObject NeonTetra;
    [SerializeField]
    private GameObject Leaf;
    [SerializeField]
    private GameObject Anubias;

    private int _fish_count;

	void Start ()
    {
	    if(NeonTetra == null)
        {
            NeonTetra = Resources.Load("Prefub/NeonTetra") as GameObject;
        }
        if (Leaf == null)
        {
            Leaf = Resources.Load("Prefub/Leaf") as GameObject;
        }
        if (Anubias == null)
        {
            Anubias = Resources.Load("Prefub/Anubias") as GameObject;
        }

        _fish_count = 0;
    }
	
    public void FishCreate()
    {
        GameObject _fish;
        _fish = Instantiate(NeonTetra);
        _fish.name = "NeonTetra" + _fish_count;
        _fish_count++;
    }

    public void FishDelete()
    {
        _fish_count--;
        GameObject _fish = GameObject.Find("NeonTetra" + _fish_count);
        Destroy(_fish);
    }

	void Update ()
    {
        
	}
}
