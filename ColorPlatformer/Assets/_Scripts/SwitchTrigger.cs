using UnityEngine;
using System.Collections;

public class SwitchTrigger : MonoBehaviour {
    public bool isTriggered;
    [SerializeField] GameObject movingObject;
    MovingPlatform movingPlatform;
    [SerializeField] GameObject tutorialText;
    [SerializeField] AudioClip audio;
    // Use this for initialization
    void Start () {
		 movingPlatform=movingObject.GetComponent<MovingPlatform>();
    }
	
    // Update is called once per frame
    void Update () {
	
    }
    void OnTriggerStay2D (Collider2D other) {
        if (gameObject.GetComponent<ColoredPlatform>().ObjectEnabled) {//enable
            //print("enter switch trigger");

            PullTrigger();

        } else {//disable
			
        }

    }
    void OnTriggerEnter2D (Collider2D other) {
        if (gameObject.GetComponent<ColoredPlatform>().ObjectEnabled) {//enable
           	transform.position+=new Vector3(0f,0.3f,0f);
            tutorialText.SetActive(true);

        } else {//disable
			
        }

    }
    void OnTriggerExit2D (Collider2D other) {
        if (gameObject.GetComponent<ColoredPlatform>().ObjectEnabled) {//enable
           	transform.position+=new Vector3(0f,-0.3f,0f);
            tutorialText.SetActive(false);

        } else {//disable
			
        }

    }
	
    void PullTrigger () {
        if (Input.GetKeyDown(KeyCode.Space)) {
        	AudioSource.PlayClipAtPoint(audio, transform.position);
            if (transform.eulerAngles != new Vector3(0f, 0f, 120f)) {
                transform.eulerAngles = new Vector3(0f, 0f, 120f);
            } else {
                transform.eulerAngles = new Vector3(0f, 0f, 60f);
            }
            isTriggered = !isTriggered;
            movingPlatform.Trigger();
        }
    }
}
