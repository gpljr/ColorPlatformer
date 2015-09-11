using UnityEngine;
using System.Collections;

public class ColliderPlatform : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(gameObject.GetComponent<ColoredPlatform>().ObjectEnabled)
		{//enable
			gameObject.layer = 0;

		}else{//disable
			gameObject.layer = 10;
		}
	}
}
