using TMPro;
using UnityEngine;

public class LevelDisplay : MonoBehaviour
{
    public int level = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<TMP_Text>().text = level.ToString();
    }
}