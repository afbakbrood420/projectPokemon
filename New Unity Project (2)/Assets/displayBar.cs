using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayBar : MonoBehaviour
{
    [SerializeField]
    private Slider stretchingRt;

    
    public float value = 0.75f; //must be between 0 and 1

    private void Update()
    {
        value = value + 0.02f;
        if (value > 1)
        {
            value = 0f;
        }
        stretchingRt.value = value;
    }
}
