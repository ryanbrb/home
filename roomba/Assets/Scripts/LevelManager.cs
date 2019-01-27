using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum GameEvent {
BatteryDead, Warning, NextLevel
}


public class LevelManager : MonoBehaviour
{
	private static string[] Level = {"Nothing!", "Room01", "Room02"};
	private static List<string> OtherScenes = new List<string>(new string[] {"main", "credits", "Lose", "Win"});

	private  static int CurrentRoom = 0;
	private static LevelManager ThisisMe;
	public void Start()
	{
		LevelManager.ThisisMe = this;
		
	}
	public static void CallEvent(GameEvent EventCalled)
	{
		switch (EventCalled)		
		{
			case GameEvent.NextLevel:
				if (LoadNextLevel())
					return;
				else
					Load("main");
				break;
			case GameEvent.BatteryDead:
				Load("main");
				return;
				break;
			case GameEvent.Warning:
				ThisisMe.Warning();
				break;
				
		}
	}

	private void Warning()
	{
		Debug.Log("Warnign");
	}

	public void LoadRoom(int RoomNumber)
	{
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
