using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    public Collider2D coll;
    public float speed;
    public float jumpforce;
  //public float downforce;
    public LayerMask ground;
    public int Cherry;
    public Text CherryNum;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
        SwitchAnim();
    }

    void Movement()
    {
        float horizontalmove = Input.GetAxis("Horizontal");
        float facedirection = Input.GetAxisRaw("Horizontal");
       
       //角色移动
        if(horizontalmove !=0)
        {
            rb.velocity = new Vector2(horizontalmove * speed * Time.deltaTime, rb.velocity.y);
            anim.SetFloat("running", Mathf.Abs(horizontalmove));
        }

        if(facedirection !=0)
        {
            transform.localScale = new Vector3(facedirection,1,1);
        }

        //角色跳跃
        if(Input.GetButtonDown("Jump") && coll.IsTouchingLayers(ground))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce * 1);
            anim.SetBool("jumping",true);

        }

        //角色下蹲
        /*if(Input.GetButtonDown("Down") && coll.IsTouchingLayers(ground))
        {
            rb.velocity = new Vector2(rb.velocity.x, downforce * 1);
            anim.SetBool("downing",true);

        }*/

    }
    //切换动画
    void SwitchAnim()
    {
        if(anim.GetBool("jumping"))
        {
            if(rb.velocity.y<0)
            {
                anim.SetBool("jumping", false);
                anim.SetBool("falling", true);
            }
        }else if(coll.IsTouchingLayers(ground))
        {
            anim.SetBool("falling",false);
            anim.SetBool("idle",true);
        }
    }

    //收集
     private void OnTriggerEnter2D(Collider2D collision) 
    {
         if(collision.tag == "Collection")
         {
             Destroy(collision.gameObject);
             Cherry += 1;
             CherryNum.text = Cherry.ToString();
         } 
    }

    //消灭敌人
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.tag == "Enemy") 
        {
            //Destroy(Collision);
        }

        //死亡机关
        if(collision.gameObject.tag == "DeadJiGuan") 
        {
            //Destroy(Collision.tag == "Player");
        }

    }

   
    

    }


