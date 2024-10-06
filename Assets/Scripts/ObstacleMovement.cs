using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float speed = 5f; // Velocidad del obstáculo
    public float destroyXPosition = -10f; // Posición en X donde se destruye el obstáculo

    void Update()
    {
        // Mover el obstáculo de derecha a izquierda
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        // Destruir el obstáculo si se sale de la pantalla (en X)
        if (transform.position.x < destroyXPosition)
        {
            Destroy(gameObject);
        }
    }

    // Detectar la colisión con el jugador
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Verificar si colisiona con el jugador
        {
            collision.GetComponent<PlayerController>().TakeDamage(1);
            Destroy(gameObject); // Destruir el obstáculo
            // A futuro: Llamar a una función para reducir la vida del jugador
        }
    }
}