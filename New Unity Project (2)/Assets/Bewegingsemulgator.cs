using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bewegingsemulgator : MonoBehaviour
    
{
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
       rb = gameObject.GetComponent<Rigidbody2D>();
       transform.position = new Vector3(0.0f, -2.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        if (Input.GetKey("w")) 
        {
            rb.AddForce(transform.up * 3);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(transform.right * 3);
        }
        if (Input.GetKey("s"))
        {
            rb.AddForce(transform.up * -3);
        }
        if (Input.GetKey("d"))
        {
            rb.AddForce(transform.right * -3);
        }
    }
}
