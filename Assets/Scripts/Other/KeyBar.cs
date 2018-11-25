using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyBar : MonoBehaviour {

    public Sprite[] keyBar;
    public Image keyBarUI;

    private Player player;
	
	void Start () {
        player = FindObjectOfType<Player>();
    }
	
	void Update () {
        keyBarUI.sprite = keyBar[player.key];
	}
}
