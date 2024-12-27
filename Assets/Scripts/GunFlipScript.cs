using UnityEngine;

public class GunFlipScript : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (gameObject.transform.localRotation.eulerAngles.z > 90 && gameObject.transform.localRotation.eulerAngles.z < 270)
        {
            Debug.Log("silah �evirildi");
            spriteRenderer.flipY = true;
        }
        else
        {
            spriteRenderer.flipY = false;
        }*/
    }
}
