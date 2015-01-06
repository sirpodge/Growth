using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Heart : MonoBehaviour {

	public float timeTaken = 0;
	public GameObject can;
	Text textco;

	void Update()
	{
		textco = can.GetComponentInChildren<Text>();
		textco.text = timeTaken.ToString();
		if (Input.touchCount > 0)
		{
			Touch touch = Input.touches[0];
			switch (touch.phase)
			{
				case TouchPhase.Began:
				timeTaken = Time.deltaTime;
				break;
					
				case TouchPhase.Ended:
				break;
			}
		}
	}
}