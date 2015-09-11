using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

	[SerializeField]
	private Vector3 destination;

	[SerializeField]
	private float duration = 2;

	[SerializeField]
	private Material lineMaterial;

	[SerializeField]
	private bool autoMove;

	private Vector3 originalPosition;

	private bool atOrigin = true;
	private LTDescr activeMove = null;


	// Use this for initialization
	void Start () {
		originalPosition = transform.position;
		//Vector3 centerOffset = (transform.Find ("Collider").GetComponent<BoxCollider2D> ().bounds.center - originalPosition);

		Color lineColor;
		if (GetComponent<ColoredPlatform> () != null) {
			var moodColor = MoodManager.GetColorForMood (GetComponent<ColoredPlatform> ().mood);
			lineColor = new Color (moodColor.r, moodColor.g, moodColor.b, 0.75f);
			Debug.Log (moodColor);
			Debug.Log (lineColor);
		} else {
			lineColor = new Color(0.5f, 0f, 0f);
		}


		GameObject line = new GameObject ("MovingPlatformLine");
		var lineRenderer = line.AddComponent<LineRenderer> ();
		lineRenderer.SetVertexCount (2);
		lineRenderer.SetPosition (0, transform.position);
		lineRenderer.SetPosition (1, destination);
		lineRenderer.SetWidth (0.1f, 0.1f);
		lineRenderer.SetColors (lineColor, lineColor);
		lineRenderer.material = lineMaterial;




		if (autoMove) {
			Trigger ();
		}
		// else if (switchTrigger!= null && switchTrigger.GetComponent<SwitchTrigger>().isTriggered)
		// {
		// 	Trigger ();
		// }

	}

	void OnDrawGizmos() {
		
			//Vector3 centerOffset = (transform.Find ("Collider").GetComponent<BoxCollider2D> ().bounds.center - transform.position);

			Gizmos.DrawLine(transform.position, destination);
		
	}

	public void Trigger() {
		if (activeMove == null) {
			Vector3 to;
			if(atOrigin) {
				to = destination;
			} else {
				to = originalPosition;
			}

			activeMove = LeanTween.move(gameObject, to, duration).setOnComplete(() => {
				activeMove = null;
				atOrigin = !atOrigin;
				if(autoMove) {
					Trigger ();
				}
			});
        }
	}
}
