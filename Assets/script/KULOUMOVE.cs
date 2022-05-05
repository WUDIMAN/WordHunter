using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KULOUMOVE : Enermy
{
    private Rigidbody2D rb;
    public Transform leftpoint, rightpoint;
    private bool Faceleft = true;
    public float Speed;
    private float leftx, rightx;
    public Animator anim;



    // Start is called before the first frame update
    public void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        transform.DetachChildren();
        leftx = leftpoint.position.x;
        rightx = rightpoint.position.x;
        Destroy(leftpoint.gameObject);
        Destroy(rightpoint.gameObject);
    }

    // Update is called once per frame
    public void Update()
    {
        Movement();
        SwitchAnim();
        base.Update();
    }






    void Movement()
    {
        if (Faceleft)
        {
            rb.velocity = new Vector2(-Speed, rb.velocity.y);
            if (transform.position.x < leftx)
            {
                transform.localScale = new Vector3(1, 1, 1);
                Faceleft = false;
            }
        }
        else
        {
            rb.velocity = new Vector2(Speed, rb.velocity.y);
            if (transform.position.x > rightx)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                Faceleft = true;
            }
        }
    }



    void SwitchAnim()
    {
        anim.SetBool("idle", false);
        /*if(){
        anim.SetBool("idle", true);
        }
        */


    }
}