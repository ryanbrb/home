using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delayer : MonoBehaviour
{

	protected static Delayer Instance;
    // Start is called before the first frame update
    void Start()
    {
        if(Instance == null) {
			Instance = this;
		} else {
			Destroy(this.gameObject);
		}
    }

	public static void Execute(float length, Action delayedMethod) {
		Instance.StartCoroutine(_Execute(length, delayedMethod));
	}

	private static IEnumerator _Execute(float length, Action delayedMethod) {
		yield return new WaitForSeconds(length);
		delayedMethod();
	}

    
}
