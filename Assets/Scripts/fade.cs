using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class fade : MonoBehaviour {

	Animator anim;
	public float dir;
	public float speed;
	bool start1;
	public Sprite pressed, notPressed;
	public Animator anim2;
	
	
	// Use this for initialization
	void Start () {
	
		
		if(gameObject.name == "ScreenOverlay")
		{
			anim = GameObject.Find("finger").GetComponent<Animator>();
		}
	}
	
	IEnumerator wait()
	{
		yield return new WaitForSeconds(2);
		Debug.Log ("h");
		Application.LoadLevel("Heartbeat");
	}
	
	IEnumerator Flip()
	{
		yield return new WaitForSeconds(3);
		dir = -1;
		yield return new WaitForSeconds(2);
		anim2.Play("New Animation");
	}
	
	// Update is called once per frame
	void Update () 
	{
	
		if(start1)
		{
			if(Mathf.Clamp01(GameObject.Find("ScreenOverlay").GetComponent<Image>().color.a) == 1f)
			{
				StartCoroutine("wait");
			}
		}
		
		if(GetComponent<Text>())
		{
			GetComponent<Text>().color = new Color(GetComponent<Text>().color.r,GetComponent<Text>().color.g,GetComponent<Text>().color.b, Mathf.Clamp01(GetComponent<Text>().color.a) + dir * speed * Time.deltaTime);
			if(Mathf.Clamp01(GetComponent<Text>().color.a) ==1)
			{
				StartCoroutine("Flip");
			}
		}
	
		if(GetComponent<Image>())
		{
			GetComponent<Image>().color = new Color(GetComponent<Image>().color.r,GetComponent<Image>().color.g,GetComponent<Image>().color.b, Mathf.Clamp01(GetComponent<Image>().color.a) + dir * speed * Time.deltaTime);
			
		}
		
		if(gameObject.name == "ScreenOverlay")
		{
			if(Mathf.Clamp01(GetComponent<Image>().color.a) == 0)
			{
				anim.SetTrigger("go");
				//GetComponent<animTrigger>().Trigger();
			}
		}
		
		if(gameObject.name == "Button")
		{
			
			
			if(Input.touchCount >0)
			{
				Touch touches = Input.touches[0];
				if(touches.phase != TouchPhase.Ended)
				{
					GetComponent<Image>().sprite = pressed;
				}
				
				if(touches.phase == TouchPhase.Ended)
				{
					GetComponent<Image>().sprite = notPressed;
					dir = -1;
					start1=true;
					GameObject.Find("ScreenOverlay").GetComponent<fade>().dir = 1;
				}
			}
		}
	}
}
