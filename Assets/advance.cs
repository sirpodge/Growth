using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class advance : MonoBehaviour {
	public Sprite pressed, notPressed;
	public LayerMask advanced;
	public float dir;
	public float speed;
	RaycastHit2D temp;
	bool fade;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(fade)
		{
			StartCoroutine("wait");
		}

		GetComponent<Image>().color = new Color(GetComponent<Image>().color.r,GetComponent<Image>().color.g,GetComponent<Image>().color.b, Mathf.Clamp01(GetComponent<Image>().color.a) + dir * speed * Time.deltaTime);

		if (Input.touchCount > 0)
		{
			
			Touch touches = Input.touches[0];
			Vector2 worldPoint = Camera.main.ScreenToWorldPoint(touches.position);
			RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero, advanced);
			if(touches.phase != TouchPhase.Ended)
			{
				if(hit.collider != null)
				{
				
				if(hit.collider.name == "advanced")
				{
					GetComponent<Image>().sprite = pressed;
				}
				}
			
			}
			
			if(touches.phase == TouchPhase.Ended)
			{
				if(hit.collider != null)
				{
				if(hit.collider.name == "advanced")
				{
						GetComponent<Image>().sprite = notPressed;
						dir = -1;
						fade = true;
						GameObject.Find("Image").GetComponent<NewBehaviourScript>().dir = 1;
				}
				}
				

			}
		}	
	}

	IEnumerator wait()
	{
		yield return new WaitForSeconds(2);
		Application.LoadLevel("StartScene");
	}
}
