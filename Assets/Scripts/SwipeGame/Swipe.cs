using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Swipe : MonoBehaviour 
{
	private Vector2 startPos = Vector2.zero;
	public Image egg_1, egg_2, advance, finger;
	Touch touch;
	public bool stage1;
	public bool stage2;
	bool begin;
	float alphaChannel;
	float timer = 2.5f;


	public Animator anim;

	void Start()
	{

		if(gameObject.name == "Egg_3")
		{
			anim = GetComponent<Animator>();
		}

	}




	void Update()
	{
		if (!begin) {
						timer -= Time.deltaTime;
						if (timer <= 0) {
								begin = true;
				if(finger)
				{
					finger.gameObject.SetActive(false);
				}

						}
				}

		if (begin) {
				if (stage1) {
						if (gameObject.name == "Egg_1") {
								if (!stage2) {
										egg_1.color = new Color (egg_1.color.r, egg_1.color.g, egg_1.color.b, Mathf.Clamp01 (egg_1.color.a) + 1f * 0.5f * Time.deltaTime);
										GetComponent<Image> ().color = new Color (GetComponent<Image> ().color.r, GetComponent<Image> ().color.g, GetComponent<Image> ().color.b, Mathf.Clamp01 (GetComponent<Image> ().color.a) - 1f * 0.5f * Time.deltaTime);
								}
						}



				}

			if (stage2) 
			{
				if (gameObject.name == "Egg_2") 
				{
					Debug.Log ("hh");

					GetComponent<Image> ().color = new Color (GetComponent<Image> ().color.r, GetComponent<Image> ().color.g, GetComponent<Image> ().color.b, Mathf.Clamp01 (GetComponent<Image> ().color.a) - 1f * 0.5f * Time.deltaTime);
					egg_2.color = new Color (egg_2.color.r, egg_2.color.g, egg_2.color.b, Mathf.Clamp01 (egg_2.color.a) + 1f * 0.5f * Time.deltaTime);
					advance.color = new Color (advance.color.r, advance.color.g, advance.color.b, Mathf.Clamp01 (advance.color.a) + 1f * 0.5f * Time.deltaTime);
				}

				if(gameObject.name == "Egg_3")
				{
					if(Mathf.Clamp01(GameObject.Find("Egg_2").GetComponent<Image>().color.a) == 0)
					{
						Debug.Log("hi");
						anim.SetBool("go", true);
					}
				}
			}

				if (Input.touchCount > 0) { //If there's a finger on the screen
						touch = Input.touches [0];//Only count 1



						switch (touch.phase) {//Touch function switch
						case TouchPhase.Began://First touch, stores where it begins
								startPos = touch.position;

								break;//jumps to next phase

						case TouchPhase.Ended://When I take my finger up
								Debug.DrawLine (startPos, touch.position, Color.white, 3f);
								Debug.Log (startPos);
								Debug.Log (touch.position);
								if (!stage1) {
										if (startPos.x > 130f && startPos.x < 220f) {
												if (touch.position.x > 30f && touch.position.x < 150f) {
														if (startPos.y < 340f && startPos.y > 260f) {
																if (touch.position.y < 160f && touch.position.y > 65f) {

																		stage1 = true;


																}
														}
												}
										}

								} else {
										if (startPos.y < 315f && startPos.y > 260f) {
												if (touch.position.y < 150f && touch.position.y > 65f) {
														if (startPos.x > 50f && startPos.x < 110f) {
																if (touch.position.x > 150f && touch.position.x < 210f) {
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