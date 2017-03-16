using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//カメラ移動用スクリプト
public class CameraMove : MonoBehaviour
{
    private Vector3 DEFAULT_POS = new Vector3(0, 0, 0.7f);

    //移動速度
    private float _move_speed;

    //ボタン長押し判定
    private bool up_button;
    private bool down_button;
    private bool left_button;
    private bool right_button;

    void Start()
    {
        _move_speed = 0.5f * Time.deltaTime;
    }

    public void UpButtonPush()
    {
        up_button = true;
    }
    public void UpButtonRelease()
    {
        up_button = false;
    }

    public void DownButtonPush()
    {
        down_button = true;
    }
    public void DownButtonRelease()
    {
        down_button = false;
    }

    public void LeftButtonPush()
    {
        left_button = true;
    }
    public void LeftButtonRelease()
    {
        left_button = false;
    }

    public void RightButtonPush()
    {
        right_button = true;
    }
    public void RightButtonRelease()
    {
        right_button = false;
    }

    public void ResetButton()
    {
        gameObject.transform.position = DEFAULT_POS;
        gameObject.transform.LookAt(Vector3.zero);
    }

    private void Update()
    {
        if(up_button)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(transform.position.x, 0.2f, 0.6f), _move_speed);
        }
        else if (down_button)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(transform.position.x, 0, 0.7f), _move_speed);
        }
        else if(left_button)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(0.35f, transform.position.y, 0.6f), _move_speed);
        }
        else if(right_button)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(-0.35f, transform.position.y, 0.6f), _move_speed);
        }
        gameObject.transform.LookAt(Vector3.zero);
    }
}
