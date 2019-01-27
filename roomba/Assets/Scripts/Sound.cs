using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface iSound
{
	void MakeSound(Sound.SoundTrigger trigger, Sound.AfterSound myDeligate);
}


public class Sound : MonoBehaviour, iSound
{
	
	public static iSound instance;

	public AudioClip Blah;
	public AudioClip[] WallHit;

	[SerializeField]
	private AudioSource[] audioSources;

		// Use get set here
	private int nextSoundSource = 0;




	public delegate void AfterSound();
	public AfterSound callWhenDone;

	public enum SoundTrigger { WinSound, LoseSound, MenuSceneChange, LowBatteryWarning }






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
		myDeligate();
		return;

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
		//Invoke("OnFinishSound", ClipToPlay.length);

		StartCoroutine(WaitWhileRunningSound(ClipToPlay.length));
	}

	/*/// This is called when the sound is done. if nothing is there we can 
	public void OnFinishSound()
	{
		if(callWhenDone != null)
		{
			callWhenDone();
		}
	}*/

	private IEnumerator WaitWhileRunningSound(float clipLength) {
		yield return new WaitForSeconds(clipLength);
		if(callWhenDone != null) {
			callWhenDone();
		}
	}



	void Start()
	{
		//Singleton
		if (Music.instance == null)
		{
			instance = this;
			//Set destroy on load to false;
			//DontDestroyOnLoad(this.gameObject);
		}
		else
		{
			Destroy(this.gameObject);
		}
	}
}
