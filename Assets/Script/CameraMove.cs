using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//カメラ移動用スクリプト
public class CameraMove : MonoBehaviour {

    private int count;

    void Start()
    {
        count = 0;
    }

	void Update ()
    {
		if(Input.GetKey(KeyCode.LeftArrow) && count < 2 * 45)
        {
            gameObject.transform.RotateAround(Vector3.zero, Vector3.up, 20 * Time.deltaTime);
            count++;
        }
        if (Input.GetKey(KeyCode.RightArrow) && count > -2 * 45)
        {
            gameObject.transform.RotateAround(Vector3.zero, Vector3.down, 20 * Time.deltaTime);
            count--;
        }

        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    gameObject.transform.RotateAround(Vector3.zero, Vector3.forward, 20 * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    gameObject.transform.RotateAround(Vector3.zero, Vector3.back, 20 * Time.deltaTime);
        //}

    }
}
