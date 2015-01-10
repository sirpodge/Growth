using UnityEngine;
using System.Collections;

public class animTrigger : MonoBehaviour {
	public Animator anim;
	public string animationName;
	
	public void Trigger()
	{
			anim.Play (animationName);
	}
}
