using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //    private float horizontal;
    //    private float speed = 8f;
    //    private float jumpingPower = 16f;
    //    private bool isFacingRight = true;

    //    [SerializeField] private Rigidbody2D rb;
    //    [SerializeField] private Transform groundCheck;
    //    [SerializeField] private LayerMask groundLayer;


    [SerializeField] private float movementSpeed = 2f;
    private Rigidbody2D rb;
    private Vector2 movementDirection;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = movementDirection * movementSpeed;
    }
}
