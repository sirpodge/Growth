using UnityEngine;
using System.Collections;

public class ScreenFlash : MonoBehaviour
{
	public float fadeSpeed;
	public float alphaChannel;
	public int fade;
	bool end;
	
	IEnumerator wait(float time)//Timer for blackout
	{
		yield return new WaitForSeconds(time);
//		Application.LoadLevel("GameStage1");
	}
	
	void OnGUI()
	{
		if (name == "ScreenOverlay")
		{
			if(end == false)//AlphaFader
			{
				alphaChannel += fade * fadeSpeed * Time.deltaTime;
				alphaChannel = Mathf.Clamp01(alphaChannel);//0 - 1
				guiTexture.color = new Color(guiTexture.color.r, guiTexture.color.g, guiTexture.color.b, alphaChannel);
				guiTexture.pixelInset = (new Rect(0, 0, Screen.width, Screen.height));//makes sure the screen overlay image matches the size of the screen
				if(Application.loadedLevelName == "StartScene")//If your current scene is "StartScene", it'll run this code
				{
					if(alphaChannel == 1)//Switch
					{
						end=true;
					}
				}
			}
			
			if(end==true)//RGBFader
			{
				guiTexture.color = new Color(alphaChannel,alphaChannel,alphaChannel,guiTexture.color.a);
				fade = -1;
				alphaChannel += fade * fadeSpeed * Time.deltaTime;
				alphaChannel = Mathf.Clamp01(alphaChannel);
				
				if(alphaChannel ==0)
				{
					StartCoroutine(wait(1f));
				}
			}
		}
	}
	
	public float StartFade(int direction)//Fade controller
	{
		fade = direction;
		return (fadeSpeed);
	}
}


