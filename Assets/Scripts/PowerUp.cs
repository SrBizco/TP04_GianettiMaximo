using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private int healAmount = 1;

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController player = collision.GetComponent<PlayerController>();

            if (player != null)
            {
                player.Heal(healAmount);
                Destroy(gameObject); 
            }
        }
    }
}