using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class randomizeButton : MonoBehaviour
{
    public Button btn;
    // Start is called before the first frame update

   /*
    * this script is not being referenced, since the button it was assignet to was removed
    * it used to quickly put in the moves of the pokemon, so that you did not have to do that in each debug. 
    */
    void Start()
    {
        btn.onClick.AddListener(randomizeMoves);
    }
    void randomizeMoves()
    {
        foreach (moveCollector moveList in GameObject.FindObjectsOfType<moveCollector>())
        {
            moveList.defaultMoves();
        }
    }


}
