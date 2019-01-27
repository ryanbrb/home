using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITitleScreen : MonoBehaviour
{

    public Button[] buttons;
    public Button currentButton;
    public int buttonIndex;

    // Start is called before the first frame update
    void Start()
    {
        //buttons = FindObjectsOfType<Button>();
        //if (buttons.Length > 2)
        //{
        //    currentButton = buttons[2];
        //    buttonIndex = 2;
        //    currentButton.Select();
        //}

        currentButton = buttons[0];
        buttonIndex = 0;


    }

    // Update is called once per frame
    void Update()
    {
        currentButton.Select();
    }

    public void HandleSelection(string action)
    {
        if (action == "up")
        {
            Debug.Log("Button Up");
            try
            {
                currentButton = buttons[buttonIndex - 1];
                buttonIndex -= 1;
                //currentButton.Select();
                Sound.instance.MakeSound(Sound.SoundTrigger.MenuSceneChange, null);
            }
            catch (Exception e)
            {
                print("error");
            }
            Debug.Log("End of try catch up");
        }
        else if (action == "down")
        {
            Debug.Log("Button Down");
            try
            {
                currentButton = buttons[buttonIndex + 1];
                buttonIndex += 1;
                //currentButton.Select();
                Sound.instance.MakeSound(Sound.SoundTrigger.MenuSceneChange, null);
            }
            catch (Exception)
            {
                print("error");
            }
            Debug.Log("End of try catch down");
        }
        else if (action == "select")
        {
            Debug.Log("Click the button");
            currentButton.onClick.Invoke();
        }
        Debug.Log(currentButton);
    }
}
