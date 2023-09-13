using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateScript : MonoBehaviour
{
    public Vector3 originalPos;
    private Vector3 blockdepth;
    bool moveBack = false;

    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.position;
        blockdepth = new Vector3(0.0f, -2.6f, 0.0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.transform.parent = transform;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
          if(transform.position.y > blockdepth.y)
            {
                transform.Translate(0, -0.01f, 0);
                moveBack = false;
            }  
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            moveBack = true;
            collision.transform.parent = null;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (moveBack) 
        {
            if(transform.position.y < originalPos.y)
            {
                transform.Translate(0, 0.005f, 0);
            }
            else
            {
                moveBack = false;
            }
        }
    }
}
