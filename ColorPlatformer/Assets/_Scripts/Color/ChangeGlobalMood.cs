﻿using UnityEngine;
using System.Collections;

public class ChangeGlobalMood : MonoBehaviour {

	[SerializeField]
	private MoodManager.Mood newMood;

	// Use this for initialization
	void Start () {
		GetComponent<Renderer> ().material.color = MoodManager.GetColorForMood (newMood);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") {

			var moodManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<MoodManager>();
			
			if(moodManager.mood != newMood) {
				moodManager.mood = newMood;
			}
		}
	}
	void OnDrawGizmos(){
		Gizmos.color=MoodManager.GetColorForMood(newMood);
		Gizmos.DrawSphere(transform.position, 0.6f);
	}
}
