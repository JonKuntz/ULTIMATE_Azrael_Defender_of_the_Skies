using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class orbScoreProjector : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    public Text orbScoreText;
    public GameObject player;
    public string currentScoreString;
    void Update()
    {
        currentScoreString = (player.GetComponent<playerManager>().currentScore).ToString();
        //Debug.Log(currentScoreString);
        orbScoreText.text = currentScoreString;
    }
}
