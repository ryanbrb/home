using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum GameEvent {
BatterDead, Warning
}


public class LevelManager : MonoBehaviour
{
	public string[] Level;
	//public static LevelManager ThisisMe;
	public void Start()
	{
		//LevelManager.ThisisMe = this;
	}
	public static void CallEvent(GameEvent EventCalled)
	{
		
	}
	
	public void LoadRoom(int RoomNumber){
        if(Level[RoomNumber] != null) {
            SceneManager.LoadScene(Level[RoomNumber]);
            Debug.Log("Loading " + Level[RoomNumber]);
        }
        else{
            Debug.Log("Level does not exist, or is not set in the Level Manager");
        }
    }
}
