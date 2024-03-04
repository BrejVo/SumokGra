using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;

    private void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical"); // Pobiera input x i y

        Vector2 movement = new Vector2(horizontalInput, verticalInput);

        if (movement.magnitude > 0.1f) // Magnitude sprawdza czy gracz si� porusza w jakim� kierunku
        {
            movement.Normalize(); // Dzi�ki temu nawet id�c po przek�tnej mamy tak� sam� szybko�� ruchu jak id�c w bok
            transform.position += (Vector3)movement * speed * Time.deltaTime; // Nadanie nowej pozycji
        }
    }
}