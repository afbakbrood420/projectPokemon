using System.Collections;
using System.Collections.Generic;
using UnityEngine;





private party Party;

public class OnCollisionBattleBrouwer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        BoxCollider2D bc;
        bc = gameObject.AddComponent<BoxCollider2D>() as BoxCollider2D;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void onTriggerEnter2D(string Collider2D)
    {
        Party = GameObject.FindWithTag("party");
        Party.startFight<Brouwer>;
    }
}
