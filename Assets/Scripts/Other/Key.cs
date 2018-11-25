using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

    private Player player;

    void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FXSoundManager.instance.PlaySoundFX2(4);
            player.key += 1;
            gameObject.SetActive(false);
        }
    }
}
