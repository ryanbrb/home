using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public string[] Level;

    public void LoadRoom01(){
        if(Level[01] != null) {
            SceneManager.LoadScene(Level[01]);
            Debug.Log("Loading " + Level[01]);
        }
        else{
            Debug.Log("Level does not exist, or is not set in the Level Manager");
        }
    }
}
