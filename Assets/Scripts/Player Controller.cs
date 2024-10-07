using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private int health = 3;
    [SerializeField] private GameObject defeatPanel;
    [SerializeField] private GameObject victoryPanel;

    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        defeatPanel.SetActive(false);
        victoryPanel.SetActive(false);
    }

    void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {

        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    private void Jump()
    {

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.SetBool("IsJumping", !isGrounded);
            AudioManager.instance.StopMovementSFX();
            AudioManager.instance.PlayJumpSFX();
        }
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        AudioManager.instance.PlayDamageSFX();
        if (health <= 0)
        {
            Defeat();
            Debug.Log("El jugador ha sido derrotado.");

        }
    }
    private void Defeat()
    {

        Time.timeScale = 0;
        AudioManager.instance.StopMusic();
        AudioManager.instance.StopMovementSFX();
        AudioManager.instance.PlayDeathSFX();


        defeatPanel.SetActive(true);
    }
    private void Victory()
    {

        Time.timeScale = 0;
        AudioManager.instance.StopMusic();
        AudioManager.instance.StopMovementSFX();
        AudioManager.instance.PlayDeathSFX();


        victoryPanel.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        AudioManager.instance.PlayMusic();
    }
    public void Heal(int amount)
    {
        health += amount;
        health = Mathf.Min(health, 3);
        Debug.Log("Vida curada, nueva vida: " + health);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("IsJumping", !isGrounded);
            AudioManager.instance.PlayMovementSFX();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            TakeDamage(1);
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            animator.SetBool("IsJumping", !isGrounded);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fall"))
        {
            Defeat();
        }
        else if (collision.gameObject.CompareTag("Win"))
        {
            Victory();
        }
    }

}