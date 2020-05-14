using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletFly : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public float speed = 300;
    public int bulletDamage = 50;
    public GameObject impactEffect;
    
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Camera.main.WorldToViewportPoint(transform.position).x > 2)
        {
            Destroy(this.gameObject);

        }
        if (Camera.main.WorldToViewportPoint(transform.position).x < -1)
        {
            Destroy(this.gameObject);

        }
    }

    //void OnTriggerEnter2D(Collider2D enemyCollider)
    //{
    //    Debug.Log(enemyCollider.name);
    //    Destroy(gameObject);

    //}

    void OnTriggerEnter2D(Collider2D enemy) //this method copied from a Brackey's Tutorial https://www.youtube.com/watch?v=wkKsl1Mfp5M
    {
        enemyDeath destroyer = enemy.GetComponent<enemyDeath>();
        if (enemy != null)
        {
            destroyer.TakeDamage(bulletDamage);
        }
        
        //Instantiate(impactEffect, transform.position, transform.rotation);
        
        //Destroy(gameObject);
        
    }
}

