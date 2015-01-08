using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Heart : MonoBehaviour {
	
	public float timeTaken =0;
	public float taps;
	public bool checker1;
	public GameObject can;
	Text textco;
	
	void Start()
	{
		textco = can.GetComponentInChildren<Text>();
	}
	
	void Update()
	{
		textco.text = timeTaken.ToString();
		if (Input.touchCount > 0)
		{
			Touch touch = Input.touches[0];
			if(touch.phase == TouchPhase.Began)
			{
				taps++;
			}
		}
		if(taps >0)
		{
			if(taps <3)
			{
				if(timeTaken < 0.5)
				{
					if(taps ==2 && timeTaken <0.4 && timeTaken > 0.2)
					{
						Debug.Log("You win!");//Dumb code everywhere!
					}
					timeTaken += Time.deltaTime;
				}

				else
				{
					taps = 0;
					timeTaken = 0;
				}
			}
			else
			{
				taps = 0;
				timeTaken = 0;
			}
		}

	}
}
	
