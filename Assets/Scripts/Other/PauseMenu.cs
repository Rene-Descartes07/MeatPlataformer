using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance;

    public bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    public GameObject setting;

    public Button buttonPlay; // Variavel que seleciona o Resume assim que o jogo pausa
    public Button optionButton; //Variavel para concertar o problema do Resume
    public GameObject obj; //Variavel que controla qual GameObject esta selecionado

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == null)
        {
            EventSystem.current.SetSelectedGameObject(obj);
        }
        else
        {
            obj = EventSystem.current.currentSelectedGameObject;
        }

        if (GameManager.instance.currentState == GameState.POPUP)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
                buttonPlay.Select();
            }
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        setting.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        GameManager.instance.changeState(GameState.GAMEPLAY);
        optionButton.Select();
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        GameManager.instance.changeState(GameState.PAUSE);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}


