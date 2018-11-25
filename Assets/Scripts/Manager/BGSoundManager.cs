using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BGSoundManager : MonoBehaviour
{
    public static BGSoundManager instance;

    [Header("AudioSource")]
    public AudioSource soundBG;
    [Header("AudioClips")]
    public AudioClip[] songs;

    [Header("Variaves")]
    public int index;
    public Slider sliderBG;
    public int fase = -1;

    void Awake()
    {
        soundBG = GetComponent<AudioSource>();

        if (PlayerPrefs.HasKey("MusicBG"))
        {
            soundBG.volume = PlayerPrefs.GetFloat("MusicBG");
        }
        else
        {
            PlayerPrefs.SetFloat("MusicBG", sliderBG.value);
            sliderBG.value = 1;
        }

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        SceneManager.sceneLoaded += VerificaFase;
        //PlayerPrefs.DeleteAll();
    }

    void Start()
    {
        StartMusicPlayer();
    }

    void Update()
    {
        SettingMusicUpdate();
    }

    void SettingMusicUpdate()
    {
        soundBG.volume = PlayerPrefs.GetFloat("MusicBG");
        sliderBG.value = PlayerPrefs.GetFloat("MusicBG");
    }

    public void SaveMusicBG()
    {
        PlayerPrefs.SetFloat("MusicBG", sliderBG.value);
    }

    void StartMusicPlayer()
    {
        soundBG.clip = songs[index];
        //index++;
        if (index >= songs.Length)
        {
            index = 0;
        }

        soundBG.Play();
        Invoke("StartMusicPlayer", soundBG.clip.length + 0.5f);
    }

    void VerificaFase(Scene cena, LoadSceneMode modo)
    {
        fase = SceneManager.GetActiveScene().buildIndex;

        if (fase == 0)
        {
            index = 0;
        }
        else if (fase == 1)
        {
            index++;
        }
        else if (fase == 2)
        {
            index = 0;
        }
    }
}
