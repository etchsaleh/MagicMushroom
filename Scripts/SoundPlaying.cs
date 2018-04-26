using UnityEngine;
using System.Collections;

public class SoundPlaying : MonoBehaviour {

	public AudioSource bgMusic;

	// Use this for initialization
	void Start () {
		bgMusic = GetComponent<AudioSource>();
		if (LevelManager.isPlaying == true)
			bgMusic.Play ();

	}
}
