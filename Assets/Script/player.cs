using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class player : MonoBehaviour
{
    Rigidbody2D playerRigidbody2D;
    public Collider2D coll;
 
    public AudioClip audioClip;
    private AudioSource _audioSource;
    public int s; //宣告分數變數
    public Text stext,final; //宣告分數欄文字變數
    public float WaitTime = 3;
    private bool isHurt;//默認為false
    private Animator animator;





    [Header("目前的水平速度")]
    int key =0;
    public float speedX;
    [Header("目前的水平方向")]
    public float horizontalDirection;//數值會在-1~1之間
    const string HORIZONTAL = "Horizontal";
    
    [Header("水平推力")]
    [Range(0,150)]
    public float xForce;

    //目前垂直速度
     float speedY;

     [Header("最大水平速度")]
     public float maxSpeedX;
     
     public void ControlSpeed()
      { 
        speedX = playerRigidbody2D.velocity.x;
       speedY = playerRigidbody2D.velocity.y;
       float newSpeedX=Mathf.Clamp(speedX, -maxSpeedX, maxSpeedX);
       playerRigidbody2D.velocity = new Vector2(newSpeedX,speedY);
      }
     [Header("垂直向上推力")]
       public float yForce;
       void TryJump()
       {
         if (Input.GetKeyDown(KeyCode.Space)&&coll.IsTouchingLayers(groundLayer))
         {
           playerRigidbody2D.velocity = new Vector2(playerRigidbody2D.velocity.x, yForce);
           Debug.Log("jump");
           animator.SetBool("jumping",true);
         }
         else if (Input.GetKeyDown(KeyCode.Space)&&animator.GetBool("jumping")==true)
         {
           playerRigidbody2D.velocity = new Vector2(playerRigidbody2D.velocity.x,yForce*1);
           animator.SetBool("Double",true);
           animator.SetBool("jumping",false);
         }
         else
         {
           animator.SetBool("Double",false);
           
         }
       
       }
       //切換動畫
       void switchAni()
       {
         animator.SetBool("idle",false);
         
         if (animator.GetBool("jumping")&& !coll.IsTouchingLayers(groundLayer))
         {
           if ((playerRigidbody2D.velocity.y<0))
           {
             animator.SetBool("falling",true);
             animator.SetBool("jumping",false);
             animator.SetBool("Double",false);
           }
         }
         else if (isHurt)
         {
           animator.SetBool("hit",true); 
           
           if(Mathf.Abs(playerRigidbody2D.velocity.x)<0.1)
           {
             isHurt = false;
             animator.SetBool("hit",false);
             animator.SetBool("idle", true);
           }
         }
         else if (coll.IsTouchingLayers(groundLayer))
         {
           animator.SetBool("falling", false);
           animator.SetBool("idle", true);
         }
        
       }
        //在玩家的底部設一條很短的射線 如果射線有打到地板圖層的話 表示正踩著地板
         bool IsGround 
         {
           get 
           {
             Vector2 start = groundCheck.position;
             Vector2 end =new Vector2(start.x, start.y - distance);

             Debug.DrawLine(start,end, Color.blue);
             grounded = Physics2D.Linecast(start,end, groundLayer);
             return grounded;
           }
         }
         [Header("感應地板的距離")]
         [Range(0,0.5f)]
         public float distance;
         [Header("偵測地板的射線起點")]
         public Transform groundCheck;
         [Header("地面圖層")]
         public LayerMask groundLayer;
         public bool grounded;

    void Awake()
    {
           _audioSource = this.gameObject.AddComponent<AudioSource>();
           _audioSource.clip = audioClip;
           
    }

    // Start is called before the first frame update
    void Start()
    { 
      playerRigidbody2D =GetComponent<Rigidbody2D>();
      animator = GetComponent<Animator>();
     
    }
    
    /// <summary>水平移動</summary>
    void MovementX ()
    {
        horizontalDirection = Input.GetAxis(HORIZONTAL);
        playerRigidbody2D.AddForce(new Vector2(xForce*horizontalDirection,0));
        animator.SetFloat("running",Mathf.Abs(horizontalDirection));
    }

    // Update is called once per frame
    void Update()
    {
      if (!isHurt)
      {
        MovementX ();
      }
      ControlSpeed();
       TryJump();
       switchAni();
       speedX=playerRigidbody2D.velocity.x;
       //面相
      if(key != 0)
      { 
        transform.localScale = new Vector3(key,3,3);
      }
      if(Input.GetKey(KeyCode.RightArrow)) key= 3 ;
      if(Input.GetKey(KeyCode.LeftArrow)) key= -3 ;
      //跑出畫面就回初始畫面
    if(transform.position.y < -10)
    {
      SceneManager.LoadScene("game");
    }
    
    }
    //水果分數
    void OnTriggerEnter2D(Collider2D Coll)
    {
      Debug.Log("Trigger - 碰到:"+ Coll.gameObject.name) ;
      //印出Trigger -觸發:碰撞物件的名字
     
      if (Coll.gameObject.tag =="B1")
      { 
        Destroy(Coll.gameObject);
        s += 1;
        Debug.Log(s);
        _audioSource.Play();
        stext.text = s.ToString(); // 將數值轉換成字串
        final.text = s.ToString();
      }
      if (Coll.gameObject.tag =="A2")
      { 
        Destroy(Coll.gameObject);
        s += 2;
        Debug.Log(s);
        _audioSource.Play();
        stext.text = s.ToString(); // 將數值轉換成字串
        final.text = s.ToString();
      }
      if (Coll.gameObject.tag =="KO3")
      { 
        Destroy(Coll.gameObject);
        s += 3;
        Debug.Log(s);
        _audioSource.Play();
        stext.text = s.ToString(); // 將數值轉換成字串
        final.text = s.ToString();
      }
      if (Coll.gameObject.tag =="P4")
      { 
        Destroy(Coll.gameObject);
        s += 4;
        Debug.Log(s);
        _audioSource.Play();
        stext.text = s.ToString(); // 將數值轉換成字串
        final.text = s.ToString();
      }
      if (Coll.gameObject.tag =="M5")
      { 
        Destroy(Coll.gameObject);
        s += 5;
        Debug.Log(s);
        _audioSource.Play();
        stext.text = s.ToString(); // 將數值轉換成字串
        final.text = s.ToString();
      }
    }
    //撞到敵人
    private void OnCollisionEnter2D(Collision2D collision2D)
    {
      if (collision2D.gameObject.tag == "Enemy" )
      {
        if (animator.GetBool("falling"))
        {
          Destroy(collision2D.gameObject);
          animator.SetBool("jumping",true);
        }
        else if (transform.position.x < collision2D.gameObject.transform.position.x)
        {
          playerRigidbody2D.velocity = new Vector2(-10, playerRigidbody2D.transform.position.y);
          isHurt = true;
        }
        else if(transform.position.x > collision2D.gameObject.transform.position.x)
        {
          animator.SetBool("hit",true);
          playerRigidbody2D.velocity = new Vector2( 10, playerRigidbody2D.transform.position.y);
          isHurt = true;
        }
        else 
        {
          animator.SetBool("hit",false);
        }
      }
    }
}




    
     


    


