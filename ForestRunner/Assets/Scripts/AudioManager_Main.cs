using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager_Main : MonoBehaviour
{
    [Header("------------------- Audio Source -----------------")]
    [SerializeField] AudioSource musicSource_main;
    [SerializeField] AudioSource SFXSource_main;


    [Header("------------------- Audio Clip -------------------")]

    public AudioClip background_main;    
    public AudioClip buttonClick;
    public AudioClip buyHealth;

    private void Start()
    {
        musicSource_main.clip = background_main;
        musicSource_main.Play();  // inspectorda loop'a alýnmýþ background music

    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource_main.PlayOneShot(clip);  // tek seferde çalýþtýrýlacak efekt

    }
}
