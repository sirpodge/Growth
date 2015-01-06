using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LickTheRainbow : MonoBehaviour
{
    bool down = true;
    bool dir = true;
    public float speed = 10;
    public float speed2 = 10;
    float colorSpeed = 0.02f;
    SpriteRenderer sr;
	public Color sp;
    GUITexture gt;


    Vector3 pos;

    void Start()
    {
        if (GetComponent<SpriteRenderer>())
        {
            sr = GetComponent<SpriteRenderer>();
        }

		if(GetComponent<Image>())
		{
			sp = GetComponent<Image>().color;
		}
		
        if(gameObject.guiTexture)
        {
            gt = GetComponent<GUITexture>();
        }
        pos = Camera.main.transform.position;
        pos.x = 0.06f;
    }
    
    IEnumerator flash()
    {
        
        yield return new WaitForSeconds(colorSpeed);

        if (sr)
        {
            sr.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 255);
        }

		if(GetComponent<Image>())
		{
			gameObject.GetComponent<Image>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 255);
		}

        if (gameObject.guiTexture)
        {
            gt.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 255);
        }
        
        StopCoroutine("flash");
    }
    

    void Update()
    {
        StartCoroutine("flash");
    }
    void FixedUpdate()
    {
        if (gameObject.name == "Main Camera")
        {
            if (down)
            {
                if (camera.orthographicSize >= 0.69f)
                {
                    camera.orthographicSize -= 0.1f * Time.deltaTime * speed;
                }
                if (camera.orthographicSize <= 0.69f)
                {
                    camera.orthographicSize = 0.69f;
                    down = false;
                }
            }

            if (!down)
            {
                if (camera.orthographicSize >= 0.69f && camera.orthographicSize <= 1.08f)
                {
                    camera.orthographicSize += 0.1f * Time.deltaTime * speed;
                }
                else
                {
                    camera.orthographicSize = 1.08f;
                    down = true;
                }
            }

            if (dir)
            {
                if (camera.transform.position.x <= 0.06)
                {
                    camera.transform.Translate(new Vector3(pos.x, pos.y) * Time.deltaTime * speed2);
                }

                if (camera.transform.position.x >= 0.06)
                {
                    dir = false;
                }


            }

            if (!dir)
            {
                if (camera.transform.position.x >= -0.06)
                {
                    camera.transform.Translate(new Vector3(-pos.x, pos.y) * Time.deltaTime * speed2);
                }

                if (camera.transform.position.x <= -0.06)
                {
                    dir = true;
                }


            }


        }
    }
}
