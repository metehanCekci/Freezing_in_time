using UnityEngine;

public class SFXScript : MonoBehaviour
{
    public AudioClip hit;
    public AudioClip damage;
    public AudioClip gunshot;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayHit()
    {
        this.gameObject.GetComponent<AudioSource>().PlayOneShot(hit);
    }

    public void PlayDamage()
    {
        this.gameObject.GetComponent<AudioSource>().PlayOneShot(damage);
    }

    public void PlayGunShot()
    {
        this.gameObject.GetComponent<AudioSource>().PlayOneShot(gunshot);
    }
}
