using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class fingerIcon : MonoBehaviour {
	public float alphaChannel;
	bool touched;

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
			}
			
			if(touch.phase !=TouchPhase.Ended)
			{
				Vector3 startPos;
				startPos = Camera.main.ScreenToWorldPoint(touch.position);
				transform.position = new Vector2(startPos.x,startPos.y);
			}
		}
	}
}
