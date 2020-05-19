using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    //this method learned from tutorial: https://www.youtube.com/watch?v=ExRQAEm4jPg 

    
    
    public Transform[] waypointMarkers= new Transform[3];
    
    
    public float speed = 2f;

    private int waypointIndex =0;

    public Rigidbody2D rb;
    public int enemyDamage = 10;

    public AudioSource playerCollision;
  
    
    void Start()
    {
        this.transform.position = waypointMarkers[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        //plsMove();
        Move();
        
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Player")
        {
            GameObject.Find("player").GetComponent<playerManager>().currentHealth -= 10f;
            //Destroy(gameObject);
            playerCollision.Play();
            Destroy(gameObject,0.1f);

        }
    }
    //void OnTriggerEnter2D(Collider2D enemy) //this method copied from a Brackey's Tutorial https://www.youtube.com/watch?v=wkKsl1Mfp5M
    //{
    //    playerManager destroyer = enemy.GetComponent<playerManager>();
    //    if (enemy != null)
    //    {
    //        destroyer.enemyAttack(enemyDamage);
    //    }

    //Instantiate(impactEffect, transform.position, transform.rotation);

    //    Destroy(gameObject);

    //}



    //void Move()
    //{
    //    transform.position = Vector2.MoveTowards(transform.position, waypointMarkers[waypointIndex+1].transform.position, speed * Time.deltaTime);
    //    if (transform.position== waypointMarkers[waypointIndex+1].transform.position)
    //    {
    //       waypointIndex += 1;
    //   }
    //    if (waypointIndex==((waypointMarkers.Length)))
    //    {
    //        waypointIndex = 0;
    //    }
    //    Debug.Log("it should be moving");
    //}

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypointMarkers[waypointIndex].transform.position, speed * Time.deltaTime);
        
        if (this.transform.position == waypointMarkers[waypointIndex].transform.position)
        {
            waypointIndex +=1;
            rb.transform.Rotate(0, 180, 0);
            //Debug.Log("the first if statement worked");
        }
        if (waypointIndex == waypointMarkers.Length)
        {
            waypointIndex = 0;
            //Debug.Log("the second statement worked");
        }
        //Debug.Log("it should be moving");

        
    }
    //void plsMove()
    //{
    //    transform.position = Vector2.MoveTowards(transform.position, waypointMarkers[1].transform.position, speed * Time.deltaTime);
    //}
}
