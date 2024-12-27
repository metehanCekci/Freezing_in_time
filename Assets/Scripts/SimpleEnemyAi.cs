using UnityEngine;

public class SimpleEnemyAi : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 3f;  // The speed at which the enemy moves
    public float fallSpeed = 10f;  // Fall speed multiplier during the initial fall

    private Transform player; // Reference to the player's Transform
    private Rigidbody2D rb;   // Reference to the Rigidbody2D for movement

    private bool isFalling = true; // Check if the enemy is in the falling state
    private float fallDuration = 1f; // Time for fast fall
    private float fallTimer = 0f; // Timer to track the fall duration

    private SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer for flipping

    void Start()
    {
        // Get references to the necessary components
        player = GameObject.FindWithTag("Player").transform; // Assuming the player is tagged "Player"
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get the SpriteRenderer component

        // Start the falling phase
        rb.gravityScale = fallSpeed; // Set gravity scale to simulate fast falling
    }

    void Update()
    {
        if (isFalling)
        {
            // Increment the fall timer
            fallTimer += Time.deltaTime;

            if (fallTimer >= fallDuration)
            {
                // After 1 second, stop falling fast and revert to normal gravity
                rb.gravityScale = 1f;  // Reset gravity to normal
                isFalling = false;     // Stop falling, start normal movement
            }
        }
        else
        {
            // Once the falling phase is over, move the enemy normally
            MoveTowardsPlayer();
        }
    }

    void MoveTowardsPlayer()
    {
        // Calculate the direction towards the player, but only in the X axis
        Vector2 direction = new Vector2(player.position.x - transform.position.x, 0).normalized;

        // Move the enemy using Rigidbody2D, only affecting the X axis
        rb.linearVelocity = new Vector2(direction.x * moveSpeed, rb.linearVelocity.y);

        // Flip the sprite based on the movement direction
        if (direction.x < 0) // Moving left
        {
            spriteRenderer.flipX = true; // Flip the sprite to face left
        }
        else if (direction.x > 0) // Moving right
        {
            spriteRenderer.flipX = false; // Flip the sprite to face right
        }
    }
}
