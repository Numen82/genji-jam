using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private PlayerStatus scriptAComponent;
    
    // Start is called before the first frame update
    void Start()
    {
        scriptAComponent = player.GetComponent<PlayerStatus>();
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
            scriptAComponent.KeyCollected = true;
        }
    }
}
