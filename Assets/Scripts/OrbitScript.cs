using UnityEngine;

public class PlanetOrbit : MonoBehaviour
{
    public Transform center;  // Karakterin pozisyonunu referans alacağız
    public float orbitSpeed = 10f;  // Yörünge hızını belirleyeceğiz
    public float orbitRadius = 5f;  // Yörüngenin çapı

    public int damage = 8;
    public bool isSecondPlanetActive = false;  // İkinci gezegenin hareketi aktif mi?

    private float angle = 0f;  // Başlangıçtaki açı
    private float oppositeAngleOffset = 180f;  // İkinci gezegenin açısı, ilk gezegenin tam karşısı

    private void Start() {
        center = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        if (center != null)
        {
            // Eğer ikinci gezegenin hareketi aktifse, farklı bir açı ile dönecek
            if (isSecondPlanetActive)
            {
                // Gezegenin karşısına geçmek için açıyı 180 derece kaydırıyoruz
                angle += orbitSpeed * Time.deltaTime;  // Zamanla açıyı arttır

                // İkinci gezegenin başlangıç açısını kaydırıyoruz
                float x = center.position.x + Mathf.Cos((angle + oppositeAngleOffset) * Mathf.Deg2Rad) * orbitRadius;
                float y = center.position.y + Mathf.Sin((angle + oppositeAngleOffset) * Mathf.Deg2Rad) * orbitRadius;

                // Gezegenin pozisyonunu güncelle
                transform.position = new Vector3(x, y, transform.position.z);
            }
            else
            {
                // İlk gezegen normal şekilde dönecek
                angle += orbitSpeed * Time.deltaTime;  // Zamanla açıyı arttır

                // İlk gezegenin pozisyonunu hesapla
                float x = center.position.x + Mathf.Cos(angle * Mathf.Deg2Rad) * orbitRadius;
                float y = center.position.y + Mathf.Sin(angle * Mathf.Deg2Rad) * orbitRadius;

                // Gezegenin pozisyonunu güncelle
                transform.position = new Vector3(x, y, transform.position.z);
            }
        }
    }
}
