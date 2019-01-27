using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint : MonoBehaviour
{
	private SpriteRenderer sr;
	public bool ActivatedHint;
	public Hint NextHint;
    // Start is called before the first frame update
    void Start()
    {
		sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
		if (ActivatedHint)
		{
			float Intensity = Mathf.Abs(Mathf.Sin(Time.time));
			//Debug.Log(Intensity);
			sr.color = new Color(1, 1, Intensity, 1);
		}
    }
	private void OnDestroy()
	{
		if(NextHint != null)
		{
			NextHint.ActivatedHint = true;
		}
	}
}
