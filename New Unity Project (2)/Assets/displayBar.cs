using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class displayBar : MonoBehaviour
{
    [SerializeField]
    private RectTransform stretchingRt;

    private RectTransform rt;
    public float value = 0.75f; //must be between 0 and 1
    private void Start()
    {
        rt = gameObject.GetComponent<RectTransform>();

    }
    private void Update()
    {
        stretchingRt.right = rt.right * value;
    }
}
