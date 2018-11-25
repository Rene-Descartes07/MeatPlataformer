using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSprite : MonoBehaviour {

    private Player player;

    private SpriteRenderer spriteRenderer;
    public Sprite[] doorSprite;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = FindObjectOfType<Player>();
    }

    void Update ()
    {
        if (player.key >=3)
        {
            spriteRenderer.sprite = doorSprite[1];
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && player.key >=3)
        {
            UIManager.instance.WinGameUI();
        }
    }
}
