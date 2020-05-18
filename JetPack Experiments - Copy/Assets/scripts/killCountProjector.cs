using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class killCountProjector : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    public Text killScoreText;
    public GameObject gameMasterObject;
    public string currentKillsString;
    void Update()
    {
        currentKillsString = (gameMasterObject.GetComponent<gameMaster>().killCount).ToString();
        //Debug.Log(currentKillsString);
        killScoreText.text = currentKillsString;
    }
}
