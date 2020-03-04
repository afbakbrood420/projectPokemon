using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class credit : MonoBehaviour
{
    public List<string> textLines = new List<string> { };
    public ScrollRect sr;
    public float speed = 50f;
    public GameObject textLinePrefab;
    public Transform content;

    private GameObject textToEdit;

    private void Start()
    {
        foreach (string line in textLines)
        {
            textToEdit = Instantiate(textLinePrefab,content);
            textToEdit.GetComponent<Text>().text = line;
        }
    }

    private void FixedUpdate()
    {
        sr.velocity = new Vector2(0f,speed);
        if (sr.verticalNormalizedPosition < 0)
        {
            sr.verticalNormalizedPosition = 1.1f;
        }
    }
}
