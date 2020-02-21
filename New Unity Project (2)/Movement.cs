using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public 
Rigidbody2D rb;


public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        GameObject.Rigidbody2d.addForce(0, 10, 0);
    }
}
