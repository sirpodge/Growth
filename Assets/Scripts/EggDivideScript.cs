using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EggDivideScript : MonoBehaviour {

	public Color c1 = Color.red;
	public Color c2 = Color.red;
	private GameObject lineGO;
	private LineRenderer lineRenderer;
	private int i = 0;
	private Animator anim;
	int clickCount = 0;

	// Use this for initialization
	void Start () {

		anim = gameObject.GetComponent<Animator> ();
	}

	void OnMouseDown() {
		clickCount++;
		if (clickCount < 4) {
						anim.SetTrigger ("Stage" + clickCount);
				}
		}
	void OnCollisionEnter(Collision other)
	{
			if (other.gameObject.name == "Line") {
				anim.SetTrigger ("Stage1");
			}
	}

}
