using Unity.Cinemachine;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    [SerializeField] public GameObject[] enemies;  // Yaratıkların dizisi

    public GameObject player;
    public GameObject boss;
    [SerializeField] private float spawnInterval = 5f;
 // Yaratık çağırma aralığı

    public bool summonsBoss = false;
    private float startingInterval;
    [SerializeField] private Vector2 spawnRange = new Vector2(-5f, 5f);  // Yaratıkların spawn olacağı x ekseni aralığı
    [SerializeField] private float spawnHeight = 0f;  // Yaratıkların y eksenindeki pozisyonu

    private float nextSpawnTime = 0f;  // Bir sonraki yaratık spawn zamanı
    private float bossSpawnTime = 5f;
    private float timeSinceLastLevelUp = 0f; // Seviye atlamadan geçen süre
    private int level = 0; // Spawner seviyesi

    public WarningText wt;

    private void Start() {
        startingInterval = spawnInterval;
    }

    void Update()
    {
        // Eğer şu anki zaman, bir sonraki spawn zamanından büyükse, yeni yaratık spawn et
        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();  // Yaratığı spawn et
            nextSpawnTime = Time.time + spawnInterval;  // Bir sonraki spawn için zamanı ayarla
            if(startingInterval>0.02f)
                startingInterval -= 0.03f;
            if(startingInterval>1.25f)
                spawnInterval = Random.Range(startingInterval-1,startingInterval+1);
        }

        if(Time.time >= bossSpawnTime)
        {
            if(summonsBoss)
            {
            GameObject clone = Instantiate(boss);
            clone.transform.position = player.transform.position;        
            clone.SetActive(true);

            boss.GetComponent<EnemyHealthScript>().hp = Mathf.CeilToInt(clone.GetComponent<EnemyHealthScript>().hp*1.45f);
            boss.GetComponent<EnemyHealthScript>().exp = Mathf.CeilToInt(clone.GetComponent<EnemyHealthScript>().exp*1.5f);
            boss.GetComponent<EnemyHealthScript>().timeReward = Mathf.CeilToInt(boss.GetComponent<EnemyHealthScript>().timeReward*1.2f);

            bossSpawnTime += bossSpawnTime;
            }
        }

        // Seviye atlamak için 5 dakika geçip geçmediğini kontrol et
        timeSinceLastLevelUp += Time.deltaTime;
        if (timeSinceLastLevelUp >= 90f) // 5 dakika = 300 saniye
        {
            LevelUp(); // Seviye atla
            timeSinceLastLevelUp = 0f; // Zamanı sıfırla
        }
    }

    private void LevelUp()
    {
        wt.TriggerVisibilityCycle();
        level++; // Seviyeyi artır
        Debug.Log("Level Up! Current Level: " + level);

        // Düşmanların HP değerlerini 2 katına çıkar
        foreach (var enemy in enemies)
        {
            EnemyHealthScript enemyHealth = enemy.GetComponent<EnemyHealthScript>();
            if (enemyHealth != null)
            {
                enemyHealth.hp = Mathf.CeilToInt(enemyHealth.hp*1.45f); // HP'yi iki katına çıkar
                enemyHealth.exp = Mathf.CeilToInt(enemyHealth.exp*1.5f);
                enemyHealth.timeReward = Mathf.CeilToInt(enemyHealth.timeReward*1.2f);
            }
        }
    }

    // Yaratık spawn fonksiyonu
    private void SpawnEnemy()
    {
        if (enemies.Length > 0) // Eğer yaratık dizisi boş değilse
        {
            // Diziden rastgele bir yaratık seç
            int randomIndex = Random.Range(0, 12);

            GameObject enemyToSpawn = null;

            if(randomIndex>= 0 && randomIndex<=7)
            {
                enemyToSpawn = enemies[0];
            }
            
            else if(randomIndex>=8 && randomIndex<=10)
            {
                enemyToSpawn = enemies[1];
            }
            
            else if(randomIndex == 11)
            {
                enemyToSpawn = enemies[2];
            }

            // Yaratığın spawn edileceği x pozisyonunu rastgele belirle

            // Yeni yaratığı spawn et
            GameObject clone = Instantiate(enemyToSpawn);
            clone.transform.position = new Vector3(this.transform.position.x, spawnHeight, 0); // Spawn Y pozisyonu da belirtildi

            clone.SetActive(true);
            if (clone.gameObject.GetComponent<FlyEnemyAi>() != null) 
            {
                clone.GetComponent<FlyEnemyAi>().enabled = true;
            }
            
        }
    }
}
