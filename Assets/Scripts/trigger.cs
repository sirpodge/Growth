using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class trigger : MonoBehaviour {

	Touch touch;
	public LayerMask advanced;
	public Sprite touched;
	public Sprite notTouched;
	bool go;
	public GameObject sperm;
	public Image logo;

	void Update()
	{
		if(!go)
		{
			if (Input.touchCount > 0) 
			{ 
				
				touch = Input.touches [0];
				Vector2 worldPoint = Camera.main.ScreenToWorldPoint(touch.position);
				RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero, advanced);
				if(touch.phase != TouchPhase.Ended)
				{
					if(hit.collider != null)
					{
						GetComponent<Image>().sprite = touched;
					}
				}
	
				if(touch.phase == TouchPhase.Ended)
				{
					if(hit.collider != null)
					{
						GetComponent<Image>().sprite = notTouched;
						go = true;
					}
	
				}
			}
			
		}



		if(go)
		{
			GetComponent<Image>().color = new Color(GetComponent<Image>().color.r,GetComponent<Image>().color.g,GetComponent<Image>().color.b, Mathf.Clamp01(GetComponent<Image>().color.a) -1f * 1f * Time.deltaTime);
			logo.color = new Color(logo.color.r, logo.color.g, logo.color.b, Mathf.Clamp01(logo.color.a) -1f * 1f * Time.deltaTime);
			if(gameObject.name == "Play")
			{
				sperm.SetActive(true);
			}
		}

	}
}
