using UnityEngine;

public class BossScript : MonoBehaviour
{
    [Header("Kol Ayarlar�")]
    public GameObject leftArm; // Sol kol nesnesi
    public GameObject rightArm; // Sa� kol nesnesi
    public Transform leftArmBasePos; // Sol kolun ba�lang�� pozisyonu
    public Transform rightArmBasePos; // Sa� kolun ba�lang�� pozisyonu
    public Transform playerTarget; // Oyuncu hedefi
    public float speed = 5f; // Hareket h�z�

    public bool attacking = false; // Sald�r� durumu

    void Update()
    {
        if (attacking)
        {
            // Sald�r� modunda kollar� oyuncuya do�ru hareket ettir
            MoveArmToTarget(leftArm, playerTarget.position);
            MoveArmToTarget(rightArm, playerTarget.position);
        }
        else
        {
            // Sald�r� sona erdi�inde kollar� ba�lang�� pozisyonlar�na geri d�nd�r
            MoveArmToTarget(leftArm, leftArmBasePos.position);
            MoveArmToTarget(rightArm, rightArmBasePos.position);
        }
    }

    private void MoveArmToTarget(GameObject arm, Vector3 targetPosition)
    {
        arm.transform.position = Vector3.MoveTowards(arm.transform.position, targetPosition, speed * Time.deltaTime);

        // Hedefe ula�t���nda log ver
        if (Vector3.Distance(arm.transform.position, targetPosition) < 0.1f)
        {
            Debug.Log($"{arm.name} hedefe ula�t�: {targetPosition}");
        }
    }

    public void StartAttack()
    {
        Debug.Log("Sald�r� ba�lat�l�yor!");
        attacking = true; // Sald�r� modunu etkinle�tir
    }

    public void EndAttack()
    {
        Debug.Log("Sald�r� sona erdi, kollar ba�lang�� pozisyonlar�na d�n�yor!");
        attacking = false; // Sald�r� modunu devre d��� b�rak
    }
}
