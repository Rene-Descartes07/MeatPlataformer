using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public static UIManager instance;
    public int score;
    public Text scoreText;
    public GameObject painelWin;
    public GameObject painelLose;

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
    }

    public void SetScore(int scorePoints)
    {
        score += scorePoints;
        scoreText.text = score.ToString();
    }

    public void WinGameUI()
    {
        StartCoroutine(WinGameState());
    }

    public void LoseGameUI()
    {
        StartCoroutine(LoseGameState());
    }

    IEnumerator WinGameState()
    {
        GameManager.instance.changeState(GameState.POPUP);
        yield return new WaitForSeconds(1.3f);
        painelWin.SetActive(true);
        BGSoundManager.instance.soundBG.Stop();
        FXSoundManager.instance.PlaySoundFX(5);
    }

    IEnumerator LoseGameState()
    {
        GameManager.instance.changeState(GameState.POPUP);
        yield return new WaitForSeconds(1.3f);
        painelLose.SetActive(true);
        BGSoundManager.instance.soundBG.Stop();
        FXSoundManager.instance.PlaySoundFX(6);
    }
}
