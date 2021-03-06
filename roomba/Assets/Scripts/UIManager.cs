﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private Scene currentScene;
    private string screenName;
    private Cat playerCat;
    private Vector3 v3;
	[SerializeField]
    private UITitleScreen titleScreen;
    public bool menuMove;
	public bool isMenu;

    delegate void MovementDelegate(Vector3 v3);
    MovementDelegate movement;

    delegate void MenuDelegate(string action);
    MenuDelegate menu;
    

    // Start is called before the first frame update
    void Start()
    {
		if(isMenu == null)
			isMenu = true;
        menu += MoveSelection;
        currentScene = SceneManager.GetActiveScene();
        screenName = currentScene.name;

        if (screenName == "main" || isMenu)
        {
			Music.instance.SceneChange(Music.SceneTypeList.Menu, "main");
			titleScreen = (UITitleScreen)FindObjectOfType(typeof(UITitleScreen));
        }
        else
        {
            playerCat = (Cat)FindObjectOfType(typeof(Cat));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (screenName == "main" || isMenu) 
        {
            if(Input.GetAxis("Vertical") > 0 && menuMove)
            {
                //menu = MoveSelection;
                menu("up");
                menuMove = false;
            }
            else if (Input.GetAxis("Vertical") < 0 && menuMove)
            {
                //menu = MoveSelection;
                menu("down");
                menuMove = false;
            }
            else if (Input.GetAxis("Fire1") > 0)
            {
                //menu = MoveSelection;
                Debug.Log("Fire1 detected");
                menu("select");
            }
            else if (Input.GetAxis("Vertical") == 0)
            {
                menuMove = true;
            }

        }
        else
        {

            if (Input.GetButtonDown("Reset"))
            {
                Debug.Log("reset button pushed");
                BatteryUI.Drain();
            }
            v3 = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0.0f);
            movement = MoveDiagonal;
            MoveDiagonal(v3);
        }

    }

    void MoveDiagonal(Vector3 dir)
    {
        playerCat.MoveDiagonal(dir);
    }

    void MoveSelection(string action)
    {
        //menuMove = true;
        titleScreen.HandleSelection(action);
        Debug.LogFormat("menumove: {0}", menuMove);
    }


}
