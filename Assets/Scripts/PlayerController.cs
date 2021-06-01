using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [FormerlySerializedAs("_speed")] public float movementSpeed = 5f;
    [FormerlySerializedAs("_rb")] public Rigidbody2D rb;
    Vector2 movement;
    
    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * (movementSpeed * Time.fixedDeltaTime));
    }
}