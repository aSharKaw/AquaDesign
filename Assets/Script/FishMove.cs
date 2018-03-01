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

    private Vector3 SetPosition ( )
    {
        GameObject water_pot = GameObject.Find( "WaterPot" );
        GameObject _water = water_pot.transform.FindChild( "Water" ).gameObject;
        var localScale = _water.transform.localScale;
        var ranX = Random.Range( -1.0f, 1.0f );
        var ranY = Random.Range( -1.0f, 1.0f );
        var ranZ = Random.Range( -1.0f, 1.0f );
        var x = ranX * localScale.x / 2;
        var y = ranY * localScale.y / 2;
        var z = ranZ * localScale.z / 2;
        var y2 = ( _water.transform.localScale.y / -2 ) + gameObject.transform.FindChild( "body" ).gameObject.transform.localScale.y;

        return new Vector3( x, ( !ground ) ? y : y2, z );
    }

    void Start ( )
    {
        _swim_flug = false;
        _count = 0;
        _wait_count = 0;

        _target_position = SetPosition();
        _child = transform.FindChild( "body" ).gameObject;

        //サイズが小さいため移動速度を調整
        move_speed = move_speed / 1000;

        if (nonAnimation)
        {
            _child.AddComponent<Animator>();
        }
        _anima = _child.GetComponent<Animator>();


    }

    private void OnTriggerExit ( Collider other )
    {
        if (other.name == "Water")
        {

            _target_position = SetPosition();
        }
    }

    private void OnTriggerEnter ( Collider other )
    {
        if (other.name == "FishTank" || other.name == "Floor")
        {

            //move_speed = -move_speed;
            _target_position = SetPosition();
        }
    }

    void Update ( )
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
                return;
            }
            swim( _target_position );
            if (!swim( _target_position ))
            {
                _swim_flug = false;
            }
            return;
        }


        if (!_swim_flug)
        {
            nonMotion_idle();
            _target_position = SetPosition();

            if (!nonMotion_idle())
            {
                _swim_flug = true;
            }
            return;
        }
        nonMotion_swim( _target_position );
        if (!nonMotion_swim( _target_position ))
        {
            _swim_flug = false;
        }
    }

    //アイドル時
    bool idle ( )
    {
        if (_count == 0)
        {
            _wait_count = ( int )Random.Range( 1.0f, 4.0f );
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
    bool swim ( Vector3 target_position )
    {
        if (target_position == Vector3.MoveTowards( this.transform.position, target_position, move_speed ))
        {
            _anima.SetBool( "swimming", false );
            return false;
        }

        this.transform.position = Vector3.MoveTowards( this.transform.position, target_position, move_speed );
        this.transform.LookAt( target_position );
        _anima.SetBool( "swimming", true );
        return true;
    }

    //アニメーションが無いテクスチャ
    //アイドル時
    bool nonMotion_idle ( )
    {
        if (_count == 0)
        {
            _wait_count = ( int )Random.Range( 1.0f, 4.0f );
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
    bool nonMotion_swim ( Vector3 target_position )
    {
        if (target_position == Vector3.MoveTowards( this.transform.position, target_position, move_speed ))
        {
            return false;
        }

        this.transform.position = Vector3.MoveTowards( this.transform.position, target_position, move_speed );
        this.transform.LookAt( target_position );
        return true;
    }

}
