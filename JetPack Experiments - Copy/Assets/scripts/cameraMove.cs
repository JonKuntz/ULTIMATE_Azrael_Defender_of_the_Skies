using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{
    public Transform Player;
    public Vector3 cameraVector = new Vector3(0,0,0);
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("player") != null)
        {
            transform.position = new Vector3(Player.position.x + cameraVector.x, Player.position.y + cameraVector.y, Player.position.z + cameraVector.z);
        }
    }
}
