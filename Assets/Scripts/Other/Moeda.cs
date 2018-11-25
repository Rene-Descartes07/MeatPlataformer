using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moeda : MonoBehaviour {

    public int moedas;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FXSoundManager.instance.PlaySoundFX2(3);
            UIManager.instance.SetScore(moedas);
            gameObject.SetActive(false);
        }
    }
}
