using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Heart : MonoBehaviour {

	public LayerMask heart;
	public bool play;
	public float timer = 1.5f;
	public int score;
	public GameObject advance;
	bool hit1;

	void Update()
	{		
		
			timer -= Time.deltaTime;
		
		if(timer <=0)
		{
			GetComponentInParent<AudioSource>().Play();
			timer = 1.5f;
			hit1 = true;
		}
		
		if(score >= 8)
		{
			
			GetComponent<animTrigger>().Trigger();
			transform.parent.GetComponent<animTrigger>().Trigger();
		}

		if(play)
		{
			GetComponentInParent<AudioSource>().volume += Time.deltaTime;
			if(score >= 8)
			{
				advance.SetActive(true);
				play = false;
			}
			
			
			if (Input.touchCount > 0)
			{
				Touch touch = Input.touches[0];
				if(touch.phase == TouchPhase.Began)
				{
					Vector2 worldPoint = Camera.main.ScreenToWorldPoint(touch.position);
					RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero, heart);
					

					if(hit.collider != null)
					{
						if(hit.collider.name == "GameObject")
						{
							if(GetComponentInParent<AudioSource>().audio.isPlaying)
							{
								transform.parent.GetComponent<animTrigger>().Trigger();
								if(hit1)
								{
									score++;
								}
								hit1=false;
							}
							else
							{
								score = 0;
							}
						}
					}



				}
			}
			
		}

	}
}
	
