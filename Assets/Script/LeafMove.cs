using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//水草ビルボードスクリプト
public class LeafMove : MonoBehaviour {

    [SerializeField]
    private Camera target_camera;

	void Start ()
    {
		if(this.target_camera == null)
        {
            target_camera = Camera.main;
        }
	}
	

	void Update ()
    {
        //X軸は維持したままカメラの方を向く
        Vector3 target = this.target_camera.transform.position;
        target.y = this.transform.position.y;
        this.transform.LookAt(target);
    }
}
