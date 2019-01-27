using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRetry : MonoBehaviour
{
	private Button retry, toMain;

    // Start is called before the first frame update
    void Start()
    {
		retry = GameObject.Find("YesButton").GetComponent<Button>();
		toMain = GameObject.Find("NoButton").GetComponent<Button>();

    }

	public void Retry(bool retry) {
		//load appropriate level depending on whether the players retrying or not
		LevelManager.CallEvent(retry ? GameEvent.reset : GameEvent.MainMenu);
	}

}
