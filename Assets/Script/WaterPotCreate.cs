using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterPotCreate : MonoBehaviour {

    [SerializeField]
    GameObject _waterpot60;
    [SerializeField]
    GameObject _waterpotcube;
    [SerializeField]
    GameObject _waterpotsphere;
    [SerializeField]
    GameObject _waterpothalfsphere;

    void Start () {
    }

	void Update () {
	}

    public void CreatePot60()
    {
        GameObject waterpot = GameObject.Find("WaterPot");
        Destroy(waterpot);

        GameObject createPot = Instantiate(_waterpot60);
        createPot.name = "WaterPot";
    }

    public void CreatePotCube()
    {
        GameObject waterpot = GameObject.Find("WaterPot");
        Destroy(waterpot);

        GameObject createPot = Instantiate(_waterpotcube);
        createPot.name = "WaterPot";
    }

    public void CreatePotSphere()
    {
        GameObject waterpot = GameObject.Find("WaterPot");
        Destroy(waterpot);

        GameObject createPot = Instantiate(_waterpotsphere);
        createPot.name = "WaterPot";
    }

    public void CreatePotHalfSphere()
    {
        GameObject waterpot = GameObject.Find("WaterPot");
        Destroy(waterpot);

        GameObject createPot = Instantiate(_waterpothalfsphere);
        createPot.name = "WaterPot";
    }
}
