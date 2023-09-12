using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTPScript : MonoBehaviour
{
    [SerializeField] private GameObject child;
    [SerializeField] private Rigidbody2D myRigidBody;

    private Rigidbody2D childBody;
    private NewBehaviourScript childScript;

    // Start is called before the first frame update
    void Start()
    {
        childBody = child.GetComponent<Rigidbody2D>();
        childScript = child.GetComponent<NewBehaviourScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRigidBody.velocity = Vector3.zero;
            transform.position = child.transform.position;

            childBody.velocity = Vector3.zero;
            childScript.stopCoroutines();
            child.transform.localPosition = new Vector2(0, 0);
        }
    }
}
