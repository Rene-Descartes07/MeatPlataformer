using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTrigger : MonoBehaviour
{
    private Player playerScript;

    public Text vidaText;

    void Awake()
    {
        playerScript = FindObjectOfType<Player>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (!playerScript.invunerable && playerScript.health > 1)
            {
                playerScript.DamagePlayer();
                FXSoundManager.instance.PlaySoundFX(0);
                vidaText.text = playerScript.health.ToString();
            }
            else if (!playerScript.invunerable && playerScript.health <= 1)
            {
                playerScript.DamagePlayer();
                vidaText.text = playerScript.health.ToString();
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (!playerScript.invunerable && playerScript.health > 1)
            {
                playerScript.DamagePlayer();
                FXSoundManager.instance.PlaySoundFX(0);
                vidaText.text = playerScript.health.ToString();
            }
            else if (!playerScript.invunerable && playerScript.health <= 1)
            {
                playerScript.DamagePlayer();
                vidaText.text = playerScript.health.ToString();
            }
        }
    }
}
