using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PA : MonoBehaviour
{
 
    public AnimatorStateInfo animSta;
    private const string IdleState = "idle-player";
    private const string Attack1State = "attack";
    private const string Attack2State = "attack2";
    private const string Attack3State = "attack3";
    private int HitCount = 0;


    public float time;
    public int damage;
    private Animator anim;
    private PolygonCollider2D coll2D;

    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        coll2D = GetComponent<PolygonCollider2D>();
        
        /*anim.SetBool("run", false);
        anim.SetBool("Jump", false);*/
        HitCount = 0;
    }

    // Update is called once per frame
    void Update()
    {

        animSta=anim.GetCurrentAnimatorStateInfo(0);
        if (!animSta.IsName(IdleState) && animSta.normalizedTime > 1.0f)
        {
            anim.SetInteger("Attack", 0);
            HitCount = 0;
        }
        if (Input.GetButtonDown("Attack"))
        {
            Attack();
        }
    }

    void Attack()
    {



        coll2D.enabled = true;

        StartCoroutine(disableHitBox());
        if (animSta.IsName(IdleState) && HitCount == 0 && animSta.normalizedTime > 0.27f)
        {
            anim.SetInteger("Attack", 1);
            HitCount = 1;
            Debug.Log("cc");
        }
        else
            if (animSta.IsName(Attack1State) && HitCount == 1 && animSta.normalizedTime > 0.45f)
        {
            anim.SetInteger("Attack", 2);
            HitCount = 2;
        }
        else
            if (animSta.IsName(Attack2State) && HitCount == 2 && animSta.normalizedTime > 0.50f)
        {
            anim.SetInteger("Attack", 3);
            HitCount = 3;
        }

    }





    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enermy"))
        {
            other.GetComponent<Enermy>().TakeDamage(damage);
        }
    }
    IEnumerator disableHitBox()
    {
        
        yield return new WaitForSeconds(time);
        coll2D.enabled = false;
        
    }



}
