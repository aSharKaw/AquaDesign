using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//カメラ移動用スクリプト
public class CameraMove : MonoBehaviour {
	
	void Update ()
    {
		if(Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.transform.RotateAround(Vector3.zero, Vector3.up, 20 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.transform.RotateAround(Vector3.zero, Vector3.down, 20 * Time.deltaTime);
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
