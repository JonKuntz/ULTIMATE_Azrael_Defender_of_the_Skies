using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDeath : MonoBehaviour
{
    // Start is called before the first frame update

    public int health = 100;
    public Transform explosionPlace;

    public AudioSource explosionSound; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            explosionSound.Play();
            Death();
        }
    }

    void Death()
    {
        
        Destroy(gameObject, 0.2f);
    }
}
