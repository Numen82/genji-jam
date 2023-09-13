using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private PlayerStatus scriptAComponent;
    public Sprite newSprite;
    private SpriteRenderer spriteRenderer;


    // Start is called before the first frame update
    void Start()
    {
        scriptAComponent = player.GetComponent<PlayerStatus>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
  
    }

    public void UnlockDoor()
    {
        spriteRenderer.sprite = newSprite;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //player passes level
        if (collision.gameObject.CompareTag("Player") && scriptAComponent.KeyCollected == true)
        {
            //instead of deleting the door, pass the player to next level
            gameObject.SetActive(false);
        }
    }
}
