using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject door;
    private PlayerStatus playerComponent;
    private DoorScript doorComponent;
    // Start is called before the first frame update
    void Start()
    {
        playerComponent = player.GetComponent<PlayerStatus>();
        doorComponent = door.GetComponent<DoorScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //remove key from player view and play animation of key pickup
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            playerComponent.KeyCollected = true;
            doorComponent.UnlockDoor();
        }
    }
}
