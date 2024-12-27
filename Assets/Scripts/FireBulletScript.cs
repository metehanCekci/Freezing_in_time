using UnityEngine;

public class FireBulletScript : MonoBehaviour
{
    public float speed = 10f; // Bullet movement speed

    public bool isLaser = false;
    private Vector2 direction; // Bullet movement direction

    private void Awake()
    {
        // Find the player by the 'Player' tag
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;

        // Get the player's position
        Vector2 playerPosition = player.position;

        // Calculate the direction from the bullet to the player
        direction = (playerPosition - (Vector2)transform.position).normalized;

        if(isLaser)
        this.gameObject.transform.localScale = new Vector3(1, 0.2f, 1);

        // Destroy the bullet after 3 seconds
        Destroy(this.gameObject, 3f);
    }

    private void Update()
    {
        // Move the bullet in the direction of the player
        transform.Translate(direction * speed * Time.deltaTime, Space.World);

        // Rotate the bullet to face the direction it's moving
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Destroy the bullet when it collides with any object
        Destroy(gameObject);
    }
}
