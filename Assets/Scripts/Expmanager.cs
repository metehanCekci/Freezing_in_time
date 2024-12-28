using System;
using UnityEngine;

public class Expmanager : MonoBehaviour
{
    public static Expmanager Instance;

    public delegate void ExpChange(int amount);
    public event ExpChange OnExperienceChange;
    public LevelDisplay lvl;
    private float currentXp = 0;
    public int expMultiplier = 0;
    private float maxXp = 50;
    private ProgressBar progressBar;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        
        progressBar = GameObject.Find("XP Bar").GetComponent<ProgressBar>();
    }

    public void AddExperience(int amount)
    {
        currentXp += ((amount / 100) * expMultiplier) + amount;

      
        if (currentXp >= maxXp)
        {
            lvl.level++;
            currentXp -= maxXp;
            this.gameObject.GetComponent<LevelUpSystem>().LevelUp();
            maxXp *= 1.45f;
        }

        
        progressBar.SetProgress(Convert.ToInt32(Mathf.Round(currentXp)), Convert.ToInt32(Mathf.Round(maxXp)));

        
        OnExperienceChange?.Invoke(Convert.ToInt32(Mathf.Round(currentXp)));
    }
}
