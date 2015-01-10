using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SimpleFade : MonoBehaviour {

	Text words; //To store component
	float Dir = 1f;//Whether to fade in or out
	bool timer;//for flipping between fade direction 
	float time = 5f;//Length of time it takes between fading

	void Start () 
	{
		words = GetComponent<Text>();//Stores the component Text
	}

	void Update () 
	{
		words.color = new Color(words.color.r, words.color.g, words.color.b, Mathf.Clamp01(words.color.a) + Dir * 0.5f * Time.deltaTime);//Used for changing alpha level of Text
		if(Mathf.Clamp01(words.color.a) == 1f)//If the alpha level is either 0 or 1, it'll start the timer
		{
			timer = true;//Starts timer
		}

		if(timer)//Check whether it's been started
		{
			time -= Time.deltaTime; //Takes time away from itself
			if(time <=0)//If time is less than or equal to "0"
			{
				Dir = -Dir;//The direction equals the opposite of itself
				time = 5f;//Make the time equal "5" for its next
				timer = !timer;//turns timer off
			}
		}
	}
}
