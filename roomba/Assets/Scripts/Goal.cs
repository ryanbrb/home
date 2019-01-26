using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour{

    public GameObject LevelManagerGameObject;
    public int LevelToLoad = 0;

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Roomba"){
            // load next level
            LevelManagerGameObject.GetComponent<LevelManager>().LoadRoom(LevelToLoad);
            Debug.Log("collision detected with roomba");
        }
    }
}
