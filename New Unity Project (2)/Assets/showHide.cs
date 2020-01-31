using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showHide : MonoBehaviour
{

    public bool hidden = false;

    private List<targetFinder> targetFinders = new List<targetFinder> { };

    [SerializeField]
    private List<Image> rest = new List<Image> { };

    [SerializeField]
    private targetFinderBuilder TargetFinderBuilder;

    private void Start()
    {
        targetFinders = TargetFinderBuilder.targetFinders;
        foreach (targetFinder target in targetFinders)
        {
            Debug.Log(target.pokemon.name);
        }

        hide();
    }
    public void hide()
    {
        foreach (targetFinder TargetFinder in targetFinders)
        {
            TargetFinder.visibility(false);
        }
    }
    public void show()
    {
        foreach (targetFinder TargetFinder in targetFinders)
        {
            TargetFinder.visibility(true);
        }
    }
}
