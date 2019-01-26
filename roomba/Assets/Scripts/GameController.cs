using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public float Coutnter;
	protected static int _Level;
	public static int Level
	{
		get
		{
			return _Level;
		}
		set
		{
			if (value > 0 && value < 5)
				_Level = value;
			return;
		}
	}



	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public static void Win()
	{
	}
	public static void Lose()
	{
	}
}
