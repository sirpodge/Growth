using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Swipe : MonoBehaviour 
{
	private Vector2 startPos;
	public Sprite stage_2, stage_3;
	bool stage1;

	void Update()
	{
		if (Input.touchCount > 0) //If there's a finger on the screen
		{
			Touch touch = Input.touches[0];//Only count 1
			switch (touch.phase)//Touch function switch
			{
				case TouchPhase.Began://First touch, stores where it begins
				startPos = touch.position;
				break;//jumps to next phase
		
				case TouchPhase.Ended://When I take my finger up
				if(!stage1)
				{
					if(startPos.x > 100f && startPos.x < 200f)
					{
						if(touch.position.x > 100f && touch.position.x < 200f)
						{
							if(startPos.y < 400f && startPos.y > 280f)
							{
								if(touch.position.y < 190f && touch.position.y > 100f)
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