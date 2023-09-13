using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D myRigidBody;
    [SerializeField] private BoxCollider2D myCollider;
    [SerializeField] private Collider2D[] otherColliders;

    [SerializeField] private int type;
    [SerializeField] private float jumpForce;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float wait;

    //For parent
    private bool canJump;
    public bool CanJump
    {
        get { return canJump; }
        set { canJump = value; }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (Collider2D collider in otherColliders)
        {
            Physics2D.IgnoreCollision(myCollider, collider);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float inputH = Input.GetAxisRaw("Horizontal");
        float inputV = Input.GetAxisRaw("Vertical");

        
        if (type == 0)
        {
            if (Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity, LayerMask.GetMask("Ground")).distance < 0.1)
            {
                canJump = true;
            }

            myRigidBody.velocity = new Vector2(inputH * moveSpeed, myRigidBody.velocity.y);

            if (inputV > 0 && canJump)
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce * inputV);
                canJump = false;
            }
        }
        else
        {
            StartCoroutine(WaitMove(inputH));

            if (inputV > 0 && transform.parent.GetComponent<NewBehaviourScript>().CanJump)
            {
                StartCoroutine(WaitJump());
            }
        }
        
    }

    public IEnumerator WaitJump()
    {
        yield return new WaitForSeconds(wait);
        myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);

    }

    public IEnumerator WaitMove(float input)
    {
        yield return new WaitForSeconds(wait);
        myRigidBody.velocity = new Vector2(input * moveSpeed, myRigidBody.velocity.y);
    }

    public void stopCoroutines()
    {
        StopAllCoroutines();
    }
}
