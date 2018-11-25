using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    GAMEPLAY,
    PAUSE,
    MORTE,
    POPUP
}

public class GameManager : MonoBehaviour
{
    public GameState currentState;

    public static GameManager instance;

    public int fase = -1;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        SceneManager.sceneLoaded += VerificaFase;
    }

    public void changeState(GameState newState)
    {
        currentState = newState;
    }

    void VerificaFase(Scene cena, LoadSceneMode modo)
    {
        fase = SceneManager.GetActiveScene().buildIndex;

        if (fase != 1)
        {
            changeState(GameState.GAMEPLAY);
        }
    }
}
