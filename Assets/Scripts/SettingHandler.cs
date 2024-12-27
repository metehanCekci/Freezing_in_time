using UnityEngine;
using UnityEngine.UI;
public class SettingHandler : MonoBehaviour
{

    public Slider musicSlider, sfxSlider;

   
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void ToggleMusic(){
        AudioManager.Instance.ToggleMusic(); //buton tanıtırsak bu fonksiyonları onlara atayabiliriz
    }

    public void ToggleSFX(){
        AudioManager.Instance.ToggleSFX();
    }

    public void MusicVolume(){
        AudioManager.Instance.MusicVolume(musicSlider.value);
    }

    public void SFXVolume(){
        AudioManager.Instance.SFXVolume(sfxSlider.value);
    }

    
}
