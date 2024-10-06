using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento horizontal
    public float jumpForce = 10f; // Fuerza del salto
    public int health = 3; // Vida del jugador

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move(); // Llamar al m�todo de movimiento
        Jump(); // Llamar al m�todo de salto
    }

    void Move()
    {
        // Movimiento autom�tico hacia la derecha
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    void Jump()
    {
        // L�gica para saltar
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount; // Resta vida al jugador
        if (health <= 0)
        {
            Debug.Log("El jugador ha sido derrotado.");
            // Aqu� puedes agregar la l�gica de reinicio del juego o destruir al jugador
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // El jugador est� en el suelo
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            TakeDamage(1); // Resta vida al chocar con un obst�culo
            Destroy(collision.gameObject); // Destruye el obst�culo al colisionar
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false; // El jugador ya no est� en el suelo
        }
    }
}