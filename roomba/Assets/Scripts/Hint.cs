using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint : MonoBehaviour
{
	private SpriteRenderer sr;
	
    // Start is called before the first frame update
    void Start()
    {
		sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
		
		float Intensity = Mathf.Abs(Mathf.Sin(Time.time));
		//Debug.Log(Intensity);
		sr.color = new Color(1, 1, Intensity, 1);
    }
}
