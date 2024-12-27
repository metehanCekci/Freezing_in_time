using UnityEngine;
using System.Collections;

public class BossScript : MonoBehaviour
{
    public GameObject controlledObject; // Hareket ettirilecek nesne
    public Transform targetObject; // Hedef nesne
    public float speed = 3f; // Hareket hýzý

    private Animator animator;
    private bool isMoving = false; // Hareket durumu
    private bool attack = false; // Saldýrý durumu
    private bool isCooldown = false; // Saldýrý cooldown kontrolü

    public float attackCooldown = 2f; // Saldýrý arasýndaki bekleme süresi

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (attack && !isCooldown)
        {
            // Hedefe doðru hareketi kontrol et
            if (controlledObject != null && targetObject != null)
            {
                MoveControlledObject();
            }
        }
        else
        {
            animator.SetBool("attacking", false); // Saldýrýyý durdur
        }
    }

    private void MoveControlledObject()
    {
        // Kontrol edilen nesneyi hedefe doðru hareket ettir
        float newX = Mathf.MoveTowards(controlledObject.transform.position.x, targetObject.position.x, speed * Time.deltaTime);
        controlledObject.transform.position = new Vector2(newX, controlledObject.transform.position.y);

        // Hedefe ulaþtýysa hareketi durdur ve rastgele bir saldýrý baþlat
        if (Mathf.Abs(controlledObject.transform.position.x - targetObject.position.x) <= 0.01f) // Daha hassas kontrol
        {
            controlledObject.transform.position = new Vector2(targetObject.position.x, controlledObject.transform.position.y); // Pozisyonu tam hizala
            isMoving = false;
            StartCoroutine(HandleAttack());
        }
    }

    private IEnumerator HandleAttack()
    {
        isCooldown = true; // Cooldown baþlat

        // Rastgele bir saldýrý seç
        int randomAttack = Random.Range(0, 2);
        if (randomAttack == 0)
        {
            Debug.Log("Saldýrý 1 baþladý!");
            animator.SetBool("attacking", true);
        }
        else
        {
            Debug.Log("Saldýrý 2 baþladý!");
            animator.SetBool("attacking", true);
        }

        yield return new WaitForSeconds(attackCooldown); // Cooldown süresi boyunca bekle
        isCooldown = false; // Cooldown sona erdi
        attack = false; // Yeni bir saldýrý için hazýr
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Temas algýlandý!");
            targetObject = collision.transform; // Hedef nesneyi ayarla
            attack = true; // Saldýrýyý baþlat
        }
    }

    public void attacking()
    {
        // Saldýrý sýrasýnda collider'ý etkinleþtir
        gameObject.GetComponent<CircleCollider2D>().enabled = true;
    }

    public void attackingEnd()
    {
        // Saldýrý sona erdiðinde collider'ý devre dýþý býrak
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
    }
}
