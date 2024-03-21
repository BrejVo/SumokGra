using System;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform target; // Referencja do obiektu Player, do kt�rego d��y Enemy
    public float speed = 2f; // Pr�dko�� ruchu Enemy
    Animator animator;
    bool facingRight = false;

    private void Start()
    {

        animator = GetComponent<Animator>();
        // Szukaj obiektu Player na pocz�tku gry
        target = GameObject.FindGameObjectWithTag("Player").transform;

        if (target == null)
        {
            Debug.LogError("Nie mo�na znale�� obiektu Player!");
        }
    }

    private void Update()
    {
        if (target == null)
        {
            // Je�li nie ma obiektu Player, zako�cz funkcj� Update
            return;
        }

        // Oblicz wektor kierunku od pozycji Enemy do pozycji Player
        Vector3 direction = target.position - transform.position;

        // Normalizuj wektor kierunku, aby uzyska� jednostkowy wektor kierunku
        direction.Normalize();

        // Przesu� Enemy w kierunku Player z okre�lon� pr�dko�ci�
        transform.position += direction * speed * Time.deltaTime;

        if (direction.x < 0 && facingRight)
        {
            Flip();
        }
        if (direction.x > 0 && !facingRight)
        {
            Flip();
        }
        animator.SetFloat("xVelocity", Math.Abs(direction.x));
        animator.SetFloat("yVelocity", Math.Abs(direction.y));

        void Flip()
        {
           facingRight = !facingRight;
           transform.Rotate(0, 180, 0);
        }
    }
}