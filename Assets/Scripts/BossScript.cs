using UnityEngine;
using System.Collections;

public class BossScript : MonoBehaviour
{
    public GameObject controlledObject; // Hareket ettirilecek nesne
    public Transform targetObject; // Hedef nesne
    public float speed = 3f; // Hareket h�z�

    private Animator animator;
    private bool isMoving = false; // Hareket durumu
    private bool attack = false; // Sald�r� durumu
    private bool isCooldown = false; // Sald�r� cooldown kontrol�

    public float attackCooldown = 2f; // Sald�r� aras�ndaki bekleme s�resi

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (attack && !isCooldown)
        {
            // Hedefe do�ru hareketi kontrol et
            if (controlledObject != null && targetObject != null)
            {
                MoveControlledObject();
            }
        }
        else
        {
            animator.SetBool("attacking", false); // Sald�r�y� durdur
        }
    }

    private void MoveControlledObject()
    {
        // Kontrol edilen nesneyi hedefe do�ru hareket ettir
        float newX = Mathf.MoveTowards(controlledObject.transform.position.x, targetObject.position.x, speed * Time.deltaTime);
        controlledObject.transform.position = new Vector2(newX, controlledObject.transform.position.y);

        // Hedefe ula�t�ysa hareketi durdur ve rastgele bir sald�r� ba�lat
        if (Mathf.Abs(controlledObject.transform.position.x - targetObject.position.x) <= 0.01f) // Daha hassas kontrol
        {
            controlledObject.transform.position = new Vector2(targetObject.position.x, controlledObject.transform.position.y); // Pozisyonu tam hizala
            isMoving = false;
            StartCoroutine(HandleAttack());
        }
    }

    private IEnumerator HandleAttack()
    {
        isCooldown = true; // Cooldown ba�lat

        // Rastgele bir sald�r� se�
        int randomAttack = Random.Range(0, 2);
        if (randomAttack == 0)
        {
            Debug.Log("Sald�r� 1 ba�lad�!");
            animator.SetBool("attacking", true);
        }
        else
        {
            Debug.Log("Sald�r� 2 ba�lad�!");
            animator.SetBool("attacking", true);
        }

        yield return new WaitForSeconds(attackCooldown); // Cooldown s�resi boyunca bekle
        isCooldown = false; // Cooldown sona erdi
        attack = false; // Yeni bir sald�r� i�in haz�r
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Temas alg�land�!");
            targetObject = collision.transform; // Hedef nesneyi ayarla
            attack = true; // Sald�r�y� ba�lat
        }
    }

    public void attacking()
    {
        // Sald�r� s�ras�nda collider'� etkinle�tir
        gameObject.GetComponent<CircleCollider2D>().enabled = true;
    }

    public void attackingEnd()
    {
        // Sald�r� sona erdi�inde collider'� devre d��� b�rak
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
    }
}
