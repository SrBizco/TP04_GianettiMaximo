using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float destroyXPosition = -10f;

    void Update()
    {
        
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        
        if (transform.position.x < destroyXPosition)
        {
            Destroy(gameObject);
        }
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().TakeDamage(1);
            Destroy(gameObject);
            
        }
    }
}