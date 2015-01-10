using UnityEngine;
using System.Collections;

public class PlayHeart : MonoBehaviour {

	void Play()
	{
		GameObject.Find("heart").GetComponentInChildren<Heart>().play = true;
	}
}
