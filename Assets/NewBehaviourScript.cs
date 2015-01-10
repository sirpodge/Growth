using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {
	public float dir;
	public float speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(GetComponent<Image>())
		{
			GetComponent<Image>().color = new Color(GetComponent<Image>().color.r,GetComponent<Image>().color.g,GetComponent<Image>().color.b, Mathf.Clamp01(GetComponent<Image>().color.a) + dir * speed * Time.deltaTime);
		}

		if(Mathf.Clamp01(GetComponent<Image>().color.a) == 0)
		{
			GetComponent<animTrigger>().Trigger();
		}
	}
}
