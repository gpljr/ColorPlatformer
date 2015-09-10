using UnityEngine;
using System.Collections;

public class ReloadToCheckpoint : MonoBehaviour {

	[SerializeField]
	private Checkpoint[] orderedCheckpoints;

	public void Reload()
	{
		Checkpoint lastPassed = null;
		foreach(Checkpoint c in orderedCheckpoints)
		{
			if(c.passed) lastPassed = c;
		}

		GameObject.FindGameObjectWithTag ("Player").transform.position = lastPassed.SpawnPosition;
	}

	void Update() {
		if (Input.GetKey (KeyCode.Escape)) {
			Application.Quit ();
		} else if (Input.GetKey (KeyCode.Delete) || Input.GetKey (KeyCode.Backspace)) {
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}
