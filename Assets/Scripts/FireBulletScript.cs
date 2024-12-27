using UnityEngine;

public class FireBulletScript : MonoBehaviour
{
    public float speed = 10f; // Merminin hareket hızı
    private Vector2 direction; // Merminin hareket yönü

    private void Awake()
    {
        // Oyuncuyu 'Player' tag'ı ile bul
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;

        // Merminin hareket yönünü oyuncudan almak
        Vector2 playerPosition = player.position; // Oyuncunun pozisyonu
        direction = (playerPosition - (Vector2)transform.position).normalized; // Merminin hareket yönü (normalize edilmiş)
        Destroy(this.gameObject,3);
    }

    private void Update()
    {
        // Mermiyi belirlenen yönde hareket ettir
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Mermi bir nesneye çarptığında, mermi yok olmalı
        Destroy(gameObject);
    }
}
