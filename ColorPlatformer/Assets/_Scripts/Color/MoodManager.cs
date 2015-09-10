using UnityEngine;
using System.Collections;
using System.Linq;

public class MoodManager : MonoBehaviour {

	private Collider2D[] angryColliders, happyColliders, regretfulColliders;

	public enum Mood { Angry, Happy, Regretful };

	[SerializeField]
	private Mood _mood;
	public Mood mood {
		get {
			return _mood;
		}
		set {
			_mood = value;
			UpdateBackgroundColor();
			UpdateColliders ();
		}
	}

	// Use this for initialization
	void Start () {

		var coloredPlatforms = Object.FindObjectsOfType<ColoredPlatform> ();

		angryColliders = coloredPlatforms.Where ((p) => p.mood == Mood.Angry).SelectMany ((p) => p.GetComponentsInChildren<Collider2D> ()).ToArray ();
		happyColliders = coloredPlatforms.Where ((p) => p.mood == Mood.Happy).SelectMany ((p) => p.GetComponentsInChildren<Collider2D> ()).ToArray ();
		regretfulColliders = coloredPlatforms.Where ((p) => p.mood == Mood.Regretful).SelectMany ((p) => p.GetComponentsInChildren<Collider2D> ()).ToArray ();

		UpdateColliders ();

		foreach(Renderer r in GetComponentsInChildren<Renderer>())
		{
			r.material.color = MoodManager.GetColorForMood (mood);
		}
	}
	
	void UpdateBackgroundColor()
	{
		var components = GetComponentsInChildren<Renderer> ();
		var targetColor = MoodManager.GetColorForMood (mood);
		foreach(Renderer r in GetComponentsInChildren<Renderer>())
		{
			LeanTween.color (r.gameObject, targetColor, 0.5f);
		}
	}

	private void UpdateColliders()
	{
		foreach(Collider2D c in angryColliders) {
			c.isTrigger = (mood == Mood.Angry);
		}
		foreach(Collider2D c in happyColliders) {
			c.isTrigger = (mood == Mood.Happy);
		}
		foreach(Collider2D c in regretfulColliders) {
			c.isTrigger = (mood == Mood.Regretful);
		}
	}

	public static Color GetColorForMood(Mood mood)
	{
		switch(mood) {
		case Mood.Angry:
			return new Color(0.8f, 0.3f, 0.2f);
		case Mood.Happy:
			return new Color(0.2f, 0.8f, 0.2f);
		case Mood.Regretful:
			return new Color(0.2f, 0.2f, 0.8f);
			
		default:
			return new Color(1f, 0f, 1f);
		}
	}
}
