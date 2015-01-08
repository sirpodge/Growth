using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class fingerIcon : MonoBehaviour {
	private Vector2 startPos;
	public float alphaChannel;
	bool touched;
	// Use this for initialization
	void Start () {
	
	}

	public void setTrailRenderer()
	{
		TrailRenderer tr = this.GetComponent<TrailRenderer>();
		tr.sortingLayerName = "Foreground";
	}
	
	// Update is called once per frame
	void Update () 
	{
		alphaChannel = Mathf.Clamp01(alphaChannel);
		alphaChannel += -1f * 1.5f * Time.deltaTime;
		//gameObject.GetComponent<Image>().color = new Color(gameObject.GetComponent<Image>().color.r,gameObject.GetComponent<Image>().color.g,gameObject.GetComponent<Image>().color.b,alphaChannel);

		if (Input.touchCount > 0) //If there's a finger on the screen
		{
			Touch touch = Input.touches[0];
			if(touch.phase != TouchPhase.Ended)
			{
				alphaChannel = 0.5f;
				startPos = touch.position;
				Debug.Log(touch.position);
				//transform.position = new Vector3(startPos.x, startPos.y, 0f);
			

			}
		}
	}
}
