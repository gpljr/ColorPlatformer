using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
	[SerializeField] Transform doorOut;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D other){
		if(gameObject.GetComponent<ColoredPlatform>().ObjectEnabled)
		{//enable
			//print("enter door");
			other.transform.position=doorOut.position;

		}else{//disable
			
		}

	}
}
