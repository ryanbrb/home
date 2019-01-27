using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum GameEvent {
BatteryDead, Warning, NextLevel, reset
}


public class LevelManager : MonoBehaviour
{
	private static string[] Level = {"Nothing!", "Room01", "Room02"};
	private static List<string> OtherScenes = new List<string>(new string[] {"main", "credits", "Lose", "Win"});

	
	private  static int CurrentRoom = 0;
	private static LevelManager ThisisMe;

	private static int ResetCounter = 0;
	public SpriteRenderer[] Hints;
	public UnityEngine.UI.Button b;
	public void Start()
	{
		LevelManager.ThisisMe = this;
		if (ResetCounter >= 3)
		{
			foreach(SpriteRenderer go in Hints)
			{
				go.gameObject.AddComponent<Hint>();
			}
		}


	}
	public static void CallEvent(GameEvent EventCalled)
	{
		switch (EventCalled)		
		{
			case GameEvent.NextLevel:
				ThisisMe.Invoke("Win", 3);
				//ThisisMe.Win();
				break;
			case GameEvent.BatteryDead:
				ThisisMe.Invoke("Lose", 3);
				
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
		Debug.Log("Warning");
	}

	private void Win()
	{
		ResetCounter = 0;
		if (LoadNextLevel())
			return;
		else
			Load("main");
	}
	
	private void Lose()
	{
		ResetLevel();
		//Load("main");
	}

	private void ResetLevel()
	{
		ResetCounter++;
		LoadRoomNo(CurrentRoom);
	}


	public void LoadRoom(int RoomNumber)
	{
		ResetCounter = 0;
		LoadRoomNo(RoomNumber);
	}
	private bool LoadRoomNo(int RoomNumber)
	{
		if(RoomNumber < Level.Length && RoomNumber >= 0)
		{
			if (Level[RoomNumber] != null)
			{
				CurrentRoom = RoomNumber;
				SceneManager.LoadScene(Level[RoomNumber]);
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
	private static void Load(string scene)
	{
		if(OtherScenes.Contains(scene))
		{
				SceneManager.LoadScene(scene);
				Debug.Log("Loading " + scene);
			/*
				Debug.Log("Scene \"" + scene + "\" does not exist, or is not in the Level Manager as an optional other scene.");// defaulting to Menu.");
				if (scene != "main")
				{
					Debug.Log("defaulting to Menu.");
					Load("main");
				}

			}
			*/
		}
		else
		{
			
			Debug.Log("Scene \"" + scene + "\" does not exist, or is not in the Level Manager as an optional other scene. defaulting to Menu.");
			Load("main");
		}
	}
}
