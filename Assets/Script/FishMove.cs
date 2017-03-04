using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//魚移動用スクリプト
public class FishMove : MonoBehaviour {

    private Vector3 _target_position;
    private bool _swim_flug;
    private int _count;
    private int _wait_count;
    private float move_speed;

    private GameObject _child;
    private Animator _anima;

	void Start ()
    {
        _swim_flug = false;
        _count = 0;
        _wait_count = 0;

        move_speed = 0.002f;

        _target_position = new Vector3(Random.Range(-0.25f, 0.25f), Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f));
        _child = transform.FindChild("body").gameObject;

        _anima = _child.GetComponent<Animator>();
    }
	
	void Update ()
    {
        if(!_swim_flug)
        {
            idle();
            _target_position = new Vector3(Random.Range(-0.25f, 0.25f), Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f));
            if (!idle())
            {
                _swim_flug = true;
            }
        }
        else if (_swim_flug)
        {
            swim(_target_position);
            if (!swim(_target_position))
            {
                _swim_flug = false;
            }
        }
    }

    //アイドル時
    bool idle()
    {
        if (_count == 0)
        {
            _wait_count = (int)Random.Range(1.0f, 4.0f);
        }
        if (_count > _wait_count * 60)
        {
            _count = 0;
            _wait_count = 0;
            return false;
        }

        _count++;
        return true;
    }

    //移動時
    bool swim(Vector3 target_position)
    {
        if(target_position == Vector3.MoveTowards(this.transform.position, target_position, move_speed))
        {
            _anima.SetBool("swimming", false);
            return false;
        }

        this.transform.position = Vector3.MoveTowards(this.transform.position, target_position, move_speed);
        this.transform.LookAt(target_position);
        _anima.SetBool("swimming", true);
        return true;
    }


}
