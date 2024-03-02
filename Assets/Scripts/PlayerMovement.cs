using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10.0f;
    [SerializeField] private Rigidbody2D rb;
    private float horizontalInput;
    private float verticalInput;


    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        Vector2 movement = new Vector2(horizontalInput, verticalInput);
        movement.Normalize(); // Normalizacja wektora ruchu
        rb.velocity = movement * speed;
    }
}