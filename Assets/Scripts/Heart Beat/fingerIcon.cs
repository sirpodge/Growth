using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class fingerIcon : MonoBehaviour {
<<<<<<< HEAD
	private Vector2 startPos;
=======
	private Vector3 startPos;
>>>>>>> origin/master
	public float alphaChannel;
	bool touched;
	// Use this for initialization
	void Start () {
	
	}
<<<<<<< HEAD
=======

	public void setTrailRenderer()
	{
		TrailRenderer tr = this.GetComponent<TrailRenderer>();
		tr.sortingLayerName = "Foreground";
	}
>>>>>>> origin/master
	
	// Update is called once per frame
	void Update () 
	{
		alphaChannel = Mathf.Clamp01(alphaChannel);
		alphaChannel += -1f * 1.5f * Time.deltaTime;
		gameObject.GetComponent<Image>().color = new Color(gameObject.GetComponent<Image>().color.r,gameObject.GetComponent<Image>().color.g,gameObject.GetComponent<Image>().color.b,alphaChannel);

		if (Input.touchCount > 0) //If there's a finger on the screen
		{
			Touch touch = Input.touches[0];
			if(touch.phase == TouchPhase.Began)
			{
				alphaChannel = 0.5f;
				startPos = touch.position;
<<<<<<< HEAD
				transform.position = new Vector2(startPos.x, startPos.y);
=======
				Debug.Log(touch.position);
				transform.position = new Vector3(startPos.x, startPos.y, startPos.z);
			

>>>>>>> origin/master
			}
		}
	}
}
