using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class playAgainButton : MonoBehaviour
{
    public Button btn;
    
    //this script just moves to the titlescreen when button has been pressed.

    void Start()
    {
        btn.onClick.AddListener(backToTitleScreen);
    }


    void backToTitleScreen()
    {
        SceneManager.LoadScene("Scenes/titleScreen");
    }
}
