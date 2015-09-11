using UnityEngine;
using System.Collections;

public class ColliderPlatformOneWay : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(gameObject.GetComponent<ColoredPlatform>().ObjectEnabled)
		{//enable
			gameObject.layer = 9;

		}else{//disable
			gameObject.layer = 10;
		}
	}
}
