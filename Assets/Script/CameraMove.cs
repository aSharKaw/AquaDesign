using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//カメラ移動用スクリプト
public class CameraMove : MonoBehaviour {

    private int side_count;
    private int length_count;

    void Start()
    {
        side_count = 0;
        length_count = 0;
    }

	void Update ()
    {
		if(Input.GetKey(KeyCode.LeftArrow) && side_count < 0.5f * 60)
        {
            gameObject.transform.RotateAround(Vector3.zero, Vector3.up, 1);
            side_count++;
        }
        if (Input.GetKey(KeyCode.RightArrow) && side_count > -0.5f * 60)
        {
            gameObject.transform.RotateAround(Vector3.zero, Vector3.down, 1);
            side_count--;
        }

        if (Input.GetKey(KeyCode.UpArrow) && length_count < 0.5f * 60)
        {
            gameObject.transform.RotateAround(Vector3.zero, Vector3.left, 20 * Time.deltaTime);
            length_count++;
        }
        if (Input.GetKey(KeyCode.DownArrow) && length_count > -0.0f * 60)
        {
            gameObject.transform.RotateAround(Vector3.zero, Vector3.right, 20 * Time.deltaTime);
            length_count--;
        }

    }
}
