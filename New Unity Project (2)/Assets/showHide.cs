using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showHide : MonoBehaviour
{

    public bool hidden = false;

    private List<targetFinder> targetFinders = new List<targetFinder> { };

    
    public List<Image> rest = new List<Image> { };

    public targetFinderBuilder TargetFinderBuilder;

    private void Update()
    {
        if (Input.GetButtonDown("Cancel")&&hidden == false)
        {
            hide();
        }
    }
    public void initiate()
    {
        targetFinders = TargetFinderBuilder.targetFinders;
        hide();
    }
    public void hide()
    {
        foreach (targetFinder TargetFinder in targetFinders)
        {
            TargetFinder.visibility(false);
        }
        foreach (Image img in rest)
        {
            img.enabled = false;
        }
    }
    public void show()
    {
        foreach (targetFinder TargetFinder in targetFinders)
        {
            TargetFinder.visibility(true);
        }
        foreach (Image img in rest)
        {
            img.enabled = true;
        }
    }
}
