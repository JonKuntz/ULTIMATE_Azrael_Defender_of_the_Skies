using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbCollect : MonoBehaviour
{
    // Start is called before the first frame update
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Player")
        {
            GameObject.Find("player").GetComponent<playerManager>().currentScore += 10;
            
            Destroy(gameObject);

        }
    }
}
