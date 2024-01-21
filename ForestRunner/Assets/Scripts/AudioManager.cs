using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("------------------- Audio Source -----------------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("------------------- Audio Clip -------------------")]

    public AudioClip background;
    public AudioClip deathpanel;
    // public AudioClip diamond;


    PlayerMove playerMove;
    
    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();  // inspectorda loop'a alýnmýþ background music
   
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);  // tek seferde çalýþtýrýlacak efekt
       
    }

    public void DeathPlaySFX(AudioClip clip)       // Sadece Deathpanele özel fonksiyon background music disable etmesi için
    {
        SFXSource.PlayOneShot(clip);  // tek seferde çalýþtýrýlacak efekt
        musicSource.Stop();
    }
}

