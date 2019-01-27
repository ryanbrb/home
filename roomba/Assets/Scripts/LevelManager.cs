using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTag {
	public const string Roomba = "Roomba";
	public const string Home = "Goal";
	public const string Cat = "Cat";
	public const string Wall = "Wall";
	public const string Pot = "Pot";
	public const string Dirt = "Dirt";
}

public enum GameEvent {
BatteryDead, Warning, NextLevel, reset
}


public class LevelManager : MonoBehaviour
{
	private static string[] Level = {"Nothing!", "Room01",  "Room02",   "Room03",   "Room04",   "Room05",   "Room06",   "Room07",   "Room08",   "Room09" };
	private static string[] LevelNames = { "Nothing!", "Room01",    "Room02",   "Room03",   "Room04",   "Room05",   "Room06",   "Room07",   "Room08",   "Room09"};
	private static List<string> OtherScenes = new List<string>(new string[] {"main", "credits", "Lose", "Win"});

	[SerializeField]
	private  static int CurrentRoom = 0;
	private static LevelManager ThisisMe;

	private static int ResetCounter = 0;
	public SpriteRenderer[] Hints;

	public void Start()
	{
		LevelManager.ThisisMe = this;
		if (ResetCounter >= 3)
		{
			Hint LastHint = null;
			foreach(SpriteRenderer sr in Hints)
			{
				if (sr != null)
				{

					Hint thisHint; // = new Hint();
					sr.gameObject.AddComponent<Hint>();
					thisHint = sr.gameObject.GetComponent<Hint>();
					thisHint.ActivatedHint = false;
					thisHint.NextHint = LastHint;
					LastHint = thisHint;
				}
			}
			LastHint.ActivatedHint = true;
		}

		GameObject go = GameObject.Find("TextLevelNumber");
		if (go != null)
		{
			string LevelNum;
			if (CurrentRoom < 10)
			{
				LevelNum = "0" + CurrentRoom;
			}
			else
			{
				LevelNum = CurrentRoom + "";
			}
			go.GetComponent<UnityEngine.UI.Text>().text = LevelNum;
		}
		go = GameObject.Find("TextLevelName");
		if (go != null)
		{
			go.GetComponent<UnityEngine.UI.Text>().text = LevelNames[CurrentRoom];
		}
		//TextLevelName

	}
	
	//These are the public functions for different sounds.
	public static void CallEvent(GameEvent EventCalled)
	{
		switch (EventCalled)		
		{
			case GameEvent.NextLevel:
				ThisisMe.Win();
				break;
			case GameEvent.BatteryDead:
				ThisisMe.Lose();
				//ThisisMe.Invoke("Lose", 3);
				return;
				break;
			case GameEvent.Warning:
				ThisisMe.Warning();
				break;
			case GameEvent.reset:
				ThisisMe.ResetLevel();
				break;
		}
	}
	




	private void Warning()
	{
		//soundTrigger = Sound.SoundTrigger.LowBatteryWarning;
		Sound.instance.MakeSound(Sound.SoundTrigger.LowBatteryWarning, null);
		Debug.Log("Warning");
	}
	private void Win()
	{
		soundTrigger = Sound.SoundTrigger.WinSound;
		ResetCounter = 0;
		if (LoadNextLevel())
			return;
		else
			Load("main");
	}
	private void Lose()
	{
		ThisisMe.soundTrigger = Sound.SoundTrigger.LoseSound;
		ResetLevel();
		//Load("main");
	}
	private void ResetLevel()
	{
		ResetCounter++;
		LoadRoomNo(CurrentRoom);
	}
	private bool LoadRoomNo(int RoomNumber)
	{
		if(RoomNumber < Level.Length && RoomNumber >= 0)
		{
			if (Level[RoomNumber] != null)
			{
				CurrentRoom = RoomNumber;

				if(Level[RoomNumber].Substring(0,4).Equals("Room"))
				{
					SceneType = Music.SceneTypeList.Game;
				}
				else
				{
					SceneType = Music.SceneTypeList.CutScene;
				}
				ReadyAndCallToLoad(Level[RoomNumber]); //SceneManager.LoadScene(scene);

				Debug.Log("Loading " + Level[RoomNumber]);
				return true;
			}
			else
			{
				Debug.Log("Level does not exist, or is not set in the Level Manager");
				return false;
			}
		}
		Debug.Log("This is bad. can't find " + RoomNumber);
		return false;
	}
	private static bool LoadNextLevel()
	{
		CurrentRoom++;
		return ThisisMe.LoadRoomNo(CurrentRoom);
	}

	// These are all the Scene control public funcations
	public void LoadRoom(int RoomNumber)
	{
		soundTrigger = Sound.SoundTrigger.MenuSceneChange;
		ResetCounter = 0;
		LoadRoomNo(RoomNumber);
	}
	public static void Load(string scene)
	{
		if (OtherScenes.Contains(scene))
		{
			ThisisMe.ReadyAndCallToLoad(scene); //SceneManager.LoadScene(scene);
			Debug.Log("Loading " + scene);
		}
		else
		{

			Debug.Log("Scene \"" + scene + "\" does not exist, or is not in the Level Manager as an optional other scene. defaulting to Menu.");
			Load("main");
		}
	}





	public string SceneToLoad;
	private Sound.SoundTrigger soundTrigger;
	private Music.SceneTypeList SceneType;
	private void ReadyAndCallToLoad(string scene)
	{
		SceneToLoad = scene;

		FinishSoundPlay();
		//Sound.instance.MakeSound(soundTrigger, FinishSoundPlay);
		
	}
	

	public void LoadScene(string scene)
	{
		LevelManager.Load(scene);
	}

	public void QuitGame()
	{
		Sound.instance.MakeSound(Sound.SoundTrigger.MenuSceneChange, null);
		Application.Quit();
	}




	public void FinishSoundPlay()
	{
		Music.instance.SceneChange(SceneType, SceneToLoad);
		//Loads the next scene.
		SceneManager.LoadScene(SceneToLoad);
	}

}
