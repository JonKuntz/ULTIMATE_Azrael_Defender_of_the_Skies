using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthBar : MonoBehaviour //https://www.youtube.com/watch?v=STrjeoyM2q0
{
    // Start is called before the first frame update
    public Vector3 startingScale;
    void Start()
    {
        startingScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        startingScale.x=0.005f*( GameObject.Find("player").GetComponent<playerManager>().currentHealth);
        transform.localScale = startingScale;
    }
}
