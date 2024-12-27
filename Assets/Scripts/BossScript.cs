using UnityEngine;

public class BossScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void attacking()
    {
        gameObject.GetComponent<CircleCollider2D>().enabled = true;
    }
    public void attackingEnd()
    {
        gameObject.GetComponent <CircleCollider2D>().enabled = false;
    }
}
