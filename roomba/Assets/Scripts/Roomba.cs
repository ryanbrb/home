using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Roomba : MonoBehaviour{

	private Transform trans;
	private Rigidbody2D rig;

	//Transform of the goal
	private Transform objective;

	//Object the roomba is moving toward
	private Transform target;

	

    void Start(){
		rig = GetComponent<Rigidbody2D>();
		trans = transform;
		var goal = GameObject.FindWithTag(GameTag.Home);
		if(goal != null) {
			objective = goal.transform;
			target = objective;
		}
    }

	private void FixedUpdate() {
		//rig.MovePosition(rig.position + )
		if(target == objective || target == trans) {
			Scan(target == trans);
		}
		rig.position = Vector2.MoveTowards(rig.position, target.transform.position, Time.fixedDeltaTime);
	}

	/*Finds the closest dirt within the roomba sight range. Returns the following code:
	 * 0: No accessible dirt found. Obstruction between roomba and home not found
	 * 1: No accessible dirt or pot found. Obstruction between roomba and home found (Completely stuck)
	 * 2: Accessible dirt found.
	 * 3: No accessible dirt found. Accessible pot found. (Frozen but not completely stuck)
	*/
	private int Scan(bool haltIfScanFails = false) {
		var dirts = GameObject.FindGameObjectsWithTag(GameTag.Dirt);
		bool directHomeSight = true;
		var rhObstacle = Physics2D.LinecastAll(trans.position, objective.position);
		foreach(var i in rhObstacle) {
			if (i.transform.CompareTag(GameTag.Wall)) {
				directHomeSight = false;
				break;
			}
		}

		if(dirts.Length > 0) {
			dirts = dirts.OrderBy(x => Vector2.Distance(trans.position, x.transform.position)).ToArray();

			for (int i = 0; i < dirts.Length; ++i) {
				bool hasSight = true;
				var obstacles = Physics2D.LinecastAll(trans.position, dirts[i].transform.position);
				foreach (var j in obstacles) {
					if (j.transform.CompareTag(GameTag.Cat) || j.transform.CompareTag(GameTag.Wall)) {
						hasSight = false;
						break;
					}
				}
				if (hasSight) {
					target = dirts[i].transform;
					return 2;
				}
			}
		}

		if (directHomeSight) {
			target = objective;
			return 0;
		}

		//No accessible dirt and no direct path to home
		//TODO: Check if its possible to go home at all
		target = haltIfScanFails ? trans : objective;
		return 3;

	}

	private void OnCollisionEnter2D(Collision2D collision) {
		switch (collision.gameObject.tag) {
			case GameTag.Dirt:
				//Clean it up. Rescan.
				Scan();
				break;
			case GameTag.Pot:
				//Break the pot. the dirt created from it is first priority. drops the original target
				
				break;
			case GameTag.Cat:
				//Scan the entire premise
				Scan();
				break;
			case GameTag.Home:
				//Fire a event to level manager that roomba reached the goal
				Debug.Log("Reached home");
				LevelManager.CallEvent(GameEvent.NextLevel);
				break;
			case GameTag.Wall:
				//Stops. Rescans until dirt is detected.
				Scan(true);
				break;
			default:
				break;
		}
	}
}
