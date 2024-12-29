using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealthScript : MonoBehaviour
{
    public int hp = 2;
    public int timeReward = 5;
    public int timeRewardScale = 0;
    public int exp = 50;
    
    public float offset;
    private GameObject player;
    //private GameObject SFXPlayer;
    private AudioManager audioManager;
    public GameObject explosion;
    private SpriteRenderer spriteRenderer;  // SpriteRenderer bileşeni için bir referans

    public GameObject criticalText;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();  // SpriteRenderer bileşenini al
        //SFXPlayer = GameObject.FindGameObjectWithTag("SFX");
        audioManager = AudioManager.Instance; 
    }

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Bullet")) //Snow
        {
            int roll = Random.Range(0,100);

            if(roll>= other.gameObject.GetComponent<BulletScript>().criticalChance)
            {
                hp -= other.gameObject.GetComponent<BulletScript>().damage;
            }
            else
            {
                GameObject clone = Instantiate(criticalText);
                clone.transform.position = this.gameObject.transform.position;
                clone.transform.position += transform.right * offset;
                clone.SetActive(true);
                hp -= (((other.gameObject.GetComponent<BulletScript>().damage/100) * other.gameObject.GetComponent<BulletScript>().criticalDamage) +  other.gameObject.GetComponent<BulletScript>().damage);
            }

            if(other.gameObject.GetComponent<BulletScript>().explosion)
            {

                GameObject clone = Instantiate(explosion);
                if(roll>= other.gameObject.GetComponent<BulletScript>().criticalChance)
                clone.GetComponent<ExplosionEffect>().damage += ( (clone.GetComponent<ExplosionEffect>().damage/100) *  other.gameObject.GetComponent<BulletScript>().criticalDamage);
                clone.transform.position = other.gameObject.transform.position;
                clone.SetActive(true);

            }

            

            if(other.gameObject.GetComponent<BulletScript>().isRicochet){
                if(other.gameObject.GetComponent<BulletScript>().simpleRicochet) other.gameObject.GetComponent<BulletScript>().StraightRicochet();
                else other.gameObject.GetComponent<BulletScript>().AngledRicochet();
            }

            // Burada renk değişikliği yapılacak
            StartCoroutine(ChangeColorTemporarily());

            other.gameObject.GetComponent<BulletScript>().bulletHp--;

            if (hp <= 0)
            {
                player.GetComponent<AnimatedController>().GainExp();
                player.GetComponent<AnimatedController>().GainBullet(timeReward += ((timeReward/100) * timeRewardScale));
                //SFXPlayer.gameObject.GetComponent<SFXScript>().PlayHit();
                //audioManager.PlaySFX("Hit");
                Destroy(this.gameObject);
                Expmanager.Instance.AddExperience(exp);
            }
        }

        else if(other.gameObject.CompareTag("Explosion"))
        {
            hp -= other.gameObject.GetComponent<ExplosionEffect>().damage;
        }

        else if (other.gameObject.CompareTag("Ball"))
        {
            hp -= other.gameObject.GetComponent<PlanetOrbit>().damage;

            // Burada renk değişikliği yapılacak
            StartCoroutine(ChangeColorTemporarily());

            if (hp <= 0)
            {
                player.GetComponent<AnimatedController>().GainExp();
                player.GetComponent<AnimatedController>().GainBullet(timeReward);
                Destroy(this.gameObject);
                Expmanager.Instance.AddExperience(exp);

            }
        }
    }

    // Rengini kısa bir süreliğine kırmızıya döndüren coroutine
    private IEnumerator ChangeColorTemporarily()
    {
        // Rengi kırmızıya çevir
        spriteRenderer.color = Color.red;

        // 0.1 saniye bekle
        yield return new WaitForSeconds(0.1f);

        // Rengi eski haline döndür
        spriteRenderer.color = Color.white;
    }
}
