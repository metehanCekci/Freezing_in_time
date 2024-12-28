using UnityEngine;

public class FlyEnemyAi : MonoBehaviour
{
    public float followSpeed = 5f; // Düşmanın takip hızı
    public float rotationSpeed = 700f; // Dönme hızı (2D için)
    public float attackRange = 10f; // Saldırı menzili
    private Transform player; // Oyuncunun transform'u
    public GameObject bullet; // Saldırı için mermi prefab'ı
    private SpriteRenderer spriteRenderer;
    private bool isInAttackRange = false; // Menzilde olup olmadığını kontrol etmek için

    private float cooldownTime = 3f; // Saldırı arasındaki bekleme süresi
    private float cooldownTimer = 0f; // Cooldown süresi

    private void Awake()
    {
        // Oyuncuyu 'Player' tag'ı ile bul
        player = GameObject.FindGameObjectWithTag("Player").transform;
        spriteRenderer = spriteRenderer.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // Eğer oyuncu bulunmuşsa, onu takip et
        if (player != null)
        {
            // Oyuncunun menzile girip girmediğini kontrol et
            if (Vector2.Distance(transform.position, player.position) <= attackRange)
            {

                EnemyAttack();
                
            }
            else
            {
                FollowPlayer();

            }
        }

        // Cooldown süresi var mı?
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime; // Her frame'de cooldown süresi azalacak
        }
    }

    private void FollowPlayer()
    {
        // Oyuncuya doğru hareket et
        Vector2 direction = player.position - transform.position;
        direction.Normalize(); // Yönü normalize et

        // Dönüş (y ekseninde dönecek şekilde)
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));

        // Düşman rotasını yavaşça değiştirecek
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        
        

        // Düşman oyuncuya doğru hareket ediyor
        transform.Translate(direction * followSpeed * Time.deltaTime, Space.World);
    }
    

    private void EnemyAttack()
    {
        // Eğer cooldown süresi sıfırlanmışsa, saldırıyı yap
        if (cooldownTimer <= 0)
        {

            // Saldırı yap
            GameObject clone = Instantiate(bullet);
            clone.transform.position = this.gameObject.transform.position;
            clone.SetActive(true);

            // Cooldown başlat
            cooldownTimer = cooldownTime;
        }
    }
}
