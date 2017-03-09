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
<<<<<<< HEAD
<<<<<<< HEAD
		if(Input.GetKey(KeyCode.LeftArrow) && count < 0.5f * 60)
        {
            gameObject.transform.RotateAround(Vector3.zero, Vector3.up, 1);
            count++;
        }
        if (Input.GetKey(KeyCode.RightArrow) && count > -0.5f * 60)
        {
            gameObject.transform.RotateAround(Vector3.zero, Vector3.down, 1);
=======
		if(Input.GetKey(KeyCode.LeftArrow) && count < 2 * 45)
=======
		if(Input.GetKey(KeyCode.LeftArrow) && count < 0.5f * 60)
>>>>>>> 1273a02f36410d686f8ae0e274ad16750704c987
        {
            gameObject.transform.RotateAround(Vector3.zero, Vector3.up, 1);
            count++;
        }
        if (Input.GetKey(KeyCode.RightArrow) && count > -0.5f * 60)
        {
<<<<<<< HEAD
            gameObject.transform.RotateAround(Vector3.zero, Vector3.down, 20 * Time.deltaTime);
>>>>>>> 747f9e808c0244cd8de86cb043a057a8716cac94
=======
            gameObject.transform.RotateAround(Vector3.zero, Vector3.down, 1);
>>>>>>> 1273a02f36410d686f8ae0e274ad16750704c987
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
