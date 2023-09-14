using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D myRigidBody;
    [SerializeField] private BoxCollider2D myCollider;
    [SerializeField] private Collider2D[] otherColliders;

    [SerializeField] private int type;
    [SerializeField] private float jumpForce;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float wait;
   
    

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
        //transform.rotation = Quaternion.Euler(0, 0, 0); 
        float inputH = Input.GetAxisRaw("Horizontal");

        if (type == 0)
        {
            Move(inputH);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }
        else
        {
            StartCoroutine(WaitMove(inputH));

            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(WaitJump());
            }
        }

        if (Input.GetKey(KeyCode.R))
        {
            ResetLevel();
        }
    }

    public void Jump()
    {
        myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
    }

    public void Move(float input)
    {
        myRigidBody.velocity = new Vector2(input * moveSpeed, myRigidBody.velocity.y);
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

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
