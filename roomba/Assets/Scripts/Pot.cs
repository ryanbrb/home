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
	public Dirt dirt { get; private set; }
	public Animator MyAnimation;
	//Declaring Audio Objects
	private AudioSource PotSounds;
    public AudioClip PotHit;
    public AudioClip PotCrash;

    private void Start()
	{
		dirt = myDirt.GetComponent<Dirt>();
		myDirt.SetActive(false);
		StartColor = sr.color;
        PotSounds = GetComponent<AudioSource>();
		

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
		MyAnimation.SetTrigger("HitRight");
		knocked = true;
		myDirt.active = true;
		myDirt.transform.parent = null;
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.Log("Collider Entered for pot");
		if ((collision.gameObject.CompareTag(GameTag.Cat) || collision.gameObject.CompareTag(GameTag.Roomba)) && !knocked)
		{
            PotSounds.PlayOneShot(PotHit);
            KnockOver();
		}
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		Debug.Log("Trigger Entered for pot");
		if (collision.gameObject.CompareTag(GameTag.Cat))
		{
			KnockOver();
		}
	}
}

