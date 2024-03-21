using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCatcher : MonoBehaviour
{
    public float pushForce = 10.0f; // Si�a pchania
    public float maxDistance = 2.0f; // Obszar gdzie mo�e z�apa� sumo
    public LayerMask pushableLayer; // Tag kt�ry mo�e �apa� sumo

    private Transform playerTransform; // Transform gracza
    private bool isPushing; // Czy obiekt jest pchany

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isPushing = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            isPushing = false;
        }

        if (isPushing)
        {
            // Lista w kt�rej zapisuje obiekt kt�ry koliduje z sumokiem, potem listuje te elementy i je�eli trafi na tag Enemy to bierze jego komponent rigidbody i przesuwa
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(playerTransform.position, maxDistance, pushableLayer);

            foreach (Collider2D hitCollider in hitColliders)
            {
                if (hitCollider.CompareTag("Enemy")) // Sprawdzenie tagu enemy czyli sumok
                {
                    Rigidbody2D enemyRb = hitCollider.GetComponent<Rigidbody2D>();

                    if (enemyRb != null)
                    {
                        Vector2 pushDirection = (playerTransform.position - hitCollider.transform.position).normalized;
                        Vector2 pushForceVector = pushDirection * pushForce;

                        // Ograniczenie maksymalnej odleg�o�ci pchania
                        if (Vector2.Distance(playerTransform.position, hitCollider.transform.position) > maxDistance)
                        {
                            pushForceVector = pushForceVector * (maxDistance / Vector2.Distance(playerTransform.position, hitCollider.transform.position));
                        }

                        enemyRb.AddForce(pushForceVector);
                    }
                }
            }
        }
    }
}