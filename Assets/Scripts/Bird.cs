using UnityEngine;

public class Bird : MonoBehaviour
{
    public float jumpForce = 5f;      // Upward force
    public float gravity = -9.8f;     // Fall speed
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0; // Bird doesn't fall until game starts
    }

    void Update()
    {
        if (GameManager.Instance.gameStarted)
        {
            rb.gravityScale = 2; // Enable gravity once game starts

            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.linearVelocity = Vector2.up * jumpForce;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.Instance.GameOver();
    }
}
