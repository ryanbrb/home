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
                currentButton.Select();
            }
            catch (Exception e)
            {
                print("error");
            }
        }
        else if (action == "down")
        {
            Debug.Log("Button Down");
            try
            {
                currentButton = buttons[buttonIndex + 1];
                buttonIndex += 1;
                currentButton.Select();
            }
            catch (Exception)
            {
                print("error");
            }
        }
        else if (action == "select")
        {
            currentButton.onClick.Invoke();
        }
    }
}
