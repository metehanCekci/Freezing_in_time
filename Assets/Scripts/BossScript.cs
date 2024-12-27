using UnityEngine;

public class BossScript : MonoBehaviour
{
    [Header("Kol Ayarlarý")]
    public GameObject leftArm; // Sol kol nesnesi
    public GameObject rightArm; // Sað kol nesnesi
    public Transform leftArmBasePos; // Sol kolun baþlangýç pozisyonu
    public Transform rightArmBasePos; // Sað kolun baþlangýç pozisyonu
    public Transform playerTarget; // Oyuncu hedefi
    public float speed = 5f; // Hareket hýzý

    public bool attacking = false; // Saldýrý durumu

    void Update()
    {
        if (attacking)
        {
            // Saldýrý modunda kollarý oyuncuya doðru hareket ettir
            MoveArmToTarget(leftArm, playerTarget.position);
            MoveArmToTarget(rightArm, playerTarget.position);
        }
        else
        {
            // Saldýrý sona erdiðinde kollarý baþlangýç pozisyonlarýna geri döndür
            MoveArmToTarget(leftArm, leftArmBasePos.position);
            MoveArmToTarget(rightArm, rightArmBasePos.position);
        }
    }

    private void MoveArmToTarget(GameObject arm, Vector3 targetPosition)
    {
        arm.transform.position = Vector3.MoveTowards(arm.transform.position, targetPosition, speed * Time.deltaTime);

        // Hedefe ulaþtýðýnda log ver
        if (Vector3.Distance(arm.transform.position, targetPosition) < 0.1f)
        {
            Debug.Log($"{arm.name} hedefe ulaþtý: {targetPosition}");
        }
    }

    public void StartAttack()
    {
        Debug.Log("Saldýrý baþlatýlýyor!");
        attacking = true; // Saldýrý modunu etkinleþtir
    }

    public void EndAttack()
    {
        Debug.Log("Saldýrý sona erdi, kollar baþlangýç pozisyonlarýna dönüyor!");
        attacking = false; // Saldýrý modunu devre dýþý býrak
    }
}
