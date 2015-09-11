using UnityEngine;
using System.Collections;
using System.Linq;

public class MoodManager : MonoBehaviour {

    private Collider2D[] angryColliders, happyColliders, regretfulColliders;

    public enum Mood {
        Angry,
        Happy,
        Regretful}

    ;
    // [SerializeField] Color colorForAngry=new Color(0.8f, 0.3f, 0.2f);
    // [SerializeField] Color colorForHappy=new Color(0.2f, 0.8f, 0.2f);
    // [SerializeField] Color colorForRegretful=new Color(0.2f, 0.2f, 0.8f);

    [SerializeField]
    private Mood _mood;
    public Mood mood {
        get {
            return _mood;
        }
        set {
            _mood = value;
            UpdateBackgroundColor();
            UpdateColoredPlatforms();
        }
    }

    // Use this for initialization
    void Start () {

        var coloredPlatforms = Object.FindObjectsOfType<ColoredPlatform>();

        angryColliders = coloredPlatforms.Where((p) => p.mood == Mood.Angry).SelectMany((p) => p.GetComponentsInChildren<Collider2D>()).ToArray();
        happyColliders = coloredPlatforms.Where((p) => p.mood == Mood.Happy).SelectMany((p) => p.GetComponentsInChildren<Collider2D>()).ToArray();
        regretfulColliders = coloredPlatforms.Where((p) => p.mood == Mood.Regretful).SelectMany((p) => p.GetComponentsInChildren<Collider2D>()).ToArray();

        UpdateColoredPlatforms();

        foreach (Renderer r in GetComponentsInChildren<Renderer>()) {
            r.material.color = MoodManager.GetColorForMood(mood);
        }
        transform.localScale = new Vector3(100, 100, 1);
    }
	
    void UpdateBackgroundColor () {
        var targetColor = MoodManager.GetColorForMood(mood);
        foreach (Renderer r in GetComponentsInChildren<Renderer>()) {
            LeanTween.color(r.gameObject, targetColor, 0.5f);
        }
    }
    void UpdateColoredPlatforms(){
        foreach (Collider2D c in angryColliders) {
            if (mood == Mood.Angry) {
                c.gameObject.GetComponent<ColoredPlatform>().ObjectEnabled=false;
            }
            else{
                c.gameObject.GetComponent<ColoredPlatform>().ObjectEnabled=true;
            }
        }
        foreach (Collider2D c in happyColliders) {
            if (mood == Mood.Happy) {
                c.gameObject.GetComponent<ColoredPlatform>().ObjectEnabled=false;
            }
            else{
                c.gameObject.GetComponent<ColoredPlatform>().ObjectEnabled=true;
            }
        }
        foreach (Collider2D c in regretfulColliders) {
            if (mood == Mood.Regretful) {
                c.gameObject.GetComponent<ColoredPlatform>().ObjectEnabled=false;
            }
            else{
                c.gameObject.GetComponent<ColoredPlatform>().ObjectEnabled=true;
            }
        }
    }

    // private void UpdateColliders () {
    //     foreach (Collider2D c in angryColliders) {
    //         //c.isTrigger = (mood == Mood.Angry);
    //         if (mood == Mood.Angry) {
    //             c.gameObject.layer = 10;
    //         } else {
    //             if (c.gameObject.GetComponent<EdgeCollider2D>() != null) {
    //                 c.gameObject.layer = 9;
    //             } else {
    //                 c.gameObject.layer = 0;
    //             }
    //         }
    //     }
    //     foreach (Collider2D c in happyColliders) {
    //         //c.isTrigger = (mood == Mood.Happy);
    //         if (mood == Mood.Happy) {
    //             c.gameObject.layer = 10;
    //         } else {
                
    //             if (c.gameObject.GetComponent<EdgeCollider2D>() != null) {
    //                 c.gameObject.layer = 9;
    //             } else {
    //                 c.gameObject.layer = 0;
    //             }
    //         }
    //     }
    //     foreach (Collider2D c in regretfulColliders) {
    //         //c.isTrigger = (mood == Mood.Regretful);
    //         if (mood == Mood.Regretful) {
    //             c.gameObject.layer = 10;
    //         } else {
    //             if (c.gameObject.GetComponent<EdgeCollider2D>() != null) {
    //                 c.gameObject.layer = 9;
    //             } else {
    //                 c.gameObject.layer = 0;
    //             }
    //         }
    //     }
    // }

    public static Color GetColorForMood (Mood mood) {
        switch (mood) {
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
