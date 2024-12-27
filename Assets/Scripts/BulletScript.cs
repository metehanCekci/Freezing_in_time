using Unity.VisualScripting;
//using UnityEditor.Callbacks;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [Header("Bullet Settings")]
    [SerializeField] private float deleteDelay = 2f; // Time before the bullet is destroyed
    public float speed = 2f; // Bullet speed
    public int damage = 1; // Damage dealt by the bullet
    public int bulletHp = 1; // Bullet health (i.e., how many hits it can take before it gets destroyed
    public int criticalDamage = 50; // %50
    public int criticalChance = 10; // %10

    [Header("Spread Shot Settings")]
    public int spreadCount = 1; // Number of bullets to spread (1 means normal, 3 means spread shot)
    public float spreadAngle = 10f; // Angle between the spread bullets

    private float timer; // Timer to track the bullet's life
    private bool hasSpread = false; // Flag to ensure the bullet only spreads once
    [Header("Simply reverted bullets or angled ricochets")]
    public bool simpleRicochet = true;
    public bool isRicochet = false;
    public bool explosion = false;
    private Vector2 direction;

    void Start(){
        direction = transform.right;

    }
    void Update()
    {
        // Check if the bullet needs to be destroyed after a delay
        if ((timer += Time.deltaTime) > deleteDelay)
        {
            Destroy(gameObject);
        }
        else
        {
            // Move the bullet forward
            transform.position += (Vector3)direction * Time.deltaTime * speed;
        }

        // Destroy the bullet if its health reaches zero
        if (bulletHp <= 0)
        {
            Destroy(gameObject);
        }

        // Handle spread shot behavior if enabled and not yet spread
        if (spreadCount > 1 && !hasSpread)
        {
            SpreadShot();
        }
    }

    // Function to spread the shot into multiple bullets
    // Function to spread the shot into multiple bullets
    private void SpreadShot()
    {
        // Mark that the spread has occurred to avoid repeating it
        hasSpread = true;

        // Create the bullets based on spreadCount
        int halfSpreadCount = spreadCount / 2;

        // For even spreadCount, you need an additional bullet in the center
        // Calculate the total number of bullets, including the center bullet
        int totalBullets = spreadCount;

        // Create bullets, including the center bullet at the 0 angle
        for (int i = -halfSpreadCount; i <= halfSpreadCount; i++)
        {
            // Check if the spread count is even and avoid creating an extra bullet
            if (spreadCount % 2 == 0 && i == 0) continue; // Skip the center bullet if spreadCount is even

            // Create a new bullet
            GameObject newBullet = Instantiate(gameObject, transform.position, transform.rotation);

            // Calculate the spread direction for each new bullet
            float spreadDirection = transform.eulerAngles.z + (i * spreadAngle);

            // Set the new bullet's direction based on the calculated angle
            newBullet.transform.eulerAngles = new Vector3(0, 0, spreadDirection);

            // Set the new bullet's speed and other properties (if needed)
            BulletScript bulletScript = newBullet.GetComponent<BulletScript>();
            bulletScript.speed = this.speed;  // Maintain the original bullet's speed
            bulletScript.damage = this.damage; // Maintain the original bullet's damage
            bulletScript.deleteDelay = this.deleteDelay; // Maintain the delete delay
            bulletScript.bulletHp = this.bulletHp; // Maintain the bullet health

            // Disable spread for the newly created bullet (to prevent further spreading)
            bulletScript.hasSpread = true;  // Mark these new bullets as already spread

            // Activate the new bullet
            newBullet.SetActive(true);
        }

        // Disable the current bullet (as it has split into new bullets)
        Destroy(gameObject);
    }

    [HideInInspector]
    public void StraightRicochet()
    {
        transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + 180);
        direction = -direction;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    [HideInInspector]
    public void AngledRicochet()
    {
        Debug.Log("Angled Ricochet not implemented yet!");
    }
    /*
        void OnCollisionEnter2D(Collision2D collision){
            if(simpleRicochet&&collision.gameObject.CompareTag("HurtBox")){
                Debug.Log("help");
                StraightRicochet();
            }
            else if(!simpleRicochet&&collision.gameObject.CompareTag("HurtBox")){
                AngledRicochet();
            }
        }*/

}
