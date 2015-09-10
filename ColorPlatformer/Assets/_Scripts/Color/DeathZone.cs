using UnityEngine;
using System.Collections;

public class DeathZone : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") {
            AudioManager.instance.DeathSound();
            Invoke("DoReload", 0.15f);
		}
	}

    private void DoReload()
    {
        GameObject.FindGameObjectWithTag("Respawn").GetComponent<ReloadToCheckpoint>().Reload();
    }
}
