using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class popUpWindow : MonoBehaviour
{
    public Button btn;
    public Text msgText;
    public List<Text> texts = new List<Text> { };
    public List<Image> images = new List<Image> { };
    // Start is called before the first frame update
    private void Start()
    {
        hideAll();
        btn.onClick.AddListener(hideAll);
    }
    void hideAll()
    {
        btn.enabled = false;
        foreach (Image image in images)
        {
            image.enabled = false;
        }
        foreach (Text text in texts)
        {
            text.enabled = false;
        }
    }
    void showAll()
    {
        btn.enabled = true;
        foreach (Image image in images)
        {
            image.enabled = true;
        }
        foreach (Text text in texts)
        {
            text.enabled = true;
        }
    }
    void notification(string msg)
    {
        msgText.text = msg;
        showAll();
    }

}
