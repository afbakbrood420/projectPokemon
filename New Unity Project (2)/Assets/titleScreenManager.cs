using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class titleScreenManager : MonoBehaviour
{
    public Button playbutton;
    public popUpWindow popUp;
    public AudioSource music;
    public AudioClip mainTheme;
    // Start is called before the first frame update
    void Start()
    {
        music.clip = mainTheme;
        music.Play();
        //look for a party object, if there is one, destroy it, and notify the player he has lost
        GameObject possibleParty = GameObject.FindGameObjectWithTag("party");
        if (possibleParty != null)
        {
            Destroy(possibleParty);
            popUp.notification("game over");
        }
        playbutton.onClick.AddListener(startGame);
    }
    void startGame()
    {
        SceneManager.LoadScene("Scenes/PokemonSelector");
    }
}
