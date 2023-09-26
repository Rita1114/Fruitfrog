using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D Enemyrb;
    private Animator _animator;
    private Collider2D coll;
    public Transform  leftpoint,rightpoint;
    private bool face = true;//往右邊走
    private float leftX, rightX;
    public LayerMask Ground;

    public float speed = 5;
    public float JumpForce = 5;
    // Start is called before the first frame update
    void Start()
    {
        Enemyrb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        transform.DetachChildren();
        leftX = leftpoint.position.x;
        rightX = rightpoint.position.x;
        Destroy(leftpoint.gameObject);
        Destroy(rightpoint.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
        EnmeyJump();
    }

    //走路動畫(來回)
    void EnemyMove()
    {
        if (face)
        { 
            _animator.SetBool("run",true);
            Enemyrb.velocity = new Vector2(speed, Enemyrb.velocity.y);
            if (Enemyrb.transform.position.x > rightX)
            {
                transform.localScale = new Vector3(-3, 3, 3);
                face = false;
            }
        }
        else
        {
            Enemyrb.velocity = new Vector2(-speed, Enemyrb.velocity.y);
            if (Enemyrb.transform.position.x < leftX)
            {
                transform.localScale = new Vector3(3, 3, 3);
                face = true;
            }
        }
    }

    void EnmeyJump()
    {
        if (coll.IsTouchingLayers(Ground))
        {
            Enemyrb.velocity = new Vector2(speed, JumpForce);
            _animator.SetBool("jump",true);
        }
        //右
        if (_animator.GetBool("jump"))
        {
            if(Enemyrb.velocity.y<0)
            {
                _animator.SetBool("fall",true);
                _animator.SetBool("jump",false);
            }
            if (coll.IsTouchingLayers(Ground))
            {
                _animator.SetBool("fall",false);
                _animator.SetBool("run",true);
            }
        }
        //左
        if (coll.IsTouchingLayers(Ground))
        {
            Enemyrb.velocity = new Vector2(-speed, JumpForce);
            _animator.SetBool("jump",true);
        }

        if (_animator.GetBool("jump"))
        {
            if (Enemyrb.velocity.y < 0)
            {
                _animator.SetBool("fall", true);
                _animator.SetBool("jump", false);
            }

            if (coll.IsTouchingLayers(Ground))
            {
                _animator.SetBool("fall", false);
                _animator.SetBool("run", true);
            }
        }

    }
}
