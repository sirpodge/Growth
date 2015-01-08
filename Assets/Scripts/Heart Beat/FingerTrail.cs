using UnityEngine;
using System.Collections;

public class FingerTrail : MonoBehaviour {
	TrailRenderer trail;

	void Start() 
	{
		trail = gameObject.GetComponent<TrailRenderer> ();
		trail.sortingLayerName = "Default";
		trail.sortingOrder = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.touchCount > 0) //If there's a finger on the screen
		{
			Touch touch = Input.touches[0];
			if(touch.phase != TouchPhase.Ended)
			{
				Debug.Log(touch.position);
				transform.position = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10f));
				
				
			}
		}
	}
}
