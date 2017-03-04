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
    [SerializeField]
    private GameObject TigerOscar;

    private int _neonTetra_count;
    private int _tigerOscar_count;

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
        if (TigerOscar == null)
        {
            TigerOscar = Resources.Load("Prefub/TigerOscar") as GameObject;
        }

        _neonTetra_count = 0;
        _tigerOscar_count = 0;
    }
	
    public void NeonTetraCreate()
    {
        GameObject _fish;
        _fish = Instantiate(NeonTetra);
        _fish.name = "NeonTetra" + _neonTetra_count;
        _neonTetra_count++;
    }

    public void NeonTetraDelete()
    {
        _neonTetra_count--;
        GameObject _fish = GameObject.Find("NeonTetra" + _neonTetra_count);
        Destroy(_fish);
    }

    public void TigerOscarCreate()
    {
        GameObject _fish;
        _fish = Instantiate(TigerOscar);
        _fish.name = "TigerOscar" + _tigerOscar_count;
        _tigerOscar_count++;
    }

    public void TigerOscarDelete()
    {
        _tigerOscar_count--;
        GameObject _fish = GameObject.Find("TigerOscar" + _neonTetra_count);
        Destroy(_fish);
    }

    void Update ()
    {
        
	}
}
