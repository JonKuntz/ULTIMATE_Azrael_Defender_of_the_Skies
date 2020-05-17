using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireballScript : MonoBehaviour
{
   
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public float speed = 200;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Player")
        {
            GameObject.Find("player").GetComponent<playerManager>().currentHealth -= 10f;
            Destroy(gameObject);

        }
    }


}


