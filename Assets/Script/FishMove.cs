using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//魚移動用スクリプト
public class FishMove : MonoBehaviour
{

    private Vector3 _target_position;
    private bool _swim_flug;
    private int _count;
    private int _wait_count;
    [SerializeField]
    private float move_speed;

    private GameObject _child;
    private Animator _anima;

    [SerializeField]
    private bool nonAnimation;
    [SerializeField]
    private bool ground;

    private Vector3 SetPosition()
    {
        GameObject water_pot = GameObject.Find("WaterPot");
        GameObject _water = water_pot.transform.FindChild("Water").gameObject;
        if(!ground)
        {
            return new Vector3(Random.Range(_water.transform.localScale.x / -2, _water.transform.localScale.x / 2), Random.Range(_water.transform.localScale.y / -2, _water.transform.localScale.y / 2), Random.Range(_water.transform.localScale.z / -2, _water.transform.localScale.z / 2));
        }
        else
        {
            return new Vector3(Random.Range(_water.transform.localScale.x / -2, _water.transform.localScale.x / 2), (_water.transform.localScale.y / -2) + gameObject.transform.FindChild("body").gameObject.transform.localScale.y, Random.Range(_water.transform.localScale.z / -2, _water.transform.localScale.z / 2));
        }
    }

    void Start()
    {
        _swim_flug = false;
        _count = 0;
        _wait_count = 0;

        _target_position = SetPosition();
        _child = transform.FindChild("body").gameObject;

        //サイズが小さいため移動速度を調整
        move_speed = move_speed / 1000;

        if (!nonAnimation)
        {
            _anima = _child.GetComponent<Animator>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Water")
        {

            _target_position = SetPosition();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "FishTank" || other.name == "Floor")
        {

            //move_speed = -move_speed;
            _target_position = SetPosition();
        }
    }

    void Update()
    {
        if (!nonAnimation)
        {

            if (!_swim_flug)
            {
                idle();
                _target_position = SetPosition();
       
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
        else if (nonAnimation)
        {

            if (!_swim_flug)
            {
                nonMotion_idle();
                _target_position = SetPosition();

                if (!nonMotion_idle())
                {
                    _swim_flug = true;
                }
            }
            else if (_swim_flug)
            {
                nonMotion_swim(_target_position);
                if (!nonMotion_swim(_target_position))
                {
                    _swim_flug = false;
                }
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
        if (target_position == Vector3.MoveTowards(this.transform.position, target_position, move_speed))
        {
            _anima.SetBool("swimming", false);
            return false;
        }

        this.transform.position = Vector3.MoveTowards(this.transform.position, target_position, move_speed);
        this.transform.LookAt(target_position);
        _anima.SetBool("swimming", true);
        return true;
    }

    //アニメーションが無いテクスチャ
    //アイドル時
    bool nonMotion_idle()
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
    bool nonMotion_swim(Vector3 target_position)
    {
        if (target_position == Vector3.MoveTowards(this.transform.position, target_position, move_speed))
        {
            return false;
        }

        this.transform.position = Vector3.MoveTowards(this.transform.position, target_position, move_speed);
        this.transform.LookAt(target_position);
        return true;
    }

}
