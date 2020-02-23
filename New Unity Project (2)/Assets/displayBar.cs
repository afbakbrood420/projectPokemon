using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayBar : MonoBehaviour
{
    public Slider stretchingRt;

    public Image rearImg;
    
    public float value = 0.75f; //must be between 0 and 1

    private float steps;
    private float valuePerStep;

    private void Update()
    {
        stretchingRt.value = value;
    }
    public void visibility(bool visible)
    {
        stretchingRt.gameObject.SetActive(visible);
        rearImg.enabled = visible;
    }
    public IEnumerator slideOverTime(float newValue, float overTime, float timeStep = 0.1f)
    {
        steps = overTime / timeStep;
        valuePerStep = (newValue - value)/steps;
        for (int i = 0; i < steps; i++)
        {
            value = value + valuePerStep;
            yield return new WaitForSeconds(timeStep);
        }
    }
}
