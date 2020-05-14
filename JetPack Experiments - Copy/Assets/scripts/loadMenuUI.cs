using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadMenuUI : MonoBehaviour
{
    // Start is called before the first frame update
   

    // Update is called once per frame
   public void StartGame() //based on brackey's tutorial https://www.youtube.com/watch?v=zc8ac_qUXQY
    {
        SceneManager.LoadScene("Level1");
    }

    public void QuitGame()
    {
        Debug.Log("it would quit here");
        Application.Quit();

    }


}
