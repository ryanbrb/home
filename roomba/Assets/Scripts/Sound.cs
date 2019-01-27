using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
	
	public static Sound instance;

	public AudioClip Blah;
	public AudioClip[] WallHit;

	[SerializeField]
	private AudioSource[] audioSources;

		// Use get set here
	private int nextSoundSource = 0;




	public delegate void AfterSound();
	public AfterSound callWhenDone;

	public enum SoundTrigger { WinSound, LoseSound, MenuSceneChange }






	/// <summary>
	/// This is called by all functions that will have a sound effect.
	/// Ask for everyone else to call this.
	/// 
	/// ---- It is Mike's responsibility for this to work, it is everyone else's responsibility to call these!
	/// </summary>
	/// <param name="trigger">What triggered this?</param>
	/// <param name="myDeligate">What happens after. (Can be null)</param>
	public void MakeSound(SoundTrigger trigger, AfterSound myDeligate)
	{
		float lengthOfSound = 0;
		callWhenDone = myDeligate;
		AudioClip ClipToPlay = null;

		// here is where you select what sound to make.
		switch(trigger)
		{
			
		}
		PlaySound(ClipToPlay);
		
	}







	/// <summary>
	///  This is how you will make a sound
	/// </summary>
	/// <param name="ClipToPlay"></param>
	private void PlaySound(AudioClip ClipToPlay)
	{
		audioSources[nextSoundSource].clip = ClipToPlay;
		audioSources[nextSoundSource].Play();
		nextSoundSource++;
		Invoke("OnFinishSound", ClipToPlay.length);
	}

	/// This is called when the sound is done. if nothing is there we can 
	public void OnFinishSound()
	{
		if(callWhenDone != null)
		{
			callWhenDone();
		}
	}



	void Start()
	{
		//Singleton
		if (Music.instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(this.gameObject);
		}
	}
}
