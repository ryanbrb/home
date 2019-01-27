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
		retry = transform.Find("YesButton").GetComponent<Button>();
		toMain = transform.Find("NoButton").GetComponent<Button>();

    }

	public void Retry(bool retry) {
		//load appropriate level depending on whether the players retrying or not

	}

}
