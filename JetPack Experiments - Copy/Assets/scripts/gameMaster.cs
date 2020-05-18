using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameMaster : MonoBehaviour
{
    private GameObject doorToDestroy;
    // Start is called before the first frame update
    public int killCount = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("player") == null)
        {
            SceneManager.LoadScene("gameOver");
            Debug.Log("it should end here");
        }


    }
    
}
