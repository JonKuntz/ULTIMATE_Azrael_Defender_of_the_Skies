﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyDoor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        {
            int x = GameObject.Find("player").GetComponent<playerManager>().currentScore;
            Debug.Log("score is " + x);

            if (x == 20)
            {
                Destroy(gameObject);

            }

        }
    }

    
}