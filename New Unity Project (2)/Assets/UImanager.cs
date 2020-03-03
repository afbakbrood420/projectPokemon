using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour
{
    public Transform player;
    public Transform movePoint;

    private party Party;
    private Scene currentScene;
    private Vector3 playerPos;
    private void Start()
    {
        Party = GameObject.FindObjectOfType<party>().GetComponent<party>();
        if (Party.usePlayerPosOnLoad)
        {
            player.position = Party.playerPosInMap;
            movePoint.position = Party.playerPosInMap;
        }
    }
    private void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            currentScene = SceneManager.GetActiveScene();
            playerPos = movePoint.position;
            Party.playerPosInMap = playerPos;
            Party.currentMapScene = currentScene;
            Party.usePlayerPosOnLoad = true;
            Party.accesInventory();
        }
    }
}
