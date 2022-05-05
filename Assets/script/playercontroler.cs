using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class playercontroler : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public float speed;
    public float jumpforce;
    public LayerMask ground;
    public Collider2D coll;
    public Transform GroundCheck;
    private bool isGround;
    private int extraJump;
   // public int damage;

    //public Transform  GroundCheck;
    //private bool isGround;
    //private int extraJump;
    // Start is called before the first frame update
    void Start()
    {

    }

    void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(GroundCheck.position, 0.2f, ground);
        SwitchAnim();
    }




    // Update is called once per frame
    void Update()
    {
       // Attack();
        Movement();
       
        
        newJump();

    }

    /* void Attack()
     {
         if (Input.GetButtonDown("Attack"))
         {
             anim.SetTrigger("Attack");
         }
     }

     */






    void Movement()
    {
        float horizontalmove = Input.GetAxis("Horizontal");
        float facedirection = Input.GetAxisRaw("Horizontal");

        //½ÇÉ«ÒÆ¶¯
        if (horizontalmove != 0)
        {
            rb.velocity = new Vector2(horizontalmove * speed, rb.velocity.y);
            anim.SetFloat("running", Mathf.Abs(facedirection));

        }

        if (facedirection != 0)
        {
            transform.localScale = new Vector3(facedirection, 1, 1);

        }
    }







    //¶þ¶ÎÌø
    void newJump()
     {
        
        if (isGround)
         {
             extraJump = 1;
         }
         if (Input.GetButtonDown("Jump") && extraJump > 0)
         {
             rb.velocity = Vector2.up * jumpforce;
             extraJump--;
             anim.SetBool("jumping", true);
           
            if ( extraJump == 0)
            {

                rb.velocity = Vector2.up * jumpforce;
                extraJump--;
                anim.SetBool("2jump", true);
              
            }
            

        }
        

    }
     





    void SwitchAnim()
    {
        
        anim.SetBool("idle", false);
        if (anim.GetBool("jumping"))
        {
           

            if (rb.velocity.y < 0)
            {
                anim.SetBool("jumping", false);
                anim.SetBool("falling", true);
            }
                if (anim.GetBool("2jump"))
            {
       
                if (rb.velocity.y < 0)
                {
                    anim.SetBool("jumping", false);
                    anim.SetBool("falling", true);
                    anim.SetBool("2jump", false );
                }
            }
        }
        else if (coll.IsTouchingLayers(ground))
        {
            anim.SetBool("falling", false);
            anim.SetBool("idle", true);
            
        }
 
    }
}
