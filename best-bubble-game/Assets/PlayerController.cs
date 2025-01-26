using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private ConstantForce2D cf;
    private float movementX;
    private float movementY;
    public float moveSpeed;

    // Jumping Variables
    [SerializeField] bool isGrounded;
    [SerializeField] bool isJumping;
    [SerializeField] float jumpForce;
    [SerializeField] float jumpBrake;
    [SerializeField] float mass;
    [SerializeField] float linearDrag;
    [SerializeField] float angularDrag;
    [SerializeField] float gravity;

    private float updateGravity;

    public SpringJoint2D[] springs;
	public GameObject[] points;
	public GameObject hirax;

    public bool deflate = false;

    private InputAction inputAction;

    public GameObject bubble;
    public Vector3 minScale;

    void Start()
    {
        updateValues();
    }

    private void FixedUpdate()
    {
        Move(movementX);
        checkYVelocity();
        updateValues();

        if (deflate == true) 
        {
            Deflate();
        }
		
		FindCenter();
    }
	
	public void FindCenter()
	{
		var sumX = 0.0f;
		var sumY = 0.0f;
		
		foreach(var point in points)
		{
			sumX += point.transform.position.x;
			sumY += point.transform.position.y;
		}
		
		hirax.transform.position = new Vector2(sumX / 8.0f, sumY / 8.0f);
	}

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "above_water")
        {
            this.gravity = -gravity;
        }

        /*if (collision.tag == "under_water")
        {
            this.gravity = -gravity;
        }*/
    }

    public void onUpdateValues(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            updateValues();
        }
    }

    public void updateValues()
    {
        rb = GetComponent<Rigidbody2D>();
        cf = GetComponent<ConstantForce2D>();
        rb.mass = mass;
        rb.linearDamping = linearDrag;
        rb.angularDamping = angularDrag;
        rb.gravityScale = gravity;
    }

    // OnMove is called with the movement button is pressed
    public void OnMove(InputAction.CallbackContext ctx)
    {
        movementX = ctx.ReadValue<Vector2>().x;
        //Debug.Log(moveDirection);
    }

    // Move is called on Update and controls actual direction
    // direction is the Vector2 from the Callback Context (ctx)
    public void Move(float direction)
    {
        //Debug.Log(direction);
        rb.linearVelocity = new Vector2(movementX * moveSpeed, rb.linearVelocity.y);
        //Debug.Log(rb.velocity);
    }

    public void OnJump(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            Jump();
            Debug.Log("Jump!");
        }
    }

    public void OnReload(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            ReloadScene();
            Debug.Log("Reloadin!");
        }
    }

    public void Jump()
    {
        if (isGrounded)
        {
            //Debug.Log("Grounded");
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

    }

    public void checkYVelocity()
    {
        if (rb.linearVelocity.y < .5 && !isGrounded)
        {
            cf.force = new Vector2(0, -jumpBrake);
        }
        else if (isGrounded)
        {
            cf.force = new Vector2(0, 0);
        }
        //Debug.Log(cf.force);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //6 is Ground
        if (collision.gameObject.layer == 6)
        {
            isGrounded = true;
        }
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        //6 is Ground
        if (collision.gameObject.layer == 6)
        {
            isGrounded = false;
        }
    }

    public void OnDeflate(InputAction.CallbackContext ctx)
    {

        if (ctx.performed)
        {
            deflate = true;
            Debug.Log("Deflatin!");
        }
        else if (ctx.canceled)
        {
            deflate = false;
        }

    }

    public void Deflate()
    {
    //    if (bubble.transform.localScale.y > minScale.y)
      //  {
        //    foreach (var spring in springs)
          //  {
            //    spring.distance -= .01f;
            //}
        //}
		
		//if (bubble.transform.localScale.y > minScale.y)
        //{
			foreach (var spring in springs)
			{
				spring.distance -= .01f;
			}
		//}
    }
}