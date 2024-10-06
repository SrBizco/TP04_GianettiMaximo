using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float speed = 5f; // Velocidad del obst�culo
    public float destroyXPosition = -10f; // Posici�n en X donde se destruye el obst�culo

    void Update()
    {
        // Mover el obst�culo de derecha a izquierda
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        // Destruir el obst�culo si se sale de la pantalla (en X)
        if (transform.position.x < destroyXPosition)
        {
            Destroy(gameObject);
        }
    }

    // Detectar la colisi�n con el jugador
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Verificar si colisiona con el jugador
        {
            collision.GetComponent<PlayerController>().TakeDamage(1);
            Destroy(gameObject); // Destruir el obst�culo
            // A futuro: Llamar a una funci�n para reducir la vida del jugador
        }
    }
}