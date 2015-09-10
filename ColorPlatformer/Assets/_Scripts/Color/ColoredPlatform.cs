using UnityEngine;
using System.Collections;

public class ColoredPlatform : MonoBehaviour {

	[SerializeField]
	private MoodManager.Mood _mood;
	public MoodManager.Mood mood {
		get {
			return _mood;
		}
		set {
			_mood = value;
			UpdatePlatformColor();
		}
	}

	// Use this for initialization
	void Start () {
		foreach(Renderer r in GetComponentsInChildren<Renderer>())
		{
			r.material.color = MoodManager.GetColorForMood(mood);
		}
	}

	void UpdatePlatformColor()
	{
		var components = GetComponentsInChildren<Renderer> ();
		var targetColor = MoodManager.GetColorForMood (mood);
		foreach(Renderer r in GetComponentsInChildren<Renderer>())
		{
			LeanTween.color (r.gameObject, targetColor, 0.5f);
		}
	}


}
