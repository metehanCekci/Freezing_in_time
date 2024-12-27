using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField]
    int currentHealth, maxHealth,
             currentExperience, maxExperience,
             currentLevel;

    private void OnEnable()
    {
        Expmanager.Instance.OnExperienceChange += ExpChange;

    }

    private void OnDisable()
    {
        Expmanager.Instance.OnExperienceChange -= ExpChange;
    }
    private void ExpChange(int newExperience)
    {
        currentExperience += newExperience;
        if (currentExperience >= maxExperience)
        {
            LevelUp();
        }
    }
    private void LevelUp()
    {
        currentLevel++;
        currentExperience = 0;
        maxExperience += 100;
    }

    

    }
