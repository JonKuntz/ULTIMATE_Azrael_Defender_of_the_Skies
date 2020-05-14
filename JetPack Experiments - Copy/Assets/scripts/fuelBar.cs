using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuelBar : MonoBehaviour
{
    public Vector3 startingScale;
    void Start()
    {
        startingScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        startingScale.x = 0.005f * (GameObject.Find("player").GetComponent<PlayerMovement>().fuelRemaining);
        transform.localScale = startingScale;
    }
}
