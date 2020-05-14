using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public Transform firepoint;
    public Rigidbody2D rb;
    public float bulletSpeed;
    public GameObject bulletPrefab;
    // Start is called before the first frame update
 

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("j"))
        {
            Shoot();
        }

        
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        Debug.Log("shoot has succeeded");
    }
}
