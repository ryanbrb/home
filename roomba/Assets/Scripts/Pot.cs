using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
	private float fade = 3;
	private bool knocked = false;
	private Color StartColor;
	[SerializeField]
	private SpriteRenderer sr;
	[SerializeField]
	private GameObject myDirt;

	private void Start()
	{
		myDirt.active = false;
		StartColor = sr.color;
	}
	// Update is called once per frame
	void Update()
    {
        if(knocked)
		{
			fade = fade - Time.deltaTime;
			StartColor.a = fade;
			sr.color = StartColor;// new Color(1, 1, 1, fade);
			if (fade < 0)
			{
				gameObject.GetComponent<Collider2D>().enabled = false;
				Destroy(this.gameObject);
			}
		}
    }
	private void KnockOver()
	{
		knocked = true;
		myDirt.active = true;
		myDirt.transform.parent = null;
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.Log("Collider Entered for pot");
		if (collision.gameObject.CompareTag("Cat") && !knocked)
		{
			KnockOver();
		}
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		Debug.Log("Trigger Entered for pot");
		if (collision.gameObject.CompareTag("Cat"))
		{
			KnockOver();
		}
	}
}
