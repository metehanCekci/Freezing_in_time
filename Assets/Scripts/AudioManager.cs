using System;
using UnityEngine;
using System.Collections.Generic;
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource,sfxSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void PlayMusic(string name){
        Sound s = Array.Find(musicSounds, x=> x.name == name);
        if(s==null){
            Debug.Log("Music file not found!");
        }
        else{
            musicSource.clip = s.clip; 
            musicSource.Play();
        }
    }

    public void PlaySFX(string name){
        Sound s = Array.Find(sfxSounds, x=> x.name == name);
        if(s == null){
            Debug.Log("SFX file not found!");
        }
        else{
            sfxSource.PlayOneShot(s.clip);
        }
    }

    public void ToggleMusic(){
        musicSource.mute = !musicSource.mute;
    }

    public void ToggleSFX(){
        sfxSource.mute = !sfxSource.mute;
    }

    public void MusicVolume(float volume){
        musicSource.volume = volume;
    }

    public void SFXVolume(float volume){
        sfxSource.volume = volume;
    }

    void Awake(){
        if(Instance==null){
            Instance=this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(Instance);
        }
    }
    void Start()
    {
        //PlayMusic("Theme");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
