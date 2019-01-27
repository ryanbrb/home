using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface iMusic
{
	void SceneChange(Music.SceneTypeList sceneType, string NameOfScene);
}

public class Music : MonoBehaviour, iMusic
{
	public static iMusic instance;
	public enum SceneTypeList { Menu, Game, CutScene }

	[SerializeField]
	private AudioClip[] mySongs;
	[SerializeField]
	private AudioSource source;



	void Start()
	{
		//Singleton
		if(Music.instance == null)
		{
			instance = this;
			//Set destroy on load to false;
		}
		else
		{
			Destroy(this.gameObject);
		}
	}

	/// This is called every time a scene is changed.
	/// the scene Type is what kind of scene it is
	/// The name is for you to differentiate how to use it - ie sounds for cutscenes
	/// ---- It is Mike's responsibility for this to work, it is everyone else's responsibility to call these!
	public void SceneChange(SceneTypeList sceneType, string NameOfScene )
	{
		
	}

}
