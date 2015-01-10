using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Swipe : MonoBehaviour 
{
	private Vector2 startPos = Vector2.zero;
	public Image egg_1, egg_2, finger;
	Touch touch;
	public bool stage1;
	public bool stage2;
	public bool begin;
	float alphaChannel;
	float timer = 7f;
	public GameObject advance;
	Vector2 updatedPos = Vector2.zero;

	

	void Update()
	{
		if (!begin) 
		{
			timer -= Time.deltaTime;
			if (timer <= 0) 
			{
				begin = true;
				if(finger)
				{
					finger.gameObject.SetActive(false);
				}

			}
		}

		if (begin) 
		{
			if (stage1) 
			{
				if (gameObject.name == "Egg_1") 
				{
						if (!stage2) 
						{
								egg_1.color = new Color (egg_1.color.r, egg_1.color.g, egg_1.color.b, Mathf.Clamp01 (egg_1.color.a) + 1f * 1f * Time.deltaTime);
								GetComponent<Image> ().color = new Color (GetComponent<Image> ().color.r, GetComponent<Image> ().color.g, GetComponent<Image> ().color.b, Mathf.Clamp01 (GetComponent<Image> ().color.a) - 1f * 1f * Time.deltaTime);
						}
				}
			}

			if (stage2) 
			{
			
				if (gameObject.name == "Egg_1") 
				{
					GetComponent<Image> ().color = new Color (GetComponent<Image> ().color.r, GetComponent<Image> ().color.g, GetComponent<Image> ().color.b, 0f);
				}
				
				if (gameObject.name == "Egg_2") 
				{
					GetComponent<Image> ().color = new Color (GetComponent<Image> ().color.r, GetComponent<Image> ().color.g, GetComponent<Image> ().color.b, Mathf.Clamp01 (GetComponent<Image> ().color.a) - 1f * 0.5f * Time.deltaTime);
					egg_2.color = new Color (egg_2.color.r, egg_2.color.g, egg_2.color.b, Mathf.Clamp01 (egg_2.color.a) + 1f * 1f * Time.deltaTime);
				}

				if(gameObject.name == "Egg_3")
				{
				
					if(Mathf.Clamp01(GetComponent<Image>().color.a) == 1)
					{
						if(Mathf.Clamp01( egg_1.color.a) !=0)
						{
							egg_1.color = new Color (egg_1.color.r, egg_1.color.g, egg_1.color.b, 0f);
							
						}
						Animator a = GetComponent<Animator>();
						a.enabled = true;
						GetComponent<animTrigger>().Trigger();
						advance.SetActive(true);
					}
				}
			}

			if (Input.touchCount > 0) 
			{ 
				touch = Input.touches [0];
				


				switch (touch.phase) 
				{
				case TouchPhase.Began:
						startPos = Camera.main.ScreenToWorldPoint(touch.position);

						break;

				case TouchPhase.Moved:
					updatedPos = Camera.main.ScreenToWorldPoint(touch.position);
					break;
				case TouchPhase.Ended:
						Debug.DrawLine (startPos, updatedPos, Color.white, 3f);
						Debug.Log (startPos);
						Debug.Log (updatedPos);
						if (!stage1) 
						{
							if (startPos.x > 0.4f && startPos.x < 4.7f)
							{
								Debug.Log("g");
								if (updatedPos.x > -6f && updatedPos.x < -0.1f) 
								{
								Debug.Log("f");
									if (startPos.y < 8f && startPos.y > 3f) 
									{
									Debug.Log("v");
										if (updatedPos.y < -3.6f && updatedPos.y > -8.6f) 
										{		
											
											stage1 = true;
										}
									}
								}
							}
	
						} 
						else 
						{
								if (startPos.y < 8f && startPos.y > 3f) 
								{
							Debug.Log("h");
										if (updatedPos.y > -9.6f && updatedPos.y < -2f)
										{
								Debug.Log("u");
												if (startPos.x > -5.4f && startPos.x < -1.2f) 
												{
									Debug.Log("w");
														if (updatedPos.x > 1.2f && updatedPos.x < 5f) 
														{
																stage2 = true;
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
}