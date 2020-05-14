using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class playerManager : MonoBehaviour
{
    public int currentScore = 0;
    public float currentHealth = 1.0f;
    public AudioSource orbCollectSound;
    public AudioSource healthPackSound;
    public AudioSource fireWeapon;
    public GameObject deathMessage;
    public AudioSource playerDeathClip;
    public AudioSource playerExplosionClip;
    private bool isDestroyed = false;
    public Animator animator;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDestroyed)
        {
            if (currentHealth <= 0)
            {

                playerDeath();
                isDestroyed = true;
            }
        }

        if (currentHealth>100)
        {
            currentHealth = 100;
        }

        if(currentHealth<0)
        { currentHealth = 0; }
      
        if (Input.GetKeyDown(KeyCode.J))
        {
            fireWeapon.Play();
        }


    }

    public void enemyAttack(int x)
    {
        currentHealth -= x;
    }

    public void playerDeath()
    {
        //Instantiate(deathMessage, this.transform.position, this.transform.rotation)
        playerDeathClip.Play();
        playerExplosionClip.Play();
        
        animator.SetFloat("isFlying", 0f);
        animator.SetBool("isDying", true);
        Destroy(gameObject, 2);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        

        if (LayerMask.LayerToName(collision.gameObject.layer) == "GoldenOrbs")
        {
            orbCollectSound.Play();
            
        }
        else if (LayerMask.LayerToName(collision.gameObject.layer) == "HealthPacks")
        {
            healthPackSound.Play();

        }
    }
    
}
