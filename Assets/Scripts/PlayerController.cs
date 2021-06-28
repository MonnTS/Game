using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 5f; // Initialize current speed for the player
    public Rigidbody2D rb; // Getting rigidbody for the object player
    Vector2 movement; // 2D Vector
    
    // Update is called once per frame
    void Update()
    {
        /* Getting x and y from the object */ 
        movement.x = Input.GetAxisRaw("Horizontal"); 
        movement.y = Input.GetAxisRaw("Vertical");
    }

    // FixedUpdate called for physics calculation
    void FixedUpdate()
    {
        // Formula for movement of the object Player  
        rb.MovePosition(rb.position + movement * (movementSpeed * Time.fixedDeltaTime));
    }
}