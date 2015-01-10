using UnityEngine;
using System.Collections;

public class SpermTrigger : MonoBehaviour 
{
	void Update ()
	{
		if(gameObject.name == "Sperm")
		{
			if(gameObject.transform.position.y>=-3.24f)
			{
				GetComponent<animTrigger>().Trigger();
			}
		}
	}
	
	void Scene()
	{
		Application.LoadLevel("SwipeGame");
	}
	
	
}
