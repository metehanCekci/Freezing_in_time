using UnityEngine;

public class SimpleEnemyAi : MonoBehaviour
{

    [SerializeField] public float timeAmount = 100f;

    [Header("Movement Settings")]
    public float moveSpeed = 3f;  // The speed at which the enemy moves
    public float fallSpeed = 10f;  // Fall speed multiplier during the initial fall

    private Transform player; // Reference to the player's Transform
    private Rigidbody2D rb;   // Reference to the Rigidbody2D for movement

    private bool isFalling = true; // Check if the enemy is in the falling state
    private float fallDuration = 1f; // Time for fast fall
    private float fallTimer = 0f; // Timer to track the fall duration

    private SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer for flipping

    // Time-based speed adjustment
    
    private float normalSpeed = 3f; // Default speed
    private float reducedSpeed = 1.5f; // Reduced speed

    void Start()
    {
        // Initialize references
        player = GameObject.FindWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Start with increased fall speed
        rb.gravityScale = fallSpeed;
    }

    void Update()
    {
        // **Timer Kontrol� ile H�z G�ncelleme**
        if (timeAmount <= 95f) // E�er zaman 1 saniyeden azsa
        {
            moveSpeed = reducedSpeed; // H�z� azalt
        }
        else
        {
            moveSpeed = normalSpeed; // Normal h�za d�n
        }

        if (isFalling)
        {
            // Falling logic
            fallTimer += Time.deltaTime;

            if (fallTimer >= fallDuration)
            {
                rb.gravityScale = 1f; // Reset gravity to normal
                isFalling = false;    // Stop falling
            }
        }
        else
        {
            // Normal hareket
            MoveTowardsPlayer();
        }

        
    }

    void MoveTowardsPlayer()
    {
        // **Yaln�zca X ekseninde oyuncuya do�ru hareket**
        Vector2 direction = new Vector2(player.position.x - transform.position.x, 0).normalized;

        // Rigidbody h�z�n� ayarla
        rb.linearVelocity = new Vector2(direction.x * moveSpeed, rb.linearVelocity.y);

        // Sprite y�n�n� ayarla
        if (direction.x < 0) // E�er sola hareket ediyorsa
        {
            spriteRenderer.flipX = true;
        }
        else if (direction.x > 0) // E�er sa�a hareket ediyorsa
        {
            spriteRenderer.flipX = false;
        }
    }
}

