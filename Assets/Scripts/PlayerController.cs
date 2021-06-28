using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Initialize current speed for the player
    private const float MovementSpeed = 5.0f;
    // Getting rigidbody for the object player
    public Rigidbody2D rb;
    // 2D Vector
    private Vector2 _movement;
    
    // Update is called once per frame
    private void Update()
    {
        // Getting X, Y from the object
        _movement.x = Input.GetAxisRaw("Horizontal"); 
        _movement.y = Input.GetAxisRaw("Vertical");
    }

    // FixedUpdate called for physics calculation
    private void FixedUpdate()
    {
        // Formula for movement of the object Player
        rb.MovePosition(rb.position + _movement * (MovementSpeed * Time.fixedDeltaTime));
    }
}