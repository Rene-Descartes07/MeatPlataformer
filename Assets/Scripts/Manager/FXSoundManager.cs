using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FXSoundManager : MonoBehaviour
{
    public static FXSoundManager instance;

    [SerializeField] AudioSource soundFX, soundFX2;
    [SerializeField] AudioClip[] clipsFX;
    public Slider sliderFX;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        if (PlayerPrefs.HasKey("MusicFX"))
        {
            soundFX.volume = PlayerPrefs.GetFloat("MusicFX");
            soundFX2.volume = PlayerPrefs.GetFloat("MusicFX");
        }
        else
        {
            PlayerPrefs.SetFloat("MusicFX", sliderFX.value);
            sliderFX.value = 1;
        }

        //DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        SettingMusicFXUpdate();
    }

    void SettingMusicFXUpdate()
    {
        soundFX.volume = PlayerPrefs.GetFloat("MusicFX");
        soundFX2.volume = PlayerPrefs.GetFloat("MusicFX");
        sliderFX.value = PlayerPrefs.GetFloat("MusicFX");
    }

    public void SaveSoundFX()
    {
        PlayerPrefs.SetFloat("MusicFX", sliderFX.value);
    }

    public void PlaySoundFX(int index)
    {
        soundFX.clip = clipsFX[index];
        soundFX.Play();
    }

    public void PlaySoundFX2(int index)
    {
        soundFX2.clip = clipsFX[index];
        soundFX2.Play();
    }
}
