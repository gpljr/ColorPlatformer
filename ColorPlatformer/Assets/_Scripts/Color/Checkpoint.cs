using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

	public bool passed { get; private set; }

	public Vector3 SpawnPosition { get; private set; }

	// Use this for initialization
	void Start () {
		passed = false;
		SpawnPosition = transform.Find ("SpawnPosition").transform.position;
	}

	void OnTriggerEnter2D (Collider2D other) {
		passed = true;
	}
}
