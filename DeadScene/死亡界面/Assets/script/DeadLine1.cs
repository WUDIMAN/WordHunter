using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadLine : MonoBehaviour
{
    public GameObject GameOverImage;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {            
            GameOverImage.SetActive(true);
        }
    }
 
       private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.tag == "DeadJiGuan") 
        {
            //Destroy(gameObject.CompareTag("Player"));
        }

    }
    
}
