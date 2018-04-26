using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

  public GameObject Enemy;
  float spawnTime = 1.5f;
  public Transform spawnPoint;

	// Use this for initialization
	void Start () {
		InvokeRepeating("Spawning", spawnTime, spawnTime);
	}

	// Update is called once per frame
	void Spawning () {
        Instantiate(Enemy, spawnPoint.position, spawnPoint.rotation);
	}
}
