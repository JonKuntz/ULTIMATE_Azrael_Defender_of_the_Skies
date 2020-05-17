using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1FireBallAttack : MonoBehaviour
{
    // Start is called before the first frame update

    public bool canShoot = true;
    public GameObject fireballPrefab;
    public GameObject fireballPrefab2;
    public Transform fireballFirePoint;

    // Update is called once per frame
    void Update()
    {
        if (canShoot)
        {
            Instantiate(fireballPrefab, fireballFirePoint.position, fireballFirePoint.rotation);
            Instantiate(fireballPrefab2, fireballFirePoint.position, fireballFirePoint.rotation);
            StartCoroutine(Reload());
            canShoot = false;
        }
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(2f);
        canShoot = true;
        Debug.Log("ready to shoot again");

    }
}
