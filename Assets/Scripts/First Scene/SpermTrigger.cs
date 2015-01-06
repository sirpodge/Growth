using UnityEngine;
using System.Collections;

public class SpermTrigger : MonoBehaviour 
{
	public GameObject ScreenOverlay;
	bool on = true;
	
	void Update ()
	{
		if(gameObject.transform.position.y>=-3.24f)
		{
			if(on ==true)
			{
				ScreenOverlay.gameObject.SetActive(true);
				on = false;
			}
		}
	}
}
