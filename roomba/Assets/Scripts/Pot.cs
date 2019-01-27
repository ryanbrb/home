using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
	private float fade = 3;
	private bool knocked = false;
	[SerializeField]
	private SpriteRenderer sr;

    // Update is called once per frame
    void Update()
    {
        if(knocked)
		{
			fade = fade - Time.deltaTime;
			sr.color = new Color(1, 1, 1, fade);
			if (fade < 0)
				Destroy(this);
		}
    }
	private void KnockOver()
	{
		knocked = true;	
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Cat"))
		{
			KnockOver();
		}
	}
}
