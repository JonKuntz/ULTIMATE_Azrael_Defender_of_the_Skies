using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDeath : MonoBehaviour
{
    // Start is called before the first frame update

    public int health = 100;
    public Transform explosionPlace;
    private bool killCounted=false;

    public AudioSource explosionSound; 
    

    // Update is called once per frame
 
    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        if (health == 0)
        {
            explosionSound.Play();
            health -= 1;
            Death();
        }
    }

    void Death()
    {
        GameObject.Find("GameMaster").GetComponent<gameMaster>().killCount += 1;
        Destroy(gameObject, 0.2f);
    }
}
