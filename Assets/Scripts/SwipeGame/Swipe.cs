using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Swipe : MonoBehaviour 
{
	private Vector2 startPos = Vector2.zero;
	public Sprite stage_2, stage_3;
	Touch touch;
	bool stage1;
	LineRenderer swipeLine;

	void Start()
	{
		swipeLine = gameObject.GetComponent<LineRenderer> ();
	}


	void Update()
	{


		if (Input.touchCount > 0) //If there's a finger on the screen
		{
			touch = Input.touches[0];//Only count 1



			switch (touch.phase)//Touch function switch
			{
				case TouchPhase.Began://First touch, stores where it begins
				startPos = touch.position;

				break;//jumps to next phase

				case TouchPhase.Ended://When I take my finger up
				Debug.DrawLine(startPos, touch.position, Color.white,1f);
				Debug.Log(startPos);
				Debug.Log(touch.position);
				if(!stage1)
				{
					if(startPos.x > 80f && startPos.x < 140f)
					{
						if(touch.position.x > 80f && touch.position.x < 140f)
						{
							if(startPos.y < 345f && startPos.y > 260f)
							{
								if(touch.position.y < 145f && touch.position.y > 25f)
								{
									gameObject.GetComponent<Image>().sprite = stage_2;
									stage1 = true;
								}
							}
						}
					}

				}


				else
				{
					if(startPos.y < 320f && startPos.y > 180f)
					{
						if(touch.position.y < 320f && touch.position.y > 180f)
						{
							if(startPos.x > 0f && startPos.x < 100f)
							{
								if(touch.position.x > 200f && touch.position.x < 310f)
								{
									gameObject.GetComponent<Image>().sprite = stage_3;
									GameObject.Find("Background").GetComponent<LickTheRainbow>().enabled = true;
									gameObject.GetComponent<LickTheRainbow>().enabled = true;
									Debug.DrawLine(startPos,touch.position, Color.white);
								}
							}
						}
					}
				}
				break;
			}
		}
	}
}