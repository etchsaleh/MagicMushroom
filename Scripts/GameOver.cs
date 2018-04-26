using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
	public Image overlayImage;
	public Text gameoverText;
	public Text scoreText;

	// Update is called once per frame
	void Update () {
		if (Player.isDead == true) {
			overlayImage.enabled = true;
			gameoverText.enabled = true;
			scoreText.enabled = true;
			Camera.current.enabled = false;
		}
	}
}
