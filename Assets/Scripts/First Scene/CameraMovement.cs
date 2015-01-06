using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour 
{
	public Transform sperm;
	public float smoothing;
	public float cameraDrop;
	Vector2 velocity = Vector2.zero;//Sets cameras velocity to zero
	Vector3 pos;//Keeps current position of gameObject releative to the Sperm, applies smoothing and resets our velocity

	void Update ()
	{

		if(sperm.gameObject.activeInHierarchy)
		{
			//Bad coding is bad :P
			pos = Vector2.SmoothDamp(transform.position,sperm.transform.position, ref velocity, smoothing);
			transform.position = new Vector3(transform.position.x,pos.y,transform.position.z);

			if(cameraDrop < 7)
			{
				cameraDrop += 0.8f * Time.deltaTime * 2f;//increasing the rate at which the camera zoom rate is multiplied
			}

			if(camera.orthographicSize >= 4.65f)
			{
				camera.orthographicSize -= 0.1f*Time.deltaTime * cameraDrop;//changes the camera zoom size
				if(camera.orthographicSize <= 4.65f)//Classic MonoDevelop, decides not to let me use "<" for five minutes!
				{
					camera.orthographicSize = 4.65f;
				}

				if(smoothing >1f)
				{
					smoothing -=1f* Time.deltaTime;//rate at which the camera can keep up with target object, less is faster
				}

				if(smoothing <=1f)
				{
					smoothing = 1f;
				}
			}
		}
	}
}
