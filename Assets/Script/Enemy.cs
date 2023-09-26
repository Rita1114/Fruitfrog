using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D Enemyrb;
    private Animator _animator;

    public Transform  leftpoint,rightpoint;
    private bool face = true;//往右邊走
    private float leftX, rightX;

    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        Enemyrb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
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
    }

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
}
