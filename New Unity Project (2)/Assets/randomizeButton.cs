using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class randomizeButton : MonoBehaviour
{
    public Button btn;
    // Start is called before the first frame update
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
