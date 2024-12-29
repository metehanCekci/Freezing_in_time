using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class ProgressBar : MonoBehaviour
{
    public int maximum = 100;
    public int current = 0;
    public Image mask;

    void Start()
    {
        if (mask == null)
        {
            Debug.LogError("Mask is not assigned in the ProgressBar script!", this);
        }
    }

    public void SetProgress(int xp, int maxXp)
    {
        current = xp;
        maximum = maxXp;
        GetCurrentFill();
    }

    void GetCurrentFill()
    {
        if (maximum > 0)
        {
            float fillAmount = (float)current / (float)maximum;
           mask.fillAmount = fillAmount;
            Debug.Log("OZAN");
        }
        else
        {
            Debug.LogError("Maximum value must be greater than 0!", this);
        }
    }
}
